namespace TAPS
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
            this.CampusMapFrame = new TAPS.UI.CampusMapFrame();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CampusMapFrame
            // 
            this.CampusMapFrame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CampusMapFrame.Location = new System.Drawing.Point(20, 51);
            this.CampusMapFrame.MapImage = null;
            this.CampusMapFrame.Name = "CampusMapFrame";
            this.CampusMapFrame.Size = new System.Drawing.Size(821, 489);
            this.CampusMapFrame.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(443, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Note: Use the scroll bar to zoom the image and click-and-drag to pan";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 552);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CampusMapFrame);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UI.CampusMapFrame CampusMapFrame;
        private System.Windows.Forms.Label label1;


    }
}

