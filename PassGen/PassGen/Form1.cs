using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int minLength = 15; //minimum char
            int maxLength = 16; //maximum char

            string charAvailable = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!.$";
            StringBuilder password = new StringBuilder();
            Random rdm = new Random();
            //random length for password is 15-16 char 
            int passwordLength = rdm.Next(minLength, maxLength + 1);

            //add a random char to your password untill it reaches the randomized length
            while (passwordLength-- > 0)
                password.Append(charAvailable[rdm.Next(charAvailable.Length)]);

            label1.Text = password.ToString();
            label2.Text = "COPIED";
            Clipboard.SetText(label1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //Moving the form 
        bool grab;
        int grabX, grabY;

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            grab = false;
            grabX = 0;
            grabY = 0;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(grab == true) {
                Left = Cursor.Position.X - grabX;
                Top = Cursor.Position.Y - grabY;

            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            grab = true;
            grabX = Cursor.Position.X - Left;
            grabY = Cursor.Position.Y - Top;
        }
    }
}
