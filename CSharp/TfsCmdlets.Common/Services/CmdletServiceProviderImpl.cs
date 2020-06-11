﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.TeamFoundation.Core.WebApi;
using TfsCmdlets.Cmdlets;
using TfsConnection = TfsCmdlets.Services.Connection;
using WebApiTeamProject = Microsoft.TeamFoundation.Core.WebApi.TeamProject;

namespace TfsCmdlets.Services
{
    internal class CmdletServiceProviderImpl : ICmdletServiceProvider
    {
        private readonly Dictionary<Type, Func<ICmdletServiceProvider, BaseCmdlet, IService>> _factories =
            new Dictionary<Type, Func<ICmdletServiceProvider, BaseCmdlet, IService>>();

        internal CmdletServiceProviderImpl()
        {
            RegisterFactories();
        }

        public T GetService<T>(BaseCmdlet BaseCmdlet) where T : IService
        {
            var serviceType = typeof(T);

            if (!_factories.ContainsKey(serviceType))
            {
                throw new ArgumentException($"Invalid service {serviceType.FullName}");
            }

            return (T) _factories[serviceType](this, BaseCmdlet);
        }

        public TObj GetInstanceOf<TObj>(BaseCmdlet BaseCmdlet, object overriddenParameters)
            where TObj: class
        {
            var serviceType = typeof(TObj);

            if (!_factories.ContainsKey(serviceType))
            {
                throw new ArgumentException($"Invalid service {serviceType.FullName}");
            }

            return ((IDataService<TObj>) _factories[serviceType](this, BaseCmdlet)).GetInstanceOf(overriddenParameters);
        }

        public IEnumerable<TObj> GetCollectionOf<TObj>(BaseCmdlet BaseCmdlet, object overriddenParameters)
            where TObj: class
        {
            var serviceType = typeof(TObj);

            if (!_factories.ContainsKey(serviceType))
            {
                throw new ArgumentException($"Invalid service {serviceType.FullName}. Are you missing an [Exports] attribute?");
            }

            return ((IDataService<TObj>)_factories[serviceType](this, BaseCmdlet)).GetCollectionOf(overriddenParameters);
        }

        public TfsConnection GetServer(BaseCmdlet cmdlet, ParameterDictionary parameters = null)
        {
            var pd = new ParameterDictionary(parameters) {
                ["ConnectionType"] = "Server"
            };

            var srv = GetInstanceOf<TfsConnection>(cmdlet, pd);

            if (srv == null)
            {
                throw new ArgumentException("No TFS connection information available. Either supply a valid -Server argument or use Connect-TfsConfigurationServer prior to invoking this cmdlet.");
            }

            return srv;
        }

        public TfsConnection GetCollection(BaseCmdlet cmdlet, ParameterDictionary parameters = null)
        {
            var pd = new ParameterDictionary(parameters) {
                ["ConnectionType"] = "Collection"
            };

            var tpc = GetInstanceOf<TfsConnection>(cmdlet, pd);

            if (tpc == null)
            {
                throw new ArgumentException("No TFS connection information available. Either supply a valid -Collection argument or use Connect-TfsTeamProjectCollection prior to invoking this cmdlet.");
            }

            return tpc;
        }

        public (TfsConnection, WebApiTeamProject) GetCollectionAndProject(BaseCmdlet cmdlet, ParameterDictionary parameters = null)
        {
            var tpc = GetCollection(cmdlet, parameters);

            var pd = new ParameterDictionary(parameters) {
                ["Collection"] = tpc
            };

            var tp = GetInstanceOf<WebApiTeamProject>(cmdlet, pd);

            if (tp == null)
            {
                throw new ArgumentException("No TFS team project information available. Either supply a valid -Project argument or use Connect-TfsTeamProject prior to invoking this cmdlet.");
            }

            return (tpc, tp);
        }

        public (TfsConnection, WebApiTeamProject, WebApiTeam) GetCollectionProjectAndTeam(BaseCmdlet cmdlet, ParameterDictionary parameters = null)
        {
            var (tpc, tp) = GetCollectionAndProject(cmdlet, parameters);

            var pd = new ParameterDictionary(parameters) {
                ["Collection"] = tpc,
                ["Project"] = tp
            };

            var team = GetInstanceOf<WebApiTeam>(cmdlet, pd);

            if (team == null)
            {
                throw new ArgumentException("No TFS team information available. Either supply a valid -Team argument or use Connect-TfsTeam prior to invoking this cmdlet.");
            }

            return (tpc, tp, team);
        }

        private void RegisterFactories()
        {
            foreach (var type in GetType().Assembly.GetTypes()
                .Where(t => t.GetCustomAttributes<ExportsAttribute>().Any()))
            {
                var attr = type.GetCustomAttribute<ExportsAttribute>();

                if (attr.Singleton)
                {
                    if (!(Activator.CreateInstance(type) is IService svc)) continue;
                    svc.Provider = this;
                    _factories.Add(attr.Exports, (prv, ctx) => svc);
                }
                else
                {
                    _factories.Add(attr.Exports, delegate(ICmdletServiceProvider prv, BaseCmdlet ctx)
                    {
                        if (!(Activator.CreateInstance(type) is IService svc))
                            throw new Exception($"Error instantiating {type.FullName}");

                        svc.Provider = prv;
                        svc.Cmdlet = ctx;
                        return svc;

                    });
                }
            }
        }
    }
}