using System.Management.Automation;
using TfsCmdlets.HttpClient;

namespace TfsCmdlets.Cmdlets.Team.TeamAdmin
{
    [Cmdlet(VerbsCommon.Add, "TeamAdmin", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType(typeof(TeamAdmins))]
    public class AddTeamAdmin : PSCmdlet
    {
        /*
                # Specifies the board name(s). Wildcards accepted
                [Parameter(Position=0)]
                [Alias("Name")]
                [Alias("User")]
                public object Identity { get; set; }

                [Parameter(ValueFromPipeline=true)]
                public object Team { get; set; }

                [Parameter()]
                public object Project { get; set; }

                [Parameter()]
                public object Collection { get; set; }

            protected override void ProcessRecord()
            {
                t = Get-TfsTeam -Team Team -Project Project -Collection Collection; if (t.Count != 1) {throw new Exception($"Invalid or non-existent team "{Team}"."}; if(t.ProjectName) {Project = t.ProjectName}; tp = Get-TfsTeamProject -Project Project -Collection Collection; if (! tp || (tp.Count != 1)) {throw "Invalid or non-existent team project Project."}; tpc = tp.Store.TeamProjectCollection)

                id = Get-TfsIdentity -Identity Identity -Collection tpc

                client = Get-TfsRestClient "TfsCmdlets.TeamAdminHttpClient" -Collection tpc

                _Log $"Adding {{id}.IdentityType} "$(id.DisplayName) ($(id.Properties["Account"]))" to team "$(t.Name)""

                if(! ShouldProcess(t.Name, $"Add administrator "{{id}.DisplayName} ($(id.Properties["Account"]))""))
                {
                    return
                }

                WriteObject(client.AddTeamAdmin(tp.Name, t.Id, id.Id)); return;
            }
        }
        */
    }
}
