﻿---
title: Add-TfsGroupMember
breadcrumbs: [ "Identity", "Group" ]
parent: "Identity.Group"
description: "Adds group members to an Azure DevOps group. "
remarks: 
parameterSets: 
  "_All_": [ Collection, Group, Member ] 
  "__AllParameterSets":  
    Member: 
      type: "object"  
      position: "0"  
      required: true  
    Group: 
      type: "object"  
      position: "1"  
      required: true  
    Collection: 
      type: "object" 
parameters: 
  - name: "Member" 
    description: "Specifies the member (user or group) to add to the given group. " 
    required: true 
    globbing: false 
    pipelineInput: "true (ByValue)" 
    position: 0 
    type: "object" 
  - name: "Group" 
    description: "Specifies the group to which the member is added. " 
    required: true 
    globbing: false 
    position: 1 
    type: "object" 
  - name: "Collection" 
    description: "Specifies the URL to the Team Project Collection or Azure DevOps Organization to connect to, a TfsTeamProjectCollection object (Windows PowerShell only), or a VssConnection object. You can also connect to an Azure DevOps Services organizations by simply providing its name instead of the full URL. For more details, see the Get-TfsTeamProjectCollection cmdlet. When omitted, it defaults to the connection set by Connect-TfsTeamProjectCollection (if any). " 
    globbing: false 
    type: "object"
inputs: 
  - type: "System.Object" 
    description: "Specifies the member (user or group) to add to the given group. "
outputs: 
notes: 
relatedLinks: 
  - text: "Online Version:" 
    uri: "https://tfscmdlets.dev/docs/cmdlets/Identity/Group/Add-TfsGroupMember"
aliases: 
examples: 
---