namespace Vinca_Projekat
{
    partial class ConnectionForm
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
            label1 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            comboBox3 = new System.Windows.Forms.ComboBox();
            comboBox4 = new System.Windows.Forms.ComboBox();
            button7 = new System.Windows.Forms.Button();
            button8 = new System.Windows.Forms.Button();
            label5 = new System.Windows.Forms.Label();
            comboBox1 = new System.Windows.Forms.ComboBox();
            comboBox2 = new System.Windows.Forms.ComboBox();
            button5 = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Sitka Banner", 14.2499981F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(315, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(22, 28);
            label1.TabIndex = 0;
            label1.Text = "X";
            label1.Click += label1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(78, 9);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(186, 32);
            label6.TabIndex = 21;
            label6.Text = "SR850 LOCK IN";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new System.Drawing.Point(12, 44);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new System.Drawing.Size(164, 24);
            comboBox3.TabIndex = 23;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new System.Drawing.Point(12, 74);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new System.Drawing.Size(164, 24);
            comboBox4.TabIndex = 24;
            // 
            // button7
            // 
            button7.Location = new System.Drawing.Point(182, 44);
            button7.Name = "button7";
            button7.Size = new System.Drawing.Size(111, 25);
            button7.TabIndex = 25;
            button7.Text = "Refresh";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new System.Drawing.Point(182, 75);
            button8.Name = "button8";
            button8.Size = new System.Drawing.Size(111, 25);
            button8.TabIndex = 26;
            button8.Text = "Connect";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(128, 142);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(84, 32);
            label5.TabIndex = 27;
            label5.Text = "LASER";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(24, 178);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(152, 24);
            comboBox1.TabIndex = 28;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new System.Drawing.Point(24, 209);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new System.Drawing.Size(152, 24);
            comboBox2.TabIndex = 29;
            // 
            // button5
            // 
            button5.Location = new System.Drawing.Point(182, 177);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(111, 25);
            button5.TabIndex = 30;
            button5.Text = "Refresh";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(182, 208);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(111, 25);
            button1.TabIndex = 31;
            button1.Text = "Connect";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new System.Drawing.Point(182, 239);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(111, 25);
            button2.TabIndex = 32;
            button2.Text = "LaserTest";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Location = new System.Drawing.Point(182, 106);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(111, 25);
            button3.TabIndex = 33;
            button3.Text = "LockInTest";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // ConnectionForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
            ClientSize = new System.Drawing.Size(350, 276);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(button5);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label5);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(comboBox4);
            Controls.Add(comboBox3);
            Controls.Add(label6);
            Controls.Add(label1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "ConnectionForm";
            Text = "ConnectionForm";
            MouseDown += ConnectionForm_MouseDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}