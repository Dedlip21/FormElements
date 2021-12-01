using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormElements
{
    public partial class Form1 : Form
    {
        TextBox tb;
        PictureBox picture;
        RadioButton rb, rb1, rb2;
        Label lbl;
        Button btn;
        TabControl tabC;
        ListBox lb;
        DataSet ds;
        DataGridView dg;
        MainMenu menu;
        MenuItem menuFile;
        MessageBox msb;

        public Form1()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Картинки")
            {
                picture = new PictureBox();
                picture.Location = new Point(500, 10);
                picture.Size = new Size(180, 180);
                picture.SizeMode = PictureBoxSizeMode.Zoom;
                picture.BorderStyle = BorderStyle.Fixed3D;
                picture.Image = Image.FromFile(@"..\..\images\ElPrimo.png");
                this.Controls.Add(picture);

                picture = new PictureBox();
                picture.Location = new Point(300, 10);
                picture.Size = new Size(180, 180);
                picture.SizeMode = PictureBoxSizeMode.Zoom;
                picture.BorderStyle = BorderStyle.Fixed3D;
                picture.Image = Image.FromFile(@"..\..\images\SuperIdol.jpg");
          
                this.Controls.Add(picture);
            }

            else if (e.Node.Text == "Надпись")
            {
                lbl = new Label();
                lbl.Text = "Привет";
                lbl.AutoSize = true;
                lbl.Location = new Point(300, 100);
                this.Controls.Add(lbl);
            }

            else if (e.Node.Text == "Уведомление")
            {
                /*MessageBox.Show("MessageBox", "Kõige lihtsam aken");
                var answer = MessageBox.Show("Tahad InputBoxi näha?", "Aken koos nupudega", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    string text = Interaction.InputBox("Sisesta siia mingi tekst", "InputBox", "Mingi tekst");
                    if (MessageBox.Show("Kas tahad tekst saada Tekskastisse?", "Teksti salvestamine", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        lbl.Text = text;
                        Controls.Add(lbl);
                    }
                }*/

            }

            else if (e.Node.Text == "Цвет фона")
            {
                RadioButton rb1 = new RadioButton();
                rb1.Text = "Черная тема";
                rb1.Location = new Point(300, 150);
                RadioButton rb2 = new RadioButton();
                rb2.Text = "Белая тема";
                rb2.Location = new Point(300, 200);
                this.Controls.Add(rb1);
                this.Controls.Add(rb2);
                rb1.CheckedChanged += rb1_CheckedChanged;

            }

            else if (e.Node.Text == "Сайт")
            {
                TabControl tabC = new TabControl();
                tabC.Location = new Point(450, 50);
                tabC.Size = new Size(500, 400);
                TabPage tabP1 = new TabPage("Первый");
                WebBrowser wb = new WebBrowser();
                wb.Url = new Uri("https://www.tthk.ee/");
                tabP1.Controls.Add(wb);

                TabPage tabP2 = new TabPage("Второй");

                TabPage tabP3 = new TabPage("Третий");
                tabP3.DoubleClick += TabP3_DoubleClick;
                tabC.Controls.Add(tabP1);
                tabC.Controls.Add(tabP2);
                tabC.Controls.Add(tabP3);
                this.Controls.Add(tabC);
            }

            else if (e.Node.Text == "ListBox")
            {
                lb = new ListBox();
                lb.Items.Add("Roheline");
                lb.Items.Add("Punane");
                lb.Items.Add("Sinine");
                lb.Items.Add("Hall");
                lb.Items.Add("Kollane");
                lb.Items.Add("Roheline");
                lb.Location = new Point(150, 120);
                lb.SelectedIndexChanged += new EventHandler(Lb_SelectedIndexChanged); 
                this.Controls.Add(lb);
            }

            else if (e.Node.Text == "DataGridView")
            {
                DataSet ds = new DataSet("Xml fail. Menüü");
                ds.ReadXml(@"..\..\images\food.xml");
                DataGridView dg = new DataGridView();
                dg.Width = 200;
                dg.Height = 120;
                dg.Location = new Point(300, 250);
                dg.AutoGenerateColumns = true;
                dg.DataSource = ds;

                this.Controls.Add(dg);
            }

            else if (e.Node.Text == "MainMenu")
            {
                MainMenu menu = new MainMenu();
                MenuItem menuFile = new MenuItem("File");
                menuFile.MenuItems.Add("Exit", new EventHandler(MenuFile_Exit_Select));
                menuFile.MenuItems.Add("Hide", new EventHandler(MenuFile_Hide_Select));

                MenuItem menuColor = new MenuItem("BG Color");
                menuColor.MenuItems.Add("Red", new EventHandler(MenuFile_Color1_Select));
                menuColor.MenuItems.Add("Gray", new EventHandler(MenuFile_Color2_Select));
                menuColor.MenuItems.Add("Violet", new EventHandler(MenuFile_Color3_Select));
                //site
                MenuItem menuSite = new MenuItem("Site");
                menuSite.MenuItems.Add("tthk site", new EventHandler(MenuFile_Site_Select));
               // WebBrowser wb = new WebBrowser();
                //wb.Url = new Uri("https://www.tthk.ee/");
                // menuSite.MenuItems.Add("TTHK");

                menu.MenuItems.Add(menuSite);
                menu.MenuItems.Add(menuColor);
                menu.MenuItems.Add(menuFile);
                this.Menu = menu;
            }
        }

        //---------menu-----------------------
        private void MenuFile_Site_Select(object sender, EventArgs e)
        {
            TabControl tabC = new TabControl();
            tabC.Location = new Point(450, 50);
            tabC.Size = new Size(500, 400);
            TabPage tabP1 = new TabPage("tthk.ee");
            WebBrowser wb = new WebBrowser();
            wb.Url = new Uri("https://www.tthk.ee/");
            tabP1.Controls.Add(wb);

            tabC.Controls.Add(tabP1);
            this.Controls.Add(tabC);

        }
        private void MenuFile_Hide_Select(object sender, EventArgs e)
        {
            

        }
        private void MenuFile_Color1_Select(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
        }
        private void MenuFile_Color2_Select(object sender, EventArgs e)
        {
            this.BackColor = Color.Gray;
        }
        private void MenuFile_Color3_Select(object sender, EventArgs e)
        {
            this.BackColor = Color.BlueViolet;
        }
        private void MenuFile_Exit_Select(object sender, EventArgs e)
        {
            this.Close();
        }
        //------------------/menu----------------

        private void Lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void rb1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void TabP3_DoubleClick(object sender, EventArgs e)
        {
            string title = "tabP" + (tabC.TabCount + 1).ToString();
            TabPage tb = new TabPage(title);
            tabC.TabPages.Add(tb);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Add("Действия");
            treeView1.Nodes.Add("Игры на рандом");

            treeView1.Nodes[0].Nodes.Add("Надпись");
            treeView1.Nodes[0].Nodes.Add("Цвет фона");
            treeView1.Nodes[0].Nodes.Add("Картинки");
            treeView1.Nodes[0].Nodes.Add("MainMenu");
            treeView1.Nodes[0].Nodes.Add("Уведомление");
            treeView1.Nodes[0].Nodes.Add("Сайт");
            treeView1.Nodes[0].Nodes.Add("ListBox");
            treeView1.Nodes[0].Nodes.Add("DataGridView");
            treeView1.Nodes[1].Nodes.Add("Загадай цифру");
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode.Remove();
        }

        private void buttonDeleteAll_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
        }
    }
}





/*if (rb1.Checked)
            {
                this.BackColor = Color.Black;
                rb2.ForeColor = Color.White;
                rb1.ForeColor = Color.White;
            }

            else if (rb2.Checked)
            {
                this.BackColor = Color.White;
                rb2.ForeColor = Color.Black;
                rb1.ForeColor = Color.Black;
            }*/