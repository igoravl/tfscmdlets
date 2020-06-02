/*
.SYNOPSIS
Deletes one or more Git repositories from a team project.

.PARAMETER Project
Specifies either the name of the Team Project or a previously initialized Microsoft.TeamFoundation.WorkItemTracking.Client.Project object to connect to. If omitted, it defaults to the connection opened by Connect-TfsTeamProject (if any). 

For more details, see the Get-TfsTeamProject cmdlet.

.PARAMETER Collection
Specifies either a URL/name of the Team Project Collection to connect to, or a previously initialized TfsTeamProjectCollection object. 

When using a URL, it must be fully qualified. The format of this string is as follows: 

http[s]://<ComputerName>:<Port>/[<TFS-vDir>/]<CollectionName> 

Valid values for the Transport segment of the URI are HTTP and HTTPS. If you specify a connection URI with a Transport segment, but do not specify a port, the session is created with standards ports: 80 for HTTP and 443 for HTTPS. 

To connect to a Team Project Collection by using its name, a TfsConfigurationServer object must be supplied either via -Server argument or via a previous call to the Connect-TfsConfigurationServer cmdlet. 

For more details, see the Get-TfsTeamProjectCollection cmdlet.

.INPUTS
Microsoft.TeamFoundation.SourceControl.WebApi.GitRepository
System.String
*/

using System.Management.Automation;
using Microsoft.TeamFoundation.SourceControl.WebApi;
using TfsCmdlets.Extensions;

namespace TfsCmdlets.Cmdlets.Git.Repository
{
    [Cmdlet(VerbsCommon.Remove, "GitRepository", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    public class RemoveGitRepository : BaseCmdlet
    {

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [SupportsWildcards()]
        [Alias("Name")]
        public object Repository { get; set; }

        [Parameter()] public object Project { get; set; }

        [Parameter()] public object Collection { get; set; }

        /// <summary>
        /// Performs execution of the command
        /// </summary>
        protected override void ProcessRecord()
        {
            if (Repository is Microsoft.TeamFoundation.SourceControl.WebApi.GitRepository repo)
            {
                Project = repo.ProjectReference.Name;
            }

            var (tpc, tp) = this.GetCollectionAndProject();
            var client = GetClient<Microsoft.TeamFoundation.SourceControl.WebApi.GitHttpClient>();
            //        var reposToDelete = Get - TfsGitRepository - Name Repository - Project Project - Collection Collection
            //            }

            //        foreach (repo in reposToDelete)
            //        {
            //            if (ShouldProcess(repo.Name, $"Delete Git repository from Team Project {{tp}.Name}"))
            //            {
            //                client.DeleteRepositoryAsync(repo.Id).Wait()
            //                }
            //        }
            //    }
            //}

            //    */
        }
    }
}