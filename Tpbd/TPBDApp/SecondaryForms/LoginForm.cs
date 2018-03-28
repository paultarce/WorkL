using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess;

namespace TPBDApp.SecondaryForms
{
    public partial class LoginForm : Form
    {
        private OracleConnection cn;
        OracleDataAdapter da;
        DataSet ds;
        String strSQL;
        public static bool correctPass ;
        public LoginForm()
        {
            InitializeComponent();

        }
        public LoginForm(OracleConnection cn,OracleDataAdapter da,DataSet ds)
        {
            
            InitializeComponent();
            this.cn = cn;
            this.ds = ds;
            this.da = da;
            correctPass = false;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
            
        }

        private void btnAutentificare_Click(object sender, EventArgs e)
        {
            string pass = ds.Tables["procente"].Rows[0]["parola"].ToString();
              
            if (pass.Equals(txtPass.Text))
            {
                correctPass = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect Password", "Warning", MessageBoxButtons.OK);
            }
            
        }

        private void btnIesire_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
