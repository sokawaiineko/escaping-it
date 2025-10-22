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
        private Menu menu;
        Inventory inventory;
        List<Puzzle> puzzles;
        private Item selectedItem = null;
        public Game(Menu m)
        {
            InitializeComponent();
            menu = m;
            borderless(bmenu);
            inventory = new Inventory();
            puzzles = new List<Puzzle>();
            RefreshInventoryUI();
            this.FormClosed += Game_FormClosed;
            bkey.Visible = false;


            puzzles.Add(new Puzzle("darkcorner", "too dark to see here", new List<String> { "flashlight" }));
            puzzles.Add(new Puzzle("generator", "needs a battery to power lights", new List<String> { "battery" }));
            puzzles.Add(new Puzzle("locker", "a rusty locker with a keyhole", new List<String> { "key" })); 
        }
        private Item firstCombineItem = null;
        private bool combineMode = false;


        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Show();
        }

        private void borderless(Button b)
        {

            b.TabStop = false;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
            b.BackColor = Color.Transparent;
        }
        private void bmenu_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            menu.Show();
        }
        private void FlashlightWORKING(Item item1, Item item2)
        {

            if ((item1.GetName() == "flashlight" && item2.GetName() == "battery") ||
        (item1.GetName() == "battery" && item2.GetName() == "flashlight"))
            {
                inventory.RemoveItem("flashlight");
                inventory.RemoveItem("battery");
                Item combined = new Item("working flashlight", "a flashlight with a fresh battery, now usable.");
                inventory.AddItem(combined);
                lname.Text = combined.GetName();
                linfodetail.Text = combined.GetDescription();

                MessageBox.Show("You combined them into a working flashlight!");
            }
            else
            {
                MessageBox.Show("that doesn’t seem to work...");
            }

            RefreshInventoryUI();
        }

        private void listinventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listinventory == null || linfodetail == null) return;
            if (listinventory.SelectedIndex < 0)
            {
                lname.Text = "";
                linfodetail.Text = "";
                selectedItem = null;
                return;
            }
            string n = listinventory.SelectedItem.ToString();
            Item it = inventory.Find(n);
            if (it == null) return;
            lname.Text = it.GetName();
            linfodetail.Text = it.GetDescription();
            selectedItem = it;

            if (combineMode)
            {
                if (firstCombineItem == null)
                {
                    firstCombineItem = it;
                    
                }
                else
                {
                    FlashlightWORKING(firstCombineItem, it);
                    combineMode = false;
                    firstCombineItem = null;
                }
            }
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

        private void bflashlight_Click(object sender, EventArgs e)
        {
            if (!inventory.HasItem("flashlight"))
            {
                Item flashlight = new Item("flashlight", "a small handheld light, useful for dark places.");
                inventory.AddItem(flashlight);

                bflashlight.Visible = false;
                RefreshInventoryUI();

                
                lname.Text = flashlight.GetName();
                linfodetail.Text = flashlight.GetDescription();
            }
        }

        private void bcombine_Click(object sender, EventArgs e)
        {
            if (!combineMode)
            {
                combineMode = true;
                firstCombineItem = null;
                
            }
            else
            {
                combineMode = false;
                firstCombineItem = null;
                
            }
        }

        private void bbattery_Click(object sender, EventArgs e)
        {
            if (!inventory.HasItem("battery"))
            {
                Item battery = new Item("battery", "a small battery, might power something.");
                inventory.AddItem(battery);

                bbattery.Visible = false;      
                RefreshInventoryUI();

                lname.Text = battery.GetName();
                linfodetail.Text = battery.GetDescription();
            }
        }

        private void bwrench_Click(object sender, EventArgs e)
        {
            if (!inventory.HasItem("wrench"))
            {
                Item wrench = new Item("wrench", "A simple wrench, a little rust along the edges");
                inventory.AddItem(wrench);

                bbattery.Visible = false;
                RefreshInventoryUI();

                lname.Text = wrench.GetName();
                linfodetail.Text = wrench.GetDescription();
            }
        }

        private void bbox_Click(object sender, EventArgs e)
        {
            if (!bbox.Enabled) return;
            
            if (selectedItem != null && selectedItem.GetName() == "wrench")
            {
                
                // bbox.BackgroundImage = Properties.Resources.openbox;   <--- NEED TO ADD IMAGE
                bbox.BackgroundImageLayout = ImageLayout.Stretch;
                bkey.Visible = true;
                bbox.Enabled = false;
            }
            else
            {
                MessageBox.Show("You need a wrench selected to open this box!");
            }
        }
    }

    
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
