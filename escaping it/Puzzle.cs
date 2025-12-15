using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace escaping_it
{
    internal class Puzzle
    {
        private String Name;
        private String Description;
        private List<String> RequiredItems;
        private bool Solved;

        public Puzzle(String name, String description, List<String> requiredItems)
        {
            Name = name;
            Description = description;
            RequiredItems = requiredItems;
            Solved = false;
        }

        public String GetName()
        {
            return Name;
        }

        public String GetDescription()
        {
            return Description;
        }

        public bool IsSolved()
        {
            return Solved;
        }

        public bool TrySolve(Inventory inv)
        {
            if (Solved) return true;
            foreach (String r in RequiredItems)
            {
                if (!inv.HasItem(r)) return false;
            }
            Solved = true;
            return true;
        }

        public List<String> MissingItems(Inventory inv)
        {
            List<String> miss = new List<String>();
            foreach (String r in RequiredItems)
            {
                if (!inv.HasItem(r)) miss.Add(r);
            }
            return miss;
        }
        //comment

        public void Reset()
        {
            Solved = false;
        }

        public void SetRequirements(List<String> req)
        {
            RequiredItems = req;
        }
    }
}
