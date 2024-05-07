namespace InformationSecurity.Forms
{
    partial class CaptchForm
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
            this.pbCaptch = new System.Windows.Forms.PictureBox();
            this.lblEnterCaptch = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbCaptch = new System.Windows.Forms.TextBox();
            this.btnEnterCaptch = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaptch)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCaptch
            // 
            this.pbCaptch.Location = new System.Drawing.Point(25, 91);
            this.pbCaptch.Name = "pbCaptch";
            this.pbCaptch.Size = new System.Drawing.Size(297, 150);
            this.pbCaptch.TabIndex = 0;
            this.pbCaptch.TabStop = false;
            // 
            // lblEnterCaptch
            // 
            this.lblEnterCaptch.AutoSize = true;
            this.lblEnterCaptch.Location = new System.Drawing.Point(12, 267);
            this.lblEnterCaptch.Name = "lblEnterCaptch";
            this.lblEnterCaptch.Size = new System.Drawing.Size(126, 20);
            this.lblEnterCaptch.TabIndex = 1;
            this.lblEnterCaptch.Text = "Введите капчу:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(134, 26);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(60, 20);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Капча";
            // 
            // tbCaptch
            // 
            this.tbCaptch.Location = new System.Drawing.Point(16, 303);
            this.tbCaptch.Name = "tbCaptch";
            this.tbCaptch.Size = new System.Drawing.Size(188, 26);
            this.tbCaptch.TabIndex = 3;
            // 
            // btnEnterCaptch
            // 
            this.btnEnterCaptch.Location = new System.Drawing.Point(16, 371);
            this.btnEnterCaptch.Name = "btnEnterCaptch";
            this.btnEnterCaptch.Size = new System.Drawing.Size(328, 38);
            this.btnEnterCaptch.TabIndex = 4;
            this.btnEnterCaptch.Text = "Подтвердить";
            this.btnEnterCaptch.UseVisualStyleBackColor = true;
            this.btnEnterCaptch.Click += new System.EventHandler(this.btnEnterCaptch_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(215, 257);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(129, 30);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Обновить";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // CaptchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 433);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnEnterCaptch);
            this.Controls.Add(this.tbCaptch);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblEnterCaptch);
            this.Controls.Add(this.pbCaptch);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "CaptchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Капча";
            ((System.ComponentModel.ISupportInitialize)(this.pbCaptch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCaptch;
        private System.Windows.Forms.Label lblEnterCaptch;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox tbCaptch;
        private System.Windows.Forms.Button btnEnterCaptch;
        private System.Windows.Forms.Button btnUpdate;
    }
}