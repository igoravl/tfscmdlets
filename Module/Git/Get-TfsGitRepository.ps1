<#

.SYNOPSIS
    Gets information from one or more Git repositories in a team project.

.PARAMETER Project
    HELP_PARAM_PROJECT

.PARAMETER Collection
    HELP_PARAM_COLLECTION

.INPUTS
    Microsoft.TeamFoundation.WorkItemTracking.Client.Project
    System.String
#>
Function Get-TfsGitRepository
{
    [CmdletBinding()]
    [OutputType('Microsoft.TeamFoundation.SourceControl.WebApi.GitRepository')]
    Param
    (
        [Parameter(Position=0)]
        [SupportsWildcards()]
        [Alias('Name')]
        [string] 
        $Repository = '*',

        [Parameter(ValueFromPipeline=$true)]
        [object]
        $Project,

        [Parameter()]
        [object]
        $Collection
    )

    Begin
    {
        REQUIRES(Microsoft.TeamFoundation.SourceControl.WebApi)
    }

    Process
    {
        $guid = [guid]::Empty

        if([guid]::TryParse($Repository, [ref] $guid))
        {
            $tpc = Get-TfsTeamProjectCollection $Collection
            $client = _GetRestClient 'Microsoft.TeamFoundation.SourceControl.WebApi.GitHttpClient' -Collection $tpc

            CALL_ASYNC($client.GetRepositoryAsync($guid),"Error getting repository with ID $guid")

            return $result
        }

        GET_TEAM_PROJECT($tp,$tpc)

        $client = _GetRestClient 'Microsoft.TeamFoundation.SourceControl.WebApi.GitHttpClient' -Collection $tpc

        CALL_ASYNC($client.GetRepositoriesAsync($tp.Name), "Error getting repository '$Name'")
        
        return $result | Where-Object Name -Like $Repository
    }
}