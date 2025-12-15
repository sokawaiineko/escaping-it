using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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

        //MAKE INHERITANCE CLASSES FOR ITEMS//quickl
    }
    internal class usable : Item
    {
        private string puzzleInteractable;
        public usable(string name, string description, string PuzzleInteractable) : base (name, description)
        {
            puzzleInteractable = PuzzleInteractable;
        }
        public bool canBeUsed(Puzzle p)
        {
            return p != null && p.GetName()==puzzleInteractable;
        }
        public string getPuzzleInteractable()
        {
            return puzzleInteractable;
        }
    }
}
