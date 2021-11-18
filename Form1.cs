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
        TreeView tree;
        Button btn;
        Label lbl;
        PictureBox pcb;
        public Form1()
        {
            //tree
            this.Height = 500;
            this.Width = 700;
            this.Text = "Vorm elementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;
            

            TreeNode tn = new TreeNode("Elemendid");
            tn.Nodes.Add(new TreeNode("Nupp-Button"));
            tn.Nodes.Add(new TreeNode("Silt-Label"));
            tn.Nodes.Add(new TreeNode("Märkeruut-Checkbox"));
            tn.Nodes.Add(new TreeNode("Radionupp-Radiobutton"));
            tn.Nodes.Add(new TreeNode("Tekstikast-Textbox"));
            tn.Nodes.Add(new TreeNode("Pilt"));
            tn.Nodes.Add(new TreeNode("Kaart-TabControl"));
            tn.Nodes.Add(new TreeNode("Messagebox"));

            tree.Nodes.Add(tn);
            this.Controls.Add(tree);

            //nupp
            btn = new Button();
            btn.Text = "Vajuta siia";
            btn.Location = new Point(150,30);
            btn.Height = 30;
            btn.Width = 100;
            btn.Click += Btn_Click;
            //pelkiri
            lbl = new Label();
            lbl.Text = "Elemendide loomine c# abil";
            lbl.Size = new Size(600, 30);
            lbl.Location = new Point(150, 0);
            lbl.MouseHover += Lbl_MouseHover;
            lbl.MouseLeave += Lbl_MouseLeave;
            //Picturebox
            pcb = new PictureBox();
            pcb.Size = new Size(50, 50);
            pcb.Location = new Point(150, 60);
            pcb.SizeMode = PictureBoxSizeMode.StretchImage;
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            pcb.Image = Image.FromFile(@"C:\Kasutajad\opilane\source\repos\TARpv20 Rolan Maslennikov\FormElements\img\bird1.jpg");

            pcb.DoubleClick += Pcb_DoubleClick;


        }

        private void Pcb_DoubleClick(object sender, EventArgs e)
        {
            //
        }

        private void Lbl_MouseLeave(object sender, EventArgs e)
        {
            lbl.Text = "Elemendide loomine c# abil";
            lbl.ForeColor = Color.FromArgb(200, 10, 20);
        }

        private void Lbl_MouseHover(object sender, EventArgs e)
        {
            lbl.Text = "Mouse on label";
            lbl.ForeColor = Color.FromArgb(200, 10, 20);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            //if(e.MouseClick==true)
        }

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text=="Nupp")
            {
                this.Controls.Add(btn);
            }
            else if(e.Node.Text== "Silt-Label")
            {
                this.Controls.Add(lbl);
            }
            else if (e.Node.Text == "Pilt")
            {
                this.Controls.Add(pcb);
            }
        }
    }
}
