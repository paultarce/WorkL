﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge;
using System.Threading;

namespace BoardApp
{
    public partial class BoardAppMain : Form
    {

        private FilterInfoCollection VideoCaptureDevices;
        private VideoCaptureDevice FinalVideo;
        private int pictureNr;

        public BoardAppMain()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(1000);

            InitializeComponent();
            t.Abort();

            #region  Get attached cameras
            VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach(FilterInfo VideoCaptureDevice in VideoCaptureDevices)
            {
                cbAttachedCameras.Items.Add(VideoCaptureDevice.Name);
            }
            cbAttachedCameras.SelectedIndex = 0;
            #endregion

            #region Get supported modes
            FinalVideo = new VideoCaptureDevice(VideoCaptureDevices[cbAttachedCameras.SelectedIndex].MonikerString);
            foreach(var capability in FinalVideo.VideoCapabilities)
            {
                cbSupportedModes.Items.Add(capability.FrameSize.ToString() + ":" + capability.MaximumFrameRate.ToString() + ":" + capability.BitCount.ToString());

            }

            cbSupportedModes.SelectedIndex = 0;

            #endregion
            FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
            
        }

        private void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if(liveCamera.Image != null)
            {
                liveCamera.Image.Dispose();
            }
            Bitmap tempBitmap = (Bitmap)eventArgs.Frame.Clone();
            liveCamera.Image = tempBitmap;
            
        }

        private void BoardAppMain_Load(object sender, EventArgs e)
        {
            pictureNr = 0;
            btnOpenImages.Enabled = false;
            btnPlay.Enabled = false;
            btnStop.Enabled = false;
            btnSaveImage.Enabled = false;
        }

        public void StartForm()
        {
            Application.Run(new SpashScreen());

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            FinalVideo.Stop();
            FinalVideo.VideoResolution = FinalVideo.VideoCapabilities[cbSupportedModes.SelectedIndex];

            this.Width = FinalVideo.VideoResolution.FrameSize.Width + 40;
            this.Height = FinalVideo.VideoResolution.FrameSize.Height + 70;

            this.liveCamera.Width = FinalVideo.VideoResolution.FrameSize.Width;
            this.liveCamera.Height = FinalVideo.VideoResolution.FrameSize.Height;
            FinalVideo.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            pictureBox.Image = liveCamera.Image ;
            FinalVideo.Stop();
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap b = new Bitmap("Poza");
            }
            catch
            {

            }
        }

        private void rbDisplayMode_CheckedChanged(object sender, EventArgs e)
        {
           // rbCaptureMode.Enabled = false;
            
            btnPlay.Enabled = false;
            btnStop.Enabled = false;
            btnOpenImages.Enabled = true;
            btnSaveImage.Enabled = false;

        }

        private void rbCaptureMode_CheckedChanged(object sender, EventArgs e)
        {
            btnPlay.Enabled = true;
            btnStop.Enabled = true;
            btnOpenImages.Enabled = false;
            btnSaveImage.Enabled = true;
        }

        private void btnOpenImages_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if(result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string path = fbd.SelectedPath;
                }
            }
           
        }
    }
}
