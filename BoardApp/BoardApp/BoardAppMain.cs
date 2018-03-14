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
using AForge.Imaging.Filters;
using AForge;
using System.Threading;
using System.IO;
using BoardApp.Exceptions_Algorithms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Forms.Integration;


using Emgu.CV;
using Emgu.CV.Structure;
using System.Windows.Media.Imaging;

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
        //public var wpfwindow;
        //private Crop c;


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

            flpPictureList = new List<PictureBox>();
            f = new FullScreenForm();
            f.pb.BackColor = Color.Black;
            f.BackColor = Color.Black;
            
            PictureBox pict = new PictureBox(); pict.BackColor = Color.Black;
            PictureEditor.ShowPictureFullSreen2(ref f, ref pict);

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
            btnDeletePict.Enabled = true;

            tbResize1.Value = pbEditPhoto.Size.Width;
            tbResizeVer.Value = pbEditPhoto.Size.Height;

            pbEditPhoto.Left = (this.ClientSize.Width - pbEditPhoto.Width) / 2;
            pbEditPhoto.Top = (this.ClientSize.Height - pbEditPhoto.Height) / 2;



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

            this.btnStop.Enabled = true;

            this.liveCamera.Width = FinalVideo.VideoResolution.FrameSize.Width;
            this.liveCamera.Height = FinalVideo.VideoResolution.FrameSize.Height;
            FinalVideo.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //pictureBox.Image.Dispose();
            //this.ClearPictureBox();

            //pictureBox.Image = liveCamera.Image;
            //FinalVideo.Stop();
            Bitmap b = new Bitmap(liveCamera.Image);
            pictureBox.Image = b;


            PictureBox myPict = new PictureBox(); //dinamicly created control
                                                  //pictureBox.Image = Bitmap.FromFile(file);
            myPict = PictureEditor.PictBoxTOflowLayout(myPict);

            myPict.Image = pictureBox.Image;

            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(myPict);
            myPict.Click += MyPict_Click;
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            try
            {
                //Bitmap b = new Bitmap("Poza");
                /* Bitmap b = new Bitmap(pictureBox.Image);
                 Graphics gr = Graphics.FromImage(b);
                 pictureBox.Image = b;*/
                pictureBox.Image.Save(@"D:\cursuri\LICENTA\WorkL\BoardApp\courses\Pict" + pictureNr.ToString() + ".jpeg", ImageFormat.Jpeg);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Save error:" + ex.Message);
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
            //btnStop.Enabled = true;
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
                        flpPictureList.Add(myPict);

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
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
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

            if (e.KeyChar >= 48 && e.KeyChar <= 57) // numeric
            {

            }
            if (e.KeyChar == (char)Keys.F || e.KeyChar == char.ToLower((char)Keys.F))
            {
                /*if (pictureBox.Image != null)
                {
                    PictureEditor.ShowPictureFullSreen2(ref f, ref pictureBox); //to update "this" controls 
                    this.BringToFront();
                }
                else
                {
                    MessageBox.Show("No picture to display", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }*/

                if(pbEditPhoto.Image != null)
                {
                    PictureEditor.ShowPictureFullSreen2(ref f, ref pbEditPhoto);
                    imageOriginal = f.pb.Image;
                    imageOriginal2 = pbEditPhoto.Image;
                }
            }

            if (flowLayoutPanel1.Controls.Count > 0)
            {

                if (e.KeyChar == '6')
                {
                    if (pictureNr >= 0 && pictureNr <= flowLayoutPanel1.Controls.Count - 1)
                    {
                        //flowLayoutPanel1.Controls[pictureNr].Click += MyPict_Click;
                        //MyPict_Click((PictureBox)flowLayoutPanel1.Controls[pictureNr], e);
                        FullScreenDisplay();


                        PictureEditor.ShowPictureFullSreen2(ref f, ref pictureBox);
                        this.BringToFront();
                        pictureNr++;
                    }


                }
                if (e.KeyChar == '4')
                {
                    if (pictureNr > 0 && pictureNr <= flowLayoutPanel1.Controls.Count)
                    {
                        //flowLayoutPanel1.Controls[pictureNr].Click += MyPict_Click;
                        //MyPict_Click((PictureBox)flowLayoutPanel1.Controls[pictureNr], e);
                        pictureNr--;
                        FullScreenDisplay();


                        PictureEditor.ShowPictureFullSreen2(ref f, ref pictureBox);
                        this.BringToFront();

                    }
                }

            }
            if (liveCamera.Image != null)
            {
                if (e.KeyChar == (char)Keys.C || e.KeyChar == char.ToLower((char)Keys.C))
                {
                    btnStop_Click(sender, e);
                }
            }
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
            /* foreach (Control ctrl in flowLayoutPanel1.Controls)
             {
                 flowLayoutPanel2.Controls.Add(Clone);
                 Control c2 =
             }*/
            /*foreach (Control pict in flowLayoutPanel1.Controls)
             {
                 Control p = new Control();
                 p = CopyControl.Clone<Control>(pict);
                 flowLayoutPanel3.Controls.Add(p);
             }
             */
            /*  foreach (PictureBox pict in flowLayoutPanel1.Controls)
              {
                  PictureBox p = new PictureBox();
                  p = CopyControl.Clone<PictureBox>(pict);
                  flowLayoutPanel3.Controls.Add(p);
              }
              */
            foreach (PictureBox pict in flowLayoutPanel1.Controls)
            {
                PictureBox p = pict.CreateNewWithAttribute();
                PictureBox p2 = PictureEditor.PictBoxTOflowLayout(p);
                flowLayoutPanel2.Controls.Add(p2);
            }
            pbEditPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            pbEditPhoto.Image = pictureBox.Image;
            if(pbEditPhoto.Image != null)
            {
                tbResize1.Enabled = true;
                tbRotate.Enabled = true;
                tbResizeVer.Enabled = true;
            }

            //tbResize1.Value = pbEditPhoto.Size.Width;
            //img = Image.FromFile(@"D:\POZE\torturi\P2150615.jpg");
            //imageOriginal = pbEditPhoto.Image;
            //imageOriginal = pbEdi
            //tbResize1.Value = tbResize1.Maximum;
            //tbResizeVer.Value = tbResizeVer.Maximum;
            tbResize1.Value = pbEditPhoto.Width;
            tbResizeVer.Value = pbEditPhoto.Height;
            tbZoom.Value = 0;

            this.pbEditPhoto.MouseWheel += PbEditPhoto_MouseWheel;
        }

        

        /*
         * CROP PART
         */
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

       

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if(rbCropMode.Checked == true)
            {
                IsMouseDown = true;
                StartLocation = e.Location;
            }
            
        }
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (rbCropMode.Checked == true)
            {
                if (IsMouseDown == true)
                {
                    EndLocation = e.Location;
                    pictureBox.Invalidate();
                }
            }
        }


        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
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
                        //pbCrop.Image=PictureEditor.PictBoxTOflowLayout(pictureBox).Image;
                        rbCropMode.Checked = false;
                    }
                }
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (rbCropMode.Checked == true)
            {

                if (rect != null)
                {
                    e.Graphics.DrawRectangle(Pens.Red, GetRectangle());
                }
            }
        }
        public Rectangle GetRectangle()
        {
            rect = new Rectangle();
            rect.X = Math.Min(StartLocation.X, EndLocation.X); //pentru a putea desena dreptunghiul de crop in oricare directie
            rect.Y = Math.Min(StartLocation.Y, EndLocation.Y);
            rect.Width = Math.Abs(StartLocation.X - EndLocation.X);
            rect.Height = Math.Abs(StartLocation.Y - EndLocation.Y);

            return rect;
        }

        private void rbCropMode_CheckedChanged(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                  Bitmap b = new Bitmap(pictureBox.Image);
                  imgInput = new Image<Bgr, byte>(b);
                  pictureBox.Image = imgInput.Bitmap;
                  //if(rbCaptureMode)
                  
              /*  OpenFileDialog ofd = new OpenFileDialog();
                {
                    if(ofd.ShowDialog() == DialogResult.OK)
                    {
                        imgInput = new Image<Bgr, byte>(ofd.FileName);
                        pictureBox.Image = imgInput.Bitmap;
                    }
                }
                */
            }
            else
            {
                MessageBox.Show("No picture in PictureBox!!");
            }
        }


        #endregion

        #region TAB2 TRACK BAR + ROTATE ZOOM region

        //int angle;
        

        private void tbResize1_Scroll(object sender, EventArgs e)
        {
            pbEditPhoto.Size = new Size(tbResize1.Value, pbEditPhoto.Size.Height);
            pbEditPhoto.Left = (this.ClientSize.Width - pbEditPhoto.Width) / 2;
            pbEditPhoto.Top = (this.ClientSize.Height - pbEditPhoto.Height) / 2;

            f.pb.Size = new Size(tbResize1.Value, f.pb.Size.Height);
            f.pb.Left = (f.ClientSize.Width - f.pb.Width) / 2;
            f.pb.Top = (f.ClientSize.Height - f.pb.Height) / 2;
        }

        private void tbResizeVer_Scroll(object sender, EventArgs e)
        {
            pbEditPhoto.Size = new Size(pbEditPhoto.Size.Width, tbResizeVer.Value);
            pbEditPhoto.Left = (this.ClientSize.Width - pbEditPhoto.Width) / 2;
            pbEditPhoto.Top = (this.ClientSize.Height - pbEditPhoto.Height) / 2;

            f.pb.Size = new Size(f.pb.Size.Width, tbResizeVer.Value);
            f.pb.Left = (f.ClientSize.Width - f.pb.Width) / 2;
            f.pb.Top = (f.ClientSize.Height - f.pb.Height) / 2;
        }

        private void tbRotate_Scroll(object sender, EventArgs e)
        {
            Bitmap image = (Bitmap)pictureBox.Image;
            Bitmap a = AForge.Imaging.Image.Clone(image, PixelFormat.Format24bppRgb);  //convert your image to 8bpp and grayscale
            //AForge.Imaging.Image.SetGrayscalePalette(a);                   
            RotateBilinear ro = new RotateBilinear(tbRotate.Value, true);
            Bitmap image2 = ro.Apply(a);
            pbEditPhoto.Image = image2;

            PictureEditor.TbRotate(ref f,pbEditPhoto,tbRotate.Value);
        }

        Image imageOriginal,imageOriginal2; // imageOriginal -> for secondary screen image ...imageOriginal2 - for pbEditPhoto image
        float value = 1;
        private void tbZoom_Scroll(object sender, EventArgs e)
        {
          /* if(tbZoom.Value > 0)
            {
                pbEditPhoto.Image = Zoom(imageOriginal, new Size(tbZoom.Value, tbZoom.Value));
            }
            */
            if(tbZoom.Value > 0)
            {
                //f.pb.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        Image Zoom(Image img,Size size)
        {
         
            Bitmap bmp = new Bitmap(img, img.Width + (img.Width * size.Width / 100), img.Height + (img.Height * size.Height / 100));
            Graphics g = Graphics.FromImage(bmp);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            return bmp;
        }


        private void PbEditPhoto_MouseWheel(object sender, MouseEventArgs e)
        {
            f.pb.SizeMode = PictureBoxSizeMode.Normal;
          
            if(e.Delta > 0)
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

        private void btnDeletePict_Click(object sender, EventArgs e)
        {
            //BitmapTOImgSource.BitmapToImageSource(pbEditPhoto.Image);
            BitmapImage bitImage = FormImageToWpfcs.ToWpfImage(pbEditPhoto.Image);
            wpfwindow = new FullScreenWPF.MainWindow(bitImage);
            ElementHost.EnableModelessKeyboardInterop(wpfwindow);
            wpfwindow.Show();
            
        }

        private void tbRotate_ValueChanged(object sender, EventArgs e)
        {
          
        }




        #endregion

       
    }
}
