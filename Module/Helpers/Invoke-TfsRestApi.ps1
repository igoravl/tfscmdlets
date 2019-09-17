<#
.SYNOPSIS
    Short description
.DESCRIPTION
    Long description
.EXAMPLE
    PS C:\> <example usage>
    Explanation of what the example does
.INPUTS
    Inputs (if any)
.OUTPUTS
    Output (if any)
.NOTES
    General notes
#>
Function Invoke-TfsRestApi
{
    [CmdletBinding()]
    Param
    (
        [Parameter(Position=0, Mandatory=$true, ParameterSetName="Library call")]
        [Alias("Name")]
        [Alias("API")]
        [string]
        $Operation,

        [Parameter(ParameterSetName="Library call")]
        [Alias("Client")]
        [Alias("Type")]
        [string]
        $ClientType,

        [Parameter(ParameterSetName="Library call")]
        [object[]]
        $ArgumentList,

        [Parameter(Mandatory=$true, ParameterSetName="URL call")]
        [string]
        $Path,

        [Parameter(ParameterSetName="URL call")]
        [string]
        $Method = 'GET',

        [Parameter(ParameterSetName="URL call")]
        [string]
        $Content,

        [Parameter(ParameterSetName="URL call")]
        [string]
        $RequestMediaType = 'application/json',

        [Parameter(ParameterSetName="URL call")]
        [string]
        $ResponseMediaType = 'application/json',

        [Parameter(ParameterSetName="URL call")]
        [hashtable]
        $AdditionalHeaders,

        [Parameter(ParameterSetName="URL call")]
        [hashtable]
        $QueryParameters,

        [Parameter(ParameterSetName="URL call")]
        [string]
        $ApiVersion = '1.0',

        [Parameter(ParameterSetName="URL call")]
        [object]
        $Team,

        [Parameter(ParameterSetName="URL call")]
        [object]
        $Project,

        [Parameter()]
        [object]
        $Collection,

        [Parameter()]
        [switch]
        $AsTask
    )

    End
    {
        GET_COLLECTION($tpc)

        if($PSCmdlet.ParameterSetName -eq 'Library call')
        {
            GET_CLIENT($ClientType)
            $task = $client.$Operation.Invoke($ArgumentList)
        }
        else
        {
            GET_CLIENT('TfsCmdlets.GenericHttpClient')

            if($Path -like '*{projectId}*')
            {
                GET_TEAM_PROJECT_FROM_ITEM($tp,$tpc,$Team.Project)
                $Path = $Path.Replace('{projectId}', $tp.Guid)
            }

            if($Path -like '*{teamId}*')
            {
                GET_TEAM($t,$tp,$tpc)
                $Path = $Path.Replace('{teamId}', $t.Id)
            }
            
            $task = $client.InvokeAsync($Method, $Path, $Content, $RequestMediaType, $ResponseMediaType, $AdditionalHeaders, $QueryParameters, $ApiVersion)
        }

        if ($AsTask)
        {
            return $task
        }

        CHECK_ASYNC($task,$result,$Message)

        if($PSCmdlet.ParameterSetName -eq 'URL call')
        {
            Add-Member -InputObject $result -Name 'ResponseString' -MemberType NoteProperty -Value $result.Content.ReadAsStringAsync().GetAwaiter().GetResult()

            if($ResponseMediaType -eq 'application/json')
            {
                Add-Member -InputObject $result -Name 'ResponseObject' -MemberType NoteProperty -Value ($result.Content.ReadAsStringAsync().GetAwaiter().GetResult() | ConvertFrom-Json)
            }
        }
        
        return $result
    }
}