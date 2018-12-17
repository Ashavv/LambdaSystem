namespace Client
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
            this.getSalesButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.yearTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // getSalesButton
            // 
            this.getSalesButton.Location = new System.Drawing.Point(288, 209);
            this.getSalesButton.Name = "getSalesButton";
            this.getSalesButton.Size = new System.Drawing.Size(187, 57);
            this.getSalesButton.TabIndex = 0;
            this.getSalesButton.Text = "Hent antal salg";
            this.getSalesButton.UseVisualStyleBackColor = true;
            this.getSalesButton.Click += new System.EventHandler(this.getSalesButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(330, 353);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(82, 25);
            this.resultLabel.TabIndex = 1;
            this.resultLabel.Text = "Resultat";
            this.resultLabel.Click += new System.EventHandler(this.resultLabel_Click);
            // 
            // yearTextBox
            // 
            this.yearTextBox.Location = new System.Drawing.Point(288, 141);
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.Size = new System.Drawing.Size(187, 29);
            this.yearTextBox.TabIndex = 2;
            this.yearTextBox.Text = "Indtast år (tal tak)";
            this.yearTextBox.TextChanged += new System.EventHandler(this.yearTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hent antal salg for et givent år";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.yearTextBox);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.getSalesButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getSalesButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.TextBox yearTextBox;
        private System.Windows.Forms.Label label1;
    }
}

