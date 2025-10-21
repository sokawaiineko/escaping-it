using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace escaping_it
{
    public partial class Game : Form
    {
        Menu menu = new Menu();
        Inventory inventory;
        List<Puzzle> puzzles;

        public Game()
        {
            InitializeComponent();
            borderless(bmenu);
            inventory = new Inventory();
            puzzles = new List<Puzzle>();
            RefreshInventoryUI();
            //example puzzles for room1
            puzzles.Add(new Puzzle("darkcorner", "too dark to see here", new List<String> { "flashlight" }));
            puzzles.Add(new Puzzle("generator", "needs a battery to power lights", new List<String> { "battery" }));
            puzzles.Add(new Puzzle("locker", "a rusty locker with a keyhole", new List<String> { "key" })); //will be unsolved until a 'key' is acquired later
        }

        private void borderless(Button btn)
        {

            btn.TabStop = false;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn.BackColor = Color.Transparent;
        }
        private void bmenu_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            menu.Show();
        }
        private void listinventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listinventory == null || linfodetail == null) return;
            if (listinventory.SelectedIndex < 0) { linfodetail.Text = ""; return; }
            String n = listinventory.SelectedItem.ToString();
            Item it = inventory.Find(n);
            if (it != null) linfodetail.Text = it.GetDescription();
        }
        private void RefreshInventoryUI()
        {
            if (listinventory == null) return;
            listinventory.Items.Clear();
            foreach (Item it in inventory.GetItems())
            {
                listinventory.Items.Add(it.GetName());
            }
            if (lcount != null) lcount.Text = $"items: {inventory.GetItems().Count}";
            if (linfodetail != null) linfodetail.Text = "";
        }
        
       

        
        

        
        
    }

    // ----------------------
    // week1 classes
    // ----------------------
    class Inventory
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

    class Item
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
    }

    class Puzzle
    {
        private String Id;
        private String Description;
        private List<String> RequiredItems;
        private bool Solved;

        public Puzzle(String id, String description, List<String> requiredItems)
        {
            Id = id;
            Description = description;
            RequiredItems = requiredItems;
            Solved = false;
        }

        public String GetId()
        {
            return Id;
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
