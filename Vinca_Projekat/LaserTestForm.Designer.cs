namespace Vinca_Projekat
{
    partial class LaserTestForm
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
            pwmbtn = new System.Windows.Forms.Button();
            testericabtn = new System.Windows.Forms.Button();
            stpbutton = new System.Windows.Forms.Button();
            snagatb = new System.Windows.Forms.TextBox();
            frekvtb = new System.Windows.Forms.TextBox();
            dutytb = new System.Windows.Forms.TextBox();
            vremetb = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            exitbtn = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // pwmbtn
            // 
            pwmbtn.BackColor = System.Drawing.Color.SandyBrown;
            pwmbtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            pwmbtn.Location = new System.Drawing.Point(449, 58);
            pwmbtn.Name = "pwmbtn";
            pwmbtn.Size = new System.Drawing.Size(134, 33);
            pwmbtn.TabIndex = 0;
            pwmbtn.Text = "PWMmode";
            pwmbtn.UseVisualStyleBackColor = true;
            pwmbtn.Click += pwmbtn_Click;
            // 
            // testericabtn
            // 
            testericabtn.BackColor = System.Drawing.Color.SandyBrown;
            testericabtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            testericabtn.Location = new System.Drawing.Point(449, 97);
            testericabtn.Name = "testericabtn";
            testericabtn.Size = new System.Drawing.Size(134, 33);
            testericabtn.TabIndex = 1;
            testericabtn.Text = "Testerica";
            testericabtn.UseVisualStyleBackColor = true;
            testericabtn.Click += testericabtn_Click;
            // 
            // stpbutton
            // 
            stpbutton.BackColor = System.Drawing.Color.SandyBrown;
            stpbutton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            stpbutton.Location = new System.Drawing.Point(449, 136);
            stpbutton.Name = "stpbutton";
            stpbutton.Size = new System.Drawing.Size(134, 33);
            stpbutton.TabIndex = 2;
            stpbutton.Text = "Stop";
            stpbutton.UseVisualStyleBackColor = true;
            stpbutton.Click += stpbutton_Click;
            // 
            // snagatb
            // 
            snagatb.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            snagatb.Location = new System.Drawing.Point(208, 20);
            snagatb.Name = "snagatb";
            snagatb.Size = new System.Drawing.Size(186, 33);
            snagatb.TabIndex = 3;
            // 
            // frekvtb
            // 
            frekvtb.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            frekvtb.Location = new System.Drawing.Point(208, 74);
            frekvtb.Name = "frekvtb";
            frekvtb.Size = new System.Drawing.Size(186, 33);
            frekvtb.TabIndex = 4;
            // 
            // dutytb
            // 
            dutytb.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dutytb.Location = new System.Drawing.Point(208, 129);
            dutytb.Name = "dutytb";
            dutytb.Size = new System.Drawing.Size(186, 33);
            dutytb.TabIndex = 5;
            dutytb.Leave += dutytb_Leave;
            // 
            // vremetb
            // 
            vremetb.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            vremetb.Location = new System.Drawing.Point(208, 182);
            vremetb.Name = "vremetb";
            vremetb.Size = new System.Drawing.Size(186, 33);
            vremetb.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(21, 24);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(129, 23);
            label1.TabIndex = 7;
            label1.Text = "SNAGA(%)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(21, 78);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(129, 23);
            label2.TabIndex = 8;
            label2.Text = "FREKV(HZ)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(38, 133);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(112, 23);
            label3.TabIndex = 9;
            label3.Text = "DUTY(%)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(35, 186);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(115, 23);
            label4.TabIndex = 10;
            label4.Text = "VREME(s)";
            // 
            // exitbtn
            // 
            exitbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            exitbtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            exitbtn.Location = new System.Drawing.Point(575, 12);
            exitbtn.Name = "exitbtn";
            exitbtn.Size = new System.Drawing.Size(84, 35);
            exitbtn.TabIndex = 11;
            exitbtn.Text = "EXIT";
            exitbtn.UseVisualStyleBackColor = true;
            exitbtn.Click += exitbtn_Click;
            // 
            // LaserTestForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.RosyBrown;
            ClientSize = new System.Drawing.Size(684, 248);
            Controls.Add(exitbtn);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(vremetb);
            Controls.Add(dutytb);
            Controls.Add(frekvtb);
            Controls.Add(snagatb);
            Controls.Add(stpbutton);
            Controls.Add(testericabtn);
            Controls.Add(pwmbtn);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "LaserTestForm";
            Text = "LaserTestForm";
            FormClosing += LaserTestForm_FormClosing;
            MouseDown += LaserTestForm_MouseDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button pwmbtn;
        private System.Windows.Forms.Button testericabtn;
        private System.Windows.Forms.Button stpbutton;
        private System.Windows.Forms.TextBox snagatb;
        private System.Windows.Forms.TextBox frekvtb;
        private System.Windows.Forms.TextBox dutytb;
        private System.Windows.Forms.TextBox vremetb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button exitbtn;
    }
}