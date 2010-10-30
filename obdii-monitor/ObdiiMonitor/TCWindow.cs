﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ObdiiMonitor
{
    public partial class TCWindow : Form
    {
        private Controller controller;
        private string Codes = "00";
        
        internal Controller Controller
        {
            set { controller = value; }
        }

        public TCWindow()
        {
            InitializeComponent();

        }
        public void Set_Data(string data)
        {
            bool added = false;
            for(int j=0;j<Codes.Length;j=j+2)
            {
                if (data[0] == Codes[j] && data[1] == Codes[j + 1])
                    added = true;
            }
            if (!added)
            {
                Codes += data;
                string outdata = "";
                for (int i = 0; i < data.Length; i = i + 2)
                {
                    if (data[i] != 0 || data[i] != 0)
                    {
                        switch (data[i])
                        {
                            case '0':
                                outdata = "P0";
                                break;
                            case '1':
                                outdata = "P1";
                                break;
                            case '2':
                                outdata = "P2";
                                break;
                            case '3':
                                outdata = "P3";
                                break;
                            case '4':
                                outdata = "C0";
                                break;
                            case '5':
                                outdata = "C1";
                                break;
                            case '6':
                                outdata = "C2";
                                break;
                            case '7':
                                outdata = "C3";
                                break;
                            case '8':
                                outdata = "B0";
                                break;
                            case '9':
                                outdata = "B1";
                                break;
                            case 'A':
                                outdata = "B2";
                                break;
                            case 'B':
                                outdata = "B3";
                                break;
                            case 'C':
                                outdata = "U0";
                                break;
                            case 'D':
                                outdata = "U1";
                                break;
                            case 'E':
                                outdata = "U2";
                                break;
                            case 'F':
                                outdata = "U3";
                                break;
                        }
                        outdata += data[i + 1].ToString();

                        DataGridViewTextBoxCell dgvCell = new DataGridViewTextBoxCell();
                        dgvCell.Value = outdata;
                        dataGridView1.Rows.Add(dgvCell.Value);
                        // outdata=data;


                    }
                }
            }

        }
        private void btnget_Click(object sender, EventArgs e)
        {
            Set_Data("0605");
            /*    controller.SensorData.clearPollResponses();
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                controller.Serial.sendCommand("0101\r");
                bool stopTrying = false, response = false;
                DateTime time = DateTime.Now;
                while (!stopTrying && !response)
                {
                    try
                    {
                        string buffer = controller.Serial.dataReceived();
                        if (buffer.Length > 0 && buffer[0] == '>')
                        {
                            response = true;
                            controller.SensorData.parseData(buffer, (int)stopWatch.ElapsedMilliseconds);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (DateTime.Now.Subtract(time) > new TimeSpan(12000000))
                        {
                            stopTrying = true;
                        }
                    }
                }*/
        }
    }
}