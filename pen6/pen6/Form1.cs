using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pen6
{
    public partial class Form1 : Form
    {
        public ArrayList pbl = new ArrayList();
        public ArrayList pbname = new ArrayList();
        //List<PictureBox> pbList = new List<PictureBox>();
        PictureBox pbox = new PictureBox();
        bool isPanel = false;
        int count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int dxnew = 30, dynew = 30;
            Panel panel = new Panel();
            panel.Size = new System.Drawing.Size(this.Width - 6, this.Height - 96);
            /*panel.Text = "panel";
            panel.SendToBack();
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_OnMouseMove);*/
            
            //CrBox cb = new CrBox(); //Constructor
            Bitmap bmp2 = new Bitmap(300, 300);
            Graphics gr2 = Graphics.FromImage(bmp2);
            Color color = Color.Black;
            Pen redPen = new Pen(Color.Red, 1);
            Rectangle rect2 = new Rectangle(0, 0, 120, 50); //35, 35);

            pbox = new CrBox();
            pbox.Image = bmp2;
            pbox.Name = textBox1.Text;
            gr2.DrawRectangle(redPen, rect2);
            gr2.DrawString(pbox.Name, new Font("Times New Roman", 12), new SolidBrush(Color.Green), rect2);
            pbox.Size = new System.Drawing.Size(124, 54);
            //pbox.BorderStyle = BorderStyle.FixedSingle;
            dxnew = panel.Width / 2 - pbox.Width / 2;
            dynew = panel.Height / 2 - pbox.Height / 2;
            pbox.Location = new Point(dxnew, dynew);
            pbox.BringToFront();
            Controls.Add(pbox);

            pbl.Add(pbox); ///////////////////////////////////
            pbname.Add(pbox.Name);
            count++;
            label7.Text = "Count boxex is " + Convert.ToString(count);
            //Controls.Add(panel);
        }

        public void BoxDelete()
        {
            if (pbl.Count > 0)
            {
                pbox = (PictureBox)pbl[pbl.Count - 1];
                pbox.Select();
                pbl.Remove(pbox);
                pbname.Remove(pbox.Name);
                pbox.Dispose();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < pbl.Count; i++)
            {
                pbox = (PictureBox)this.pbl[i];
                pbox.Dispose();
            }
            pbl.Clear();
            pbname.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BoxDelete();
        }

        private void panel_OnMouseMove(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < pbl.Count; i++)
            {
                pbox = (PictureBox)pbl[i];
                if (pbox.Focused)
                {
                    SetLabelText("Local focused box is ", (String)pbname[i], (String)pbl[i]);
                }
            }
        }

        public void SetLabelText(string name, string value1, string value2)
        {
            label1.Text = name; label2.Text = value1; label3.Text = value2;
            //label4.Text = "picbox loc:";
            //label5.Text = Convert.ToString(pballF.Location.X);
            //label6.Text = Convert.ToString(pballF.Location.Y);
        }

        public void BoxArrangeToForm()
        {
            int xbegin = 5, ybegin = 5, space = 5;
            Point posxy = new Point();
            for (int i = 0; i < pbl.Count; i++)
            {
                pbox = (PictureBox)pbl[i];
                posxy.X = xbegin;
                posxy.Y = ybegin;
                pbox.Location = posxy;
                xbegin = xbegin + 122 + space;
                ybegin = ybegin + 52 + space;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BoxArrangeToForm();
        }

        }
    }
