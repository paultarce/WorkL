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
using AForge.Imaging.Filters;
using AForge;
using System.Threading;
using System.IO;
using BoardApp.Exceptions_Algorithms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Forms.Integration;
using BoardApp.ImageProcessAlgo;

using Emgu.CV;
using Emgu.CV.Structure;
using System.Windows.Media.Imaging;
using System.IO.Ports;
using BoardApp.SecondaryForms;
using System.IO.Compression;

namespace BoardApp
{
    public partial class BoardAppMain : Form
    {

        private FilterInfoCollection VideoCaptureDevices;
        private VideoCaptureDevice FinalVideo;
        private int pictureNr;
        private FullScreenForm f;
        public List<PictureBox> flpPictureList; // to dispaly a flowLayoutPanel in tab2
        private int pictPosition = 0;
        FullScreenWPF.MainWindow wpfwindow;
        CustomMessageBox messageBox;
        Image prevImage;
        //public var wpfwindow;
        //private Crop c;


        public BoardAppMain()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(1000);

            InitializeComponent();
            t.Abort();

            this.BringToFront();

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

            flpPictureList = new List<PictureBox>();
            f = new FullScreenForm();
            f.pb.BackColor = Color.Black;
            f.BackColor = Color.Black;

            PictureBox pict = new PictureBox();
            pict.BackColor = Color.Black;
            PictureEditor.ShowPictureFullSreen2(ref f, ref pict);
            btnSendEmail.Enabled = false;

            messageBox = new CustomMessageBox();

        }

        private void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (liveCamera.Image != null)
            {
                liveCamera.Image.Dispose();
            }
            Bitmap tempBitmap = (Bitmap)eventArgs.Frame.Clone();
            liveCamera.SizeMode = PictureBoxSizeMode.StretchImage;
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

            tbResize1.Value = pbEditPhoto.Size.Width;
            tbResizeVer.Value = pbEditPhoto.Size.Height;

            //pbEditPhoto.Left = (this.ClientSize.Width - pbEditPhoto.Width) / 1;
            //pbEditPhoto.Top = (this.ClientSize.Height - pbEditPhoto.Height) / 1;

            prevImage = Image.FromFile(@"C:\Users\Paul\Desktop\Untitled.png");

            for (int k = 1; k < 360; k++)
            {
                cbGrade.Items.Add(k);
            }
            cbGrade.SelectedIndex = 0;

