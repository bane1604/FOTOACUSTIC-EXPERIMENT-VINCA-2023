namespace Vinca_Projekat
{
    partial class LockInForm
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
            rmcb = new System.Windows.Forms.ComboBox();
            l1 = new System.Windows.Forms.Label();
            tccb = new System.Windows.Forms.ComboBox();
            l2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            lpcb = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // rmcb
            // 
            rmcb.FormattingEnabled = true;
            rmcb.Items.AddRange(new object[] { "Max", "Manual", "Min" });
            rmcb.Location = new System.Drawing.Point(133, 32);
            rmcb.Name = "rmcb";
            rmcb.Size = new System.Drawing.Size(121, 24);
            rmcb.TabIndex = 0;
            rmcb.SelectedIndexChanged += rmcb_SelectedIndexChanged;
            // 
            // l1
            // 
            l1.AutoSize = true;
            l1.Location = new System.Drawing.Point(49, 35);
            l1.Name = "l1";
            l1.Size = new System.Drawing.Size(78, 16);
            l1.TabIndex = 1;
            l1.Text = "ReserveMode";
            // 
            // tccb
            // 
            tccb.FormattingEnabled = true;
            tccb.Items.AddRange(new object[] { "10 μs", "30 μs", "100 μs", "300 μs", "1 ms", "3 ms", "10 ms", "30 ms", "100 ms", "300 ms", "1 s", "3 s", "10 s", "30 s", "100 s", "300 s", "1 ks", "3 ks", "10 ks", "30 ks" });
            tccb.Location = new System.Drawing.Point(133, 71);
            tccb.Name = "tccb";
            tccb.Size = new System.Drawing.Size(121, 24);
            tccb.TabIndex = 4;
            tccb.SelectedIndexChanged += tccb_SelectedIndexChanged;
            // 
            // l2
            // 
            l2.AutoSize = true;
            l2.Location = new System.Drawing.Point(48, 74);
            l2.Name = "l2";
            l2.Size = new System.Drawing.Size(79, 16);
            l2.TabIndex = 5;
            l2.Text = "TimeConstant";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(75, 110);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(52, 16);
            label1.TabIndex = 6;
            label1.Text = "LowPass";
            // 
            // lpcb
            // 
            lpcb.FormattingEnabled = true;
            lpcb.Items.AddRange(new object[] { "6 db/Oct", "12 db/Oct", "18 db/Oct", "24 db/Oct" });
            lpcb.Location = new System.Drawing.Point(133, 107);
            lpcb.Name = "lpcb";
            lpcb.Size = new System.Drawing.Size(121, 24);
            lpcb.TabIndex = 7;
            lpcb.SelectedIndexChanged += lpcb_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI Variable Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(331, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(24, 28);
            label2.TabIndex = 8;
            label2.Text = "X";
            label2.Click += label2_Click;
            // 
            // LockInForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(367, 178);
            Controls.Add(label2);
            Controls.Add(lpcb);
            Controls.Add(label1);
            Controls.Add(l2);
            Controls.Add(tccb);
            Controls.Add(l1);
            Controls.Add(rmcb);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "LockInForm";
            Text = "LockInForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox rmcb;
        private System.Windows.Forms.Label l1;
        private System.Windows.Forms.ComboBox tccb;
        private System.Windows.Forms.Label l2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox lpcb;
        private System.Windows.Forms.Label label2;
    }
}