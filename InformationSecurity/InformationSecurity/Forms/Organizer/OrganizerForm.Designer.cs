namespace InformationSecurity.Forms.Organizer
{
    partial class OrganizerForm
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnEvents = new System.Windows.Forms.Button();
            this.btnParticipants = new System.Windows.Forms.Button();
            this.btnJuries = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(605, 94);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(214, 31);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(176, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Окно Организатора";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(324, 113);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(154, 20);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Добро пожаловать";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(324, 144);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(154, 20);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Добро пожаловать";
            // 
            // pbPhoto
            // 
            this.pbPhoto.Location = new System.Drawing.Point(12, 102);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(171, 199);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPhoto.TabIndex = 3;
            this.pbPhoto.TabStop = false;
            // 
            // btnProfile
            // 
            this.btnProfile.Location = new System.Drawing.Point(31, 332);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(124, 47);
            this.btnProfile.TabIndex = 4;
            this.btnProfile.Text = "Мой профиль";
            this.btnProfile.UseVisualStyleBackColor = true;
            // 
            // btnEvents
            // 
            this.btnEvents.Location = new System.Drawing.Point(249, 184);
            this.btnEvents.Name = "btnEvents";
            this.btnEvents.Size = new System.Drawing.Size(293, 80);
            this.btnEvents.TabIndex = 5;
            this.btnEvents.Text = "Мероприятия";
            this.btnEvents.UseVisualStyleBackColor = true;
            // 
            // btnParticipants
            // 
            this.btnParticipants.Location = new System.Drawing.Point(249, 270);
            this.btnParticipants.Name = "btnParticipants";
            this.btnParticipants.Size = new System.Drawing.Size(293, 80);
            this.btnParticipants.TabIndex = 6;
            this.btnParticipants.Text = "Участники";
            this.btnParticipants.UseVisualStyleBackColor = true;
            // 
            // btnJuries
            // 
            this.btnJuries.Location = new System.Drawing.Point(249, 356);
            this.btnJuries.Name = "btnJuries";
            this.btnJuries.Size = new System.Drawing.Size(293, 80);
            this.btnJuries.TabIndex = 7;
            this.btnJuries.Text = "Жюри";
            this.btnJuries.UseVisualStyleBackColor = true;
            this.btnJuries.Click += new System.EventHandler(this.btnJuries_Click);
            // 
            // OrganizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 456);
            this.Controls.Add(this.btnJuries);
            this.Controls.Add(this.btnParticipants);
            this.Controls.Add(this.btnEvents);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.pbPhoto);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "OrganizerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrganizerForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrganizerForm_FormClosing);
            this.Load += new System.EventHandler(this.OrganizerForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnEvents;
        private System.Windows.Forms.Button btnParticipants;
        private System.Windows.Forms.Button btnJuries;
    }
}