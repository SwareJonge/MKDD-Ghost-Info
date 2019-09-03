using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            byte[] InputDataLengthArray = File.ReadAllBytes(openFileDialog1.FileName).Skip(0x148E).Take(2).ToArray();            
            ushort InputDataLength = BitConverter.ToUInt16(new byte[2] { InputDataLengthArray[1], InputDataLengthArray[0] }, 0);

            byte[] FinishTime = File.ReadAllBytes(openFileDialog1.FileName).Skip(0x146B).Take(8).ToArray();
            var str = Encoding.Default.GetString(FinishTime);

            int Length = InputDataLength * 2;

            string GetCharInfo(byte x)
            {                    
                if (x == 1)
                { 
                    return "Baby Mario";
                }
                if (x == 2)
                {
                    return"Baby Luigi";
                }
                if (x == 3)
                {
                    return "Patroopa";
                }
                if (x == 4)
                {
                    return "Koopa";
                }
                if (x == 5)
                {
                    return "Peach";
                }
                if (x == 6)
                {
                    return "Daisy";
                }
                if (x == 7)
                {
                    return "Mario";
                }
                if (x == 8)
                {
                    return "Luigi";
                }
                if (x == 9)
                {
                    return "Wario";
                }
                if (x == 10)
                {
                    return "Waluigi";
                }
                if (x == 11)
                {
                    return "Yoshi";
                }
                if (x == 12)
                {
                    return "Birdo";
                }
                if (x == 13)
                {
                    return "Donkey Kong";
                }
                if (x == 14)
                {
                    return "Diddy Kong";
                }
                if (x == 15)
                {
                    return "Bowser";
                }
                if (x == 16)
                {
                    return "Bowser Jr.";
                }
                if (x == 17)
                {
                    return "Toad";
                }
                if (x == 18)
                {
                    return "Toadette";
                }
                if (x == 19)
                {
                    return "King Boo";
                }
                if (x == 20)
                {
                    return "Petey Piranha";
                }
                else
                {
                    return "None";
                }
            }

            string GetKartID(byte x)
            {

                if (x == 0)
                {
                    return "Red Fire";
                }
                if (x == 1)
                {
                    return "DK Jumbo";
                }
                if (x == 2)
                {
                    return "Turbo Yoshi";
                }
                if (x == 3)
                {
                    return "Koopa Dasher";
                }
                if (x == 4)
                {
                    return "Heart Coach";
                }
                if (x == 5)
                {
                    return "Goo-Goo Buggy";
                }
                if (x == 6)
                {
                    return "Wario Car";
                }
                if (x == 7)
                {
                    return "Koopa King";
                }
                if (x == 8)
                {
                    return "Green Fire";
                }
                if (x == 9)
                {
                    return "Barrel Train";
                }
                if (x == 10)
                {
                    return "Turbo Birdo";
                }
                if (x == 11)
                {
                    return "Para Wing";
                }
                if (x == 12)
                {
                    return "Bloom Coach";
                }
                if (x == 13)
                {
                    return "Rattle Buggy";
                }
                if (x == 14)
                {
                    return "Waluigi Racer";
                }
                if (x == 15)
                {
                    return "Bullet Blaster";
                }
                if (x == 16)
                {
                    return "Toad Kart";
                }
                if (x == 17)
                {
                    return "Toadette Kart";
                }
                if (x == 18)
                {
                    return "Boo Pipes";
                }
                if (x == 19)
                {
                    return "Piranha Pipes";
                }
                if (x == 20)
                {
                    return "Parade Kart";
                }
                else
                {
                    return "Unknown ID";
                }
            }

            string GetCourseID(byte x)
            {

                if (x == 0x21)
                {
                    return "Baby Park";
                }
                if (x == 0x22)
                {
                    return "Peach Beach";
                }
                if (x == 0x23)
                {
                    return "Daisy Cruiser";
                }
                if (x == 0x24)
                {
                    return "Luigi Circuit";
                }
                if (x == 0x25)
                {
                    return "Mario Circuit";
                }
                if (x == 0x26)
                {
                    return "Yoshi Circuit";
                }
                if (x == 0x28)
                {
                    return "Mushroom Bridge";
                }
                if (x == 0x29)
                {
                    return "Mushroom City";
                }
                if (x == 0x2A)
                {
                    return "Waluigi Stadium";
                }
                if (x == 0x2B)
                {
                    return "Wario Colosseum";
                }
                if (x == 0x2C)
                {
                    return "Dino Dino Jungle";
                }
                if (x == 0x2D)
                {
                    return "DK Mountain";
                }
                if (x == 0x2F)
                {
                    return "Bowser\'s Castle";
                }
                if (x == 0x31)
                {
                    return "Rainbow Road";
                }
                if (x == 0x32)
                {
                    return "Waluigi Racer";
                }
                if (x == 0x33)
                {
                    return "Dry Dry Desert";
                }
                else
                {
                    return "Sherbet Land";
                }
            }

            byte[] Characters = File.ReadAllBytes(openFileDialog1.FileName).Skip(0x1480).Take(2).ToArray();
            byte[] KartID = File.ReadAllBytes(openFileDialog1.FileName).Skip(0x1482).Take(1).ToArray();
            byte[] CourseID = File.ReadAllBytes(openFileDialog1.FileName).Skip(0x1483).Take(1).ToArray();

            dataGridView1.Rows.Clear();

            int i = 0;
            while (i < Length)
            {
                i += 1;
                byte[] Inputs = File.ReadAllBytes(openFileDialog1.FileName).Skip(0x14A8 + i).Take(2).ToArray();
                dataGridView1.Rows.Add(i / 2, "0x" + Inputs[1].ToString("X2"), "0x" + Inputs[0].ToString("X2"));                
                i++;
            }
            label3.Text = str;
            label4.Text = InputDataLength.ToString();
            label8.Text = GetCharInfo(Characters[0]);
            label9.Text = GetCharInfo(Characters[1]);
            label10.Text = GetKartID(KartID[0]);
            label11.Text = GetCourseID(CourseID[0]);
        }
    }
}
