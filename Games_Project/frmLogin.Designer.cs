namespace Games_Project
{
    partial class frmLogin
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
            this.txtUserNameEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLoginMessage = new System.Windows.Forms.Label();
            this.llRegister = new System.Windows.Forms.LinkLabel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdEmail = new System.Windows.Forms.RadioButton();
            this.rdUserName = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTrailsMessage = new System.Windows.Forms.Label();
            this.btnShowPassword = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUserNameEmail
            // 
            this.txtUserNameEmail.Location = new System.Drawing.Point(501, 176);
            this.txtUserNameEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserNameEmail.Name = "txtUserNameEmail";
            this.txtUserNameEmail.Size = new System.Drawing.Size(275, 29);
            this.txtUserNameEmail.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(501, 239);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(275, 29);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(396, 179);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "--";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(396, 242);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // lblLoginMessage
            // 
            this.lblLoginMessage.AutoSize = true;
            this.lblLoginMessage.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginMessage.ForeColor = System.Drawing.Color.White;
            this.lblLoginMessage.Location = new System.Drawing.Point(496, 353);
            this.lblLoginMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLoginMessage.Name = "lblLoginMessage";
            this.lblLoginMessage.Size = new System.Drawing.Size(36, 20);
            this.lblLoginMessage.TabIndex = 4;
            this.lblLoginMessage.Text = "---";
            // 
            // llRegister
            // 
            this.llRegister.AutoSize = true;
            this.llRegister.Location = new System.Drawing.Point(676, 298);
            this.llRegister.Name = "llRegister";
            this.llRegister.Size = new System.Drawing.Size(98, 24);
            this.llRegister.TabIndex = 5;
            this.llRegister.TabStop = true;
            this.llRegister.Text = "Register";
            this.llRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llRegister_LinkClicked);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(501, 298);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(145, 35);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 521);
            this.panel1.TabIndex = 7;
            // 
            // rdEmail
            // 
            this.rdEmail.AutoSize = true;
            this.rdEmail.ForeColor = System.Drawing.Color.White;
            this.rdEmail.Location = new System.Drawing.Point(189, 13);
            this.rdEmail.Name = "rdEmail";
            this.rdEmail.Size = new System.Drawing.Size(86, 28);
            this.rdEmail.TabIndex = 8;
            this.rdEmail.TabStop = true;
            this.rdEmail.Text = "Email";
            this.rdEmail.UseVisualStyleBackColor = true;
            this.rdEmail.CheckedChanged += new System.EventHandler(this.rdEmail_CheckedChanged);
            // 
            // rdUserName
            // 
            this.rdUserName.AutoSize = true;
            this.rdUserName.ForeColor = System.Drawing.Color.White;
            this.rdUserName.Location = new System.Drawing.Point(3, 13);
            this.rdUserName.Name = "rdUserName";
            this.rdUserName.Size = new System.Drawing.Size(119, 28);
            this.rdUserName.TabIndex = 9;
            this.rdUserName.TabStop = true;
            this.rdUserName.Text = "UserName";
            this.rdUserName.UseVisualStyleBackColor = true;
            this.rdUserName.CheckedChanged += new System.EventHandler(this.rdUserName_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdUserName);
            this.panel2.Controls.Add(this.rdEmail);
            this.panel2.Location = new System.Drawing.Point(501, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(275, 55);
            this.panel2.TabIndex = 10;
            // 
            // lblTrailsMessage
            // 
            this.lblTrailsMessage.AutoSize = true;
            this.lblTrailsMessage.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrailsMessage.ForeColor = System.Drawing.Color.White;
            this.lblTrailsMessage.Location = new System.Drawing.Point(496, 380);
            this.lblTrailsMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTrailsMessage.Name = "lblTrailsMessage";
            this.lblTrailsMessage.Size = new System.Drawing.Size(36, 20);
            this.lblTrailsMessage.TabIndex = 11;
            this.lblTrailsMessage.Text = "---";
            // 
            // btnShowPassword
            // 
            this.btnShowPassword.BackgroundImage = global::Games_Project.Properties.Resources.eye;
            this.btnShowPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnShowPassword.FlatAppearance.BorderSize = 0;
            this.btnShowPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowPassword.Location = new System.Drawing.Point(783, 236);
            this.btnShowPassword.Name = "btnShowPassword";
            this.btnShowPassword.Size = new System.Drawing.Size(30, 29);
            this.btnShowPassword.TabIndex = 12;
            this.btnShowPassword.UseVisualStyleBackColor = true;
            this.btnShowPassword.Click += new System.EventHandler(this.btnShowPassword_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(933, 521);
            this.Controls.Add(this.btnShowPassword);
            this.Controls.Add(this.lblTrailsMessage);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.llRegister);
            this.Controls.Add(this.lblLoginMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserNameEmail);
            this.Font = new System.Drawing.Font("Cascadia Code", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLogin";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserNameEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLoginMessage;
        private System.Windows.Forms.LinkLabel llRegister;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdEmail;
        private System.Windows.Forms.RadioButton rdUserName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTrailsMessage;
        private System.Windows.Forms.Button btnShowPassword;
    }
}

