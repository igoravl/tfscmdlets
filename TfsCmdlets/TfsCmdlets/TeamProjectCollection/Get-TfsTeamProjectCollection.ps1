<#
.SYNOPSIS
	Gets a TFS Team Project Collection.

.DESCRIPTION
	The Get-TfsTeamProject cmdlets gets one or more Team Project Collection objects (an instance of Microsoft.TeamFoundation.Client.TfsTeamProjectCollection) from a TFS instance. 
	Team Project Collection objects can either be obtained by providing a fully-qualified URL to the collection or by collection name (in which case a TFS Configuration Server object is required).

.PARAMETER Collection
	${Help_Collection_Parameter}

.PARAMETER Server
	Specifies either a URL/name of the Team Foundation Server configuration server (the "root" of a TFS installation) to connect to, or a previously initialized Microsoft.TeamFoundation.Client.TfsConfigurationServer object.

.PARAMETER Credential
	Specifies a user account that has permission to perform this action. The default is the current user.
	Type a user name, such as "User01" or "Domain01\User01", or enter a PSCredential object, such as one generated by the Get-Credential cmdlet. If you type a user name, you will be prompted for a password.
	To connect to Visual Studio Online you must enable Alternate Credentials for your user profile and supply that credential in this argument.
	For more information on Alternate Credentials for your Visual Studio Online account, please refer to https://msdn.microsoft.com/library/dd286572#setup_basic_auth.

.EXAMPLE
	Get-TfsTeamProjectCollection http://

.INPUTS
	Microsoft.TeamFoundation.Client.TfsConfigurationServer

.NOTES
	Cmdlets in the TfsCmdlets module that operate on a collection level require a TfsConfigurationServer object to be provided via the -Server argument. If absent, it will default to the connection opened by Connect-TfsConfigurationServer.
#>
Function Get-TfsTeamProjectCollection
{
	[CmdletBinding(DefaultParameterSetName='Get by collection')]
	[OutputType([Microsoft.TeamFoundation.Client.TfsTeamProjectCollection])]
	Param
	(
		[Parameter(Position=0, ParameterSetName="Get by collection")]
		[object] 
		$Collection = "*",
	
		[Parameter(ValueFromPipeline=$true, ParameterSetName="Get by collection")]
		[object] 
		$Server,
	
		[Parameter(Position=0, ParameterSetName="Get current")]
        [switch]
        $Current,

		[Parameter(ParameterSetName="Get by collection")]
		[System.Management.Automation.Credential()]
		[System.Management.Automation.PSCredential]
		$Credential
	)

	Process
	{
        if ($Current)
        {
            return $Global:TfsTpcConnection
        }

		if ($Collection -is [Microsoft.TeamFoundation.Client.TfsTeamProjectCollection])
		{
			return $Collection
		}

		if ($Collection -is [Uri])
		{
			return _GetCollectionFromUrl $Collection $Credential
		}

		if ($Collection -is [string])
		{
			if ([Uri]::IsWellFormedUriString($Collection, [UriKind]::Absolute))
			{
				return _GetCollectionFromUrl ([Uri] $Collection) $Server $Credential
			}

			if (-not [string]::IsNullOrWhiteSpace($Collection))
			{
				return _GetCollectionFromName $Collection $Server $Credential
			}

			$Collection = $null
		}

		if ($Collection -eq $null)
		{
			if ($Global:TfsTpcConnection)
			{
				return $Global:TfsTpcConnection
			}
		}

		throw "No TFS connection information available. Either supply a valid -Collection argument or use Connect-TfsTeamProjectCollection prior to invoking this cmdlet."
	}
}

# =================
# Helper Functions
# =================

Function _GetCollectionFromUrl
{
	Param ($Url, $Cred)
	
	if ($Cred)
	{
		$tpc = New-Object Microsoft.TeamFoundation.Client.TfsTeamProjectCollection -ArgumentList $Url, (_GetCredential $cred)
	}
	else
	{
		$tpc = [Microsoft.TeamFoundation.Client.TfsTeamProjectCollectionFactory]::GetTeamProjectCollection([Uri] $Url)
	}

	return $tpc
}


Function _GetCollectionFromName
{
	Param
	(
		$Name, $Server, $Cred
	)
	Process
	{
		$configServer = Get-TfsConfigurationServer $Server -Credential $Cred
		$filter = [Guid[]] @([Microsoft.TeamFoundation.Framework.Common.CatalogResourceTypes]::ProjectCollection)
		
		$collections = $configServer.CatalogNode.QueryChildren($filter, $false, [Microsoft.TeamFoundation.Framework.Common.CatalogQueryOptions]::IncludeParents) 
		$collections = $collections | Select -ExpandProperty Resource | ? DisplayName -like $Name

		if ($collections.Count -eq 0)
		{
			throw "Invalid or non-existent Team Project Collection(s): $Name"
		}

		foreach($tpc in $collections)
		{
			$collectionId = $tpc.Properties["InstanceId"]
			$tpc = $configServer.GetTeamProjectCollection($collectionId)
			$tpc.EnsureAuthenticated()

			$tpc
		}

	}
}

Function _GetCredential
{
	Param ($Cred)

	if ($Cred)
	{
		return [System.Net.NetworkCredential] $Cred
	}
	
	return [System.Net.CredentialCache]::DefaultNetworkCredentials
}