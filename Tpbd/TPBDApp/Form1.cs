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
        BindingSource bdSource2;
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
            bdSource2 = new BindingSource();
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
            dataGridView1.ReadOnly = true;
            //dgvActualizareDate = DuplicateGridView.CopyDataGridView(dataGridView1);
            dgvActualizareDate.AllowUserToAddRows = false;

            dgvCrystalRep.DataSource = bindingSource1;
            dgvCrystalRep.AllowUserToAddRows = false;
            dgvCrystalRep.ReadOnly = true;

            dgvStergere.DataSource = bindingSource1;
            dgvStergere.AllowUserToAddRows = false;
            dgvStergere.ReadOnly = true;

            btnSalvareProcente.Enabled = false;
            panelChangePass.Visible = false;
            btnModifParola.Enabled = true;

            dgvActualizareDate.Columns["nr_crt"].ReadOnly = true; dgvActualizareDate.Columns["nr_crt"].DefaultCellStyle.BackColor = Color.Gold;
            dgvActualizareDate.Columns["total_brut"].ReadOnly = true; dgvActualizareDate.Columns["total_brut"].DefaultCellStyle.BackColor = Color.Gold;
            dgvActualizareDate.Columns["brut_impz"].ReadOnly = true; dgvActualizareDate.Columns["brut_impz"].DefaultCellStyle.BackColor = Color.Gold;
            dgvActualizareDate.Columns["impozit"].ReadOnly = true; dgvActualizareDate.Columns["impozit"].DefaultCellStyle.BackColor = Color.Gold;
            dgvActualizareDate.Columns["cas"].ReadOnly = true; dgvActualizareDate.Columns["cas"].DefaultCellStyle.BackColor = Color.Gold;
            dgvActualizareDate.Columns["cass"].ReadOnly = true; dgvActualizareDate.Columns["cass"].DefaultCellStyle.BackColor = Color.Gold;
            dgvActualizareDate.Columns["virat_card"].ReadOnly = true; dgvActualizareDate.Columns["virat_card"].DefaultCellStyle.BackColor = Color.Gold;

            crystalReportViewer1.Zoom(70);
        }

       /* private void button1_Click(object sender, EventArgs e)
        {
            CrystalReport1 raport = new CrystalReport1();
            //crystalReportViewer1
            raport.SetDataSource(ds.Tables["salarii"]);
            crystalReportViewer1.ReportSource = raport;
        }*/

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


        #region ACTUALIZARE DATE 
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool k = false;
            k = CheckActualizare();
            if (k == false)
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
                    MessageBox.Show("Eroare Actualizare: Completati câmpurile Text cu minim 2 caractere \nCompletați " +
                         "câmpurile numerice astfel: \n  -> 1.900 < Salar_baza < 100.000 \n -> 0 < Spor < 100 \n -> 0 < Premii_brute < Salar_baza/2 \n ->   0 < retineri < Salar_baza/2 ", "Actualizare Esuata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Form1_Load(sender, e);
                }
            }
            else
            {
                Form1_Load(sender, e);
            }

        }

        private bool CheckActualizare()
        {
            bool k = false;
            int kNume = 0, kPrenume = 0, kFunctie = 0, kSpor = 0, kPremii = 0, kRetineri = 0, kSalar = 0;

            try
            {
                for (int i = 0; i < dgvActualizareDate.Columns.Count; i++)
                {
                    for (int j = 0; j < dgvActualizareDate.Rows.Count; j++)
                    {
                        if (i == 1) // coloana nume  + varianta in care preiau numele coloanei
                        {
                            //int cell = Convert.ToInt32(dgvActualizareDate[1, j].Value.ToString());
                            string cell = dgvActualizareDate[1, j].Value.ToString();
                            if (cell.Length < 2)
                                kNume = 1;

                        }
                        if (i == 2)
                        {
                            string cell = dgvActualizareDate[2, j].Value.ToString();
                            if (cell.Length < 2)
                                kPrenume = 1;
                        }
                        if (i == 3)
                        {
                            string cell = dgvActualizareDate[3, j].Value.ToString();
                            if (cell.Length < 2)
                                kFunctie = 1;
                        }
                        if (i == 4)
                        {
                            int cell = Convert.ToInt32(dgvActualizareDate[4, j].Value.ToString());

                            if (cell < 1900 || cell > 100000)
                                kSalar = 1;
                        }
                        if (i == 5)
                        {
                            int cell = Convert.ToInt32(dgvActualizareDate[5, j].Value.ToString());

                            if (cell > 100)
                                kSpor = 1;
                        }
                        if (i == 6)
                        {
                            int cell = Convert.ToInt32(dgvActualizareDate[6, j].Value.ToString());
                            int cellB = Convert.ToInt32(dgvActualizareDate[4, j].Value.ToString());

                            if (cell > cellB / 2)
                                kPremii = 1;
                        }
                        if (i == 12)
                        {
                            int cell = Convert.ToInt32(dgvActualizareDate[12, j].Value.ToString());
                            int cellB = Convert.ToInt32(dgvActualizareDate[4, j].Value.ToString());

                            if (cell > cellB / 2)
                                kRetineri = 1;
                        }
                    }
                }
            }
            catch(OverflowException e)
            {
                MessageBox.Show("Valoare In afara limitelor","Eroare",MessageBoxButtons.OK,MessageBoxIcon.Error);
                k = true;
            }
            if(kNume == 1)
            {
                MessageBox.Show("Nume - minim 2 caractere", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                k = true;
            }
            if (kPrenume == 1)
            {
                MessageBox.Show("Prenume - minim 2 caractere", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                k = true;
            }
            if (kFunctie == 1)
            {
                MessageBox.Show("Functie - minim 2 caractere", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                k = true;
            }
            if(kSalar == 1)
            {
                MessageBox.Show("Salar baza gresit.Valori : [1900,100000]", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                k = true;
            }
            if(kSpor == 1)
            {
                MessageBox.Show("Spor gresit.Valori :[0,100]", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                k = true;
            }
            if(kPremii == 1)
            {
                MessageBox.Show("Premii_brute gresit.Valori: [0,Salar_baza/2]", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                k = true;
            }
            if(kRetineri == 1)
            {
                MessageBox.Show("Retineri gresit.Valori : [0,Salar_baza/2]", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                k = true;
            }

            return k; 
        } 
        #endregion

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
            int k = 0; // pentru a valida modificarea
            double cas, cass, impozit;

            try
            {
                cas = Convert.ToDouble(dgvProcente.Rows[0].Cells[0].Value.ToString());
                cass = Convert.ToDouble(dgvProcente.Rows[0].Cells[1].Value.ToString());
                impozit = Convert.ToDouble(dgvProcente.Rows[0].Cells[2].Value.ToString());
                if( (cas >= 1)||(cass >= 1)||(impozit >= 1))
                {
                    k = 1;
                    MessageBox.Show("Actualizare procente eșuată.Procentele au limitele:" +
                        "\n -> 0 < cas < 1 \n -> 0 < cass < 1 \n -> 0 < impozit < 1", "Actualizare nereușită", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Date invalide:" + ex.GetType().Name);
            }
            //if((cas > 0)) // validare procente

            if (k == 0)
            {
                try
                {
                    OracleCommandBuilder comanda = new OracleCommandBuilder(daPass);
                    daPass.Update(dsPass.Tables["procente"]);
                    Form1_Load(sender, e);
                    btnSalvareProcente.Enabled = true;
                    MessageBox.Show("Salvare Procente reusita.Date reactualizate");
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Salvare Procente esuata");
                }
            }
        }


        #endregion

        #region ADAUGARE

        private void btnAdaugareA_Click(object sender, EventArgs e)
        {
            int k = 0;
            if(txtNumeA.Text.Length < 2 || txtPrenumeA.Text.Length < 2 || txtFunctieA.Text.Length < 2)
            {
                MessageBox.Show("Câmpurile 'Nume','Prenume','Funcție' trebuie să conțină minim 2 caractere!","Atenție", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                k = 1;
            }
            if (txtSalarBazaA.Text.Length < 4 || Convert.ToInt32(txtSalarBazaA.Text) < 1900 )
            {
                MessageBox.Show("Salariul de baza trebuie sa conțină minim 4 cifre si sa fie mai mare decat 1900 lei", "Atenție", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                k = 1;
            }
            if (txtPremiiBruteA.Text.Length < 1 || txtSporA.Text.Length < 1 || txtRetineriA.Text.Length < 1)
            {
                MessageBox.Show("Câmpurile 'PremiiBrute','Spor','Retineri' trebuie să conțină minim 1 caracter!", "Atenție", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                k = 1;
            }

            int salar_baza, spor, premii, retineri;
            salar_baza = Convert.ToInt32( txtSalarBazaA.Text);
            spor = Convert.ToInt32(txtSporA.Text);
            premii = Convert.ToInt32(txtPremiiBruteA.Text);
            retineri = Convert.ToInt32(txtRetineriA.Text);
            if(salar_baza >100000)
            {
                MessageBox.Show("Salar Baza < 100000");
                k = 1;
            }
            if (spor > 100)
            {
                MessageBox.Show("Spor < 100", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                k = 1;
            }
            if (premii > salar_baza / 2)
            {
                MessageBox.Show("Premii < Salar_Baza/2", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                k = 1;
            }
            if (retineri > salar_baza / 2)
            {
                MessageBox.Show("Retineri < Salar_Bza/2", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (txtSporA.Text.Length > 2 && ((Keys)e.KeyChar != Keys.Back))
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
            lblChar.Visible = false;
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
            DialogResult dialog = MessageBox.Show("Confirmati stergerea?", "Stergere", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                if (bindingSource1.Count > 0)
                {
                    try
                    {
                        bindingSource1.RemoveCurrent();
                        bindingSource1.EndEdit();
                        //btnSave_Click(sender, e);
                        Save_Stergere();
                    }
                    catch (OracleException ex)
                    {
                        MessageBox.Show("Stergere esuata", "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
    
        }

        private void Save_Stergere()
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
                Form1_Load(null, null);          //Pentru a actualiza datele imediat si in dgv
                MessageBox.Show("Actulalizare reusita");

            }
            catch (OracleException ex)
            {
                //MessageBox.Show("Eroare Actualizare: Completati câmpurile Text cu minim 2 caractere \nCompletați " +
                //     "câmpurile numerice astfel: \n  -> 1.900 < Salar_baza < 100.000 \n -> 0 < Spor < 100 \n -> 0 < Premii_brute < Salar_baza/2 \n ->   0 < retineri < Salar_baza/2 )", "Actualizare Esuata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Eroare Stergere", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region DATA GRID VALIDATION
        private void dgvActualizareDate_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnChar_KeyPress); //remove any key press event added prevoiusly in EditingControlShowing
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnNumber_KeyPress);
            int col = dgvActualizareDate.CurrentCell.ColumnIndex;
            if ( col == 1 || col == 2 || col == 3)
            {
                TextBox tb = e.Control as TextBox;
                if(tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(ColumnChar_KeyPress);
                }
            }
            if(col == 4 || col == 5 || col == 6 || col == 12)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(ColumnNumber_KeyPress);
                }
            }
          
        }

        private void dgvProcente_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnNumberDot_KeyPress); //remove any key press event added prevoiusly in EditingControlShowing
            int col = dgvProcente.CurrentCell.ColumnIndex;
            if (col == 0 || col == 1 || col == 2)
            {
                tbP = e.Control as TextBox;
                if (tbP != null)
                {
                    tbP.KeyPress += new KeyPressEventHandler(ColumnNumberDot_KeyPress);
                }
            }
        }

        private void ColumnChar_KeyPress(object sender,KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ('-')) && (e.KeyChar != (' ')))
            {
                e.Handled = true;
            }
        }
        private void ColumnNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        int dotExists = 0;

       

        TextBox tbP;

       

        private void ColumnNumberDot_KeyPress(object sender, KeyPressEventArgs e)
        {
            string txtProcente = tbP.Text;
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar) && (e.KeyChar != ('.') ))
            {
                e.Handled = true;
            }
            if (e.KeyChar == ('.') && txtProcente.Length ==  0)
                e.Handled = true;

            if ( (dotExists == 1 && e.KeyChar==('.')) || (txtProcente == "" && e.KeyChar ==('.') ))
                e.Handled = true;

            if (txtProcente == "")
                dotExists = 0;
            if (e.KeyChar == ('.') && txtProcente != "" )
                dotExists = 1;

        }

        
        #endregion

        #region CrystalReports
        private void statPlataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 5;
        }
        private void fluturașiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 5;
        }
        private void btnFluturasi_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 5;
        }

        private void btnFluturas_Click(object sender, EventArgs e)
        {

            try
            {
                if (true)
                {
                    int cell = Convert.ToInt32(dgvCrystalRep[0, 0].Value.ToString());
                    string id = ""; // = dgvCrystalRep.SelectedCells[0].Value.ToString();
                                    //DataGridViewRow row = dgvCrystalRep.SelectedRows[1];
                                    // string value = row.Cells[0].Value.ToString();
                    foreach (DataGridViewRow row in dgvCrystalRep.SelectedRows)
                    {
                        id = row.Cells[0].Value.ToString();
                        break;
                    }


                    string querry = "SELECT * from salarii where nr_crt=" + id;

                    OracleDataAdapter daCr = new OracleDataAdapter(querry, cn);
                    DataSet dsCr = new DataSet();

                    dsCr.Tables.Add("salarii");
                    daCr.Fill(dsCr, "salarii");

                    Fluturasi fluturasi = new Fluturasi();
                    //fluturasi.SetDataSource(ds.Tables["salarii"]);
                    fluturasi.SetDataSource(dsCr.Tables["salarii"]);
                    crystalReportViewer1.ReportSource = fluturasi;
                }
                else
                {
                    MessageBox.Show("Selectați o singura înregistrare!", "Atenție", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Selectati ÎNTREG RÂNDUL, nu doar o celulă!!!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void txtAngFluturas_TextChanged(object sender, EventArgs e)
        {
            string variab = "nume like " + "'" + txtAngFluturas.Text + "*'";
            bindingSource1.Filter = variab;
            bdSource2.DataSource = bindingSource1.Filter;
        }

        private void txtFluturasi_Click(object sender, EventArgs e)
        {
            Fluturasi fluturasi = new Fluturasi();
            fluturasi.SetDataSource(ds.Tables["salarii"]);
            crystalReportViewer1.ReportSource = fluturasi;

        }


        
        
        private void btnStatPlata_Click(object sender, EventArgs e)
        {
            CrystalReport1 raport = new CrystalReport1();
            //crystalReportViewer1
            raport.SetDataSource(ds.Tables["salarii"]);
            crystalReportViewer1.ReportSource = raport;
        }

       
        #endregion
    }
}
