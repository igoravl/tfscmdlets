using System.Management.Automation;

namespace TfsCmdlets.Cmdlets.ServiceHook
{
    [Cmdlet(VerbsCommon.Get, "ServiceHookConsumer")]
    [OutputType(typeof(Microsoft.VisualStudio.Services.ServiceHooks.WebApi.Consumer))]
    public class GetServiceHookConsumer: PSCmdlet
    {
/*
        [Parameter(Position=0)]
        [SupportsWildcards()]
        [Alias("Name")]
        [Alias("Id")]
        public string Consumer { get; set; } = "*",

        [Parameter()]
        public object Collection { get; set; }

    protected override void ProcessRecord()
    {
        tpc = Get-TfsTeamProjectCollection -Collection Collection; if (! tpc || (tpc.Count != 1)) {throw new Exception($"Invalid or non-existent team project collection {Collection}."})
        client = Get-TfsRestClient "Microsoft.VisualStudio.Services.ServiceHooks.WebApi.ServiceHooksPublisherHttpClient" -Collection tpc

        WriteObject(client.GetConsumersAsync().Result | Where-Object {(_Name -Like Consumer) || (_.Id -Like Consumer)}); return;
    }
}
*/
}
}
