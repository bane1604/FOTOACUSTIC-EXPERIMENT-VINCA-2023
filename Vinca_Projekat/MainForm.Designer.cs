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
            brmerenjalabel = new System.Windows.Forms.Label();
            bindingSource1 = new System.Windows.Forms.BindingSource(components);
            cbsamplerate = new System.Windows.Forms.ComboBox();
            labelsamplerate = new System.Windows.Forms.Label();
            datagrid = new System.Windows.Forms.DataGridView();
            Snaga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Frekvencija = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Duty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            vremeakvlabel = new System.Windows.Forms.Label();
            tbvrememerenja = new System.Windows.Forms.TextBox();
            button4 = new System.Windows.Forms.Button();
            button6 = new System.Windows.Forms.Button();
            pathtofile = new System.Windows.Forms.TextBox();
            selectfile = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            path = new System.Windows.Forms.Label();
            importbtn = new System.Windows.Forms.Button();
            cbsheets = new System.Windows.Forms.ComboBox();
            fillfile = new System.Windows.Forms.Button();
            connectform = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            tbvremestabilizacije = new System.Windows.Forms.TextBox();
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
            linkLabel1.Location = new System.Drawing.Point(734, 9);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new System.Drawing.Size(23, 25);
            linkLabel1.TabIndex = 0;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "X";
            linkLabel1.VisitedLinkColor = System.Drawing.Color.Black;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // brmerenjalabel
            // 
            brmerenjalabel.AutoSize = true;
            brmerenjalabel.Location = new System.Drawing.Point(28, 85);
            brmerenjalabel.Name = "brmerenjalabel";
            brmerenjalabel.Size = new System.Drawing.Size(88, 16);
            brmerenjalabel.TabIndex = 33;
            brmerenjalabel.Text = "BROJ MERENJA";
            // 
            // cbsamplerate
            // 
            cbsamplerate.FormattingEnabled = true;
            cbsamplerate.Items.AddRange(new object[] { "1", "2", "4", "8", "16", "32", "64", "128", "256", "512" });
            cbsamplerate.Location = new System.Drawing.Point(10, 193);
            cbsamplerate.Name = "cbsamplerate";
            cbsamplerate.Size = new System.Drawing.Size(121, 24);
            cbsamplerate.TabIndex = 34;
            // 
            // labelsamplerate
            // 
            labelsamplerate.AutoSize = true;
            labelsamplerate.Location = new System.Drawing.Point(36, 174);
            labelsamplerate.Name = "labelsamplerate";
            labelsamplerate.Size = new System.Drawing.Size(80, 16);
            labelsamplerate.TabIndex = 35;
            labelsamplerate.Text = "SAMPLE RATE";
            // 
            // datagrid
            // 
            datagrid.AllowUserToAddRows = false;
            datagrid.AllowUserToDeleteRows = false;
            datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datagrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Snaga, Frekvencija, Duty });
            datagrid.Location = new System.Drawing.Point(136, 45);
            datagrid.Name = "datagrid";
            datagrid.RowHeadersVisible = false;
            datagrid.RowHeadersWidth = 200;
            datagrid.RowTemplate.Height = 25;
            datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            datagrid.Size = new System.Drawing.Size(621, 216);
            datagrid.TabIndex = 36;
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
            // vremeakvlabel
            // 
            vremeakvlabel.AutoSize = true;
            vremeakvlabel.Location = new System.Drawing.Point(19, 131);
            vremeakvlabel.Name = "vremeakvlabel";
            vremeakvlabel.Size = new System.Drawing.Size(98, 16);
            vremeakvlabel.TabIndex = 37;
            vremeakvlabel.Text = "VREME MERENJA";
            // 
            // tbvrememerenja
            // 
            tbvrememerenja.Location = new System.Drawing.Point(10, 149);
            tbvrememerenja.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tbvrememerenja.Name = "tbvrememerenja";
            tbvrememerenja.Size = new System.Drawing.Size(121, 23);
            tbvrememerenja.TabIndex = 38;
            tbvrememerenja.Text = "5";
            tbvrememerenja.TextChanged += tbvrememerenja_TextChanged;
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(28, 303);
            button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(82, 23);
            button4.TabIndex = 41;
            button4.Text = "STARTEXP";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button6
            // 
            button6.Location = new System.Drawing.Point(28, 330);
            button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(82, 23);
            button6.TabIndex = 42;
            button6.Text = "STOPEXP";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // pathtofile
            // 
            pathtofile.Location = new System.Drawing.Point(171, 292);
            pathtofile.Name = "pathtofile";
            pathtofile.Size = new System.Drawing.Size(133, 23);
            pathtofile.TabIndex = 43;
            // 
            // selectfile
            // 
            selectfile.Location = new System.Drawing.Point(310, 290);
            selectfile.Name = "selectfile";
            selectfile.Size = new System.Drawing.Size(75, 25);
            selectfile.TabIndex = 44;
            selectfile.Text = "SELECT";
            selectfile.UseVisualStyleBackColor = true;
            selectfile.Click += selectfile_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(494, 273);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(40, 16);
            label2.TabIndex = 46;
            label2.Text = "SHEET";
            // 
            // path
            // 
            path.AutoSize = true;
            path.Location = new System.Drawing.Point(217, 273);
            path.Name = "path";
            path.Size = new System.Drawing.Size(35, 16);
            path.TabIndex = 47;
            path.Text = "PATH";
            // 
            // importbtn
            // 
            importbtn.Location = new System.Drawing.Point(652, 273);
            importbtn.Name = "importbtn";
            importbtn.Size = new System.Drawing.Size(75, 25);
            importbtn.TabIndex = 49;
            importbtn.Text = "IMPORT";
            importbtn.UseVisualStyleBackColor = true;
            importbtn.Click += importbtn_Click;
            // 
            // cbsheets
            // 
            cbsheets.FormattingEnabled = true;
            cbsheets.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cbsheets.Location = new System.Drawing.Point(449, 292);
            cbsheets.Name = "cbsheets";
            cbsheets.Size = new System.Drawing.Size(133, 24);
            cbsheets.TabIndex = 51;
            // 
            // fillfile
            // 
            fillfile.Location = new System.Drawing.Point(652, 301);
            fillfile.Name = "fillfile";
            fillfile.Size = new System.Drawing.Size(75, 25);
            fillfile.TabIndex = 51;
            fillfile.Text = "FILL";
            fillfile.UseVisualStyleBackColor = true;
            fillfile.Click += fillfile_Click;
            // 
            // connectform
            // 
            connectform.Location = new System.Drawing.Point(19, 45);
            connectform.Name = "connectform";
            connectform.Size = new System.Drawing.Size(111, 25);
            connectform.TabIndex = 52;
            connectform.Text = "Connect";
            connectform.UseVisualStyleBackColor = true;
            connectform.Click += connectform_Click;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(28, 358);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 53;
            button1.Text = "SR850";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(10, 220);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(120, 16);
            label1.TabIndex = 54;
            label1.Text = "VREME STABILIZACIJE";
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(10, 105);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(120, 23);
            textBox1.TabIndex = 55;
            textBox1.Text = "5";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // tbvremestabilizacije
            // 
            tbvremestabilizacije.Location = new System.Drawing.Point(10, 239);
            tbvremestabilizacije.Name = "tbvremestabilizacije";
            tbvremestabilizacije.Size = new System.Drawing.Size(120, 23);
            tbvremestabilizacije.TabIndex = 56;
            tbvremestabilizacije.Text = "20";
            tbvremestabilizacije.TextChanged += tbvremestabilizacije_TextChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ActiveCaption;
            BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            ClientSize = new System.Drawing.Size(780, 404);
            Controls.Add(tbvremestabilizacije);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(connectform);
            Controls.Add(fillfile);
            Controls.Add(cbsheets);
            Controls.Add(importbtn);
            Controls.Add(path);
            Controls.Add(label2);
            Controls.Add(selectfile);
            Controls.Add(pathtofile);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(tbvrememerenja);
            Controls.Add(vremeakvlabel);
            Controls.Add(datagrid);
            Controls.Add(labelsamplerate);
            Controls.Add(cbsamplerate);
            Controls.Add(brmerenjalabel);
            Controls.Add(linkLabel1);
            DoubleBuffered = true;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
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
        private System.Windows.Forms.ComboBox cbbrojmerenja;
        private System.Windows.Forms.Label brmerenjalabel;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ComboBox cbsamplerate;
        private System.Windows.Forms.Label labelsamplerate;
        private System.Windows.Forms.DataGridView datagrid;
        private System.Windows.Forms.Label vremeakvlabel;
        private System.Windows.Forms.TextBox tbvrememerenja;
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
        private System.Windows.Forms.Button connectform;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tbvremestabilizacije;
    }
}
