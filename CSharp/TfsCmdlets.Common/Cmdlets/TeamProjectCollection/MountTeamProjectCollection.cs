/*
.SYNOPSIS
Attaches a team project collection database to a Team Foundation Server installation.

.PARAMETER Credential
Specifies a user account that has permission to perform this action. The default is the credential of the user under which the PowerShell process is being run - in most cases that corresponds to the user currently logged in.nnType a user name, such as "User01" or "Domain01\User01", or enter a PSCredential object, such as one generated by the Get-Credential cmdlet. If you type a user name, you will be prompted for a password.nnTo connect to Visual Studio Team Services you must either: enable Alternate Credentials for your user profile and supply that credential in this argument or omit this argument to have a logon being dialog displayed automatically.nnFor more information on Alternate Credentials for your Visual Studio Team Services account, please refer to https://msdn.microsoft.com/library/dd286572#setup_basic_auth.

.INPUTS
Microsoft.TeamFoundation.Client.TfsConfigurationServer
System.String
System.Uri
*/

using System.Management.Automation;

namespace TfsCmdlets.Cmdlets.TeamProjectCollection
{
    [Cmdlet(VerbsData.Mount, "TfsTeamProjectCollection", ConfirmImpact = ConfirmImpact.Medium)]
    public class MountTeamProjectCollection : BaseCmdlet
    {
        /*
                [Parameter(Mandatory=true, Position=0)]
                [Alias("Name")]
                public string Collection { get; set; }

                [Parameter()]
                public string Description { get; set; }

                [Parameter(ParameterSetName="Use database server", Mandatory=true)]
                public string DatabaseServer { get; set; }

                [Parameter(ParameterSetName="Use database server", Mandatory=true)]
                public string DatabaseName { get; set; }

                [Parameter(ParameterSetName="Use connection string", Mandatory=true)]
                public string ConnectionString { get; set; }

                [Parameter()]
                [ValidateSet("Started", "Stopped")]
                public string InitialState { get; set; } = "Started",

                [Parameter()]
                public SwitchParameter Clone { get; set; }

                [Parameter()]
                public int PollingInterval { get; set; } = 5,

                [Parameter()]
                public timespan Timeout { get; set; } = timespan.MaxValue,

                [Parameter(ValueFromPipeline=true)]
        public object Server,

                [Parameter()]
                [System.Management.Automation.Credential()]
                [System.Management.Automation.PSCredential]
                Credential = System.Management.Automation.PSCredential.Empty
        /// <summary>
        /// Performs execution of the command
        /// </summary>
        protected override void ProcessRecord()
            {
                configServer = Get-TfsConfigurationServer Server -Credential Credential
                tpcService = configServer.GetService([type] "Microsoft.TeamFoundation.Framework.Client.ITeamProjectCollectionService")

                servicingTokens = new System.Collections.Generic.Dictionary[string,string]()

                if (DatabaseName)
                {
                    servicingTokens["CollectionDatabaseName"] = DatabaseName
                }

                if (ParameterSetName == "Use database server")
                {
                    ConnectionString = $"Data source={DatabaseServer}; Integrated Security=true; Initial Catalog=DatabaseName"
                }

                try
                {
                    Write-Progress -Id 1 -Activity $"Attach team project collection" -Status "Attaching team project collection {Collection}" -PercentComplete 0

                    #start = Get-Date

                    # string databaseConnectionString, IDictionary<string, string> servicingTokens, bool cloneCollection, string name, string description, string virtualDirectory)

                    tpcJob = tpcService.QueueAttachCollection(
                        ConnectionString,
                        servicingTokens, 
                        Clone.ToBool(),
                        Collection,
                        Description,
                        $"~/{Collection}/")

                    [void] tpcService.WaitForCollectionServicingToComplete(tpcJob, Timeout)

                    WriteObject(Get-TfsTeamProjectCollection -Server Server -Credential Credential -Collection Collection); return;
                }
                finally
                {
                    Write-Progress -Id 1 -Activity "Attach team project collection" -Completed
                }

                throw new Exception((new System.TimeoutException($"Operation timed out during creation of team project collection {Collection}")))
            }
        }
        */
    }
}
