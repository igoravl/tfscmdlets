/*

.PARAMETER Credential
    Specifies a user account that has permission to perform this action. The default is the credential of the user under which the PowerShell process is being run - in most cases that corresponds to the user currently logged in.nnType a user name, such as "User01" or "Domain01\User01", or enter a PSCredential object, such as one generated by the Get-Credential cmdlet. If you type a user name, you will be prompted for a password.nnTo connect to Visual Studio Team Services you must either: enable Alternate Credentials for your user profile and supply that credential in this argument or omit this argument to have a logon being dialog displayed automatically.nnFor more information on Alternate Credentials for your Visual Studio Team Services account, please refer to https://msdn.microsoft.com/library/dd286572#setup_basic_auth.

.INPUTS
	Microsoft.TeamFoundation.Client.TfsTeamProjectCollection
    System.String
    System.Uri
*/

using System.Management.Automation;

namespace TfsCmdlets.Cmdlets.TeamProjectCollection
{
    [Cmdlet(VerbsLifecycle.Start, "TeamProjectCollection", ConfirmImpact = ConfirmImpact.Medium, SupportsShouldProcess = true)]
    public class StartTeamProjectCollection : PSCmdlet
    {
        /*
                [Parameter(Mandatory=true, Position=0, ValueFromPipeline=true)]
                [object] 
                Collection,

                [Parameter()]
                [object] 
                Server,

                [Parameter()]
                [System.Management.Automation.Credential()]
                [System.Management.Automation.PSCredential]
                Credential = [System.Management.Automation.PSCredential]::Empty

            protected override void ProcessRecord()
            {
                if(ShouldProcess(Collection, "Start team project collection"))
                {
                    throw new Exception("Not implemented")
                }
            }
        }
        */
    }
}
