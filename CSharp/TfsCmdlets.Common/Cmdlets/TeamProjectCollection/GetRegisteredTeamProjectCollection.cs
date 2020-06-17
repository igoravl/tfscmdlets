using System.Management.Automation;

namespace TfsCmdlets.Cmdlets.TeamProjectCollection
{
    /// <summary>
    /// Gets one or more Team Project Collection addresses registered in the current computer.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TfsRegisteredTeamProjectCollection")]
    //[OutputType(typeof(Microsoft.TeamFoundation.Client.RegisteredProjectCollection[]))]
    public class GetRegisteredTeamProjectCollection : BaseCmdlet
    {
        /// <summary>
        /// Performs execution of the command
        /// </summary>
        protected override void ProcessRecord() => throw new System.NotImplementedException();

        //         [Parameter(Position=0, ValueFromPipeline=true)]
        //         [Alias("Name")]
        //         [SupportsWildcards()]
        //         public string Collection { get; set; } = "*"

        //         /// <summary>
        //         /// Performs execution of the command
        //         /// </summary>
        //         protected override void ProcessRecord()
        //     {
        //         registeredCollections = Microsoft.TeamFoundation.Client.RegisteredTfsConnections.GetProjectCollections() 

        //         foreach(tpc in registeredCollections)
        //         {
        //             tpcName = ([Uri]tpc.Uri).Segments[-1]

        //             if(tpcName -like Collection)
        //             {
        //                 Write-Output tpc
        //             }
        //         }
        //     }
        // }
    }
}
