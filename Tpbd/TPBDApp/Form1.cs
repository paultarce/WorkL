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
using TPBDApp.CrystalReports;
using TPBDApp.DataSets;
using TPBDApp.SecondaryForms;
using TPBDApp.Algorithms;


namespace TPBDApp
{
    public partial class Form1 : Form
    {

        OracleConnection cn;
        OracleDataAdapter da, daPass;
        DataSet ds, dsPass;
        OracleCommand cm;
        String strSQL;
        public BindingSource bindingSource1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            strSQL = "SELECT * from salarii order by nr_crt";
            cn = new OracleConnection("DATA SOURCE=localhost:1521/xe;PASSWORD=STUDENT;USER ID=STUDENT");
            da = new OracleDataAdapter(strSQL, cn);
            ds = new DataSet();
            da.Fill(ds, "salarii");

            bindingSource1 = new BindingSource();
            bindingSource1.DataSource = ds.Tables["salarii"];

            dataGridView1.DataSource = ds.Tables["salarii"];
            dgvActualizareDate.DataSource = ds.Tables["salarii"];
            dataGridView1.AllowUserToAddRows = false;
            //dgvActualizareDate = DuplicateGridView.CopyDataGridView(dataGridView1);
            dgvActualizareDate.AllowUserToAddRows = false;

            btnSalvareProcente.Enabled = false;
            panelChangePass.Visible = false;
            btnModifParola.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrystalReport1 raport = new CrystalReport1();
            //crystalReportViewer1
            raport.SetDataSource(ds.Tables["salarii"]);
            crystalReportViewer1.ReportSource = raport;
        }

        private void ajutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Informaii aplicatie : \n 1- \n 2- \n 3-", "Ajutor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure do you want to quit?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void actualizareDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form1_Load(sender, e);
            // button1_Click(sender, e);
            tabControl1.SelectedIndex = 2;
            //dgvActualizareDate = dataGridView1;
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommandBuilder comanda = new OracleCommandBuilder(da);
                da.Update(ds.Tables["salarii"]);
                MessageBox.Show("Actulalizare reusita");
            }
            catch(OracleException ex)
            {
                MessageBox.Show("Eroare Actualizare");
            }

            }

        #region NewPass
        private void btnModifParola_Click(object sender, EventArgs e)
        {
            panelChangePass.Visible = true;
           
        }

        private void btnConfirmModificParola_Click(object sender, EventArgs e)
        {
            if (txtConfirmNewPass.Text.Equals(txtNewPass.Text))
            {
                try
                {
                    dsPass.Tables["procente"].Rows[0]["parola"] = txtNewPass.Text;
                    OracleCommandBuilder comanda = new OracleCommandBuilder(daPass);
                    daPass.Update(dsPass.Tables["procente"]);
                    MessageBox.Show("Modificare realizata cu succes", "Succes", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Modificare nerealizata", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
               
            }
        }


       
        #endregion

        #region PROCENTE
        private void modifProcenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strSqlPass = "select * from procente";
            daPass = new OracleDataAdapter(strSqlPass, cn);
            dsPass = new DataSet();
            daPass.Fill(dsPass, "procente");
            //dataGridView1.DataSource = ds.Tables["procente"];
            LoginForm loginForm = new LoginForm(cn, daPass, dsPass);
            DialogResult dr = loginForm.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                loginForm.Close();
            }

            if (LoginForm.correctPass == true)
            {
                loginForm.Close();
                tabControl1.SelectedIndex = 3;
                dgvProcente.DataSource = dsPass.Tables["procente"];
                dgvProcente.Columns["parola"].Visible = false;
                dgvProcente.AllowUserToAddRows = false;
                btnSalvareProcente.Enabled = true;
            }


        }

        

        private void btnSalvareProcente_Click(object sender, EventArgs e)
        {
            OracleCommandBuilder comanda = new OracleCommandBuilder(daPass);
            daPass.Update(dsPass.Tables["procente"]);
        }

       
        #endregion

        #region ADAUGARE

        private void btnAdaugareA_Click(object sender, EventArgs e)
        {
            //OracleCommandBuilder comanda = new OracleCommandBuilder(da);
            try
            {
               

                cn.Open();
                string sqlString = "INSERT INTO salarii (nume,prenume,functie,salar_baza,spor,premii_brute,retineri) values ('"
                    + txtNumeA.Text +"','"+txtPrenumeA.Text+"','"+txtFunctieA.Text+"',"+txtSalarBazaA.Text+","+txtSporA.Text +","
                    + txtPremiiBruteA.Text + "," + txtRetineriA.Text+")";
                cm = new OracleCommand(sqlString, cn);
                int i = cm.ExecuteNonQuery();
                MessageBox.Show("Succes Adaugare", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(OracleException ex)
            {
                MessageBox.Show("Eroare Adaugare:"+ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }

        private void adaugareAngajatiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            txtNumeA.Text = "Jon"; txtPrenumeA.Text = "Jimmmy"; txtFunctieA.Text = "avocat"; txtSalarBazaA.Text = "4300";
            txtSporA.Text = "10"; txtPremiiBruteA.Text = "0"; txtRetineriA.Text = "0";
        }
        #endregion

        private void txtNumeCautat_TextChanged(object sender, EventArgs e)
        {
            int loc = bindingSource1.Find("nume", txtNumeCautat.Text);
            if(loc == -1)
            {

            }
            else
            {


            }
            bindingSource1.Position = loc;
        }
    }
}
