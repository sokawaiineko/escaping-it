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
        bool cipherSolved = false;
        private bool lightsOutSolved = false;
        public Game(Menu m)
        {
            InitializeComponent();

            menu = m;
            borderless(bmenu);
            borderless(briddle);
            borderless(bbox);
            borderless(bSidedoor);
            borderless(bkey);
            borderless(blightsout);
            borderless(bwrench);
            borderless(bescape);
            borderless(bflashlight);
            borderless(bbattery);
            inventory = new Inventory();
            puzzles = new List<Puzzle>();
            RefreshInventoryUI();
            this.FormClosed += Game_FormClosed;
            bkey.Visible = false;
            
            




        }
        private Item firstCombineItem = null;
        private bool combineMode = false;

        private void GiveItem(Item it)
        {
            if (it == null) return;

            if (!inventory.HasItem(it.GetName()))
            {
                inventory.AddItem(it);
                RefreshInventoryUI();
            }

            lname.Text = it.GetName();
            linfodetail.Text = it.GetDescription();
        }



        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {

            menu.Dispose();
        }

        // give all buttons a borderless style
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
        //flashlight item
        private void FlashlightWORKING(Item item1, Item item2)
        {

            if ((item1.GetName() == "flashlight" && item2.GetName() == "battery") || (item1.GetName() == "battery" && item2.GetName() == "flashlight"))
            {
                inventory.RemoveItem("flashlight");
                inventory.RemoveItem("battery");
                Item combined = new Item("working flashlight", "a flashlight with a fresh battery, now usable.");
                inventory.AddItem(combined);
                lname.Text = combined.GetName();
                linfodetail.Text = combined.GetDescription();

            }
            else
            {
                MessageBox.Show("that doesn’t workr");
            }

            RefreshInventoryUI();
        }

        //select items in the inventory list
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
        //refresh inventory
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
                GiveItem(new Item("flashlight", "a small handheld light, useful for dark places."));
                bflashlight.Visible = false;
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
            GiveItem(new Item("battery", "a small battery, might power something."));
            bbattery.Visible = false;
        }

        private void bwrench_Click(object sender, EventArgs e)
        {
            if (!inventory.HasItem("wrench"))
            {
                Item wrench = new Item("wrench", "A simple wrench, a little rust along the edges");
                inventory.AddItem(wrench);

                bwrench.Visible = false;
                RefreshInventoryUI();

                lname.Text = wrench.GetName();
                linfodetail.Text = wrench.GetDescription();
            }
        }

        private void bbox_Click(object sender, EventArgs e)
        {
            if (selectedItem == null)
            {
                return;
            }
            else if (selectedItem.GetName() != "wrench")
            {
                linfodetail.Text = "that doesnt seem to work.";

            }
            else if (selectedItem.GetName() == "wrench")
            {
                linfodetail.Text = "you open the box";
                bbox.Image = Properties.Resources.Image__1_;
                bkey.Visible = true;
                RefreshInventoryUI();
                selectedItem = null;
                lname.Text = "";
                linfodetail.Text = "";
            }


        }

        private void bkey_Click(object sender, EventArgs e)
        {
            Item key = new Item("key", "An old key");
            inventory.AddItem(key);

            bkey.Visible = false;
            RefreshInventoryUI();

            lname.Text = key.GetName();
            linfodetail.Text = key.GetDescription();
        }

        private void blightsout_Click(object sender, EventArgs e)
        {


            if (lightsOutSolved) return;

            if (!lightsOutSolved)
            {
                if (selectedItem == null)
                {
                    linfodetail.Text = "select an item to use";
                    return;
                }
                if (selectedItem.GetName() != "key")
                {
                    linfodetail.Text = "that doesnt fit the lock";
                    return;
                }

                lightsOutSolved = true;
                inventory.RemoveItem("key");
                RefreshInventoryUI();
                linfodetail.Text = "you use the key on the lock";
                lname.Text = "";
                selectedItem = null;

            }

            using (LightsOutForm lights = new LightsOutForm())
            {
                lights.ShowDialog();
                if (lights.PuzzleSolved)
                {
                    lightsOutSolved = true;
                    linfodetail.Text = "you hear a click... something is different";
                    blightsout.Enabled = false;
                }
            }


        }



        private void briddle_Click(object sender, EventArgs e)
        {
            if (selectedItem == null)
            {
                linfodetail.Text = "select an item to use";
                return;
            }

            if (selectedItem.GetName() != "Paper")
            {
                linfodetail.Text = "Do you really know what you're getting into?";
                return;
            }

            using (RiddleForm riddle = new RiddleForm())
            {
                riddle.ShowDialog();

                if (riddle.KeyEarned && !inventory.HasItem("riddle key"))
                {
                    Item riddleKey = new Item("keycard", "A small keycard earned from solving the riddle.");
                    inventory.AddItem(riddleKey);
                    RefreshInventoryUI();
                    lname.Text = riddleKey.GetName();
                    linfodetail.Text = riddleKey.GetDescription();
                }
            }

            selectedItem = null;
            lname.Text = "";
            linfodetail.Text = "";
        }

        private void bSidedoor_Click(object sender, EventArgs e)

        {
            if (!lightsOutSolved)
            {
                linfodetail.Text = "the door wont open... maybe you need to fix the lights first.";
                return;
            }

            if (selectedItem == null)
            {
                linfodetail.Text = "select an item to use.";
                return;
            }
            else if (selectedItem.GetName() != "working flashlight")
            {
                linfodetail.Text = "that doesnt seem to work, do you have everything?.";
                return;
            }
            else if (selectedItem.GetName() == "working flashlight")
            {
                linfodetail.Text = "you shine the flashlight and enter.";
                bSidedoor.BackgroundImage = Properties.Resources.IMG_1535;

                RefreshInventoryUI();
                selectedItem = null;
                lname.Text = "";
                linfodetail.Text = "";
                if (!cipherSolved)
                {
                    dark_room cf = new dark_room();
                    cf.ShowDialog();
                    if (cf.CipherSolved)
                    {
                        cipherSolved = true;
                        inventory.AddItem(new Item("Paper", "A piece of paper reading : How well do you remember those classic riddles?"));
                        RefreshInventoryUI();
                    }

                 
                }
                else
                {
                    linfodetail.Text = "you already did this.";
                }
            }
        }

        private void bescape_Click(object sender, EventArgs e)
        {
            if (selectedItem == null)
            {
                linfodetail.Text = "select an item to use";
                return;
            }

            if (selectedItem.GetName() != "keycard")
            {
                linfodetail.Text = "that doesnt unlock this";
                return;
            }

            inventory.RemoveItem("keycard");
            RefreshInventoryUI();

            selectedItem = null;
            linfodetail.Text = "you unlock the final door, quick, escape, and don't go the wrong way";
            lname.Text = "";
            

            MazeForm maze = new MazeForm();
            maze.ShowDialog();
            if (maze.MazeCompleted)   
            {
                this.Close();
            }
        }
    }








}
