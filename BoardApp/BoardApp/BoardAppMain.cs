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
using System.Threading;
using System.IO;

namespace BoardApp
{
    public partial class BoardAppMain : Form
    {

        private FilterInfoCollection VideoCaptureDevices;
        private VideoCaptureDevice FinalVideo;
        private int pictureNr;
        private FullScreenForm f;

        public BoardAppMain()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(1000);

            InitializeComponent();
            t.Abort();

            #region  Get attached cameras
            VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo VideoCaptureDevice in VideoCaptureDevices)
            {
                cbAttachedCameras.Items.Add(VideoCaptureDevice.Name);
            }
            cbAttachedCameras.SelectedIndex = 0;
            #endregion

            #region Get supported modes
            FinalVideo = new VideoCaptureDevice(VideoCaptureDevices[cbAttachedCameras.SelectedIndex].MonikerString);
            foreach (var capability in FinalVideo.VideoCapabilities)
            {
                cbSupportedModes.Items.Add(capability.FrameSize.ToString() + ":" + capability.MaximumFrameRate.ToString() + ":" + capability.BitCount.ToString());

            }

            cbSupportedModes.SelectedIndex = 0;

            #endregion
            FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);

            f = new FullScreenForm();
        }

        private void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (liveCamera.Image != null)
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
            btnDeletePict.Enabled = false;

        }

        public void StartForm()
        {
            Application.Run(new SpashScreen());

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            FinalVideo.Stop();
            FinalVideo.VideoResolution = FinalVideo.VideoCapabilities[cbSupportedModes.SelectedIndex];

            //this.Width = FinalVideo.VideoResolution.FrameSize.Width + 140;
            //this.Height = FinalVideo.VideoResolution.FrameSize.Height + 100;
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            this.liveCamera.Width = FinalVideo.VideoResolution.FrameSize.Width;
            this.liveCamera.Height = FinalVideo.VideoResolution.FrameSize.Height;
            FinalVideo.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //pictureBox.Image.Dispose();
            //this.ClearPictureBox();

            //    pictureBox.Image = liveCamera.Image;
            //FinalVideo.Stop();
            Bitmap b = new Bitmap(liveCamera.Image);
            pictureBox.Image = b;
            flowLayoutPanel1.Controls.Add(pictureBox);
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            try
            {
                //Bitmap b = new Bitmap("Poza");
                Bitmap b = new Bitmap(pictureBox.Image);
                Graphics gr = Graphics.FromImage(b);
                pictureBox.Image = b;
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
            // open DialogBox to enter the name of the lecture

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
            /* foreach (Control control in flowLayoutPanel1.Controls)
             {
                 flowLayoutPanel1.Controls.Remove(control);
                 control.Dispose();

             }*/
            flowLayoutPanel1.Controls.Clear();
            //flowLayou
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = @"D:\cursuri\LICENTA\WorkL\BoardApp\PhotoRepo";
                DialogResult result = fbd.ShowDialog();
                //fbd.RootFolder = @"D:\cursuri\LICENTA\WorkL\BoardApp\PhotoRepo";

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    fbd.Description = "Select the lecture folder";
                    string path = fbd.SelectedPath;


                    foreach (string file in Directory.EnumerateFiles(path, "*.jpg"))
                    {
                        PictureBox myPict = new PictureBox(); //dinamicly created control
                        //pictureBox.Image = Bitmap.FromFile(file);

                        myPict.Name = "Pict";
                        myPict.SetBounds(0, 0, 80, 80);
                        myPict.BackColor = Color.Black;
                        myPict.SizeMode = PictureBoxSizeMode.Zoom;
                        myPict.Image = Bitmap.FromFile(file);

                        flowLayoutPanel1.AutoScroll = true;
                        flowLayoutPanel1.Controls.Add(myPict);

                        myPict.Click += MyPict_Click;
                    }

                }
            }

        }
        //"sender" -> PictureBox 
        private void MyPict_Click(object sender, EventArgs e)
        {
            //  flowLayoutPanel1.BorderStyle = BorderStyle.Fixed3D;
            //pictureBox.SizeMode = PictureBox.Au
            //  pictureBox = (PictureBox)sender;
            ///  foreach (var picture in flowLayoutPanel1.Controls)
            // {
            var myPicture = (PictureBox)sender;
            //myPicture.BorderStyle = BorderStyle.Fixed3D;
            pictureBox.SetBounds(0, 0, 300, 300);
            pictureBox.BackColor = Color.Black;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            label5.Text = myPicture.Name;
            pictureBox.Image = myPicture.Image;
            //  }
        }

        private void ClearPictureBox()
        {
            //pict.Image = null;
            if (pictureBox.Image != null)
            {
                pictureBox.Image.Dispose();
                //pict.Image = null;
                pictureBox = new PictureBox();
            }
        }

        private void BoardAppMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            FinalVideo.Stop();
            Application.Exit();
        }

        private void BoardAppMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (pictureBox.Image != null)
            {
                if (e.KeyChar >= 48 && e.KeyChar <= 57) // numeric
                {

                }
                if (e.KeyChar == (char)Keys.F || e.KeyChar == char.ToLower((char)Keys.F))
                {
                    f.Close();
                    f = new FullScreenForm();
                    Screen[] screens = Screen.AllScreens;
                    Rectangle bounds = screens[0].Bounds;
                    f.SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);

                    //f.pb.SetBounds(0, 0, 300, 300);
                    f.pb.BackColor = Color.Black;
                    f.pb.SizeMode = PictureBoxSizeMode.StretchImage;

                    f.pb.Image = pictureBox.Image;
                    f.Show(); ///Close after showing once
                }              
            }
            else
            {
                MessageBox.Show("No picture to display", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if(flowLayoutPanel1.Controls.Count > 0)
            {
                if(e.KeyChar == (char)Keys.Right)
                {

                }
                if(e.KeyChar == (char)Keys.Left)
                {

                }
                
            }
        }
    }
}
