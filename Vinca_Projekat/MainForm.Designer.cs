namespace Vinca_Projekat
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            linkLabel1 = new System.Windows.Forms.LinkLabel();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            comboBox1 = new System.Windows.Forms.ComboBox();
            comboBox2 = new System.Windows.Forms.ComboBox();
            button1 = new System.Windows.Forms.Button();
            button5 = new System.Windows.Forms.Button();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            button7 = new System.Windows.Forms.Button();
            button8 = new System.Windows.Forms.Button();
            comboBox3 = new System.Windows.Forms.ComboBox();
            comboBox4 = new System.Windows.Forms.ComboBox();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            cbbrojmerenja = new System.Windows.Forms.ComboBox();
            brmerenjalabel = new System.Windows.Forms.Label();
            bindingSource1 = new System.Windows.Forms.BindingSource(components);
            cbsamplerate = new System.Windows.Forms.ComboBox();
            labelsamplerate = new System.Windows.Forms.Label();
            datagrid = new System.Windows.Forms.DataGridView();
            vremeakvlabel = new System.Windows.Forms.Label();
            tbvremeakvizicije = new System.Windows.Forms.TextBox();
            vremepucanjatb = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            button4 = new System.Windows.Forms.Button();
            button6 = new System.Windows.Forms.Button();
            pathtofile = new System.Windows.Forms.TextBox();
            selectfile = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            path = new System.Windows.Forms.Label();
            importbtn = new System.Windows.Forms.Button();
            cbsheets = new System.Windows.Forms.ComboBox();
            fillfile = new System.Windows.Forms.Button();
            Snaga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Frekvencija = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Duty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)datagrid).BeginInit();
            SuspendLayout();
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = System.Drawing.Color.Black;
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            linkLabel1.LinkColor = System.Drawing.Color.Black;
            linkLabel1.Location = new System.Drawing.Point(582, 9);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new System.Drawing.Size(48, 25);
            linkLabel1.TabIndex = 0;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "EXIT";
            linkLabel1.VisitedLinkColor = System.Drawing.Color.Black;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(363, 52);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(152, 23);
            comboBox1.TabIndex = 3;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new System.Drawing.Point(363, 80);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new System.Drawing.Size(152, 23);
            comboBox2.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(519, 79);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(111, 23);
            button1.TabIndex = 5;
            button1.Text = "Connect";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button5
            // 
            button5.Location = new System.Drawing.Point(519, 50);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(111, 23);
            button5.TabIndex = 17;
            button5.Text = "Refresh";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(460, 11);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(84, 32);
            label5.TabIndex = 19;
            label5.Text = "LASER";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(52, 8);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(186, 32);
            label6.TabIndex = 20;
            label6.Text = "SR850 LOCK IN";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button7
            // 
            button7.Location = new System.Drawing.Point(180, 50);
            button7.Name = "button7";
            button7.Size = new System.Drawing.Size(111, 23);
            button7.TabIndex = 24;
            button7.Text = "Refresh";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new System.Drawing.Point(179, 74);
            button8.Name = "button8";
            button8.Size = new System.Drawing.Size(111, 23);
            button8.TabIndex = 23;
            button8.Text = "Connect";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new System.Drawing.Point(10, 50);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new System.Drawing.Size(164, 23);
            comboBox3.TabIndex = 22;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new System.Drawing.Point(10, 76);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new System.Drawing.Size(164, 23);
            comboBox4.TabIndex = 21;
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new System.Drawing.Point(519, 109);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(111, 23);
            button2.TabIndex = 30;
            button2.Text = "LaserTest";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Location = new System.Drawing.Point(519, 137);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(111, 23);
            button3.TabIndex = 31;
            button3.Text = "LockInTest";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // cbbrojmerenja
            // 
            cbbrojmerenja.FormattingEnabled = true;
            cbbrojmerenja.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "25", "50", "100" });
            cbbrojmerenja.Location = new System.Drawing.Point(11, 203);
            cbbrojmerenja.Name = "cbbrojmerenja";
            cbbrojmerenja.Size = new System.Drawing.Size(121, 23);
            cbbrojmerenja.TabIndex = 32;
            cbbrojmerenja.SelectedValueChanged += cbbrojmerenja_SelectedValueChanged;
            // 
            // brmerenjalabel
            // 
            brmerenjalabel.AutoSize = true;
            brmerenjalabel.Location = new System.Drawing.Point(30, 186);
            brmerenjalabel.Name = "brmerenjalabel";
            brmerenjalabel.Size = new System.Drawing.Size(88, 15);
            brmerenjalabel.TabIndex = 33;
            brmerenjalabel.Text = "BROJ MERENJA";
            // 
            // cbsamplerate
            // 
            cbsamplerate.FormattingEnabled = true;
            cbsamplerate.Items.AddRange(new object[] { "1", "2", "4", "8", "16", "32", "64", "128", "256", "512" });
            cbsamplerate.Location = new System.Drawing.Point(145, 203);
            cbsamplerate.Name = "cbsamplerate";
            cbsamplerate.Size = new System.Drawing.Size(121, 23);
            cbsamplerate.TabIndex = 34;
            // 
            // labelsamplerate
            // 
            labelsamplerate.AutoSize = true;
            labelsamplerate.Location = new System.Drawing.Point(165, 186);
            labelsamplerate.Name = "labelsamplerate";
            labelsamplerate.Size = new System.Drawing.Size(80, 15);
            labelsamplerate.TabIndex = 35;
            labelsamplerate.Text = "SAMPLE RATE";
            // 
            // datagrid
            // 
            datagrid.AllowUserToAddRows = false;
            datagrid.AllowUserToDeleteRows = false;
            datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datagrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Snaga, Frekvencija, Duty });
            datagrid.Location = new System.Drawing.Point(10, 293);
            datagrid.Name = "datagrid";
            datagrid.RowHeadersVisible = false;
            datagrid.RowHeadersWidth = 200;
            datagrid.RowTemplate.Height = 25;
            datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            datagrid.Size = new System.Drawing.Size(621, 232);
            datagrid.TabIndex = 36;
            // 
            // vremeakvlabel
            // 
            vremeakvlabel.AutoSize = true;
            vremeakvlabel.Location = new System.Drawing.Point(30, 238);
            vremeakvlabel.Name = "vremeakvlabel";
            vremeakvlabel.Size = new System.Drawing.Size(103, 15);
            vremeakvlabel.TabIndex = 37;
            vremeakvlabel.Text = "VREME AKVIZICIJE";
            // 
            // tbvremeakvizicije
            // 
            tbvremeakvizicije.Location = new System.Drawing.Point(11, 255);
            tbvremeakvizicije.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tbvremeakvizicije.Name = "tbvremeakvizicije";
            tbvremeakvizicije.Size = new System.Drawing.Size(121, 23);
            tbvremeakvizicije.TabIndex = 38;
            // 
            // vremepucanjatb
            // 
            vremepucanjatb.Location = new System.Drawing.Point(145, 255);
            vremepucanjatb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            vremepucanjatb.Name = "vremepucanjatb";
            vremepucanjatb.Size = new System.Drawing.Size(121, 23);
            vremepucanjatb.TabIndex = 40;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(156, 238);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(99, 15);
            label1.TabIndex = 39;
            label1.Text = "VREME PUCANJA";
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(281, 202);
            button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(82, 22);
            button4.TabIndex = 41;
            button4.Text = "STARTEXP";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button6
            // 
            button6.Location = new System.Drawing.Point(281, 254);
            button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(82, 22);
            button6.TabIndex = 42;
            button6.Text = "STOPEXP";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // pathtofile
            // 
            pathtofile.Location = new System.Drawing.Point(399, 204);
            pathtofile.Name = "pathtofile";
            pathtofile.Size = new System.Drawing.Size(133, 23);
            pathtofile.TabIndex = 43;
            // 
            // selectfile
            // 
            selectfile.Location = new System.Drawing.Point(555, 204);
            selectfile.Name = "selectfile";
            selectfile.Size = new System.Drawing.Size(75, 23);
            selectfile.TabIndex = 44;
            selectfile.Text = "SELECT";
            selectfile.UseVisualStyleBackColor = true;
            selectfile.Click += selectfile_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(448, 238);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(40, 15);
            label2.TabIndex = 46;
            label2.Text = "SHEET";
            // 
            // path
            // 
            path.AutoSize = true;
            path.Location = new System.Drawing.Point(448, 186);
            path.Name = "path";
            path.Size = new System.Drawing.Size(35, 15);
            path.TabIndex = 47;
            path.Text = "PATH";
            // 
            // importbtn
            // 
            importbtn.Location = new System.Drawing.Point(555, 531);
            importbtn.Name = "importbtn";
            importbtn.Size = new System.Drawing.Size(75, 23);
            importbtn.TabIndex = 49;
            importbtn.Text = "IMPORT";
            importbtn.UseVisualStyleBackColor = true;
            importbtn.Click += importbtn_Click;
            // 
            // cbsheets
            // 
            cbsheets.FormattingEnabled = true;
            cbsheets.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cbsheets.Location = new System.Drawing.Point(398, 253);
            cbsheets.Name = "cbsheets";
            cbsheets.Size = new System.Drawing.Size(133, 23);
            cbsheets.TabIndex = 51;
            // 
            // fillfile
            // 
            fillfile.Location = new System.Drawing.Point(555, 253);
            fillfile.Name = "fillfile";
            fillfile.Size = new System.Drawing.Size(75, 23);
            fillfile.TabIndex = 51;
            fillfile.Text = "FILL";
            fillfile.UseVisualStyleBackColor = true;
            fillfile.Click += fillfile_Click;
            // 
            // Snaga
            // 
            Snaga.HeaderText = "Snaga(%)";
            Snaga.MinimumWidth = 6;
            Snaga.Name = "Snaga";
            Snaga.Width = 205;
            // 
            // Frekvencija
            // 
            Frekvencija.HeaderText = "Frekvencija(Hz)";
            Frekvencija.MinimumWidth = 6;
            Frekvencija.Name = "Frekvencija";
            Frekvencija.Width = 207;
            // 
            // Duty
            // 
            Duty.HeaderText = "Duty(%)";
            Duty.MinimumWidth = 6;
            Duty.Name = "Duty";
            Duty.Width = 205;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ActiveCaption;
            BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            ClientSize = new System.Drawing.Size(673, 566);
            Controls.Add(fillfile);
            Controls.Add(cbsheets);
            Controls.Add(importbtn);
            Controls.Add(path);
            Controls.Add(label2);
            Controls.Add(selectfile);
            Controls.Add(pathtofile);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(vremepucanjatb);
            Controls.Add(label1);
            Controls.Add(tbvremeakvizicije);
            Controls.Add(vremeakvlabel);
            Controls.Add(datagrid);
            Controls.Add(labelsamplerate);
            Controls.Add(cbsamplerate);
            Controls.Add(brmerenjalabel);
            Controls.Add(cbbrojmerenja);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button7);
            Controls.Add(button8);
            Controls.Add(comboBox3);
            Controls.Add(comboBox4);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(button5);
            Controls.Add(button1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(linkLabel1);
            DoubleBuffered = true;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "FOTO_AKUSTIKA";
            MouseDown += Form1_MouseDown;
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)datagrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cbbrojmerenja;
        private System.Windows.Forms.Label brmerenjalabel;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ComboBox cbsamplerate;
        private System.Windows.Forms.Label labelsamplerate;
        private System.Windows.Forms.DataGridView datagrid;
        private System.Windows.Forms.Label vremeakvlabel;
        private System.Windows.Forms.TextBox tbvremeakvizicije;
        private System.Windows.Forms.TextBox vremepucanjatb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox pathtofile;
        private System.Windows.Forms.Button selectfile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label path;
        private System.Windows.Forms.Button importbtn;
        private System.Windows.Forms.ComboBox cbsheets;
        private System.Windows.Forms.Button fillfile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Snaga;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frekvencija;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duty;
    }
}
