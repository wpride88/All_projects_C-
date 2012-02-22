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
    public class CrBox : PictureBox
    {
        Form1 fm1 = new Form1();
        bool isDown;
        PictureBox pball = new PictureBox();
        public Point cur, curnew;

        public CrBox() //Constructor
        {
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picturebox_OnMouseUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picturebox_OnMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picturebox_OnMouseMove);
        }

        public void picturebox_OnMouseDown(object sender, MouseEventArgs e)
        {
            curnew = this.Location;
            cur = Cursor.Position;
            isDown = true;
        }

        public void picturebox_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (isDown && e.Button == MouseButtons.Left)
            {
                this.Location = new Point(Cursor.Position.X - cur.X + curnew.X,
                    Cursor.Position.Y - cur.Y + curnew.Y);
            }
        }

        public void picturebox_OnMouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
        }
    }
}
