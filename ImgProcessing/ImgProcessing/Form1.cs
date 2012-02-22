using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ImgProcessing
{
    public partial class ImageMirror : Form
    {
        public ImageMirror()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.Image = Image.FromFile(@"C:\Image1.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            Bitmap bitmap1 = (Bitmap)pictureBox1.Image;
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.Image = Image.FromFile(@"C:\Image1.jpg");
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            Bitmap bitmap2 = (Bitmap)pictureBox2.Image;
            pictureBox2.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            label1.Visible = true;
            pictureBox2.Image.Save("c:\\image1_mirror.jpg");
        }

        public static Bitmap ImageRotateAll(Bitmap btmp, float anglert, Color bgColor)
        {
            int wdth = btmp.Width;
            int hght = btmp.Height;
            PixelFormat pixfmt = default(PixelFormat);
            if (bgColor == Color.Transparent)
            {
                pixfmt = PixelFormat.Format32bppArgb;
            }
            else
            {
                pixfmt = btmp.PixelFormat;
            }

            Bitmap tempImage = new Bitmap(wdth, hght, pixfmt);
            Graphics gr = Graphics.FromImage(tempImage);
            gr.Clear(bgColor);
            gr.DrawImageUnscaled(btmp, 1, 1);
            gr.Dispose();

            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new RectangleF(0f, 0f, wdth, hght));
            Matrix mtrx = new Matrix();
            mtrx.Rotate(anglert);
            RectangleF rect = path.GetBounds(mtrx);
            Bitmap newImage = new Bitmap(Convert.ToInt32(rect.Width), Convert.ToInt32(rect.Height), pixfmt);
            gr = Graphics.FromImage(newImage);
            gr.Clear(bgColor);
            gr.TranslateTransform(-rect.X, -rect.Y);
            gr.RotateTransform(anglert);
            gr.InterpolationMode = InterpolationMode.HighQualityBilinear;
            gr.DrawImageUnscaled(tempImage, 0, 0);
            gr.Dispose();
            tempImage.Dispose();
            return newImage;
        }
    }
}
