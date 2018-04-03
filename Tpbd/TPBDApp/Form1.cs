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
            ds.Tables.Add("salarii");
          
            da.Fill(ds, "salarii");

            bindingSource1 = new BindingSource();
            bindingSource1.DataSource = ds.Tables["salarii"];
            bindingNavigator1.BindingSource = bindingSource1;
            bindingNavigator1.AddNewItem.Enabled = false;
            bindingNavigator1.DeleteItem.Enabled = false;

            bindingNavigator2.BindingSource = bindingSource1;
            bindingNavigator2.AddNewItem.Enabled = false;
            bindingNavigator2.DeleteItem.Enabled = false;

            dataGridView1.DataSource = ds.Tables["salarii"];
            // dgvActualizareDate.DataSource = ds.Tables["salarii"];
            dgvActualizareDate.DataSource = bindingSource1;
            dataGridView1.AllowUserToAddRows = false;
            //dgvActualizareDate = DuplicateGridView.CopyDataGridView(dataGridView1);
            dgvActualizareDate.AllowUserToAddRows = false;

            dgvStergere.DataSource = bindingSource1;
            dgvStergere.AllowUserToAddRows = false;
            dgvStergere.ReadOnly = true;

            btnSalvareProcente.Enabled = false;
            panelChangePass.Visible = false;
            btnModifParola.Enabled = true;

            dgvActualizareDate.Columns["total_brut"].ReadOnly = true; dgvActualizareDate.Columns["total_brut"].DefaultCellStyle.BackColor = Color.Gold;
            dgvActualizareDate.Columns["brut_impz"].ReadOnly = true; dgvActualizareDate.Columns["brut_impz"].DefaultCellStyle.BackColor = Color.Gold;
            dgvActualizareDate.Columns["impozit"].ReadOnly = true; dgvActualizareDate.Columns["impozit"].DefaultCellStyle.BackColor = Color.Gold;
            dgvActualizareDate.Columns["cas"].ReadOnly = true; dgvActualizareDate.Columns["cas"].DefaultCellStyle.BackColor = Color.Gold;
            dgvActualizareDate.Columns["cass"].ReadOnly = true; dgvActualizareDate.Columns["cass"].DefaultCellStyle.BackColor = Color.Gold;
            dgvActualizareDate.Columns["virat_card"].ReadOnly = true; dgvActualizareDate.Columns["virat_card"].DefaultCellStyle.BackColor = Color.Gold;
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
                /*   OracleCommandBuilder comanda = new OracleCommandBuilder(da);
                   da.Update(ds.Tables["salarii"]);
                   MessageBox.Show("Actulalizare reusita");  */
                OracleCommandBuilder comanda = new OracleCommandBuilder(da);
                bindingSource1.EndEdit();
                da.Update(ds.Tables["salarii"]);
                ds.AcceptChanges();
                Form1_Load(sender, e);          //Pentru a actualiza datele imediat si in dgv
                MessageBox.Show("Actulalizare reusita");

            }
            catch (OracleException ex)
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
                    panelChangePass.Visible = false;
                    MessageBox.Show("Modificare realizata cu succes", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Modificare nerealizata", "Atenție", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Cele 2 parole nu corespund", "Atenție", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            try
            {
                OracleCommandBuilder comanda = new OracleCommandBuilder(daPass);
                daPass.Update(dsPass.Tables["procente"]);
                Form1_Load(sender, e);
                MessageBox.Show("Salvare Procente reusita.Date reactualizate");
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Salvare Procente esuata");
            }
        }


        #endregion

        #region ADAUGARE

        private void btnAdaugareA_Click(object sender, EventArgs e)
        {
            int k = 0;
            if(txtNumeA.Text.Length < 2 && txtPrenumeA.Text.Length < 2 && txtFunctieA.Text.Length < 2)
            {
                MessageBox.Show("Câmpurile 'Nume','Prenume','Funcție' trebuie să conțină minim 2 caractere!","Atenție", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                k = 1;
            }
            if (txtSalarBazaA.Text.Length < 4 )
            {
                MessageBox.Show("Salariul de baza trebuie sa conțină minim 4 cifre", "Atenție", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                k = 1;
            }
            if (txtPremiiBruteA.Text.Length < 1 || txtSporA.Text.Length < 1 || txtRetineriA.Text.Length < 1)
            {
                MessageBox.Show("Câmpurile 'PremiiBrute','Spor','Retineri' trebuie să conțină minim 1 caracter!", "Atenție", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                k = 1;
            }
            //if()
            //OracleCommandBuilder comanda = new OracleCommandBuilder(da);
            if (k == 0)
            {
                try
                {
                    cn.Open();
                    string sqlString = "INSERT INTO salarii (nume,prenume,functie,salar_baza,spor,premii_brute,retineri) values ('"
                        + txtNumeA.Text + "','" + txtPrenumeA.Text + "','" + txtFunctieA.Text + "'," + txtSalarBazaA.Text + "," + txtSporA.Text + ","
                        + txtPremiiBruteA.Text + "," + txtRetineriA.Text + ")";
                    cm = new OracleCommand(sqlString, cn);
                    int i = cm.ExecuteNonQuery();
                    Form1_Load(sender, e);
                    MessageBox.Show("Succes Adaugare", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Eroare Adaugare:" + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open)
                        cn.Close();
                }
            }
        }

        private void adaugareAngajatiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            txtNumeA.Text = "Jon"; txtPrenumeA.Text = "Jimmmy"; txtFunctieA.Text = "avocat"; txtSalarBazaA.Text = "0"; // NUME PRENUME FUNCTII defaul -> empty
            txtSporA.Text = "0"; txtPremiiBruteA.Text = "0"; txtRetineriA.Text = "0";
        }
        #endregion

       

        private void txtNumeCautat_TextChanged(object sender, EventArgs e)
        {
           
            string variab = "nume like " + "'" + txtNumeCautat.Text + "*'";
            bindingSource1.Filter = variab;

        }
        #region KeyPress
        private void txtNumeA_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblChar.Visible = false;
            if ((!char.IsLetter(e.KeyChar)) & ((Keys)e.KeyChar != Keys.Back) & (e.KeyChar != ('-')) & (e.KeyChar != (' ')))
                e.Handled = true;
            if (txtNumeA.Text.Length < 2)
            {
                lblChar.Visible = true;
                lblChar.Text = "Câmp de minim 2 caractere";
            }
        }


        private void txtPrenumeA_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblChar.Visible = false;
            if ((!char.IsLetter(e.KeyChar)) & ((Keys)e.KeyChar != Keys.Back) & (e.KeyChar != ('-')) & (e.KeyChar != (' ')))
                e.Handled = true;
            if (txtPrenumeA.Text.Length < 2)
            {
                lblChar.Visible = true;
                lblChar.Text = "Câmp de minim 2 caractere";
            }
        }

        private void txtFunctieA_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblChar.Visible = false;
            if ((!char.IsLetter(e.KeyChar)) & ((Keys)e.KeyChar != Keys.Back) & (e.KeyChar != ('-')) & (e.KeyChar != (' ')))
                e.Handled = true;
            if (txtFunctieA.Text.Length < 2)
            {
                lblChar.Visible = true;
                lblChar.Text = "Câmp de minim 2 caractere";
            }
        }

        private void txtSalarBazaA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar)) & ((Keys)e.KeyChar != Keys.Back) )
                e.Handled = true;
            if (e.KeyChar == '0' && txtSalarBazaA.Text.Length == 0)
                e.Handled = true;
        }

        private void txtSporA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar)) & ((Keys)e.KeyChar != Keys.Back))
                e.Handled = true;
            if (txtSporA.Text.Length > 6 && ((Keys)e.KeyChar != Keys.Back))
                e.Handled = true;
        }

       
        private void txtSalarBazaA_Enter(object sender, EventArgs e)
        {
            txtSalarBazaA.Text = "";
        }

        private void txtPremiiBruteA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar)) & ((Keys)e.KeyChar != Keys.Back))
                e.Handled = true;
            if (txtPremiiBruteA.Text.Length > 6 && ((Keys)e.KeyChar != Keys.Back) )
                e.Handled = true;
        }

       

        private void txtRetineriA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar)) & ((Keys)e.KeyChar != Keys.Back))
                e.Handled = true; 
            if (txtRetineriA.Text.Length > 6 && ((Keys)e.KeyChar != Keys.Back) ) 
                e.Handled = true;
        }

       

        private void btnAnulareAdaugare_Click(object sender, EventArgs e)
        {
            adaugareAngajatiToolStripMenuItem_Click(sender, e);
        }

        

        #endregion

        #region STERGERE
        private void stergereAngajatiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }

        private void txtCautareStergere_TextChanged(object sender, EventArgs e)
        {
            string variab = "nume like " + "'" + txtCautareStergere.Text + "*'";
            bindingSource1.Filter = variab;
        }

        private void btnSaveStergere_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Doriti stergere?", "Stergere", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                if (bindingSource1.Count > 0)
                {
                    try
                    {
                        bindingSource1.RemoveCurrent();
                        bindingSource1.EndEdit();
                        btnSave_Click(sender, e);
                    }
                    catch (OracleException ex)
                    {
                        MessageBox.Show("Stergere esuata", "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
    
        }

        #endregion
    }
}
