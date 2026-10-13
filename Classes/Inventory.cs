using System;

namespace ConsoleRPG.Classes
{
    public class Inventory
    {
        public List<Item> Contents = new();
        
        public void AddItem(Item item)
        {
            Contents.Add(item);
        }

        public void RemoveItem(Item item)
        {
            Contents.Remove(item);
        }
    }
}
