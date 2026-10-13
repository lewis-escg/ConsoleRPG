using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Classes
{
    public class Item(string name, Inventory container, decimal value = 1)
    {
        public string Name = name;
        public Inventory Container = container;
        public decimal Value = value;

        public void Transfer(Inventory newContainer)
        {
            Container.RemoveItem(this); // remove from contents of old table
            newContainer.AddItem(this); // add to contents of new table
            Container = newContainer; // set the local reference to the new container
        }

        public void Destroy()
        {
            Container.RemoveItem(this); // remove from container, hopefully gets cleaned up automatically
        }
    }
}
