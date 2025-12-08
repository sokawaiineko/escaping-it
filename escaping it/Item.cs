using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace escaping_it
{
    internal class Item
    {
        private String Name;
        private String Description;

        public Item(String name, String description)
        {
            Name = name;
            Description = description;
        }

        public String GetName()
        {
            return Name;
        }
        public String GetDescription()
        {
            return Description;
        }
        public void SetName(String n)
        {
            Name = n;
        }
        public void SetDescription(String d)
        {
            Description = d;
        }

        //MAKE INHERITANCE CLASSES FOR ITEMS
    }
}