            wpfwindow = new FullScreenWPF.MainWindow();
            ElementHost.EnableModelessKeyboardInterop(wpfwindow);
            wpfwindow.Show();
        }

        public void StartForm()
        {
            Application.Run(new SpashScreen());
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {

            FinalVideo.Stop();
            FinalVideo.VideoResolution = FinalVideo.VideoCapabilities[cbSupportedModes.SelectedIndex];

            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            this.btnStop.Enabled = true;

            this.liveCamera.Width = FinalVideo.VideoResolution.FrameSize.Width;
            this.liveCamera.Height = FinalVideo.VideoResolution.FrameSize.Height;
            FinalVideo.Start();
        }

        private void cbAttachedCameras_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //cbAttachedCameras.Items.Clear();
            cbSupportedModes.Items.Clear();
            FinalVideo.Stop();
            
            //FinalVideo.

            #region Get supported modes
            FinalVideo = new VideoCaptureDevice(VideoCaptureDevices[cbAttachedCameras.SelectedIndex].MonikerString);
            foreach (var capability in FinalVideo.VideoCapabilities)
            {
                cbSupportedModes.Items.Add(capability.FrameSize.ToString() + ":" + capability.MaximumFrameRate.ToString() + ":" + capability.BitCount.ToString());

            }

            cbSupportedModes.SelectedIndex = 0;
            #endregion
            FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
        }


        private void btnStop_Click(object sender, EventArgs e)
        {

            try
            {
                Bitmap b = new Bitmap(liveCamera.Image);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Image = b;
                //prevImage = pictureBox.Image;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Va rugam asteptati pornirea camerei foto", "Asteptati", MessageBoxButtons.OK, MessageBoxIcon.Stop);
               // ShowMessageBox("System is Busy. Try again!");
                
            }

        }



        private void rbDisplayMode_CheckedChanged(object sender, EventArgs e)
        {
            btnPlay.Enabled = false;
            btnStop.Enabled = false;
            btnOpenImages.Enabled = true;
            btnSaveImage.Enabled = false;

        }

        private void rbCaptureMode_CheckedChanged(object sender, EventArgs e)
        {
            btnPlay.Enabled = true;
            //btnStop.Enabled = true;
            btnOpenImages.Enabled = false;
            //btnSaveImage.Enabled = true;
        }

        private void btnOpenImages_Click(object sender, EventArgs e)
        {

            flowLayoutPanel1.Controls.Clear();
            //flowLayou
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = @"D:\cursuri\LICENTA\WorkL\BoardApp\PhotoRepo2";
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
                        flpPictureList.Add(myPict);

                        myPict.Click += MyPict_Click;
                    }

                }
            }

        }
        //"sender" -> PictureBox 
        Image imageClone;
        private void MyPict_Click(object sender, EventArgs e)
        {
            var myPicture = (PictureBox)sender;
            //myPicture.BorderStyle = BorderStyle.Fixed3D;
            pictureBox.SetBounds(0, 0, 300, 300);
            pictureBox.BackColor = Color.Black;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            label5.Text = myPicture.Name;
            pictureBox.Image = myPicture.Image;
            pictureNr = flowLayoutPanel1.Controls.GetChildIndex((PictureBox)sender);

            pict = CopyControl.Clone(pictureBox);
            imageClone = new Bitmap((Image)myPicture.Image.Clone());

            //  }
        }

        private void ClearPictureBox()
        {
            if (pictureBox.Image != null)
            {
                pictureBox.Image.Dispose();
                pictureBox = new PictureBox();
            }
        }

        private void BoardAppMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            FinalVideo.Stop();
            Application.Exit();
        }

        private void FullScreenDisplay()
        {
            pictureBox.SetBounds(0, 0, 300, 300);
            pictureBox.BackColor = Color.Black;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            label5.Text = flowLayoutPanel1.Controls[pictureNr].Name;
            pictureBox.Image = ((PictureBox)flowLayoutPanel1.Controls[pictureNr]).Image;
        }

        private void tabPage1_Enter(object sender, EventArgs e) // clone control
        {

            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.Controls.Clear();

            foreach (PictureBox pict in flowLayoutPanel1.Controls)
            {
                PictureBox p = pict.CreateNewWithAttribute();
                PictureBox p2 = PictureEditor.PictBoxTOflowLayout(p);
                flowLayoutPanel2.Controls.Add(p2);
            }
            pbEditPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            pbEditPhoto.Image = pictureBox.Image;
            if (pbEditPhoto.Image != null)
            {
                tbResize1.Enabled = true;
                tbRotate.Enabled = true;
                tbResizeVer.Enabled = true;
            }


            tbResize1.Value = pbEditPhoto.Width;
            tbResizeVer.Value = pbEditPhoto.Height;
            tbZoom.Value = 0;

            this.pbEditPhoto.MouseWheel += PbEditPhoto_MouseWheel;


            if (!serialPort1.IsOpen)
            {
                string[] ArrayComPortsNames = null;
                ArrayComPortsNames = SerialPort.GetPortNames();

                cbPorts.Items.Clear();
                int i = 0;
                foreach (string portName in ArrayComPortsNames)
                {
                    if (portName == "COM7")
                    {
                        cbPorts.Items.Add("Bluetooth Telefon");
                        cbPorts.SelectedIndex = 0;
                        serialPort1.PortName = "COM7";
                    }
                    else
                    {
                        cbPorts.Items.Add(portName);
                        cbPorts.SelectedIndex = i;
                        serialPort1.PortName = cbPorts.Text;
                    }
                    i++;

                }
                serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(DataReceived);

            }
            //serialPort1.PortName = cbPorts.Text;
        }



        #region KEYS PRESSED
        private void BoardAppMain_KeyPress(object sender, KeyPressEventArgs e)
        {

            double grades = 1;
            try { grades = Convert.ToDouble(cbGrade.SelectedItem.ToString()); }
            catch (Exception ex) { grades = 1; }


            if (e.KeyChar == '2')
            {
                wpfwindow.MoveDown(1);
            }
            if (e.KeyChar == '8')
            {
                wpfwindow.MoveUp(1);
            }
            if (e.KeyChar == '4')
            {
                wpfwindow.MoveLeft(1);
            }
            if (e.KeyChar == '6')
            {
                wpfwindow.MoveRight(1);
            }
            if (e.KeyChar == '+')
            {
                if (wpfwindow.btS != null)
                    wpfwindow.ZoomIn(1);
            }
            if (e.KeyChar == '-')
            {
                if (wpfwindow.btS != null)
                    wpfwindow.ZoomOut(1);
            }
            if (e.KeyChar == '9')
            {
                wpfwindow.RotateRight(grades);
            }
            if (e.KeyChar == '7')
            {
                wpfwindow.RotateLeft(grades);
            }
        }


        /* private void BoardAppMain_KeyPress(object sender, KeyPressEventArgs e)
         {
             // C - TAKE PICTURE 
             if (liveCamera.Image != null)
             {
                 if (e.KeyChar == (char)Keys.C || e.KeyChar == char.ToLower((char)Keys.C))
                 {
                     btnStop_Click(sender, e);
                 }
             }
             else {// MessageBox.Show("Camera foto nu a fost pornita!", "Atentie"); 
             }

             if (e.KeyChar == (char)Keys.F || e.KeyChar == char.ToLower((char)Keys.F))
             {
                 if (pictureBox.Image != null)
                 {
                     //PictureEditor.ShowPictureFullSreen2(ref f, ref pictureBox); //to update "this" controls 
                     //this.BringToFront();
                     BitmapSource btS = FormImageToWpfcs.BitmapFromBase64(FormImageToWpfcs.BitmapToBase64String(pictureBox.Image));
                     pbCrop.Image = BitmapFromSource(btS);
                     wpfwindow = new FullScreenWPF.MainWindow(btS);
                     ElementHost.EnableModelessKeyboardInterop(wpfwindow);
                     wpfwindow.Show();

                 }
                 else
                 {
                     MessageBox.Show("No picture to display", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 }

                 /*         if (pbEditPhoto.Image != null || pictureBox.Image != null)
                          {
                              tabControl1.SelectedIndex = 1;

                              PictureEditor.ShowPictureFullSreen2(ref f, ref pbEditPhoto);
                              imageOriginal = f.pb.Image;
                              imageOriginal2 = pbEditPhoto.Image;
                          }
                      }


             }



         }*/

        private void BoardAppMain_KeyDown(object sender, KeyEventArgs e)
        {

            if (wpfwindow.IsLoaded == true && e.KeyCode == Keys.Escape)
            {
                Key_Up(e.KeyCode);
            }

        }

        private void Key_Up(Keys k)
        {
            if (k == Keys.C)
            {
                if (liveCamera.Image != null)
                {
                    btnStop_Click(null, null);
                    //MyPict_Click(null,null)
                }
                else
                {
                    //MessageBox.Show("Camera foto nu a fost pornita!", "Atentie");
                    ShowMessageBox("The photo Camera was not started!");
                    
                }
            }

            if (k == Keys.F)
            {
                if (pictureBox.Image != null)
                {
                    this.ShowWpfLogic();
                }
                else
                {
                    //MessageBox.Show("No picture to display", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ShowMessageBox("No picture to display!");
                }

            }

            if (k == Keys.S)
            {
                if (pictureBox.Image != null && !(prevImage == pictureBox.Image))
                {
                    PictureBox myPict = new PictureBox(); //dinamicly created control
                                                          //pictureBox.Image = Bitmap.FromFile(file);
                    myPict = PictureEditor.PictBoxTOflowLayout(myPict);

                    myPict.Image = pictureBox.Image;

                    flowLayoutPanel1.AutoScroll = true;
                    flowLayoutPanel1.Controls.Add(myPict);
                    myPict.Click += MyPict_Click;

                    prevImage = pictureBox.Image;

                    MyPict_Click(myPict, null);
                }
                else
                {
                    //MessageBox.Show("No picture to save or picture already saved", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ShowMessageBox("No picture to save or picture already saved");
                }

                if (flowLayoutPanel1.Controls.Count > 0)
                {
                    btnSaveImage.Enabled = true;
                    btnDeletePict.Enabled = true;
                }
            }

            if (k == Keys.D)
            {
                if (flowLayoutPanel1.Controls.Count > 0)
                {

                    int indexDelete = pictureNr;
                    DialogResult dialogResult = MessageBox.Show("Delete picture?", "Delete", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        flowLayoutPanel1.Controls.Remove(flowLayoutPanel1.Controls[pictureNr]);
                        //flowLayoutPanel1.Controls[pictureNr].Dispose();
                        if (pictureNr > 0)
                        {
                            pictureNr--;
                        }
                        if (flowLayoutPanel1.Controls.Count > 0)
                        {
                            pictureBox.Image = ((PictureBox)flowLayoutPanel1.Controls[pictureNr]).Image;
                            this.ShowWpfLogic();
                        }
                        if (flowLayoutPanel1.Controls.Count == 0)
                        {
                            wpfwindow.btS = null;
                            wpfwindow.INIT();
                            pictureBox.Image = null;
                        }

                        if (flowLayoutPanel1.Controls.Count <= 0)
                        {
                            btnSendEmail.Enabled = false;
                            btnSaveImage.Enabled = false;
                        }
                    }

                }
                else
                {
                    //MessageBox.Show("Nu exista poze in colectie", "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ShowMessageBox("Nu exista poze in colectie");
                }
            }

            if (k == Keys.NumPad1)
            {
                if (flowLayoutPanel1.Controls.Count > 1)
                {
                    if (pictureNr >= 1)
                    {
                        pictureNr--;
                        pictureBox.Image = ((PictureBox)flowLayoutPanel1.Controls[pictureNr]).Image;
                        this.ShowWpfLogic();

                    }
                }
            }

            if (k == Keys.NumPad3)
            {
                if (flowLayoutPanel1.Controls.Count > 1)
                {
                    if (pictureNr < flowLayoutPanel1.Controls.Count - 1)
                    {
                        pictureNr++;
                        pictureBox.Image = ((PictureBox)flowLayoutPanel1.Controls[pictureNr]).Image;
                        this.ShowWpfLogic();
                    }
                }
            }

            if (k == Keys.Escape)
            {
                if (wpfwindow.IsLoaded == true)
                {
                    if (k == Keys.Escape)
                    {
                        wpfwindow.btS = null;
                        wpfwindow.INIT();
                    }
                }
            }

        }

        private void BoardAppMain_KeyUp(object sender, KeyEventArgs e)
        {
            // C - TAKE PICTURE 

            Key_Up(e.KeyCode);

        }

        public void ShowWpfLogic()
        {
            //PictureEditor.ShowPictureFullSreen2(ref f, ref pictureBox); //to update "this" controls 
            //this.BringToFront();
            BitmapSource btS = FormImageToWpfcs.BitmapFromBase64(FormImageToWpfcs.BitmapToBase64String(pictureBox.Image));
            //pbCrop.Image = BitmapFromSource(btS);
            //wpfwindow = new FullScreenWPF.MainWindow(btS);
            //ElementHost.EnableModelessKeyboardInterop(wpfwindow);
            //wpfwindow.Show();
            if (wpfwindow.IsVisible != false)
            {
                // wpfwindow.NewImage();
                //wpfwindow.INIT();
                // wpfwindow.btS = btS;
                //wpfwindow.INIT();
                wpfwindow.Close();
                wpfwindow = new FullScreenWPF.MainWindow();
                ElementHost.EnableModelessKeyboardInterop(wpfwindow);
                wpfwindow.btS = btS;
                wpfwindow.Show();

                wpfwindow.INIT();
                this.BringToFront();
            }
            else
            {
                wpfwindow = new FullScreenWPF.MainWindow();
                ElementHost.EnableModelessKeyboardInterop(wpfwindow);
                wpfwindow.btS = btS;
                wpfwindow.Show();

                wpfwindow.INIT();
                this.BringToFront();
            }
        }
        #endregion

        #region CropRegion

        /*
        bool IsMouseDown = false;

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
            
            c.MouseDown(e);
            //c.GetRectangle();
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if(pictureBox.Image !=null)
            {
                
                if (IsMouseDown == true)
                {
                    c.MouseMove(e, ref pictureBox);

                }
            }
           
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            
            
            if(pictureBox.Image != null)
            {

                c.Paint(e);
                
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                c.MouseUp(e,ref IsMouseDown,ref pictureBox);
            }
        }*/
        #endregion

        #region CropRegion2

        Image<Bgr, byte> imgInput;
        Rectangle rect;
        Point StartLocation;
        Point EndLocation;
        bool IsMouseDown = false;



        /*private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (rbCropMode.Checked == true)
            {
                IsMouseDown = true;
                StartLocation = e.Location;
            }
        }*/

        /* private void pictureBox_MouseMove(object sender, MouseEventArgs e)
         {
             if (rbCropMode.Checked == true)
             {
                 if (IsMouseDown == true)
                 {
                     EndLocation = e.Location;
                     pictureBox.Invalidate();
                 }
             }
         }*/

        /*private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (rbCropMode.Checked == true)
            {
                if (IsMouseDown == true)
                {
                    EndLocation = e.Location;
                    IsMouseDown = false;
                    pictureBox.Image = null;
                    if (rect != null)
                    {
                        imgInput.ROI = rect;// region of interest
                        Image<Bgr, byte> temp = imgInput.CopyBlank();
                        imgInput.CopyTo(temp);
                        imgInput.ROI = Rectangle.Empty;
                        //pbCrop.Image = temp.Bitmap;
                        pictureBox.Image = temp.Bitmap;
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        //pbCrop.Image=PictureEditor.PictBoxTOflowLayout(pictureBox).Image;
                        //rbCropMode.Checked = false;
                    }
                }
            }
        }*/

        /* private void pictureBox_Paint(object sender, PaintEventArgs e)
         {
             if (rbCropMode.Checked == true)
             {

                 if (rect != null)
                 {
                     e.Graphics.DrawRectangle(Pens.Red, GetRectangle());
                 }
             }
         }*/
        /*public Rectangle GetRectangle()
        {
            rect = new Rectangle();
            rect.X = Math.Min(StartLocation.X, EndLocation.X); //pentru a putea desena dreptunghiul de crop in oricare directie
            rect.Y = Math.Min(StartLocation.Y, EndLocation.Y);
            rect.Width = Math.Abs(StartLocation.X - EndLocation.X);
            rect.Height = Math.Abs(StartLocation.Y - EndLocation.Y);

            return rect;
        }*/

        private void rbCropMode_CheckedChanged(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {

                pict = new PictureBox();
                pict = CopyControl.Clone(pictureBox);
            }
            else
            {
                MessageBox.Show("No picture in PictureBox!!");
                rbCaptureMode.Checked = false;
            }
        }


        #endregion

        #region CROP IMAGE - USED ONE

        private bool _selecting;
        private Rectangle _selection;
        PictureBox pict;
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {



            if (rbCropMode.Checked == true)
            {

                // Starting point of the selection:
                if (e.Button == MouseButtons.Left)
                {
                    _selecting = true;
                    _selection = new Rectangle(new Point(e.X, e.Y), new Size());
                }
            }
            else
            {
                MessageBox.Show("Please enter CROP MODE!", "Attention");

            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            // Update the actual size of the selection:
            if (_selecting)
            {
                _selection.Width = e.X - _selection.X;
                _selection.Height = e.Y - _selection.Y;

                // Redraw the picturebox:
                pictureBox.Refresh();
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (_selecting)
            {
                // Draw a rectangle displaying the current selection
                Pen pen = Pens.GreenYellow;
                e.Graphics.DrawRectangle(pen, _selection);
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _selecting && _selection.Size != new Size())
            {
                // Create cropped image:
                Image img = pictureBox.Image.Crop(_selection, pictureBox);

                //int factorX
                // Fit image to the picturebox:
                //pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                // pictureBox.Image = img.Fit2PictureBox(pictureBox);
                pictureBox.Image.Dispose();
                pictureBox.Image = new Bitmap(img);
                //pictureBox.Image = img;
                _selecting = false;



                if (flowLayoutPanel1.Controls.Count > 0)
                {
                    ((PictureBox)flowLayoutPanel1.Controls[pictureNr]).SetBounds(0, 0, 80, 80);
                    ((PictureBox)flowLayoutPanel1.Controls[pictureNr]).BackColor = Color.Black;
                    ((PictureBox)flowLayoutPanel1.Controls[pictureNr]).SizeMode = PictureBoxSizeMode.Zoom;
                    ((PictureBox)flowLayoutPanel1.Controls[pictureNr]).Image = null;
                    ((PictureBox)flowLayoutPanel1.Controls[pictureNr]).Image = new Bitmap(imageClone);
                }
            }
            else
                _selecting = false;
        }
        #endregion

        #region TAB2 TRACK BAR + ROTATE ZOOM region

        //int angle;


        private void tbResize1_Scroll(object sender, EventArgs e)
        {
            pbEditPhoto.Size = new Size(tbResize1.Value, pbEditPhoto.Size.Height);
            pbEditPhoto.Left = (this.ClientSize.Width - pbEditPhoto.Width) / 1;
            pbEditPhoto.Top = (this.ClientSize.Height - pbEditPhoto.Height) / 1;

            f.pb.Size = new Size(tbResize1.Value, f.pb.Size.Height);
            f.pb.Left = (f.ClientSize.Width - f.pb.Width) / 2;
            f.pb.Top = (f.ClientSize.Height - f.pb.Height) / 2;
        }

        private void tbResizeVer_Scroll(object sender, EventArgs e)
        {
            pbEditPhoto.Size = new Size(pbEditPhoto.Size.Width, tbResizeVer.Value);
            pbEditPhoto.Left = (this.ClientSize.Width - pbEditPhoto.Width) / 1;
            pbEditPhoto.Top = (this.ClientSize.Height - pbEditPhoto.Height) / 1;

            f.pb.Size = new Size(f.pb.Size.Width, tbResizeVer.Value);
            f.pb.Left = (f.ClientSize.Width - f.pb.Width) / 1;
            f.pb.Top = (f.ClientSize.Height - f.pb.Height) / 1;
        }

        private void tbRotate_Scroll(object sender, EventArgs e)
        {
            Bitmap image = (Bitmap)pictureBox.Image;
            Bitmap a = AForge.Imaging.Image.Clone(image, PixelFormat.Format24bppRgb);  //convert your image to 8bpp and grayscale
            //AForge.Imaging.Image.SetGrayscalePalette(a);                   
            RotateBilinear ro = new RotateBilinear(tbRotate.Value, true);
            Bitmap image2 = ro.Apply(a);
            pbEditPhoto.Image = image2;

            PictureEditor.TbRotate(ref f, pbEditPhoto, tbRotate.Value);
        }

        Image imageOriginal, imageOriginal2; // imageOriginal -> for secondary screen image ...imageOriginal2 - for pbEditPhoto image
        float value = 1;
        private void tbZoom_Scroll(object sender, EventArgs e)
        {
            /* if(tbZoom.Value > 0)
              {
                  pbEditPhoto.Image = Zoom(imageOriginal, new Size(tbZoom.Value, tbZoom.Value));
              }
              */
            if (tbZoom.Value > 0)
            {
                //f.pb.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        Image Zoom(Image img, Size size)
        {

            Bitmap bmp = new Bitmap(img, img.Width + (img.Width * size.Width / 100), img.Height + (img.Height * size.Height / 100));
            Graphics g = Graphics.FromImage(bmp);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            return bmp;
        }


        private void PbEditPhoto_MouseWheel(object sender, MouseEventArgs e)
        {
            f.pb.SizeMode = PictureBoxSizeMode.Normal;

            if (e.Delta > 0)
            {
                value += 0.1f;
                //f.pb.Image = new Bitmap(pbEditPhoto.Image, new Size((int)(pbEditPhoto.Image.Width * value), (int)(pbEditPhoto.Image.Height * value)));
                //f.pb.Image = new Bitmap(imageOriginal, new Size((int)(imageOriginal.Width * value), (int)(imageOriginal.Height * value)));
                //pbEditPhoto.Image = new Bitmap(imageOriginal2, new Size((int)(imageOriginal2.Width * value), (int)(imageOriginal2.Height *value)));
            }
            else
            {
                value -= 0.1f;
                if (value > 0)
                {
                    //f.pb.Image = new Bitmap(pbEditPhoto.Image, new Size((int)(pbEditPhoto.Image.Width * value), (int)(pbEditPhoto.Height * value)));
                    //f.pb.Image = new Bitmap(imageOriginal, new Size((int)(imageOriginal.Width * value), (int)(imageOriginal.Height * value)));
                    //pbEditPhoto.Image = new Bitmap(imageOriginal2, new Size((int)(imageOriginal2.Width * value), (int)(imageOriginal2.Height * value)));
                }
                else
                    value = 0;
            }
            tbResize1.Value = pbEditPhoto.Width;
            tbResizeVer.Value = pbEditPhoto.Height;
        }

        private void pbEditPhoto_MouseHover(object sender, EventArgs e)
        {
            f.pb.Focus();
        }


        private void tbRotate_ValueChanged(object sender, EventArgs e)
        {

        }




        #endregion

        #region TO WPF
        private void btnDeletePict_Click(object sender, EventArgs e)
        {
            Keys k;

            k = Keys.D;
            Key_Up(k);
            if (flowLayoutPanel1.Controls.Count <= 0)
                btnDeletePict.Enabled = false;
            //BitmapTOImgSource.BitmapToImageSource(pbEditPhoto.Image);
            // BitmapImage bitImage = FormImageToWpfcs.ToWpfImage(pbEditPhoto.Image);
            //System.Windows.Controls.Image image = FormImageToWpfcs.ConvertDrawingImageToWPFImage(pbEditPhoto.Image);

            /*  BitmapSource btS = FormImageToWpfcs.BitmapFromBase64(FormImageToWpfcs.BitmapToBase64String(pbEditPhoto.Image));
              //pbCrop.Image = BitmapFromSource(btS);
              wpfwindow = new FullScreenWPF.MainWindow(btS);
              ElementHost.EnableModelessKeyboardInterop(wpfwindow);
              wpfwindow.Show();
              */

        }


        Bitmap BitmapFromSource(BitmapSource bitmapsource)
        {
            Bitmap bitmap;
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapsource));
                enc.Save(outStream);
                bitmap = new Bitmap(outStream);
            }
            return bitmap;
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            string url = @"D:\cursuri\LICENTA\WorkL\BoardApp\ZipRepo\Photos.zip";
            EmailForm frmEmail = new EmailForm(url);
            frmEmail.Show();

        }


        #endregion

        #region SAVE 
        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            int k = 0;
            DirectoryInfo folder = new DirectoryInfo(@"D:\cursuri\LICENTA\WorkL\BoardApp\courses");

            DialogResult dialogResult = MessageBox.Show("Delete existing items?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                foreach (FileInfo file in folder.EnumerateFiles())
                {
                    folder.EnumerateFiles().Count();
                    file.Delete();
                }
                foreach (DirectoryInfo dir in folder.EnumerateDirectories())
                {
                    dir.Delete(true);
                }
                k = 0;
            }
            else
            {

                k = folder.EnumerateFiles().Count();
            }

            try
            {
                //Bitmap b = new Bitmap("Poza");
                /* Bitmap b = new Bitmap(pictureBox.Image);
                 Graphics gr = Graphics.FromImage(b);
                 pictureBox.Image = b;*/
                //pictureBox.Image.Save(@"D:\cursuri\LICENTA\WorkL\BoardApp\courses\Pict" + pictureNr.ToString() + ".jpeg", ImageFormat.Jpeg);
                if (flowLayoutPanel1.Controls.Count > 0)
                {

                    foreach (var pict in flowLayoutPanel1.Controls)
                    {
                        ((PictureBox)pict).Image.Save(@"D:\cursuri\LICENTA\WorkL\BoardApp\courses\Pict" + k.ToString() + ".jpeg", ImageFormat.Jpeg);
                        k++;
                        btnSendEmail.Enabled = true;
                    }

                    string startPath = @"D:\cursuri\LICENTA\WorkL\BoardApp\courses";
                    string zipPath = @"D:\cursuri\LICENTA\WorkL\BoardApp\ZipRepo\Photos.zip";
                    File.Delete(@"D:\cursuri\LICENTA\WorkL\BoardApp\ZipRepo\Photos.zip");
                    ZipFile.CreateFromDirectory(startPath, zipPath, CompressionLevel.Fastest, true);
                    //string extractPath = @"c:\example\extract";
                    //ZipFile.ExtractToDirectory(zipPath, extractPath);
                }
                else
                {
                    MessageBox.Show("There are no saved pictures");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Save error:" + ex.Message);
            }




        }
        #endregion

        #region PROCESARE IMAGINE

        int brightness = 0;
        static float contrast = 0;


        private void tbImageProcess_Enter(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                pbProcessImage.Image = pictureBox.Image;
                pbProcessImage.SizeMode = PictureBoxSizeMode.StretchImage;

                tbBrightness.Value = 0;
                originalImage = (Bitmap)pbProcessImage.Image;
            }
        }

        Bitmap originalImage;
        private void tbBrightness_Scroll(object sender, EventArgs e)
        {
            pbProcessImage.Image = AdjustBrightness(originalImage, tbBrightness.Value);
        }

        private void tbContrast_Scroll(object sender, EventArgs e)
        {

            pbProcessImage.Image = AdjustContrast(originalImage, tbContrast.Value);

        }

        private void btnSaveProcesare_Click(object sender, EventArgs e)
        {
            pictureBox.Image = pbProcessImage.Image;
        }


        public static Bitmap AdjustContrast(Bitmap Image, int value)
        {
            contrast = 0.04f * value;
            Bitmap TempBitmap = Image;
            Bitmap bmp = new Bitmap(TempBitmap.Width, TempBitmap.Height);
            Graphics g = Graphics.FromImage(bmp);
            ImageAttributes ia = new ImageAttributes();
            ColorMatrix cm = new ColorMatrix(
                new float[][]
                {
                    new float[]{ contrast, 0f, 0f ,0f, 0f },
                    new float[]{ 0f, contrast, 0f ,0f, 0f },
                    new float[]{ 0f, 0f, contrast, 0f, 0f },
                    new float[]{ 0f, 0f, 0f, 1f, 0f },
                    new float[]{ 0.001f, 0.001f, 0.001f, 0f,1f }
                });

            ia.SetColorMatrix(cm);
            g.DrawImage(TempBitmap, new Rectangle(0, 0, TempBitmap.Width, TempBitmap.Height), 0, 0, TempBitmap.Width, TempBitmap.Height, GraphicsUnit.Pixel, ia);
            g.Dispose();
            ia.Dispose();
            return bmp;
        }



        public static Bitmap AdjustBrightness(Bitmap Image, int value)
        {
            Bitmap TempBitmap = Image;
            float FinalValue = (float)value / 255.0f;
            Bitmap NewBitmap = new Bitmap(TempBitmap.Width, TempBitmap.Height);
            Graphics NewGraphics = Graphics.FromImage(NewBitmap);

            float[][] FloatColorMatrix =
            {
                new float[] {1, 0, 0, 0, 0},
                new float[] {0, 1, 0, 0, 0},
                new float[] {0, 0, 1, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {FinalValue, FinalValue, FinalValue, 1, 1}
            };
            ColorMatrix NewColorMatrix = new ColorMatrix(FloatColorMatrix);
            ImageAttributes Attributes = new ImageAttributes();
            Attributes.SetColorMatrix(NewColorMatrix);
            NewGraphics.DrawImage(TempBitmap, new Rectangle(0, 0, TempBitmap.Width, TempBitmap.Height), 0, 0, TempBitmap.Width, TempBitmap.Height, GraphicsUnit.Pixel, Attributes);
            Attributes.Dispose();
            NewGraphics.Dispose();


            return NewBitmap;
        }


        #endregion

        #region SERIAL PORT

        private void btnConnectPort_Click(object sender, EventArgs e)
        {
            //serialPort1.Open();// deschiderea portului serial pentru comunicare.
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                MessageBox.Show("Serial port - CLOSED");
                btnConnectPort.Text = "Connect";
                lblConexiuneTelefon.Text = "Phone Connection - NOT available";
            }
            else if (!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Open();
                    MessageBox.Show("Serial port - OPENED");
                    btnConnectPort.Text = "Disconnect";
                    lblConexiuneTelefon.Text = "Phone CONNECTED";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la conexiunea cu Portul Serial!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            // propertyGridPorts.Prope
        }

        delegate void SetTextCallback(string text);

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            /* string txt = "";
             //serialPort1.DtrEnable = true;
             txt += serialPort1.ReadExisting().ToString();
             //txt += serialPort1.ReadTo("\n");
             //txt += 
             //txt = serialPort1.ReadLine();
             SetText(txt.ToString());
            // serialPort1.Close();
            // serialPort1.Open();*/

            //serialPort1 = new SerialPort("COM7", 9600, Parity.None, 8, StopBits.One);
            //serialPort1.Open();
            /*if (!serialPort1.IsOpen)
                serialPort1.Open();
            SerialPort sp = (SerialPort)sender;
            this.Invoke((MethodInvoker)delegate
            {
                txtSerialPort.Text = sp.ReadExisting();

            });
            serialPort1.Close();
            serialPort1 = new SerialPort("COM7", 9600, Parity.None, 8, StopBits.One);
            serialPort1.Open();*/
            //serialPort1.Close();

        }

        private void cbPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPorts.Text == "Bluetooth Telefon")
            {
                serialPort1.PortName = "COM7";
            }
            else
            {
                serialPort1.PortName = cbPorts.Text;
            }
            propertyGridPorts.SelectedObject = serialPort1;
            //serialPort1.Open();
        }

        private void SetText(string text)
        {
            if (this.txtSerialPort.InvokeRequired)
            {
                SetTextCallback textCallback = new SetTextCallback(SetText);
                this.Invoke(textCallback, new object[] { text });
            }
            else
            {
                this.txtSerialPort.Text = text;
                SetEventsFromBluetoothData(text);
            }
        }

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort spl = (SerialPort)sender;
                string text = spl.ReadLine();
                SetText(text.ToString());

            }
            catch (Exception ex)
            {

            }

        }

        private void cbGrade_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lblRotationAngle.Select();
        }



        private void SetEventsFromBluetoothData(string text)
        {
            Keys k;
            double grades = 1;
            char[] gr = new char[3];
            char[] fact = new char[4];
            int j = 0, l = 0;

            if (text.Contains("/"))
            {
                int start = text.IndexOf('/');
                int stop = text.IndexOf('|');
                //grades = Convert.ToDouble(text.Substring(start,));
                for (int i = start + 1; i < stop; i++)
                {
                    gr[j] = text[i];
                    j++;
                }
                grades = Convert.ToDouble(new string(gr)) * 2;
                if (grades > 720)
                    grades = 720;
                if (grades < -720)
                    grades = -720;

                if (!text.Contains("l"))
                    wpfwindow.RotateRight(grades);
                else
                    wpfwindow.RotateLeft(grades);
            }
            if (text.Contains("["))
            {
                int start = text.IndexOf('[');
                int stop = text.IndexOf(']');
                //grades = Convert.ToDouble(text.Substring(start,));
                for (int i = start + 1; i < stop; i++)
                {
                    fact[l] = text[i];
                    l++;
                }
                string command = text.Substring(0, start);
                switch (command)
                {
                    case "zoomin":
                        if (wpfwindow.btS != null)
                            wpfwindow.ZoomIn(Convert.ToDouble(new string(fact)));
                        break;

                    case "zoomout":
                        if (wpfwindow.btS != null)
                            wpfwindow.ZoomOut(Convert.ToDouble(new string(fact)));
                        break;
                    case "moveright":
                        wpfwindow.MoveRight(Convert.ToDouble(new string(fact)));
                        break;

                    case "moveleft":
                        wpfwindow.MoveLeft(Convert.ToDouble(new string(fact)));
                        break;

                    case "moveup":
                        wpfwindow.MoveUp(Convert.ToDouble(new string(fact)));
                        break;

                    case "movedown":
                        wpfwindow.MoveDown(Convert.ToDouble(new string(fact)));
                        break;
                }
            }

            switch (text)  /// daca vreau mai multe date , pot sa 
            {


                case "fullscreen":
                    k = Keys.F;
                    Key_Up(k);
                    break;

                case "delete":
                    k = Keys.D;
                    Key_Up(k);
                    break;

                case "capture":
                    k = Keys.C;
                    Key_Up(k);
                    break;

                case "save":
                    k = Keys.S;
                    Key_Up(k);
                    break;

                case "rotateright":
                    wpfwindow.RotateRight(grades);
                    break;

                case "rotateleft":
                    wpfwindow.RotateLeft(grades);
                    break;

                case "next":
                    k = Keys.NumPad3;
                    Key_Up(k);
                    break;

                case "previous":
                    k = Keys.NumPad1;
                    Key_Up(k);
                    break;

                case "esc":
                    k = Keys.Escape;
                    Key_Up(k);
                    break;
                case "ok":
                    messageBox.Close();
                    break;

                
            }
        }
        #endregion


        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnRotateRight_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                Bitmap bitmap = (Bitmap)pictureBox.Image;
                bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox.Image = bitmap;
                this.ShowWpfLogic();
            }
            else
            {
                MessageBox.Show("No picture to rotate!");

            }
        }

        private void btnRotateLeft_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                Bitmap bitmap = (Bitmap)pictureBox.Image;
                bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
                pictureBox.Image = bitmap;
                this.ShowWpfLogic();
            }
            else
            {
                MessageBox.Show("No picture to rotate!");

            }
        }



        private void ShowMessageBox(string text)
        {
            messageBox = new CustomMessageBox();
            

             if (Screen.AllScreens.Length > 1 )
             {
                messageBox.Show();
                messageBox.BringToFront();
                messageBox.Message = text;

                // Important !
                messageBox.StartPosition = FormStartPosition.Manual;

                // Get the second monitor screen
                Screen screen = GetSecondaryScreen();

                // set the location to the top left of the second screen
                messageBox.Location = new Point(((screen.WorkingArea.Left + screen.WorkingArea.Right) / 2) - messageBox.Width/2 , ((screen.WorkingArea.Bottom + screen.WorkingArea.Top)/2) - messageBox.Height/2);//(new Point(screen.Bounds.Height/2 , screen.Bounds.Height/2));
               

            }
        }

        
        public Screen GetSecondaryScreen()
        {
            if (Screen.AllScreens.Length == 1)
            {
                return null;
            }

            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.Primary == false)
                {
                    return screen;
                }
            }

            return null;
        }

    }
}
