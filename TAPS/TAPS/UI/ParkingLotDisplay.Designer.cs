namespace TAPS.UI
{
    partial class ParkingLotDisplay
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
            this.components = new System.ComponentModel.Container();
            this.LabelLotName = new System.Windows.Forms.Label();
            this.LabelFree = new System.Windows.Forms.Label();
            this.LabelVacantPercent = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ButtonReturnToMap = new System.Windows.Forms.Button();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.ParkingLotFrame = new TAPS.UI.ParkingLotFrame();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelLotName
            // 
            this.LabelLotName.AutoSize = true;
            this.LabelLotName.Font = new System.Drawing.Font("Calibri", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelLotName.Location = new System.Drawing.Point(23, 111);
            this.LabelLotName.Name = "LabelLotName";
            this.LabelLotName.Size = new System.Drawing.Size(359, 53);
            this.LabelLotName.TabIndex = 1;
            this.LabelLotName.Text = "lot name goes here";
            // 
            // LabelFree
            // 
            this.LabelFree.AutoSize = true;
            this.LabelFree.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFree.Location = new System.Drawing.Point(26, 180);
            this.LabelFree.Name = "LabelFree";
            this.LabelFree.Size = new System.Drawing.Size(160, 35);
            this.LabelFree.TabIndex = 2;
            this.LabelFree.Text = "22 of 40 free";
            // 
            // LabelVacantPercent
            // 
            this.LabelVacantPercent.AutoSize = true;
            this.LabelVacantPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVacantPercent.Location = new System.Drawing.Point(835, 148);
            this.LabelVacantPercent.Name = "LabelVacantPercent";
            this.LabelVacantPercent.Size = new System.Drawing.Size(245, 91);
            this.LabelVacantPercent.TabIndex = 3;
            this.LabelVacantPercent.Text = "100%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(848, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "lot vacancy";
            // 
            // ButtonReturnToMap
            // 
            this.ButtonReturnToMap.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonReturnToMap.Location = new System.Drawing.Point(32, 38);
            this.ButtonReturnToMap.Name = "ButtonReturnToMap";
            this.ButtonReturnToMap.Size = new System.Drawing.Size(184, 39);
            this.ButtonReturnToMap.TabIndex = 5;
            this.ButtonReturnToMap.Text = "Return to Map";
            this.ButtonReturnToMap.UseVisualStyleBackColor = true;
            this.ButtonReturnToMap.Click += new System.EventHandler(this.ButtonReturnToMap_Click);
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Interval = 10000;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // ParkingLotFrame
            // 
            this.ParkingLotFrame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ParkingLotFrame.Location = new System.Drawing.Point(32, 242);
            this.ParkingLotFrame.MapImage = null;
            this.ParkingLotFrame.Name = "ParkingLotFrame";
            this.ParkingLotFrame.ParkingLot = null;
            this.ParkingLotFrame.Size = new System.Drawing.Size(1048, 489);
            this.ParkingLotFrame.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(576, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(443, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Note: Use the scroll bar to zoom the image and click-and-drag to pan";
            // 
            // ParkingLotDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 753);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonReturnToMap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LabelVacantPercent);
            this.Controls.Add(this.LabelFree);
            this.Controls.Add(this.LabelLotName);
            this.Controls.Add(this.ParkingLotFrame);
            this.Name = "ParkingLotDisplay";
            this.Text = "ParkingLotDisplay";
            this.Load += new System.EventHandler(this.ParkingLotDisplay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ParkingLotFrame ParkingLotFrame;
        private System.Windows.Forms.Label LabelLotName;
        private System.Windows.Forms.Label LabelFree;
        private System.Windows.Forms.Label LabelVacantPercent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ButtonReturnToMap;
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.Label label1;
    }
}