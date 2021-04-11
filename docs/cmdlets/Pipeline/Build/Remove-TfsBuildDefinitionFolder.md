﻿---
title: Remove-TfsBuildDefinitionFolder
breadcrumbs: [ "Pipeline", "Build" ]
parent: "Pipeline.Build"
description: "Deletes one or more build/pipeline definition folders. "
remarks: 
parameterSets: 
  "_All_": [ Collection, Folder, Force, Project, Recurse ] 
  "__AllParameterSets":  
    Folder: 
      type: "object"  
      position: "0"  
      required: true  
    Collection: 
      type: "object"  
    Force: 
      type: "SwitchParameter"  
    Project: 
      type: "object"  
    Recurse: 
      type: "SwitchParameter" 
parameters: 
  - name: "Folder" 
    description: "Specifies the path of the pipeline/build folder to delete, including its name, separated by backslashes (\\). Wildcards are supperted. " 
    required: true 
    globbing: false 
    pipelineInput: "true (ByValue, ByPropertyName)" 
    position: 0 
    type: "object" 
    aliases: [ Path ] 
  - name: "Path" 
    description: "Specifies the path of the pipeline/build folder to delete, including its name, separated by backslashes (\\). Wildcards are supperted. This is an alias of the Folder parameter." 
    required: true 
    globbing: false 
    pipelineInput: "true (ByValue, ByPropertyName)" 
    position: 0 
    type: "object" 
    aliases: [ Path ] 
  - name: "Recurse" 
    description: "Removes folders recursively. When omitted, folders with subfolders cannot be deleted. " 
    globbing: false 
    type: "SwitchParameter" 
    defaultValue: "False" 
  - name: "Force" 
    description: "Forces the exclusion of folders containing build/pipelines definitions. When omitted, only empty folders can be deleted. " 
    globbing: false 
    type: "SwitchParameter" 
    defaultValue: "False" 
  - name: "Project" 
    description: "Specifies the name of the Team Project, its ID (a GUID), or a Microsoft.TeamFoundation.Core.WebApi.TeamProject object to connect to. When omitted, it defaults to the connection set by Connect-TfsTeamProject (if any). For more details, see the Get-TfsTeamProject cmdlet. " 
    globbing: false 
    type: "object" 
  - name: "Collection" 
    description: "Specifies the URL to the Team Project Collection or Azure DevOps Organization to connect to, a TfsTeamProjectCollection object (Windows PowerShell only), or a VssConnection object. You can also connect to an Azure DevOps Services organizations by simply providing its name instead of the full URL. For more details, see the Get-TfsTeamProjectCollection cmdlet. When omitted, it defaults to the connection set by Connect-TfsTeamProjectCollection (if any). " 
    globbing: false 
    type: "object"
inputs: 
  - type: "System.Object" 
    description: "Specifies the path of the pipeline/build folder to delete, including its name, separated by backslashes (\\). Wildcards are supperted. "
outputs: 
  - type: "Microsoft.TeamFoundation.Build.WebApi.Folder" 
    description: 
notes: 
relatedLinks: 
  - text: "Online Version:" 
    uri: "https://tfscmdlets.dev/docs/cmdlets/Pipeline/Build/Remove-TfsBuildDefinitionFolder"
aliases: 
examples: 
---