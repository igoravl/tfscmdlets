using System.Management.Automation;
using System.Xml;

namespace TfsCmdlets.Cmdlets.WorkItem.WorkItemType
{
    /// <summary>
    /// Exports an XML work item type definition from a team project.
    /// </summary>
    [Cmdlet(VerbsData.Export, "TfsWorkItemType", DefaultParameterSetName = "Export to output stream", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType(typeof(string))]
    [DesktopOnly]
    public partial class ExportWorkItemType : CmdletBase
    {
        /// <summary>
        /// Specifies one or more work item types to export. Wildcards are supported. 
        /// When omitted, all work item types in the given project are exported
        /// </summary>
        [Parameter(Position = 0, ParameterSetName = "Export to output stream")]
        [Alias("Name")]
        [SupportsWildcards()]
        public string Type { get; set; } = "*";

        /// <summary>
        /// Exports the definitions of referenced global lists. 
        /// When omitted, global list definitions are not included in the exported XML document.
        /// </summary>
        [Parameter()]
        public SwitchParameter IncludeGlobalLists { get; set; }

        /// <summary>
        /// Specifies the path to the folder where exported types are saved.
        /// </summary>
        [Parameter(ParameterSetName = "Export to file", Mandatory = true)]
        public string Destination { get; set; }

        /// <summary>
        /// Allows the cmdlet to overwrite an existing file in the destination folder.
        /// </summary>
        /// <value></value>
        [Parameter(ParameterSetName = "Export to file")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Exports the saved query to the standard output stream as a string-encoded 
        /// XML document.
        /// </summary>
        [Parameter(ParameterSetName = "Export to output stream", Mandatory = true)]
        public SwitchParameter AsXml { get; set; }

        /// <summary>
        /// HELP_PARAM_PROJECT
        /// </summary>
        [Parameter(ValueFromPipeline = true)]
        public object Project { get; set; }

        /// <summary>
        /// HELP_PARAM_COLLECTION
        /// </summary>
        [Parameter()]
        public object Collection { get; set; }

        //         /// <summary>
        //         /// Performs execution of the command
        //         /// </summary>
        //         protected override void DoProcessRecord()
        //     {
        //         types = Get-TfsWorkItemType -Name WorkItemType -Project Project -Collection Collection

        //         foreach(type in types)
        //         {
        //             type.Export(IncludeGlobalLists)
        //         }
        //     }
        // }
    }
}