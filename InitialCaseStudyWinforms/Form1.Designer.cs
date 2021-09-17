
namespace InitialCaseStudyWinforms
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.PathLabel = new System.Windows.Forms.Label();
            this.DistanceLabel = new System.Windows.Forms.Label();
            this.Evolution = new System.Windows.Forms.Button();
            this.CounterLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 600);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Location = new System.Drawing.Point(702, 19);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(36, 17);
            this.PathLabel.TabIndex = 1;
            this.PathLabel.Text = "Test";
            // 
            // DistanceLabel
            // 
            this.DistanceLabel.AutoSize = true;
            this.DistanceLabel.Location = new System.Drawing.Point(702, 59);
            this.DistanceLabel.Name = "DistanceLabel";
            this.DistanceLabel.Size = new System.Drawing.Size(46, 17);
            this.DistanceLabel.TabIndex = 2;
            this.DistanceLabel.Text = "label1";
            // 
            // Evolution
            // 
            this.Evolution.Location = new System.Drawing.Point(705, 161);
            this.Evolution.Name = "Evolution";
            this.Evolution.Size = new System.Drawing.Size(147, 73);
            this.Evolution.TabIndex = 3;
            this.Evolution.Text = "ClickMe";
            this.Evolution.UseVisualStyleBackColor = true;
            this.Evolution.Click += new System.EventHandler(this.Evolution_Click);
            // 
            // CounterLabel
            // 
            this.CounterLabel.AutoSize = true;
            this.CounterLabel.Location = new System.Drawing.Point(705, 95);
            this.CounterLabel.Name = "CounterLabel";
            this.CounterLabel.Size = new System.Drawing.Size(46, 17);
            this.CounterLabel.TabIndex = 4;
            this.CounterLabel.Text = "label1";
            this.CounterLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 692);
            this.Controls.Add(this.CounterLabel);
            this.Controls.Add(this.Evolution);
            this.Controls.Add(this.DistanceLabel);
            this.Controls.Add(this.PathLabel);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label PathLabel;
        private System.Windows.Forms.Label DistanceLabel;
        private System.Windows.Forms.Button Evolution;
        private System.Windows.Forms.Label CounterLabel;
    }
}

