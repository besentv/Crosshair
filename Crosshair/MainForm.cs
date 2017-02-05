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
    public partial class MainForm : Form
    {

        private string filePath1;
        private string filePath2;
        private CrosshairPart p1;
        private CrosshairPart p2;
        private CrosshairPart p3;
        private CrosshairPart p4;
        private int distance = 1;
        private bool isRunning = false;
        private bool hkRegistered = false;
        private bool isShown = false;

        private const int HK_ID = 1;
        private const int WM_HOTKEY = 0x0312;

        // Registers a hot key with Windows.
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        // Unregisters the hot key with Windows.
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public MainForm()
        {
            InitializeComponent();
            button1.Click += new EventHandler(button1_Click);
            button2.Click += button2_Click;
            button3.Click += button3_Click;
            button4.Click += button4_Click;
            button1.Enabled = true;
            button4.Enabled = false;
        }

        

        private void button1_Click(object sender, EventArgs e) {

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) {

                filePath1 = openFileDialog1.FileName;
                button1.Text = filePath1;
                if ((filePath1 != null) && (filePath2 != null))
                {

                    button3.Enabled = true;

                }
            }
        }

        private void button2_Click(object sender, EventArgs e) {

            DialogResult result = openFileDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {

                filePath2 = openFileDialog2.FileName;
                button2.Text = filePath2;

                if((filePath1 != null) && (filePath2 != null))
                {

                    button3.Enabled = true;
                    
                }
            }
        }

        public void button3_Click(object sender, EventArgs e) {
            if (!isRunning)
            {
                distance = Convert.ToInt32(numericUpDown1.Value);

                p1 = new CrosshairPart(-distance, 0, Image.FromFile(@"" + filePath1));
                p2 = new CrosshairPart(distance, 0, Image.FromFile(@"" + filePath1));
                p3 = new CrosshairPart(0, -distance, Image.FromFile(@"" + filePath2));
                p4 = new CrosshairPart(0, distance, Image.FromFile(@"" + filePath2));

                p1.Show();
                p2.Show();
                p3.Show();
                p4.Show();

                button3.Text = "stop";
                button4.Enabled = true;

                isRunning = true;
                isShown = true;
            }
            else if (isRunning) {

                p1.Close();
                p2.Close();
                p3.Close();
                p4.Close();

                button3.Text = "start";
                button4.Enabled = false;
                isRunning = false; 
            }
            
        }

        public void toggleCrosshairVisibility() {
            if (isShown)
            {

                p1.Hide();
                p2.Hide();
                p3.Hide();
                p4.Hide();

                isShown = false;
            }

            else if (!isShown) {

                p1.Show();
                p2.Show();
                p3.Show();
                p4.Show();

                isShown = true;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Enabled) {
                unregisterHotkey();
                button4.Text = "registering...(press key)";
                button4.Enabled = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private bool registerHotkey(uint vk) {

            if (!RegisterHotKey(this.Handle, HK_ID, 0, vk)) { return false; }
            else return true;



        }

        private void unregisterHotkey() {

            if (hkRegistered)
            {
                UnregisterHotKey(this.Handle, HK_ID);
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!button4.Enabled) {

              hkRegistered = registerHotkey(Convert.ToUInt32(e.KeyValue));
                if (hkRegistered) {
                    
                    button4.Text = "Fast toggle key: " + e.KeyCode.ToString();

                    button4.Enabled = true;
                    button5.Enabled = true;
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            unregisterHotkey();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY) {

                if(m.WParam.ToInt32() == HK_ID){
                    toggleCrosshairVisibility();

                }

            }

            base.WndProc(ref m);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (hkRegistered)
            {
                unregisterHotkey();
                button4.Text = "Register toggle hotkey";
                button5.Enabled = false;
            }
        }
    }
}
