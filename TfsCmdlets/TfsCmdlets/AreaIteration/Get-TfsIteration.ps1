<#
.SYNOPSIS
	Get an specific Iteration of one Team Project.

.PARAMETER Collection
	Specifies either a URL or the name of the Team Project Collection to connect to, or a previously initialized TfsTeamProjectCollection object.
	For more details, see the -Collection argument in the Get-TfsTeamProjectCollection cmdlet.

.PARAMETER Project
	Specifies either the name of the Team Project or a previously initialized Microsoft.TeamFoundation.WorkItemTracking.Client.Project object to connect to. 
	For more details, see the -Project argument in the Get-TfsTeamProject cmdlet. 

.EXAMPLE
	xxxx.
#>
Function Get-TfsIteration
{
    [CmdletBinding()]
    [OutputType([Microsoft.TeamFoundation.Server.NodeInfo])]
    Param
    (
		[Parameter(Position=0)]
		[Alias("Path")]
		[ValidateScript({($_ -is [string]) -or ($_ -is [uri]) -or ($_ -is [Microsoft.TeamFoundation.Server.NodeInfo])})] 
		[object]
		$Iteration = '\**',

		[Parameter(ValueFromPipeline=$true)]
		[object]
		$Project,

		[Parameter()]
		[object]
		$Collection
    )

    Process
    {
		return _GetCssNodes -Node $Iteration -Scope Iteration -Project $Project -Collection $Collection
    }
}
