namespace TPBDApp
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.introducereDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizareDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaugareAngajatiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stergereAngajatiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculSalariiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipărireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statPlataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fluturașiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifProcenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajutorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iesireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.btnActualizare = new System.Windows.Forms.Button();
            this.btnStergere = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMainPage = new System.Windows.Forms.TabPage();
            this.tabAdaugare = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnModifParola = new System.Windows.Forms.Button();
            this.panelChangePass = new System.Windows.Forms.Panel();
            this.btnConfirmModificParola = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConfirmNewPass = new System.Windows.Forms.TextBox();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.btnSalvareProcente = new System.Windows.Forms.Button();
            this.btnAutentificare = new System.Windows.Forms.Button();
            this.dgvProcente = new System.Windows.Forms.DataGridView();
            this.txtNumeA = new System.Windows.Forms.TextBox();
            this.txtPrenumeA = new System.Windows.Forms.TextBox();
            this.txtFunctieA = new System.Windows.Forms.TextBox();
            this.txtSalarBazaA = new System.Windows.Forms.TextBox();
            this.txtSporA = new System.Windows.Forms.TextBox();
            this.txtRetineriA = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAdaugareA = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabMainPage.SuspendLayout();
            this.tabAdaugare.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panelChangePass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcente)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(237, 143);
            this.dataGridView1.TabIndex = 0;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(392, 6);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(450, 368);
            this.crystalReportViewer1.TabIndex = 1;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(296, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.introducereDateToolStripMenuItem,
            this.tipărireToolStripMenuItem,
            this.modifProcenteToolStripMenuItem,
            this.ajutorToolStripMenuItem,
            this.iesireToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(891, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // introducereDateToolStripMenuItem
            // 
            this.introducereDateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actualizareDateToolStripMenuItem,
            this.adaugareAngajatiToolStripMenuItem,
            this.stergereAngajatiToolStripMenuItem,
            this.calculSalariiToolStripMenuItem});
            this.introducereDateToolStripMenuItem.Name = "introducereDateToolStripMenuItem";
            this.introducereDateToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.introducereDateToolStripMenuItem.Text = "Introducere Date";
            this.introducereDateToolStripMenuItem.Click += new System.EventHandler(this.introducereDateToolStripMenuItem_Click);
            // 
            // actualizareDateToolStripMenuItem
            // 
            this.actualizareDateToolStripMenuItem.Name = "actualizareDateToolStripMenuItem";
            this.actualizareDateToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.actualizareDateToolStripMenuItem.Text = "Actualizare date";
            this.actualizareDateToolStripMenuItem.Click += new System.EventHandler(this.actualizareDateToolStripMenuItem_Click);
            // 
            // adaugareAngajatiToolStripMenuItem
            // 
            this.adaugareAngajatiToolStripMenuItem.Name = "adaugareAngajatiToolStripMenuItem";
            this.adaugareAngajatiToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.adaugareAngajatiToolStripMenuItem.Text = "Adaugare angajați";
            // 
            // stergereAngajatiToolStripMenuItem
            // 
            this.stergereAngajatiToolStripMenuItem.Name = "stergereAngajatiToolStripMenuItem";
            this.stergereAngajatiToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.stergereAngajatiToolStripMenuItem.Text = "Stergere angajați";
            // 
            // calculSalariiToolStripMenuItem
            // 
            this.calculSalariiToolStripMenuItem.Name = "calculSalariiToolStripMenuItem";
            this.calculSalariiToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.calculSalariiToolStripMenuItem.Text = "Calcul salarii";
            // 
            // tipărireToolStripMenuItem
            // 
            this.tipărireToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statPlataToolStripMenuItem,
            this.fluturașiToolStripMenuItem});
            this.tipărireToolStripMenuItem.Name = "tipărireToolStripMenuItem";
            this.tipărireToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.tipărireToolStripMenuItem.Text = "Tipărire";
            // 
            // statPlataToolStripMenuItem
            // 
            this.statPlataToolStripMenuItem.Name = "statPlataToolStripMenuItem";
            this.statPlataToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.statPlataToolStripMenuItem.Text = "Stat plata";
            // 
            // fluturașiToolStripMenuItem
            // 
            this.fluturașiToolStripMenuItem.Name = "fluturașiToolStripMenuItem";
            this.fluturașiToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.fluturașiToolStripMenuItem.Text = "Fluturași";
            // 
            // modifProcenteToolStripMenuItem
            // 
            this.modifProcenteToolStripMenuItem.Name = "modifProcenteToolStripMenuItem";
            this.modifProcenteToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.modifProcenteToolStripMenuItem.Text = "Modif_Procente";
            this.modifProcenteToolStripMenuItem.Click += new System.EventHandler(this.modifProcenteToolStripMenuItem_Click);
            // 
            // ajutorToolStripMenuItem
            // 
            this.ajutorToolStripMenuItem.Name = "ajutorToolStripMenuItem";
            this.ajutorToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.ajutorToolStripMenuItem.Text = "Ajutor";
            this.ajutorToolStripMenuItem.Click += new System.EventHandler(this.ajutorToolStripMenuItem_Click);
            // 
            // iesireToolStripMenuItem
            // 
            this.iesireToolStripMenuItem.Name = "iesireToolStripMenuItem";
            this.iesireToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.iesireToolStripMenuItem.Text = "Iesire";
            this.iesireToolStripMenuItem.Click += new System.EventHandler(this.iesireToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.btnActualizare);
            this.panel1.Controls.Add(this.btnStergere);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(22, 166);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(349, 207);
            this.panel1.TabIndex = 4;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(149, 82);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(115, 37);
            this.button5.TabIndex = 3;
            this.button5.Text = "Adaugare Angajati";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // btnActualizare
            // 
            this.btnActualizare.Location = new System.Drawing.Point(12, 82);
            this.btnActualizare.Name = "btnActualizare";
            this.btnActualizare.Size = new System.Drawing.Size(106, 37);
            this.btnActualizare.TabIndex = 2;
            this.btnActualizare.Text = "Actualizare Date";
            this.btnActualizare.UseVisualStyleBackColor = true;
            // 
            // btnStergere
            // 
            this.btnStergere.Location = new System.Drawing.Point(12, 22);
            this.btnStergere.Name = "btnStergere";
            this.btnStergere.Size = new System.Drawing.Size(106, 30);
            this.btnStergere.TabIndex = 1;
            this.btnStergere.Text = "Stergere Angajati";
            this.btnStergere.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(135, 22);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabMainPage);
            this.tabControl1.Controls.Add(this.tabAdaugare);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(867, 406);
            this.tabControl1.TabIndex = 5;
            // 
            // tabMainPage
            // 
            this.tabMainPage.Controls.Add(this.dataGridView1);
            this.tabMainPage.Controls.Add(this.button1);
            this.tabMainPage.Controls.Add(this.panel1);
            this.tabMainPage.Controls.Add(this.crystalReportViewer1);
            this.tabMainPage.Location = new System.Drawing.Point(4, 22);
            this.tabMainPage.Name = "tabMainPage";
            this.tabMainPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabMainPage.Size = new System.Drawing.Size(859, 380);
            this.tabMainPage.TabIndex = 0;
            this.tabMainPage.Text = "Main Page";
            this.tabMainPage.UseVisualStyleBackColor = true;
            // 
            // tabAdaugare
            // 
            this.tabAdaugare.Controls.Add(this.label9);
            this.tabAdaugare.Controls.Add(this.panel2);
            this.tabAdaugare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabAdaugare.Location = new System.Drawing.Point(4, 22);
            this.tabAdaugare.Name = "tabAdaugare";
            this.tabAdaugare.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdaugare.Size = new System.Drawing.Size(859, 380);
            this.tabAdaugare.TabIndex = 1;
            this.tabAdaugare.Text = "Adăugare";
            this.tabAdaugare.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(859, 380);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnModifParola);
            this.tabPage3.Controls.Add(this.panelChangePass);
            this.tabPage3.Controls.Add(this.btnSalvareProcente);
            this.tabPage3.Controls.Add(this.btnAutentificare);
            this.tabPage3.Controls.Add(this.dgvProcente);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(859, 380);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Modificare Procente";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnModifParola
            // 
            this.btnModifParola.Location = new System.Drawing.Point(334, 39);
            this.btnModifParola.Name = "btnModifParola";
            this.btnModifParola.Size = new System.Drawing.Size(106, 38);
            this.btnModifParola.TabIndex = 8;
            this.btnModifParola.Text = "Modificare Parola";
            this.btnModifParola.UseVisualStyleBackColor = true;
            this.btnModifParola.Click += new System.EventHandler(this.btnModifParola_Click);
            // 
            // panelChangePass
            // 
            this.panelChangePass.Controls.Add(this.btnConfirmModificParola);
            this.panelChangePass.Controls.Add(this.label2);
            this.panelChangePass.Controls.Add(this.label1);
            this.panelChangePass.Controls.Add(this.txtConfirmNewPass);
            this.panelChangePass.Controls.Add(this.txtNewPass);
            this.panelChangePass.Location = new System.Drawing.Point(528, 102);
            this.panelChangePass.Name = "panelChangePass";
            this.panelChangePass.Size = new System.Drawing.Size(243, 151);
            this.panelChangePass.TabIndex = 7;
            // 
            // btnConfirmModificParola
            // 
            this.btnConfirmModificParola.Location = new System.Drawing.Point(96, 111);
            this.btnConfirmModificParola.Name = "btnConfirmModificParola";
            this.btnConfirmModificParola.Size = new System.Drawing.Size(125, 23);
            this.btnConfirmModificParola.TabIndex = 4;
            this.btnConfirmModificParola.Text = "Confirmare";
            this.btnConfirmModificParola.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConfirmModificParola.UseVisualStyleBackColor = true;
            this.btnConfirmModificParola.Click += new System.EventHandler(this.btnConfirmModificParola_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 41);
            this.label2.TabIndex = 3;
            this.label2.Text = "Confirmare Parola Noua";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Parola Noua";
            // 
            // txtConfirmNewPass
            // 
            this.txtConfirmNewPass.Location = new System.Drawing.Point(96, 85);
            this.txtConfirmNewPass.Name = "txtConfirmNewPass";
            this.txtConfirmNewPass.PasswordChar = '*';
            this.txtConfirmNewPass.Size = new System.Drawing.Size(125, 20);
            this.txtConfirmNewPass.TabIndex = 1;
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(96, 42);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '*';
            this.txtNewPass.Size = new System.Drawing.Size(125, 20);
            this.txtNewPass.TabIndex = 0;
            // 
            // btnSalvareProcente
            // 
            this.btnSalvareProcente.Location = new System.Drawing.Point(199, 39);
            this.btnSalvareProcente.Name = "btnSalvareProcente";
            this.btnSalvareProcente.Size = new System.Drawing.Size(106, 40);
            this.btnSalvareProcente.TabIndex = 6;
            this.btnSalvareProcente.Text = "Salvare Procente";
            this.btnSalvareProcente.UseVisualStyleBackColor = true;
            this.btnSalvareProcente.Click += new System.EventHandler(this.btnSalvareProcente_Click);
            // 
            // btnAutentificare
            // 
            this.btnAutentificare.Location = new System.Drawing.Point(68, 39);
            this.btnAutentificare.Name = "btnAutentificare";
            this.btnAutentificare.Size = new System.Drawing.Size(106, 40);
            this.btnAutentificare.TabIndex = 5;
            this.btnAutentificare.Text = "Autentificare";
            this.btnAutentificare.UseVisualStyleBackColor = true;
            this.btnAutentificare.Click += new System.EventHandler(this.modifProcenteToolStripMenuItem_Click);
            // 
            // dgvProcente
            // 
            this.dgvProcente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcente.Location = new System.Drawing.Point(68, 102);
            this.dgvProcente.Name = "dgvProcente";
            this.dgvProcente.Size = new System.Drawing.Size(435, 105);
            this.dgvProcente.TabIndex = 0;
            // 
            // txtNumeA
            // 
            this.txtNumeA.Location = new System.Drawing.Point(126, 26);
            this.txtNumeA.Name = "txtNumeA";
            this.txtNumeA.Size = new System.Drawing.Size(118, 23);
            this.txtNumeA.TabIndex = 0;
            // 
            // txtPrenumeA
            // 
            this.txtPrenumeA.Location = new System.Drawing.Point(126, 63);
            this.txtPrenumeA.Name = "txtPrenumeA";
            this.txtPrenumeA.Size = new System.Drawing.Size(118, 23);
            this.txtPrenumeA.TabIndex = 1;
            // 
            // txtFunctieA
            // 
            this.txtFunctieA.Location = new System.Drawing.Point(126, 98);
            this.txtFunctieA.Name = "txtFunctieA";
            this.txtFunctieA.Size = new System.Drawing.Size(118, 23);
            this.txtFunctieA.TabIndex = 2;
            // 
            // txtSalarBazaA
            // 
            this.txtSalarBazaA.Location = new System.Drawing.Point(126, 133);
            this.txtSalarBazaA.Name = "txtSalarBazaA";
            this.txtSalarBazaA.Size = new System.Drawing.Size(118, 23);
            this.txtSalarBazaA.TabIndex = 3;
            // 
            // txtSporA
            // 
            this.txtSporA.Location = new System.Drawing.Point(126, 172);
            this.txtSporA.Name = "txtSporA";
            this.txtSporA.Size = new System.Drawing.Size(118, 23);
            this.txtSporA.TabIndex = 4;
            // 
            // txtRetineriA
            // 
            this.txtRetineriA.Location = new System.Drawing.Point(126, 212);
            this.txtRetineriA.Name = "txtRetineriA";
            this.txtRetineriA.Size = new System.Drawing.Size(118, 23);
            this.txtRetineriA.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nume";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Prenume";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Functie";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Salar Baza";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Spor";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 17);
            this.label8.TabIndex = 11;
            this.label8.Text = "Retineri";
            // 
            // panel2
            // 
            this.panel2.CausesValidation = false;
            this.panel2.Controls.Add(this.btnAdaugareA);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtNumeA);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtPrenumeA);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtFunctieA);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtSalarBazaA);
            this.panel2.Controls.Add(this.txtSporA);
            this.panel2.Controls.Add(this.txtRetineriA);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.ForeColor = System.Drawing.Color.DarkGreen;
            this.panel2.Location = new System.Drawing.Point(51, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(297, 303);
            this.panel2.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Gadugi", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(100, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(171, 21);
            this.label9.TabIndex = 12;
            this.label9.Text = "Adaugare Angajat";
            // 
            // btnAdaugareA
            // 
            this.btnAdaugareA.ForeColor = System.Drawing.Color.Black;
            this.btnAdaugareA.Location = new System.Drawing.Point(126, 250);
            this.btnAdaugareA.Name = "btnAdaugareA";
            this.btnAdaugareA.Size = new System.Drawing.Size(118, 38);
            this.btnAdaugareA.TabIndex = 12;
            this.btnAdaugareA.Text = "Adăugare";
            this.btnAdaugareA.UseVisualStyleBackColor = true;
            this.btnAdaugareA.Click += new System.EventHandler(this.btnAdaugareA_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 434);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabMainPage.ResumeLayout(false);
            this.tabAdaugare.ResumeLayout(false);
            this.tabAdaugare.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.panelChangePass.ResumeLayout(false);
            this.panelChangePass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcente)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem introducereDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizareDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adaugareAngajatiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stergereAngajatiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculSalariiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipărireToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statPlataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fluturașiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifProcenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iesireToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnActualizare;
        private System.Windows.Forms.Button btnStergere;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolStripMenuItem ajutorToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMainPage;
        private System.Windows.Forms.TabPage tabAdaugare;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvProcente;
        private System.Windows.Forms.Button btnAutentificare;
        private System.Windows.Forms.Button btnSalvareProcente;
        private System.Windows.Forms.Panel panelChangePass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConfirmNewPass;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Button btnModifParola;
        private System.Windows.Forms.Button btnConfirmModificParola;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAdaugareA;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNumeA;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrenumeA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFunctieA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSalarBazaA;
        private System.Windows.Forms.TextBox txtSporA;
        private System.Windows.Forms.TextBox txtRetineriA;
    }
}

