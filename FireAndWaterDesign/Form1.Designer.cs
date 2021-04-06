
namespace FireAndWaterDesign
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
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.fireLabel = new System.Windows.Forms.Label();
            this.waterLabel = new System.Windows.Forms.Label();
            this.outputLabel = new System.Windows.Forms.Label();
            this.mainLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // fireLabel
            // 
            this.fireLabel.BackColor = System.Drawing.Color.Transparent;
            this.fireLabel.Font = new System.Drawing.Font("Chiller", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fireLabel.ForeColor = System.Drawing.Color.Red;
            this.fireLabel.Location = new System.Drawing.Point(145, 132);
            this.fireLabel.Name = "fireLabel";
            this.fireLabel.Size = new System.Drawing.Size(212, 95);
            this.fireLabel.TabIndex = 0;
            this.fireLabel.Text = "Fireboy";
            this.fireLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // waterLabel
            // 
            this.waterLabel.AutoSize = true;
            this.waterLabel.BackColor = System.Drawing.Color.Transparent;
            this.waterLabel.Font = new System.Drawing.Font("Papyrus", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waterLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.waterLabel.Location = new System.Drawing.Point(479, 155);
            this.waterLabel.Name = "waterLabel";
            this.waterLabel.Size = new System.Drawing.Size(199, 64);
            this.waterLabel.TabIndex = 1;
            this.waterLabel.Text = "Watergirl";
            // 
            // outputLabel
            // 
            this.outputLabel.BackColor = System.Drawing.Color.Transparent;
            this.outputLabel.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputLabel.Location = new System.Drawing.Point(184, 338);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(464, 88);
            this.outputLabel.TabIndex = 2;
            this.outputLabel.Text = "Press Space to Start, Escape to Exit\r\n";
            this.outputLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainLabel
            // 
            this.mainLabel.BackColor = System.Drawing.Color.Transparent;
            this.mainLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainLabel.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLabel.Location = new System.Drawing.Point(327, 151);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(161, 69);
            this.mainLabel.TabIndex = 3;
            this.mainLabel.Text = "and";
            this.mainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.ClientSize = new System.Drawing.Size(782, 542);
            this.Controls.Add(this.mainLabel);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.waterLabel);
            this.Controls.Add(this.fireLabel);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Fireboy and Watergirl";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label fireLabel;
        private System.Windows.Forms.Label waterLabel;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.Label mainLabel;
    }
}

