﻿/*
.SYNOPSIS
    Provides credentials to use when you connect to a Team Foundation Server or Visual Studio Team Services account.

.DESCRIPTION

.NOTES

.INPUTS
   
*/

using System;
using System.Management.Automation;
using System.Net;
using System.Security;
using Microsoft.VisualStudio.Services.Client;
using Microsoft.VisualStudio.Services.Common;
using TfsCmdlets.Extensions;

namespace TfsCmdlets.Cmdlets.Connection
{
    [Cmdlet("Get", "Credential", DefaultParameterSetName = "Cached credentials")]
    [OutputType("Microsoft.VisualStudio.Services.Client.VssClientCredentials")]
    public class GetCredential : PSCmdlet
    {
        [Parameter(ParameterSetName = "Cached credentials")]
        public SwitchParameter Cached { get; set; }

        [Parameter(ParameterSetName = "User name and password", Mandatory = true, Position = 1)]
        public string UserName { get; set; }

        [Parameter(ParameterSetName = "User name and password", Position = 2)]
        public SecureString Password { get; set; }

        [Parameter(ParameterSetName = "Credential object", Mandatory = true)]
        [AllowNull]
        public object Credential { get; set; }

        [Parameter(ParameterSetName = "Personal Access Token", Mandatory = true)]
        [Alias("Pat", "PersonalAccessToken")]
        public string AccessToken { get; set; }

        [Parameter(ParameterSetName = "Prompt for credential", Mandatory = true)]
        public SwitchParameter Interactive { get; set; }

        protected override void BeginProcessing()
        {
            this.LogParameters();
        }

        protected override void ProcessRecord()
        {
            WriteObject(this.GetCredential());
        }
    }
}