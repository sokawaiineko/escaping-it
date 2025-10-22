using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace escaping_it
{
    internal class Inventory
    {
        private List<Item> Items = new List<Item>();

        public void AddItem(Item item)
        {
            if (item != null) Items.Add(item);
        }

        public bool RemoveItem(String name)
        {
            Item found = null;
            foreach (Item it in Items)
            {
                if (it.GetName() == name) found = it;
            }
            if (found != null)
            {
                Items.Remove(found);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasItem(String name)
        {
            foreach (Item it in Items)
            {
                if (it.GetName() == name) return true;
            }
            return false;
        }

        public Item Find(String name)
        {
            foreach (Item it in Items)
            {
                if (it.GetName() == name) return it;
            }
            return null;
        }

        public List<Item> GetItems()
        {
            return Items;
        }
    }
}
