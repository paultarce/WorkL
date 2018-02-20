using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardApp
{
    public partial class FullScreenForm : Form
    {
        
        public FullScreenForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = Screen.AllScreens[0].WorkingArea.Location;
        }

        public PictureBox pb
        {
            get { return this.pbFullScreen; }
        }
        public Image PreviewImage
        {
            get { return this.pb.Image; }
            set { this.pb.Image = value; }
        }

        private void pbFullScreen_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
