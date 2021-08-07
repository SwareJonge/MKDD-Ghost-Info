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
using MKDD_Ghost_Info.Core;

namespace MKDD_Ghost_Info
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int startReadPos = 0;
        public int endReadPos = 0;

        public Label[] laptimeLabel = new Label[7];
        public Label[] lapnumLabel = new Label[7];

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Saved Ghost Data|*.gci;*.ght|Input Data only|*.bin";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.Rows.Clear();
                button1.Enabled = true;

                for(int i = 0; i < 7; i++) // clear the labels
                {
                    if (laptimeLabel[i] != null)
                        Controls.Remove(laptimeLabel[i]);
                    if (lapnumLabel[i] != null)
                        Controls.Remove(lapnumLabel[i]);
                }

                ConverterFunctions C = new ConverterFunctions();
                byte[] file = File.ReadAllBytes(openFileDialog1.FileName);
                int ghtstartPos = 0;

                if(!openFileDialog1.FileName.ToString().EndsWith(".bin"))
                {
                    if (openFileDialog1.FileName.ToString().EndsWith(".gci"))
                    {
                        ghtstartPos = 0x1480;
                    }

                    byte[] IDs = file.Skip(ghtstartPos).Take(4).ToArray();
                    string tag = Encoding.GetEncoding(932).GetString(file.Skip(ghtstartPos + 0x4).Take(3).ToArray());
                    int FinishTime = BitConverter.ToInt32(file.Skip(ghtstartPos + 0x8).Take(4).Reverse().ToArray(), 0);
                    int InputDataLength = BitConverter.ToInt32(file.Skip(ghtstartPos + 0xC).Take(4).Reverse().ToArray(), 0);

                    startReadPos = ghtstartPos + 0x28;
                    int Length = InputDataLength * 2;
                    endReadPos = Length + 2;

                    int j;

                    int laptimesTotal = 0;
                    int raceTime = 0;
                    int lapTime = 0;

                    for (j = 0; j < 7; j ++)
                    {
                        int prevLapTime = raceTime;                        
                        raceTime = BitConverter.ToInt32(file.Skip((ghtstartPos + 0x10) + (j * 4)).Take(4).Reverse().ToArray(), 0);

                        if (raceTime == 0x5b8d7f || j == 6) // handle last lap times
                        {
                            if(laptimesTotal != FinishTime)
                                lapTime = FinishTime - prevLapTime;
                            else
                                break;
                        }
                        else
                        {
                            lapTime = raceTime - laptimesTotal;
                        }

                        laptimesTotal += lapTime;

                        lapnumLabel[j] = new Label();
                        lapnumLabel[j].Location = new Point(12, 36 + (j + 1) * 13);
                        lapnumLabel[j].Text = "Lap " + (j + 1).ToString() + ":";
                        lapnumLabel[j].AutoSize = true;
                        Controls.Add(lapnumLabel[j]);

                        TimeSpan laptime = TimeSpan.FromMilliseconds(lapTime);
                        string lapTimeStr = string.Format("{0:D2}:{1:D2}:{2:D3}", laptime.Minutes, laptime.Seconds, laptime.Milliseconds);

                        laptimeLabel[j] = new Label();
                        laptimeLabel[j].Location = new Point(118, 36 + (j + 1) * 13);
                        laptimeLabel[j].Text = lapTimeStr;
                        laptimeLabel[j].AutoSize = true;                        
                        Controls.Add(laptimeLabel[j]);                        
                    }

                    TimeSpan t = TimeSpan.FromMilliseconds(FinishTime);
                    string str = string.Format("{0:D2}:{1:D2}:{2:D3}", t.Minutes, t.Seconds, t.Milliseconds);

                    label3.Text = str;
                    label4.Text = InputDataLength.ToString();
                    label8.Text = C.ECharIDstrTable[IDs[0]];
                    label9.Text = C.ECharIDstrTable[IDs[1]];
                    label10.Text = C.EKartIDstrTable[IDs[2]];
                    label11.Text = C.GetCourseID(IDs[3]);
                    label17.Text = tag;
                }
                else // inputdata array (.bin file), useful for when i forget to enable ghost saving
                {                    
                    startReadPos = 0;
                    endReadPos =  file.Length;
                }

                for (int i = 0; i < endReadPos; i += 2)
                {
                    byte[] Inputs = file.Skip(startReadPos + i).Take(2).ToArray();
                    byte Stick = Inputs[0];
                    byte ABLR = Inputs[1];

                    dataGridView1.Rows.Add(i / 2
                        , C.ConvertAnalogX(Stick, out byte originX) + " (" + originX + ")"
                        , C.ConvertAnalogY(Stick, out byte originY) + " (" + originY + ")"
                        , C.checkIfAPressed(ABLR)
                        , C.checkIfBPressed(ABLR)
                        , C.checkIfRPressed(ABLR)
                        , C.checkIfLPressed(ABLR)
                        , C.checkIfXPressed(ABLR)
                        , C.checkIfZPressed(ABLR));
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConverterFunctions C = new ConverterFunctions();
            byte[] file = File.ReadAllBytes(openFileDialog1.FileName);
            string path = @"mkdd_input_reader_ghost.lua";
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("local mkdd_input_reader_ghost = { -- { StickX(converted), StickY(converted), A, B, R, L, X, Z}");
                for (int i = 0; i < endReadPos; i += 2)
                {
                    byte[] Inputs = file.Skip(startReadPos + i).Take( 2).ToArray();
                    byte Stick = Inputs[0];
                    byte ABLR = Inputs[1];

                    sw.WriteLine("{"
                    + C.ConvertAnalogX(Stick, out byte originX2) + ", "
                    + C.ConvertAnalogY(Stick, out byte originY2) + ", "
                    + C.checkIfAPressed(ABLR) + ", "
                    + C.checkIfBPressed(ABLR) + ", "
                    + C.checkIfRPressed(ABLR) + ", "
                    + C.checkIfLPressed(ABLR) + ", "
                    + C.checkIfXPressed(ABLR) + ", "
                    + C.checkIfZPressed(ABLR) + "},");
                }
                sw.WriteLine("}\nreturn mkdd_input_reader_ghost");
            }
            MessageBox.Show("Succesfully saved to " + path);
        }
    }
}
