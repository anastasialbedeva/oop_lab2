using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory
{
    public interface IInventoryItem
    {
        string Describe();
    }



    public abstract class InventoryItem : IInventoryItem
    {
        public string Name { get; set; }
        public abstract string Describe();

        protected InventoryItem(string name)
        {
            Name = name;
        }
    }
}
