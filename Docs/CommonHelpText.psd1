@{
    "HELP_PARAM_SERVER"        = "Specifies the URL to the Team Foundation Server to connect to, a TfsConfigurationServer object (Windows PowerShell only), or a VssConnection object. When omitted, it defaults to the connection set by Connect-TfsConfiguration (if any). For more details, see the Get-TfsConfigurationServer cmdlet."
    "HELP_PARAM_COLLECTION"    = "Specifies the URL to the Team Project Collection or Azure DevOps Organization to connect to, a TfsTeamProjectCollection object (Windows PowerShell only), or a VssConnection object. You can also connect to an Azure DevOps Services organizations by simply providing its name instead of the full URL. For more details, see the Get-TfsTeamProjectCollection cmdlet. When omitted, it defaults to the connection set by Connect-TfsTeamProjectCollection (if any)."
    "HELP_PARAM_PROJECT"       = "Specifies the name of the Team Project, its ID (a GUID), or a Microsoft.TeamFoundation.Core.WebApi.TeamProject object to connect to. When omitted, it defaults to the connection set by Connect-TfsTeamProject (if any). For more details, see the Get-TfsTeamProject cmdlet."
    "HELP_PARAM_TEAM"          = "Specifies the name of the Team, its ID (a GUID), or a Microsoft.TeamFoundation.Core.WebApi.WebApiTeam object to connect to. When omitted, it defaults to the connection set by Connect-TfsTeam (if any). For more details, see the Get-TfsTeam cmdlet."
    "HELP_PARAM_AREA"          = "Specifies the name, URI or path of an Area. Wildcards are permitted. If omitted, all Areas in the given Team Project are returned. To supply a path, use a backslash ('\') between the path segments. Leading and trailing backslashes are optional. When supplying a URI, use URIs in the form of 'vstfs:///Classification/Node/<GUID>' (where <GUID> is the unique identifier of the given node)."
    "HELP_PARAM_ITERATION"     = "Specifies the name, URI or path of an Iteration. Wildcards are permitted. If omitted, all Iterations in the given Team Project are returned.nnTo supply a path, use a backslash ('\') between the path segments. Leading and trailing backslashes are optional.nnWhen supplying a URI, use URIs in the form of 'vstfs:///Classification/Node/<GUID>' (where <GUID> is the unique identifier of the given node)."
    "HELP_PARAM_PASSTHRU"      = "Returns the results of the command. By default, this cmdlet does not generate any output."
    "HELP_PARAM_CREDENTIAL"    = "Specifies a user account that has permission to perform this action. To provide a user name and password, a Personal Access Token, and/or to open a input dialog to enter your credentials, call Get-TfsCredential with the appropriate arguments and pass its return to this argument."
    "HELP_PARAM_PSCREDENTIAL"  = "Specifies a user account that has permission to perform this action. The default is the credential of the user under which the PowerShell process is being run - in most cases that corresponds to the user currently logged in. Type a user name, such as 'User01' or 'Domain01User01', or enter a PSCredential object, such as one generated by the Get-Credential cmdlet. If you type a user name, you will be prompted for a password."
    "HELP_PARAM_INTERACTIVE"   = "Prompts for user credentials. Can be used for any Team Foundation Server or Azure DevOps account - the proper login dialog is automatically selected. Should only be used in an interactive PowerShell session (i.e., a PowerShell terminal window), never in an unattended script (such as those executed during an automated build). Currently it is only supported in Windows PowerShell."
    "HELP_PARAM_GIT_REPOSITORY"= "Specifies the target Git repository. Valid values are the name of the repository, its ID (a GUID), or a Microsoft.TeamFoundation.SourceControl.WebApi.GitRepository object obtained by e.g. a call to Get-TfsGitRepository. When omitted, it default to the team project name (i.e. the default repository)."
}