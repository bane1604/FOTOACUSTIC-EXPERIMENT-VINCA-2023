namespace Vinca_Projekat
{
    partial class ViewData
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
            fplot = new ScottPlot.FormsPlot();
            exitbtn = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // fplot
            // 
            fplot.Location = new System.Drawing.Point(13, 64);
            fplot.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            fplot.Name = "fplot";
            fplot.Size = new System.Drawing.Size(724, 346);
            fplot.TabIndex = 0;
            // 
            // exitbtn
            // 
            exitbtn.Location = new System.Drawing.Point(662, 22);
            exitbtn.Name = "exitbtn";
            exitbtn.Size = new System.Drawing.Size(75, 22);
            exitbtn.TabIndex = 1;
            exitbtn.Text = "EXIT";
            exitbtn.UseVisualStyleBackColor = true;
            exitbtn.Click += exitbtn_Click;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(354, 21);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "ExportTXT";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(59, 25);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(38, 15);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(59, 46);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(38, 15);
            label2.TabIndex = 4;
            label2.Text = "label2";
            // 
            // ViewData
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(750, 436);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(exitbtn);
            Controls.Add(fplot);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "ViewData";
            Text = "ViewData";
            Load += ViewData_Load;
            MouseDown += ViewData_MouseDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ScottPlot.FormsPlot fplot;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}