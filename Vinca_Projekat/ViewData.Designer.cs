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
            SuspendLayout();
            // 
            // fplot
            // 
            fplot.Location = new System.Drawing.Point(13, 68);
            fplot.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            fplot.Name = "fplot";
            fplot.Size = new System.Drawing.Size(724, 369);
            fplot.TabIndex = 0;
            // 
            // exitbtn
            // 
            exitbtn.Location = new System.Drawing.Point(662, 23);
            exitbtn.Name = "exitbtn";
            exitbtn.Size = new System.Drawing.Size(75, 23);
            exitbtn.TabIndex = 1;
            exitbtn.Text = "EXIT";
            exitbtn.UseVisualStyleBackColor = true;
            exitbtn.Click += exitbtn_Click;
            exitbtn.MouseDown += exitbtn_MouseDown;
            // 
            // ViewData
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(750, 466);
            Controls.Add(exitbtn);
            Controls.Add(fplot);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "ViewData";
            Text = "ViewData";
            ResumeLayout(false);
        }

        #endregion

        private ScottPlot.FormsPlot fplot;
        private System.Windows.Forms.Button exitbtn;
    }
}