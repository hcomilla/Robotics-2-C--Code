namespace RoboticsIIFinalCountdownProjectExtraordinaire
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
            this.sendBtn = new System.Windows.Forms.Button();
            this.sourcePictureBox = new System.Windows.Forms.PictureBox();
            this.coloredPictureBox = new System.Windows.Forms.PictureBox();
            this.radiusPictureBox = new System.Windows.Forms.PictureBox();
            this.contourLabel = new System.Windows.Forms.Label();
            this.coordinateLabel = new System.Windows.Forms.Label();
            this.returnedPointLbl = new System.Windows.Forms.Label();
            this.lockStateToolStripStatusLabel = new System.Windows.Forms.Label();
            this.yInput = new System.Windows.Forms.TextBox();
            this.xInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coloredPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radiusPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(309, 318);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(75, 23);
            this.sendBtn.TabIndex = 0;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // sourcePictureBox
            // 
            this.sourcePictureBox.Location = new System.Drawing.Point(12, 34);
            this.sourcePictureBox.Name = "sourcePictureBox";
            this.sourcePictureBox.Size = new System.Drawing.Size(288, 214);
            this.sourcePictureBox.TabIndex = 1;
            this.sourcePictureBox.TabStop = false;
            // 
            // coloredPictureBox
            // 
            this.coloredPictureBox.Location = new System.Drawing.Point(331, 34);
            this.coloredPictureBox.Name = "coloredPictureBox";
            this.coloredPictureBox.Size = new System.Drawing.Size(288, 214);
            this.coloredPictureBox.TabIndex = 2;
            this.coloredPictureBox.TabStop = false;
            // 
            // radiusPictureBox
            // 
            this.radiusPictureBox.Location = new System.Drawing.Point(653, 34);
            this.radiusPictureBox.Name = "radiusPictureBox";
            this.radiusPictureBox.Size = new System.Drawing.Size(288, 214);
            this.radiusPictureBox.TabIndex = 3;
            this.radiusPictureBox.TabStop = false;
            // 
            // contourLabel
            // 
            this.contourLabel.AutoSize = true;
            this.contourLabel.Location = new System.Drawing.Point(40, 459);
            this.contourLabel.Name = "contourLabel";
            this.contourLabel.Size = new System.Drawing.Size(63, 17);
            this.contourLabel.TabIndex = 4;
            this.contourLabel.Text = "contours";
            // 
            // coordinateLabel
            // 
            this.coordinateLabel.AutoSize = true;
            this.coordinateLabel.Location = new System.Drawing.Point(328, 459);
            this.coordinateLabel.Name = "coordinateLabel";
            this.coordinateLabel.Size = new System.Drawing.Size(82, 17);
            this.coordinateLabel.TabIndex = 5;
            this.coordinateLabel.Text = "coordinates";
            // 
            // returnedPointLbl
            // 
            this.returnedPointLbl.AutoSize = true;
            this.returnedPointLbl.Location = new System.Drawing.Point(625, 348);
            this.returnedPointLbl.Name = "returnedPointLbl";
            this.returnedPointLbl.Size = new System.Drawing.Size(78, 17);
            this.returnedPointLbl.TabIndex = 6;
            this.returnedPointLbl.Text = "returnPoint";
            // 
            // lockStateToolStripStatusLabel
            // 
            this.lockStateToolStripStatusLabel.AutoSize = true;
            this.lockStateToolStripStatusLabel.Location = new System.Drawing.Point(664, 459);
            this.lockStateToolStripStatusLabel.Name = "lockStateToolStripStatusLabel";
            this.lockStateToolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.lockStateToolStripStatusLabel.TabIndex = 7;
            this.lockStateToolStripStatusLabel.Text = "state";
            // 
            // yInput
            // 
            this.yInput.Location = new System.Drawing.Point(841, 367);
            this.yInput.Name = "yInput";
            this.yInput.Size = new System.Drawing.Size(100, 22);
            this.yInput.TabIndex = 8;
            // 
            // xInput
            // 
            this.xInput.Location = new System.Drawing.Point(841, 319);
            this.xInput.Name = "xInput";
            this.xInput.Size = new System.Drawing.Size(100, 22);
            this.xInput.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(814, 321);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(814, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Y:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 541);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.xInput);
            this.Controls.Add(this.yInput);
            this.Controls.Add(this.lockStateToolStripStatusLabel);
            this.Controls.Add(this.returnedPointLbl);
            this.Controls.Add(this.coordinateLabel);
            this.Controls.Add(this.contourLabel);
            this.Controls.Add(this.radiusPictureBox);
            this.Controls.Add(this.coloredPictureBox);
            this.Controls.Add(this.sourcePictureBox);
            this.Controls.Add(this.sendBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coloredPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radiusPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.PictureBox sourcePictureBox;
        private System.Windows.Forms.PictureBox coloredPictureBox;
        private System.Windows.Forms.PictureBox radiusPictureBox;
        private System.Windows.Forms.Label contourLabel;
        private System.Windows.Forms.Label coordinateLabel;
        private System.Windows.Forms.Label returnedPointLbl;
        private System.Windows.Forms.Label lockStateToolStripStatusLabel;
        private System.Windows.Forms.TextBox yInput;
        private System.Windows.Forms.TextBox xInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

