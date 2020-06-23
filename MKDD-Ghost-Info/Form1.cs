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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Saved Ghost Data|*.gci;*.ght|Input Data only|*.bin";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.Rows.Clear();
                if (openFileDialog1.FileName.ToString().EndsWith(".gci"))
                {
                    ConverterFunctions C = new ConverterFunctions();
                    byte[] InputDataLengthArray = File.ReadAllBytes(openFileDialog1.FileName).Skip(0x148E).Take(2).ToArray();
                    ushort InputDataLength = BitConverter.ToUInt16(new byte[2] { InputDataLengthArray[1], InputDataLengthArray[0] }, 0);
                    int Length = InputDataLength * 2;
                    byte[] FinishTime = File.ReadAllBytes(openFileDialog1.FileName).Skip(0x146B).Take(8).ToArray();
                    var str = Encoding.Default.GetString(FinishTime);
                    byte[] IDs = File.ReadAllBytes(openFileDialog1.FileName).Skip(0x1480).Take(4).ToArray();                    
                    string path = @"mkdd_input_reader_ghost.lua";
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("local mkdd_input_reader_ghost = { -- { StickX(converted), StickY(converted), A, B, R, L, X, Z}");
                        for (int i = 0; i <= Length; i += 2)
                        {
                            byte[] Inputs = File.ReadAllBytes(openFileDialog1.FileName).Skip(0x14A8 + i).Take(2).ToArray();
                            var AnalogStickY = (Inputs[0] & 7);
                            var AnalogStickX = Inputs[0] - AnalogStickY;
                            byte ABLR = Inputs[1];
                            dataGridView1.Rows.Add(i / 2
                                , C.ConvertAnalogX(AnalogStickX)
                                , C.ConvertAnalogY(AnalogStickY)
                                , C.checkIfAPressed(Inputs[1])
                                , C.checkIfBPressed(Inputs[1])
                                , C.checkIfRPressed(Inputs[1])
                                , C.checkIfLPressed(Inputs[1])
                                , C.checkIfXPressed(Inputs[1])
                                , C.checkIfZPressed(Inputs[1]));

                            sw.WriteLine("{"
                            + C.ConvertAnalogX(AnalogStickX) + ", "
                            + C.ConvertAnalogY(AnalogStickY) + ", "
                            + C.checkIfAPressed(Inputs[1]) + ", "
                            + C.checkIfBPressed(Inputs[1]) + ", "
                            + C.checkIfRPressed(Inputs[1]) + ", "
                            + C.checkIfLPressed(Inputs[1]) + ", "
                            + C.checkIfXPressed(Inputs[1]) + ", "
                            + C.checkIfZPressed(Inputs[1]) + "},");
                        }
                        sw.WriteLine("}\nreturn mkdd_input_reader_ghost");
                    }
                    label3.Text = str;
                    label4.Text = InputDataLength.ToString();
                    label8.Text = C.GetCharInfo(IDs[0]);
                    label9.Text = C.GetCharInfo(IDs[1]);
                    label10.Text = C.GetKartID(IDs[2]);
                    label11.Text = C.GetCourseID(IDs[3]);
                }
                else if (openFileDialog1.FileName.ToString().EndsWith(".ght"))
                {                    
                        ConverterFunctions C = new ConverterFunctions();
                        byte[] InputDataLengthArray = File.ReadAllBytes(openFileDialog1.FileName).Skip(0xE).Take(2).ToArray();
                        ushort InputDataLength = BitConverter.ToUInt16(new byte[2] { InputDataLengthArray[1], InputDataLengthArray[0] }, 0);
                        int Length = InputDataLength * 2;
                        byte[] FinishTimeArray = File.ReadAllBytes(openFileDialog1.FileName).Skip(0x8).Take(4).ToArray();
                        uint FinishTime = BitConverter.ToUInt32(new byte[4] { FinishTimeArray[3], FinishTimeArray[2], FinishTimeArray[1], FinishTimeArray[0] }, 0);
                        TimeSpan t = TimeSpan.FromMilliseconds(FinishTime);
                        string str = string.Format("{0:D2}:{1:D2}:{2:D3}", t.Minutes, t.Seconds, t.Milliseconds);
                        byte[] IDs = File.ReadAllBytes(openFileDialog1.FileName).Skip(0x0).Take(4).ToArray();
                        string path = @"mkdd_input_reader_ghost.lua";
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine("local mkdd_input_reader_ghost = { -- { StickX(converted), StickY(converted), A, B, R, L, X, Z}");
                            for (int i = 0; i <= Length; i += 2)
                            {
                                byte[] Inputs = File.ReadAllBytes(openFileDialog1.FileName).Skip(0x28 + i).Take(2).ToArray();
                                var AnalogStickY = (Inputs[0] & 7);
                                var AnalogStickX = Inputs[0] - AnalogStickY;
                                byte ABLR = Inputs[1];
                            dataGridView1.Rows.Add(i / 2
                                , C.ConvertAnalogX(AnalogStickX)
                                , C.ConvertAnalogY(AnalogStickY)
                                , C.checkIfAPressed(Inputs[1])
                                , C.checkIfBPressed(Inputs[1])
                                , C.checkIfRPressed(Inputs[1])
                                , C.checkIfLPressed(Inputs[1])
                                , C.checkIfXPressed(Inputs[1])
                                , C.checkIfZPressed(Inputs[1]));

                            sw.WriteLine("{"
                            + C.ConvertAnalogX(AnalogStickX) + ", "
                            + C.ConvertAnalogY(AnalogStickY) + ", "
                            + C.checkIfAPressed(Inputs[1]) + ", "
                            + C.checkIfBPressed(Inputs[1]) + ", "
                            + C.checkIfRPressed(Inputs[1]) + ", "
                            + C.checkIfLPressed(Inputs[1]) + ", "
                            + C.checkIfXPressed(Inputs[1]) + ", "
                            + C.checkIfZPressed(Inputs[1]) + "},");
                        }
                            sw.WriteLine("}\nreturn mkdd_input_reader_ghost");
                        }
                        label3.Text = str;
                        label4.Text = InputDataLength.ToString();
                        label8.Text = C.GetCharInfo(IDs[0]);
                        label9.Text = C.GetCharInfo(IDs[1]);
                        label10.Text = C.GetKartID(IDs[2]);
                        label11.Text = C.GetCourseID(IDs[3]);
                }
                else // inputdata array (.bin file), useful for when i forget to enable ghost saving
                {
                    ConverterFunctions C = new ConverterFunctions();
                    string path = @"mkdd_input_reader_ghost.lua";
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("local mkdd_input_reader_ghost = { -- { StickX(converted), StickY(converted), A, B, R, L, X, Z}");
                        for (int i = 0; i < File.ReadAllBytes(openFileDialog1.FileName).Length; i += 2)
                        {
                            byte[] Inputs = File.ReadAllBytes(openFileDialog1.FileName).Skip(i).Take(2).ToArray();
                            var AnalogStickY = (Inputs[0] & 7);
                            var AnalogStickX = Inputs[0] - AnalogStickY;
                            byte ABLR = Inputs[1];
                            dataGridView1.Rows.Add(i / 2
                                , C.ConvertAnalogX(AnalogStickX)
                                , C.ConvertAnalogY(AnalogStickY)
                                , C.checkIfAPressed(Inputs[1])
                                , C.checkIfBPressed(Inputs[1])
                                , C.checkIfRPressed(Inputs[1])
                                , C.checkIfLPressed(Inputs[1])
                                , C.checkIfXPressed(Inputs[1])
                                , C.checkIfZPressed(Inputs[1]));

                            sw.WriteLine("{"
                            + C.ConvertAnalogX(AnalogStickX) + ", "
                            + C.ConvertAnalogY(AnalogStickY) + ", "
                            + C.checkIfAPressed(Inputs[1]) + ", "
                            + C.checkIfBPressed(Inputs[1]) + ", "
                            + C.checkIfRPressed(Inputs[1]) + ", "
                            + C.checkIfLPressed(Inputs[1]) + ", "
                            + C.checkIfXPressed(Inputs[1]) + ", "
                            + C.checkIfZPressed(Inputs[1]) + "},");
                        }
                        sw.WriteLine("}\nreturn mkdd_input_reader_ghost");
                    }
                }


            }
            else
            {
                
            }
        }
    }
}
