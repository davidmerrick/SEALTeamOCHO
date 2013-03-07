namespace TAPS.UI
{
    partial class MapFrame
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TrackBarZoom = new System.Windows.Forms.TrackBar();
            this.LabelZoomLow = new System.Windows.Forms.Label();
            this.LabelZoomHigh = new System.Windows.Forms.Label();
            this.PanelZoom = new System.Windows.Forms.Panel();
            this.PanelPan = new System.Windows.Forms.Panel();
            this.ButtonSouth = new System.Windows.Forms.Button();
            this.ButtonNorth = new System.Windows.Forms.Button();
            this.ButtonEast = new System.Windows.Forms.Button();
            this.ButtonWest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarZoom)).BeginInit();
            this.PanelZoom.SuspendLayout();
            this.PanelPan.SuspendLayout();
            this.SuspendLayout();
            // 
            // TrackBarZoom
            // 
            this.TrackBarZoom.Location = new System.Drawing.Point(20, 19);
            this.TrackBarZoom.Name = "TrackBarZoom";
            this.TrackBarZoom.Size = new System.Drawing.Size(225, 56);
            this.TrackBarZoom.TabIndex = 0;
            // 
            // LabelZoomLow
            // 
            this.LabelZoomLow.AutoSize = true;
            this.LabelZoomLow.Location = new System.Drawing.Point(28, 58);
            this.LabelZoomLow.Name = "LabelZoomLow";
            this.LabelZoomLow.Size = new System.Drawing.Size(28, 17);
            this.LabelZoomLow.TabIndex = 1;
            this.LabelZoomLow.Text = "low";
            // 
            // LabelZoomHigh
            // 
            this.LabelZoomHigh.AutoSize = true;
            this.LabelZoomHigh.Location = new System.Drawing.Point(210, 58);
            this.LabelZoomHigh.Name = "LabelZoomHigh";
            this.LabelZoomHigh.Size = new System.Drawing.Size(35, 17);
            this.LabelZoomHigh.TabIndex = 2;
            this.LabelZoomHigh.Text = "high";
            // 
            // PanelZoom
            // 
            this.PanelZoom.Controls.Add(this.LabelZoomHigh);
            this.PanelZoom.Controls.Add(this.LabelZoomLow);
            this.PanelZoom.Controls.Add(this.TrackBarZoom);
            this.PanelZoom.Location = new System.Drawing.Point(3, 3);
            this.PanelZoom.Name = "PanelZoom";
            this.PanelZoom.Size = new System.Drawing.Size(265, 83);
            this.PanelZoom.TabIndex = 3;
            // 
            // PanelPan
            // 
            this.PanelPan.Controls.Add(this.ButtonSouth);
            this.PanelPan.Controls.Add(this.ButtonNorth);
            this.PanelPan.Controls.Add(this.ButtonEast);
            this.PanelPan.Controls.Add(this.ButtonWest);
            this.PanelPan.Location = new System.Drawing.Point(584, 16);
            this.PanelPan.Name = "PanelPan";
            this.PanelPan.Size = new System.Drawing.Size(184, 134);
            this.PanelPan.TabIndex = 4;
            // 
            // ButtonSouth
            // 
            this.ButtonSouth.Location = new System.Drawing.Point(66, 97);
            this.ButtonSouth.Name = "ButtonSouth";
            this.ButtonSouth.Size = new System.Drawing.Size(45, 34);
            this.ButtonSouth.TabIndex = 3;
            this.ButtonSouth.Text = "S";
            this.ButtonSouth.UseVisualStyleBackColor = true;
            // 
            // ButtonNorth
            // 
            this.ButtonNorth.Location = new System.Drawing.Point(66, 19);
            this.ButtonNorth.Name = "ButtonNorth";
            this.ButtonNorth.Size = new System.Drawing.Size(45, 34);
            this.ButtonNorth.TabIndex = 2;
            this.ButtonNorth.Text = "N";
            this.ButtonNorth.UseVisualStyleBackColor = true;
            // 
            // ButtonEast
            // 
            this.ButtonEast.Location = new System.Drawing.Point(118, 55);
            this.ButtonEast.Name = "ButtonEast";
            this.ButtonEast.Size = new System.Drawing.Size(45, 34);
            this.ButtonEast.TabIndex = 1;
            this.ButtonEast.Text = "E";
            this.ButtonEast.UseVisualStyleBackColor = true;
            // 
            // ButtonWest
            // 
            this.ButtonWest.Location = new System.Drawing.Point(15, 55);
            this.ButtonWest.Name = "ButtonWest";
            this.ButtonWest.Size = new System.Drawing.Size(45, 34);
            this.ButtonWest.TabIndex = 0;
            this.ButtonWest.Text = "W";
            this.ButtonWest.UseVisualStyleBackColor = true;
            // 
            // MapFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelPan);
            this.Controls.Add(this.PanelZoom);
            this.Name = "MapFrame";
            this.Size = new System.Drawing.Size(821, 489);
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarZoom)).EndInit();
            this.PanelZoom.ResumeLayout(false);
            this.PanelZoom.PerformLayout();
            this.PanelPan.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar TrackBarZoom;
        private System.Windows.Forms.Label LabelZoomLow;
        private System.Windows.Forms.Label LabelZoomHigh;
        private System.Windows.Forms.Panel PanelZoom;
        private System.Windows.Forms.Panel PanelPan;
        private System.Windows.Forms.Button ButtonNorth;
        private System.Windows.Forms.Button ButtonEast;
        private System.Windows.Forms.Button ButtonWest;
        private System.Windows.Forms.Button ButtonSouth;
    }
}
