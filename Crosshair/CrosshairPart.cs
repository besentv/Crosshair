using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crosshair
{
    public partial class CrosshairPart : Form
    {

        private int SCREEN_W = Screen.PrimaryScreen.Bounds.Width;
        private int SCREEN_H = Screen.PrimaryScreen.Bounds.Height;
        private Image crosshairPic;
        int x;
        int y;

       private int X { get { return this.x; }
            set {
                if (value > 0)
                {

                    this.x = (SCREEN_W / 2 + value);

                }
                else if (value < 0)
                {


                    this.x = (SCREEN_W / 2 + value - (crosshairPic.Size.Width -1));

                }
                else { this.x = (SCREEN_W/2 - crosshairPic.Size.Width / 2); }
            } }
       private int Y
        {
            get { return this.y; }
            set
            {
                if (value > 0)
                {

                    this.y = (SCREEN_H / 2 + value);

                }
                else if (value < 0)
                {


                    this.y = (SCREEN_H / 2 + value - (crosshairPic.Size.Height -1));

                }
                else { this.y = (SCREEN_H/2 - crosshairPic.Size.Height / 2); }
            }
        }



        public CrosshairPart(int x, int y, Image crosshairPic)
        {
            InitializeComponent();
            this.crosshairPic = crosshairPic;
            this.X = x;
            this.Y = y;
            
        }


        protected override void OnLoad(EventArgs e)
        {
        //    Console.WriteLine("x: " + x);
        //    Console.WriteLine("screen x: " + Screen.PrimaryScreen.Bounds.Width);
        //    Console.WriteLine("y: " + y);
        //    Console.WriteLine("screen y: " + Screen.PrimaryScreen.Bounds.Height);
            base.OnLoad(e);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(crosshairPic.Size.Width, crosshairPic.Size.Height);
            this.WindowState = FormWindowState.Normal;
            this.TopMost = true;
            this.TransparencyKey = Color.Turquoise;
            this.BackColor = Color.Turquoise;
            this.Cursor = new Cursor(GetType(), "InvisCursor.cur");

            this.Location = new Point(x,y);
            crosshair.SizeMode = PictureBoxSizeMode.AutoSize;
            crosshair.Anchor = AnchorStyles.None;
            crosshair.Location = new Point(0,0);
            crosshair.Image = crosshairPic;
            
           // this.SetStyle(ControlStyles.Selectable, false);
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams baseParams = base.CreateParams;

                const int WS_EX_NOACTIVATE = 0x08000000;
                const int WS_EX_TOOLWINDOW = 0x00000080;
                baseParams.ExStyle |= (int)(WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW);

                return baseParams;
            }
        }







        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
