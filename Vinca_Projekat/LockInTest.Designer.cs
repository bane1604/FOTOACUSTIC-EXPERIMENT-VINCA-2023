namespace Vinca_Projekat
{
    partial class LockInTest
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
            outputtb = new System.Windows.Forms.RichTextBox();
            clrbtn = new System.Windows.Forms.Button();
            cmndtb = new System.Windows.Forms.TextBox();
            sendcmndbtn = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // outputtb
            // 
            outputtb.Location = new System.Drawing.Point(12, 19);
            outputtb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            outputtb.Name = "outputtb";
            outputtb.Size = new System.Drawing.Size(589, 391);
            outputtb.TabIndex = 0;
            outputtb.Text = "";
            // 
            // clrbtn
            // 
            clrbtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            clrbtn.Location = new System.Drawing.Point(18, 414);
            clrbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            clrbtn.Name = "clrbtn";
            clrbtn.Size = new System.Drawing.Size(98, 29);
            clrbtn.TabIndex = 1;
            clrbtn.Text = "Clear";
            clrbtn.UseVisualStyleBackColor = true;
            clrbtn.Click += clrbtn_Click;
            // 
            // cmndtb
            // 
            cmndtb.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cmndtb.Location = new System.Drawing.Point(303, 418);
            cmndtb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            cmndtb.Name = "cmndtb";
            cmndtb.Size = new System.Drawing.Size(228, 32);
            cmndtb.TabIndex = 2;
            // 
            // sendcmndbtn
            // 
            sendcmndbtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            sendcmndbtn.Location = new System.Drawing.Point(537, 414);
            sendcmndbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            sendcmndbtn.Name = "sendcmndbtn";
            sendcmndbtn.Size = new System.Drawing.Size(171, 36);
            sendcmndbtn.TabIndex = 3;
            sendcmndbtn.Text = "SendCommand";
            sendcmndbtn.UseVisualStyleBackColor = true;
            sendcmndbtn.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button2.Location = new System.Drawing.Point(615, 21);
            button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(93, 35);
            button2.TabIndex = 4;
            button2.Text = "Exit";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // LockInTest
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            ClientSize = new System.Drawing.Size(720, 463);
            Controls.Add(button2);
            Controls.Add(sendcmndbtn);
            Controls.Add(cmndtb);
            Controls.Add(clrbtn);
            Controls.Add(outputtb);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "LockInTest";
            Text = "LockInTest";
            MouseDown += LockInTest_MouseDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.RichTextBox outputtb;
        private System.Windows.Forms.Button clrbtn;
        private System.Windows.Forms.TextBox cmndtb;
        private System.Windows.Forms.Button sendcmndbtn;
        private System.Windows.Forms.Button button2;
    }
}