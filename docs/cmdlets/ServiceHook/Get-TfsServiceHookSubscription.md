﻿---
title: Get-TfsServiceHookSubscription
breadcrumbs: [ "ServiceHook" ]
parent: "ServiceHook"
description: "Gets one or more service hook subscriptions "
remarks: 
parameterSets: 
  "_All_": [ Collection, Consumer, EventType, Publisher, Subscription ] 
  "__AllParameterSets":  
    Subscription: 
      type: "object"  
      position: "0"  
    Collection: 
      type: "object"  
    Consumer: 
      type: "object"  
    EventType: 
      type: "object"  
    Publisher: 
      type: "object" 
parameters: 
  - name: "Subscription" 
    description: "Specifies the name (\"action description\") of the subscription. Wildcards are supported. When omitted, returns all service hook subscriptions in the given team project collection. " 
    globbing: false 
    position: 0 
    type: "object" 
    aliases: [ Name ] 
    defaultValue: "*" 
  - name: "Name" 
    description: "Specifies the name (\"action description\") of the subscription. Wildcards are supported. When omitted, returns all service hook subscriptions in the given team project collection. This is an alias of the Subscription parameter." 
    globbing: false 
    position: 0 
    type: "object" 
    aliases: [ Name ] 
    defaultValue: "*" 
  - name: "Publisher" 
    description: "Specifies the name or ID of the service hook publisher to filter subscriptions by. When omitted, returns all subscriptions regardless of their publishers. " 
    globbing: false 
    type: "object" 
  - name: "Consumer" 
    description: "Specifies the name or ID of the service hook consumer to filter subscriptions by. When omitted, returns all subscriptions regardless of their consumers. " 
    globbing: false 
    type: "object" 
  - name: "EventType" 
    description: "Specifies the event type to filter subscriptions by. When omitted, returns all subscriptions regardless of their event types. " 
    globbing: false 
    type: "object" 
  - name: "Collection" 
    description: "Specifies the URL to the Team Project Collection or Azure DevOps Organization to connect to, a TfsTeamProjectCollection object (Windows PowerShell only), or a VssConnection object. You can also connect to an Azure DevOps Services organizations by simply providing its name instead of the full URL. For more details, see the Get-TfsTeamProjectCollection cmdlet. When omitted, it defaults to the connection set by Connect-TfsTeamProjectCollection (if any). " 
    globbing: false 
    type: "object"
inputs: 
outputs: 
  - type: "Microsoft.VisualStudio.Services.ServiceHooks.WebApi.Subscription" 
    description: 
notes: 
relatedLinks: 
  - text: "Online Version:" 
    uri: "https://tfscmdlets.dev/docs/cmdlets/ServiceHook/Get-TfsServiceHookSubscription"
aliases: 
examples: 
---