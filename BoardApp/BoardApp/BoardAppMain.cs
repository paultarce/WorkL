using System;
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

namespace BoardApp
{
    public partial class BoardAppMain : Form
    {

        private FilterInfoCollection VideoCaptureDevices;
        private VideoCaptureDevice FinalVideo;

        public BoardAppMain()
        {
            InitializeComponent();

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
            if(pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
            Bitmap tempBitmap = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = tempBitmap;
        }

        private void BoardAppMain_Load(object sender, EventArgs e)
        {

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            FinalVideo.VideoResolution = FinalVideo.VideoCapabilities[cbSupportedModes.SelectedIndex];

            this.Width = FinalVideo.VideoResolution.FrameSize.Height + 70;
            this.Height = FinalVideo.VideoResolution.FrameSize.Height + 70;

            this.pictureBox1.Width = FinalVideo.VideoResolution.FrameSize.Width;
            this.pictureBox1.Height = FinalVideo.VideoResolution.FrameSize.Height;
            FinalVideo.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            FinalVideo.Stop();
        }
    }
}
