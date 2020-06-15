﻿using System.Collections.Generic;
using System.Management.Automation;
using TfsCmdlets.Cmdlets;
using TfsCmdlets.Extensions;
using TfsCmdlets.Services;

namespace TfsCmdlets.Services
{
    internal interface IDataService<T> : IService where T : class
    {
        T GetItem();

        IEnumerable<T> GetItems();
        
        T NewItem();

        void RemoveItem();

        T SetItem(T item);

        T RenameItem(T item, string newName);

        bool TestItem();
    }
}