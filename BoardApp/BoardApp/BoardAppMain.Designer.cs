namespace BoardApp
{
    partial class BoardAppMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BoardAppMain));
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbAttachedCameras = new System.Windows.Forms.ComboBox();
            this.cbSupportedModes = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.liveCamera = new System.Windows.Forms.PictureBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.rbCaptureMode = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCropMode = new System.Windows.Forms.RadioButton();
            this.rbDisplayMode = new System.Windows.Forms.RadioButton();
            this.btnOpenImages = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbGrade = new System.Windows.Forms.ComboBox();
            this.lblRotationAngle = new System.Windows.Forms.Label();
            this.lblConexiuneTelefon = new System.Windows.Forms.Label();
            this.btnDeletePict = new System.Windows.Forms.Button();
            this.tbImageProcess = new System.Windows.Forms.TabPage();
            this.tbContrast = new System.Windows.Forms.TrackBar();
            this.tbBrightness = new System.Windows.Forms.TrackBar();
            this.btnSaveProcesare = new System.Windows.Forms.Button();
            this.lblContrast = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pbProcessImage = new System.Windows.Forms.PictureBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtSerialPort = new System.Windows.Forms.TextBox();
            this.propertyGridPorts = new System.Windows.Forms.PropertyGrid();
            this.btnConnectPort = new System.Windows.Forms.Button();
            this.cbPorts = new System.Windows.Forms.ComboBox();
            this.tbZoom = new System.Windows.Forms.TrackBar();
            this.tbRotate = new System.Windows.Forms.TrackBar();
            this.tbResizeVer = new System.Windows.Forms.TrackBar();
            this.tbResize1 = new System.Windows.Forms.TrackBar();
            this.pbEditPhoto = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.liveCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tbImageProcess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProcessImage)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRotate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbResizeVer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbResize1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEditPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(17, 194);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(105, 184);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(87, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Capture/Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Supported Cameras";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Supported Modes";
            // 
            // cbAttachedCameras
            // 
            this.cbAttachedCameras.FormattingEnabled = true;
            this.cbAttachedCameras.Location = new System.Drawing.Point(20, 117);
            this.cbAttachedCameras.Name = "cbAttachedCameras";
            this.cbAttachedCameras.Size = new System.Drawing.Size(172, 21);
            this.cbAttachedCameras.TabIndex = 4;
            // 
            // cbSupportedModes
            // 
            this.cbSupportedModes.FormattingEnabled = true;
            this.cbSupportedModes.Location = new System.Drawing.Point(20, 157);
            this.cbSupportedModes.Name = "cbSupportedModes";
            this.cbSupportedModes.Size = new System.Drawing.Size(172, 21);
            this.cbSupportedModes.TabIndex = 5;
            // 
            // liveCamera
            // 
            this.liveCamera.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.liveCamera.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.liveCamera.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("liveCamera.BackgroundImage")));
            this.liveCamera.Cursor = System.Windows.Forms.Cursors.Default;
            this.liveCamera.Location = new System.Drawing.Point(3, 3);
            this.liveCamera.Name = "liveCamera";
            this.liveCamera.Size = new System.Drawing.Size(305, 350);
            this.liveCamera.TabIndex = 6;
            this.liveCamera.TabStop = false;
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox.BackgroundImage")));
            this.pictureBox.Location = new System.Drawing.Point(314, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(306, 350);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 7;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.liveCamera, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(350, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.60784F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.392157F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(623, 377);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(3, 356);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "Live Camera";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(314, 356);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Current Picture";
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Location = new System.Drawing.Point(105, 213);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(87, 23);
            this.btnSaveImage.TabIndex = 13;
            this.btnSaveImage.Text = "Save Image";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // rbCaptureMode
            // 
            this.rbCaptureMode.AutoSize = true;
            this.rbCaptureMode.Location = new System.Drawing.Point(16, 20);
            this.rbCaptureMode.Name = "rbCaptureMode";
            this.rbCaptureMode.Size = new System.Drawing.Size(115, 21);
            this.rbCaptureMode.TabIndex = 14;
            this.rbCaptureMode.TabStop = true;
            this.rbCaptureMode.Text = "Capture Mode";
            this.rbCaptureMode.UseVisualStyleBackColor = true;
            this.rbCaptureMode.CheckedChanged += new System.EventHandler(this.rbCaptureMode_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCropMode);
            this.groupBox1.Controls.Add(this.rbDisplayMode);
            this.groupBox1.Controls.Add(this.rbCaptureMode);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(17, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 92);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Desired Mode";
            // 
            // rbCropMode
            // 
            this.rbCropMode.AutoSize = true;
            this.rbCropMode.Location = new System.Drawing.Point(16, 65);
            this.rbCropMode.Name = "rbCropMode";
            this.rbCropMode.Size = new System.Drawing.Size(95, 21);
            this.rbCropMode.TabIndex = 23;
            this.rbCropMode.TabStop = true;
            this.rbCropMode.Text = "Crop Mode";
            this.rbCropMode.UseVisualStyleBackColor = true;
            this.rbCropMode.CheckedChanged += new System.EventHandler(this.rbCropMode_CheckedChanged);
            // 
            // rbDisplayMode
            // 
            this.rbDisplayMode.AutoSize = true;
            this.rbDisplayMode.Location = new System.Drawing.Point(16, 42);
            this.rbDisplayMode.Name = "rbDisplayMode";
            this.rbDisplayMode.Size = new System.Drawing.Size(111, 21);
            this.rbDisplayMode.TabIndex = 15;
            this.rbDisplayMode.TabStop = true;
            this.rbDisplayMode.Text = "Display Mode";
            this.rbDisplayMode.UseVisualStyleBackColor = true;
            this.rbDisplayMode.CheckedChanged += new System.EventHandler(this.rbDisplayMode_CheckedChanged);
            // 
            // btnOpenImages
            // 
            this.btnOpenImages.Location = new System.Drawing.Point(19, 223);
            this.btnOpenImages.Name = "btnOpenImages";
            this.btnOpenImages.Size = new System.Drawing.Size(73, 27);
            this.btnOpenImages.TabIndex = 16;
            this.btnOpenImages.Text = "Import";
            this.btnOpenImages.UseVisualStyleBackColor = true;
            this.btnOpenImages.Click += new System.EventHandler(this.btnOpenImages_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 267);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(341, 161);
            this.flowLayoutPanel1.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(650, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "label5";
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tbImageProcess);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(2, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(997, 460);
            this.tabControl1.TabIndex = 19;
            this.tabControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BoardAppMain_KeyPress);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage2.Controls.Add(this.btnSendEmail);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.cbGrade);
            this.tabPage2.Controls.Add(this.lblRotationAngle);
            this.tabPage2.Controls.Add(this.lblConexiuneTelefon);
            this.tabPage2.Controls.Add(this.btnDeletePict);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.btnPlay);
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Controls.Add(this.flowLayoutPanel1);
            this.tabPage2.Controls.Add(this.btnStop);
            this.tabPage2.Controls.Add(this.btnOpenImages);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.btnSaveImage);
            this.tabPage2.Controls.Add(this.cbAttachedCameras);
            this.tabPage2.Controls.Add(this.cbSupportedModes);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(989, 434);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Main Tab";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Location = new System.Drawing.Point(200, 242);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(144, 23);
            this.btnSendEmail.TabIndex = 30;
            this.btnSendEmail.Text = "Send Pictures -Email";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(198, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(146, 227);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Key Controls";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 198);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(105, 16);
            this.label19.TabIndex = 35;
            this.label19.Text = "ESC - Blank screen";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 153);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(113, 16);
            this.label18.TabIndex = 34;
            this.label18.Text = "8- Move picture up";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 137);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(133, 16);
            this.label17.TabIndex = 33;
            this.label17.Text = "2 - Move picture down";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 121);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(128, 16);
            this.label16.TabIndex = 32;
            this.label16.Text = "9 - Rotate picture right";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 105);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(121, 16);
            this.label15.TabIndex = 31;
            this.label15.Text = "7 - Rotate picture left";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 89);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 16);
            this.label14.TabIndex = 30;
            this.label14.Text = "3 - Next picture";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 16);
            this.label13.TabIndex = 29;
            this.label13.Text = "1 - Previous picture";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "F - Show picture fullscreen";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 57);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 16);
            this.label12.TabIndex = 28;
            this.label12.Text = "D - Delete picture";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "C - Capture picture";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 16);
            this.label11.TabIndex = 27;
            this.label11.Text = "S - Save picture";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "4 - Move picture left";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 182);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 16);
            this.label9.TabIndex = 22;
            this.label9.Text = "6 - Move picture right";
            // 
            // cbGrade
            // 
            this.cbGrade.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrade.FormattingEnabled = true;
            this.cbGrade.Location = new System.Drawing.Point(763, 399);
            this.cbGrade.Name = "cbGrade";
            this.cbGrade.Size = new System.Drawing.Size(55, 21);
            this.cbGrade.TabIndex = 26;
            this.cbGrade.SelectionChangeCommitted += new System.EventHandler(this.cbGrade_SelectionChangeCommitted);
            // 
            // lblRotationAngle
            // 
            this.lblRotationAngle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblRotationAngle.AutoSize = true;
            this.lblRotationAngle.Location = new System.Drawing.Point(680, 403);
            this.lblRotationAngle.Name = "lblRotationAngle";
            this.lblRotationAngle.Size = new System.Drawing.Size(77, 13);
            this.lblRotationAngle.TabIndex = 25;
            this.lblRotationAngle.Text = "Rotation Angle";
            // 
            // lblConexiuneTelefon
            // 
            this.lblConexiuneTelefon.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblConexiuneTelefon.AutoSize = true;
            this.lblConexiuneTelefon.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConexiuneTelefon.ForeColor = System.Drawing.Color.DarkRed;
            this.lblConexiuneTelefon.Location = new System.Drawing.Point(353, 399);
            this.lblConexiuneTelefon.Name = "lblConexiuneTelefon";
            this.lblConexiuneTelefon.Size = new System.Drawing.Size(263, 18);
            this.lblConexiuneTelefon.TabIndex = 24;
            this.lblConexiuneTelefon.Text = "Phone Connection - NOT available";
            // 
            // btnDeletePict
            // 
            this.btnDeletePict.Location = new System.Drawing.Point(105, 242);
            this.btnDeletePict.Name = "btnDeletePict";
            this.btnDeletePict.Size = new System.Drawing.Size(87, 23);
            this.btnDeletePict.TabIndex = 18;
            this.btnDeletePict.Text = "Delete Picture";
            this.btnDeletePict.UseVisualStyleBackColor = true;
            this.btnDeletePict.Click += new System.EventHandler(this.btnDeletePict_Click);
            // 
            // tbImageProcess
            // 
            this.tbImageProcess.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tbImageProcess.Controls.Add(this.tbContrast);
            this.tbImageProcess.Controls.Add(this.tbBrightness);
            this.tbImageProcess.Controls.Add(this.btnSaveProcesare);
            this.tbImageProcess.Controls.Add(this.lblContrast);
            this.tbImageProcess.Controls.Add(this.label10);
            this.tbImageProcess.Controls.Add(this.pbProcessImage);
            this.tbImageProcess.Location = new System.Drawing.Point(4, 22);
            this.tbImageProcess.Name = "tbImageProcess";
            this.tbImageProcess.Padding = new System.Windows.Forms.Padding(3);
            this.tbImageProcess.Size = new System.Drawing.Size(989, 434);
            this.tbImageProcess.TabIndex = 2;
            this.tbImageProcess.Text = "Edit Picture";
            this.tbImageProcess.Enter += new System.EventHandler(this.tbImageProcess_Enter);
            // 
            // tbContrast
            // 
            this.tbContrast.BackColor = System.Drawing.Color.DodgerBlue;
            this.tbContrast.LargeChange = 100;
            this.tbContrast.Location = new System.Drawing.Point(133, 107);
            this.tbContrast.Maximum = 100;
            this.tbContrast.Name = "tbContrast";
            this.tbContrast.Size = new System.Drawing.Size(242, 45);
            this.tbContrast.SmallChange = 5;
            this.tbContrast.TabIndex = 29;
            this.tbContrast.TickFrequency = 5;
            this.tbContrast.Scroll += new System.EventHandler(this.tbContrast_Scroll);
            // 
            // tbBrightness
            // 
            this.tbBrightness.BackColor = System.Drawing.Color.DodgerBlue;
            this.tbBrightness.LargeChange = 100;
            this.tbBrightness.Location = new System.Drawing.Point(133, 16);
            this.tbBrightness.Maximum = 100;
            this.tbBrightness.Minimum = -100;
            this.tbBrightness.Name = "tbBrightness";
            this.tbBrightness.Size = new System.Drawing.Size(242, 45);
            this.tbBrightness.SmallChange = 5;
            this.tbBrightness.TabIndex = 26;
            this.tbBrightness.TickFrequency = 5;
            this.tbBrightness.Scroll += new System.EventHandler(this.tbBrightness_Scroll);
            // 
            // btnSaveProcesare
            // 
            this.btnSaveProcesare.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveProcesare.Location = new System.Drawing.Point(246, 172);
            this.btnSaveProcesare.Name = "btnSaveProcesare";
            this.btnSaveProcesare.Size = new System.Drawing.Size(129, 42);
            this.btnSaveProcesare.TabIndex = 25;
            this.btnSaveProcesare.Text = "Save Changes";
            this.btnSaveProcesare.UseVisualStyleBackColor = true;
            this.btnSaveProcesare.Click += new System.EventHandler(this.btnSaveProcesare_Click);
            // 
            // lblContrast
            // 
            this.lblContrast.AutoSize = true;
            this.lblContrast.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrast.Location = new System.Drawing.Point(42, 122);
            this.lblContrast.Name = "lblContrast";
            this.lblContrast.Size = new System.Drawing.Size(62, 16);
            this.lblContrast.TabIndex = 23;
            this.lblContrast.Text = "Contrast";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(42, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "Brightness";
            // 
            // pbProcessImage
            // 
            this.pbProcessImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProcessImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbProcessImage.Location = new System.Drawing.Point(475, 16);
            this.pbProcessImage.Name = "pbProcessImage";
            this.pbProcessImage.Size = new System.Drawing.Size(482, 396);
            this.pbProcessImage.TabIndex = 20;
            this.pbProcessImage.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.txtSerialPort);
            this.tabPage1.Controls.Add(this.propertyGridPorts);
            this.tabPage1.Controls.Add(this.btnConnectPort);
            this.tabPage1.Controls.Add(this.cbPorts);
            this.tabPage1.Controls.Add(this.tbZoom);
            this.tabPage1.Controls.Add(this.tbRotate);
            this.tabPage1.Controls.Add(this.tbResizeVer);
            this.tabPage1.Controls.Add(this.tbResize1);
            this.tabPage1.Controls.Add(this.pbEditPhoto);
            this.tabPage1.Controls.Add(this.flowLayoutPanel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(989, 434);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Phone Connection";
            this.tabPage1.Enter += new System.EventHandler(this.tabPage1_Enter);
            // 
            // txtSerialPort
            // 
            this.txtSerialPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSerialPort.Location = new System.Drawing.Point(289, 219);
            this.txtSerialPort.Multiline = true;
            this.txtSerialPort.Name = "txtSerialPort";
            this.txtSerialPort.Size = new System.Drawing.Size(140, 106);
            this.txtSerialPort.TabIndex = 27;
            // 
            // propertyGridPorts
            // 
            this.propertyGridPorts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.propertyGridPorts.Location = new System.Drawing.Point(16, 219);
            this.propertyGridPorts.Name = "propertyGridPorts";
            this.propertyGridPorts.Size = new System.Drawing.Size(267, 204);
            this.propertyGridPorts.TabIndex = 26;
            // 
            // btnConnectPort
            // 
            this.btnConnectPort.Location = new System.Drawing.Point(180, 172);
            this.btnConnectPort.Name = "btnConnectPort";
            this.btnConnectPort.Size = new System.Drawing.Size(103, 34);
            this.btnConnectPort.TabIndex = 25;
            this.btnConnectPort.Text = "Connect";
            this.btnConnectPort.UseVisualStyleBackColor = true;
            this.btnConnectPort.Click += new System.EventHandler(this.btnConnectPort_Click);
            // 
            // cbPorts
            // 
            this.cbPorts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbPorts.FormattingEnabled = true;
            this.cbPorts.Location = new System.Drawing.Point(16, 180);
            this.cbPorts.Name = "cbPorts";
            this.cbPorts.Size = new System.Drawing.Size(148, 21);
            this.cbPorts.TabIndex = 24;
            this.cbPorts.SelectedIndexChanged += new System.EventHandler(this.cbPorts_SelectedIndexChanged);
            // 
            // tbZoom
            // 
            this.tbZoom.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbZoom.BackColor = System.Drawing.Color.DodgerBlue;
            this.tbZoom.Location = new System.Drawing.Point(720, 383);
            this.tbZoom.Maximum = 100;
            this.tbZoom.Name = "tbZoom";
            this.tbZoom.Size = new System.Drawing.Size(258, 45);
            this.tbZoom.TabIndex = 23;
            this.tbZoom.TickFrequency = 25;
            this.tbZoom.Value = 10;
            this.tbZoom.Scroll += new System.EventHandler(this.tbZoom_Scroll);
            // 
            // tbRotate
            // 
            this.tbRotate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbRotate.BackColor = System.Drawing.Color.DodgerBlue;
            this.tbRotate.Enabled = false;
            this.tbRotate.Location = new System.Drawing.Point(435, 8);
            this.tbRotate.Maximum = 180;
            this.tbRotate.Minimum = -180;
            this.tbRotate.Name = "tbRotate";
            this.tbRotate.Size = new System.Drawing.Size(496, 45);
            this.tbRotate.TabIndex = 22;
            this.tbRotate.Scroll += new System.EventHandler(this.tbRotate_Scroll);
            this.tbRotate.ValueChanged += new System.EventHandler(this.tbRotate_ValueChanged);
            // 
            // tbResizeVer
            // 
            this.tbResizeVer.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tbResizeVer.BackColor = System.Drawing.Color.DodgerBlue;
            this.tbResizeVer.Enabled = false;
            this.tbResizeVer.Location = new System.Drawing.Point(941, 20);
            this.tbResizeVer.Maximum = 984;
            this.tbResizeVer.Minimum = 10;
            this.tbResizeVer.Name = "tbResizeVer";
            this.tbResizeVer.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbResizeVer.Size = new System.Drawing.Size(45, 357);
            this.tbResizeVer.TabIndex = 21;
            this.tbResizeVer.TickFrequency = 25;
            this.tbResizeVer.Value = 10;
            this.tbResizeVer.Scroll += new System.EventHandler(this.tbResizeVer_Scroll);
            // 
            // tbResize1
            // 
            this.tbResize1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbResize1.BackColor = System.Drawing.Color.DodgerBlue;
            this.tbResize1.Enabled = false;
            this.tbResize1.Location = new System.Drawing.Point(435, 383);
            this.tbResize1.Maximum = 1280;
            this.tbResize1.Minimum = 10;
            this.tbResize1.Name = "tbResize1";
            this.tbResize1.Size = new System.Drawing.Size(279, 45);
            this.tbResize1.TabIndex = 20;
            this.tbResize1.TickFrequency = 25;
            this.tbResize1.Value = 10;
            this.tbResize1.Scroll += new System.EventHandler(this.tbResize1_Scroll);
            // 
            // pbEditPhoto
            // 
            this.pbEditPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbEditPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbEditPhoto.Location = new System.Drawing.Point(435, 59);
            this.pbEditPhoto.Name = "pbEditPhoto";
            this.pbEditPhoto.Size = new System.Drawing.Size(496, 318);
            this.pbEditPhoto.TabIndex = 19;
            this.pbEditPhoto.TabStop = false;
            this.pbEditPhoto.MouseHover += new System.EventHandler(this.pbEditPhoto_MouseHover);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(16, 20);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(267, 127);
            this.flowLayoutPanel2.TabIndex = 18;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(13, 164);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(61, 13);
            this.label20.TabIndex = 28;
            this.label20.Text = "Select port:";
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(289, 203);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 13);
            this.label21.TabIndex = 29;
            this.label21.Text = "Text Received";
            // 
            // BoardAppMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 457);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label5);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "BoardAppMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "BoardAppMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BoardAppMain_FormClosing);
            this.Load += new System.EventHandler(this.BoardAppMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BoardAppMain_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BoardAppMain_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BoardAppMain_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.liveCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tbImageProcess.ResumeLayout(false);
            this.tbImageProcess.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProcessImage)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRotate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbResizeVer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbResize1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEditPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbAttachedCameras;
        private System.Windows.Forms.ComboBox cbSupportedModes;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.PictureBox liveCamera;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.RadioButton rbCaptureMode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbDisplayMode;
        private System.Windows.Forms.Button btnOpenImages;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnDeletePict;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbCropMode;
        private System.Windows.Forms.PictureBox pbEditPhoto;
        private System.Windows.Forms.TrackBar tbResize1;
        private System.Windows.Forms.TrackBar tbResizeVer;
        private System.Windows.Forms.TrackBar tbRotate;
        private System.Windows.Forms.TrackBar tbZoom;
        private System.Windows.Forms.TabPage tbImageProcess;
        private System.Windows.Forms.PictureBox pbProcessImage;
        private System.Windows.Forms.Button btnSaveProcesare;
        private System.Windows.Forms.Label lblContrast;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar tbBrightness;
        private System.Windows.Forms.TrackBar tbContrast;
        private System.Windows.Forms.Button btnConnectPort;
        private System.Windows.Forms.ComboBox cbPorts;
        private System.Windows.Forms.PropertyGrid propertyGridPorts;
        private System.Windows.Forms.TextBox txtSerialPort;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label lblConexiuneTelefon;
        private System.Windows.Forms.ComboBox cbGrade;
        private System.Windows.Forms.Label lblRotationAngle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
    }
}