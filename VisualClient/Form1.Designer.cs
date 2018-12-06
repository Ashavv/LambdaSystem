namespace VisualClient
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
            this.insertButton = new System.Windows.Forms.Button();
            this.salesNoText = new System.Windows.Forms.TextBox();
            this.batchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // insertButton
            // 
            this.insertButton.Location = new System.Drawing.Point(92, 268);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(152, 68);
            this.insertButton.TabIndex = 0;
            this.insertButton.Text = "Insert Sale";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // salesNoText
            // 
            this.salesNoText.Location = new System.Drawing.Point(92, 152);
            this.salesNoText.Name = "salesNoText";
            this.salesNoText.Size = new System.Drawing.Size(152, 29);
            this.salesNoText.TabIndex = 1;
            this.salesNoText.TextChanged += new System.EventHandler(this.salesNoText_TextChanged);
            // 
            // batchButton
            // 
            this.batchButton.Location = new System.Drawing.Point(377, 268);
            this.batchButton.Name = "batchButton";
            this.batchButton.Size = new System.Drawing.Size(175, 68);
            this.batchButton.TabIndex = 2;
            this.batchButton.Text = "Compute Batch";
            this.batchButton.UseVisualStyleBackColor = true;
            this.batchButton.Click += new System.EventHandler(this.batchButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.batchButton);
            this.Controls.Add(this.salesNoText);
            this.Controls.Add(this.insertButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.TextBox salesNoText;
        private System.Windows.Forms.Button batchButton;
    }
}

