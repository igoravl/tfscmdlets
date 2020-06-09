using System;
using TfsGlobalList = TfsCmdlets.Cmdlets.GlobalList.GlobalList;

namespace TfsCmdlets.Cmdlets.GlobalList
{
    partial class RenameGlobalList
    {
        protected override void ProcessRecord()
        {
            var list = GetInstanceOf<TfsGlobalList>();

            if(list == null)
            {
                throw new ArgumentException($"Invalid or non-existent global list [{GlobalList}]");
            }

            var tpc = GetCollection();

            if(!ShouldProcess($"Team Project Collection [{tpc.DisplayName}]", $"Rename global list [{list.Name}] to [{NewName}]")) return;

            try
            {
                // Import new (renamed) list
                Import(new GlobalList(NewName, list.Items));

                // Remove old list
                Remove(list.Name);
            }
            catch (Exception ex)
            {
                if((GetInstanceOf<TfsGlobalList>(new ParameterDictionary(){["GlobalList"] = NewName}) != null) &&
                    (GetInstanceOf<TfsGlobalList>() != null))
                {
                    Remove(NewName);
                }
            }

            if(Passthru)
            {
                WriteObject(list);
            }
        }
    }
}