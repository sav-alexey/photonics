using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Controls;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Vision;



namespace Airyscan
{
    public partial class Form1 : Form
    {
        FilterInfoCollection videoDevices;
        public Form1()
        {
            InitializeComponent();
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            for (int i = 1, n = videoDevices.Count; i <= n; i++)
            {
                string cameraName = i + " : " + videoDevices[i - 1].Name;

                comboBox1.Items.Add(cameraName);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {            
            StartCameras();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCameras();
        }

        private void StopCameras()
        {
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1.WaitForStop();
        }

        private void StartCameras()
        {
            try
            {

                VideoCaptureDevice videoSource1 = new VideoCaptureDevice(videoDevices[comboBox1.SelectedIndex].MonikerString);
                videoSourcePlayer1.VideoSource = videoSource1;
                videoSourcePlayer1.Start();
            }
            catch { MessageBox.Show("Выберете камеру"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StopCameras();
        }
    }
}
