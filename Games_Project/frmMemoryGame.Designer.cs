namespace Games_Project
{
    partial class frmMemoryGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMemoryGame));
            this.lblFullName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblLossTimes = new System.Windows.Forms.Label();
            this.lblWinningTimes = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblGame = new System.Windows.Forms.Label();
            this.lblMemory = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btn16 = new System.Windows.Forms.Button();
            this.btn15 = new System.Windows.Forms.Button();
            this.btn14 = new System.Windows.Forms.Button();
            this.btn13 = new System.Windows.Forms.Button();
            this.btn12 = new System.Windows.Forms.Button();
            this.btn11 = new System.Windows.Forms.Button();
            this.btn10 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Star1 = new System.Windows.Forms.PictureBox();
            this.Star2 = new System.Windows.Forms.PictureBox();
            this.Star3 = new System.Windows.Forms.PictureBox();
            this.Star4 = new System.Windows.Forms.PictureBox();
            this.Star5 = new System.Windows.Forms.PictureBox();
            this.Star6 = new System.Windows.Forms.PictureBox();
            this.Star7 = new System.Windows.Forms.PictureBox();
            this.Star8 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Star1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star8)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Cascadia Code", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.ForeColor = System.Drawing.SystemColors.Window;
            this.lblFullName.Location = new System.Drawing.Point(744, 283);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(81, 37);
            this.lblFullName.TabIndex = 17;
            this.lblFullName.Text = "----";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ravie", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(703, 587);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 38);
            this.label1.TabIndex = 29;
            this.label1.Text = "Loss Times";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Ravie", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(670, 458);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(303, 38);
            this.label5.TabIndex = 30;
            this.label5.Text = "Winning Times";
            // 
            // lblLossTimes
            // 
            this.lblLossTimes.AutoSize = true;
            this.lblLossTimes.Font = new System.Drawing.Font("Ravie", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLossTimes.ForeColor = System.Drawing.Color.Red;
            this.lblLossTimes.Location = new System.Drawing.Point(785, 630);
            this.lblLossTimes.Name = "lblLossTimes";
            this.lblLossTimes.Size = new System.Drawing.Size(71, 57);
            this.lblLossTimes.TabIndex = 31;
            this.lblLossTimes.Text = "--";
            // 
            // lblWinningTimes
            // 
            this.lblWinningTimes.AutoSize = true;
            this.lblWinningTimes.Font = new System.Drawing.Font("Ravie", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinningTimes.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblWinningTimes.Location = new System.Drawing.Point(785, 502);
            this.lblWinningTimes.Name = "lblWinningTimes";
            this.lblWinningTimes.Size = new System.Drawing.Size(71, 57);
            this.lblWinningTimes.TabIndex = 32;
            this.lblWinningTimes.Text = "--";
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Ravie", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.Color.White;
            this.lblTimer.Location = new System.Drawing.Point(715, 375);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(63, 40);
            this.lblTimer.TabIndex = 33;
            this.lblTimer.Text = "60";
            // 
            // lblGame
            // 
            this.lblGame.AutoSize = true;
            this.lblGame.Font = new System.Drawing.Font("Showcard Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGame.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblGame.Location = new System.Drawing.Point(363, 27);
            this.lblGame.Name = "lblGame";
            this.lblGame.Size = new System.Drawing.Size(139, 53);
            this.lblGame.TabIndex = 19;
            this.lblGame.Text = "Game";
            // 
            // lblMemory
            // 
            this.lblMemory.AutoSize = true;
            this.lblMemory.Font = new System.Drawing.Font("Showcard Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemory.ForeColor = System.Drawing.Color.White;
            this.lblMemory.Location = new System.Drawing.Point(141, 27);
            this.lblMemory.Name = "lblMemory";
            this.lblMemory.Size = new System.Drawing.Size(209, 53);
            this.lblMemory.TabIndex = 18;
            this.lblMemory.Text = "Memory";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Chartreuse;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.SystemColors.Window;
            this.btnStart.Location = new System.Drawing.Point(120, 642);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(206, 52);
            this.btnStart.TabIndex = 34;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.Red;
            this.btnRestart.FlatAppearance.BorderSize = 0;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestart.ForeColor = System.Drawing.SystemColors.Window;
            this.btnRestart.Location = new System.Drawing.Point(332, 642);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(206, 52);
            this.btnRestart.TabIndex = 35;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ravie", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(767, 375);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 40);
            this.label2.TabIndex = 36;
            this.label2.Text = "Second";
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(732, 43);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(178, 211);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 16;
            this.pbImage.TabStop = false;
            // 
            // btn16
            // 
            this.btn16.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn16.BackgroundImage")));
            this.btn16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn16.Location = new System.Drawing.Point(323, 334);
            this.btn16.Name = "btn16";
            this.btn16.Size = new System.Drawing.Size(100, 100);
            this.btn16.TabIndex = 15;
            this.btn16.Tag = "java";
            this.btn16.UseVisualStyleBackColor = true;
            this.btn16.Click += new System.EventHandler(this.btnsClick);
            // 
            // btn15
            // 
            this.btn15.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn15.BackgroundImage")));
            this.btn15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn15.Location = new System.Drawing.Point(217, 334);
            this.btn15.Name = "btn15";
            this.btn15.Size = new System.Drawing.Size(100, 100);
            this.btn15.TabIndex = 14;
            this.btn15.Tag = "java";
            this.btn15.UseVisualStyleBackColor = true;
            this.btn15.Click += new System.EventHandler(this.btnsClick);
            // 
            // btn14
            // 
            this.btn14.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn14.BackgroundImage")));
            this.btn14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn14.Location = new System.Drawing.Point(111, 334);
            this.btn14.Name = "btn14";
            this.btn14.Size = new System.Drawing.Size(100, 100);
            this.btn14.TabIndex = 13;
            this.btn14.Tag = "py";
            this.btn14.UseVisualStyleBackColor = true;
            this.btn14.Click += new System.EventHandler(this.btnsClick);
            // 
            // btn13
            // 
            this.btn13.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn13.BackgroundImage")));
            this.btn13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn13.Location = new System.Drawing.Point(5, 334);
            this.btn13.Name = "btn13";
            this.btn13.Size = new System.Drawing.Size(100, 100);
            this.btn13.TabIndex = 12;
            this.btn13.Tag = "py";
            this.btn13.UseVisualStyleBackColor = true;
            this.btn13.Click += new System.EventHandler(this.btnsClick);
            // 
            // btn12
            // 
            this.btn12.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn12.BackgroundImage")));
            this.btn12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn12.Location = new System.Drawing.Point(323, 228);
            this.btn12.Name = "btn12";
            this.btn12.Size = new System.Drawing.Size(100, 100);
            this.btn12.TabIndex = 11;
            this.btn12.Tag = "react";
            this.btn12.UseVisualStyleBackColor = true;
            this.btn12.Click += new System.EventHandler(this.btnsClick);
            // 
            // btn11
            // 
            this.btn11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn11.BackgroundImage")));
            this.btn11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn11.Location = new System.Drawing.Point(217, 228);
            this.btn11.Name = "btn11";
            this.btn11.Size = new System.Drawing.Size(100, 100);
            this.btn11.TabIndex = 10;
            this.btn11.Tag = "react";
            this.btn11.UseVisualStyleBackColor = true;
            this.btn11.Click += new System.EventHandler(this.btnsClick);
            // 
            // btn10
            // 
            this.btn10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn10.BackgroundImage")));
            this.btn10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn10.Location = new System.Drawing.Point(111, 228);
            this.btn10.Name = "btn10";
            this.btn10.Size = new System.Drawing.Size(100, 100);
            this.btn10.TabIndex = 9;
            this.btn10.Tag = "go";
            this.btn10.UseVisualStyleBackColor = true;
            this.btn10.Click += new System.EventHandler(this.btnsClick);
            // 
            // btn9
            // 
            this.btn9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn9.BackgroundImage")));
            this.btn9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn9.Location = new System.Drawing.Point(5, 228);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(100, 100);
            this.btn9.TabIndex = 8;
            this.btn9.Tag = "go";
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new System.EventHandler(this.btnsClick);
            // 
            // btn8
            // 
            this.btn8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn8.BackgroundImage")));
            this.btn8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn8.Location = new System.Drawing.Point(323, 122);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(100, 100);
            this.btn8.TabIndex = 7;
            this.btn8.Tag = "php";
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new System.EventHandler(this.btnsClick);
            // 
            // btn7
            // 
            this.btn7.BackgroundImage = global::Games_Project.Properties.Resources.question;
            this.btn7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn7.Location = new System.Drawing.Point(217, 122);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(100, 100);
            this.btn7.TabIndex = 6;
            this.btn7.Tag = "php";
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.btnsClick);
            // 
            // btn6
            // 
            this.btn6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn6.BackgroundImage")));
            this.btn6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn6.Location = new System.Drawing.Point(111, 122);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(100, 100);
            this.btn6.TabIndex = 5;
            this.btn6.Tag = "cs";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.btnsClick);
            // 
            // btn5
            // 
            this.btn5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn5.BackgroundImage")));
            this.btn5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn5.Location = new System.Drawing.Point(5, 122);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(100, 100);
            this.btn5.TabIndex = 4;
            this.btn5.Tag = "cs";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.btnsClick);
            // 
            // btn4
            // 
            this.btn4.BackgroundImage = global::Games_Project.Properties.Resources.question;
            this.btn4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn4.Location = new System.Drawing.Point(323, 16);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(100, 100);
            this.btn4.TabIndex = 3;
            this.btn4.Tag = "cpp";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.btnsClick);
            // 
            // btn3
            // 
            this.btn3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn3.BackgroundImage")));
            this.btn3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn3.Location = new System.Drawing.Point(217, 16);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(100, 100);
            this.btn3.TabIndex = 2;
            this.btn3.Tag = "cpp";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btnsClick);
            // 
            // btn2
            // 
            this.btn2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn2.BackgroundImage")));
            this.btn2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn2.Location = new System.Drawing.Point(111, 16);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(100, 100);
            this.btn2.TabIndex = 1;
            this.btn2.Tag = "c";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btnsClick);
            // 
            // btn1
            // 
            this.btn1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn1.BackgroundImage")));
            this.btn1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn1.Location = new System.Drawing.Point(5, 16);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(100, 100);
            this.btn1.TabIndex = 0;
            this.btn1.Tag = "c";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btnsClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn16);
            this.panel1.Controls.Add(this.btn15);
            this.panel1.Controls.Add(this.btn14);
            this.panel1.Controls.Add(this.btn13);
            this.panel1.Controls.Add(this.btn12);
            this.panel1.Controls.Add(this.btn11);
            this.panel1.Controls.Add(this.btn10);
            this.panel1.Controls.Add(this.btn9);
            this.panel1.Controls.Add(this.btn8);
            this.panel1.Controls.Add(this.btn7);
            this.panel1.Controls.Add(this.btn6);
            this.panel1.Controls.Add(this.btn5);
            this.panel1.Controls.Add(this.btn4);
            this.panel1.Controls.Add(this.btn3);
            this.panel1.Controls.Add(this.btn2);
            this.panel1.Controls.Add(this.btn1);
            this.panel1.Location = new System.Drawing.Point(115, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 450);
            this.panel1.TabIndex = 37;
            // 
            // Star1
            // 
            this.Star1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Star1.BackgroundImage")));
            this.Star1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Star1.Location = new System.Drawing.Point(8, 5);
            this.Star1.Name = "Star1";
            this.Star1.Size = new System.Drawing.Size(38, 40);
            this.Star1.TabIndex = 21;
            this.Star1.TabStop = false;
            // 
            // Star2
            // 
            this.Star2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Star2.BackgroundImage")));
            this.Star2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Star2.Location = new System.Drawing.Point(62, 5);
            this.Star2.Name = "Star2";
            this.Star2.Size = new System.Drawing.Size(38, 40);
            this.Star2.TabIndex = 22;
            this.Star2.TabStop = false;
            // 
            // Star3
            // 
            this.Star3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Star3.BackgroundImage")));
            this.Star3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Star3.Location = new System.Drawing.Point(116, 5);
            this.Star3.Name = "Star3";
            this.Star3.Size = new System.Drawing.Size(38, 40);
            this.Star3.TabIndex = 23;
            this.Star3.TabStop = false;
            // 
            // Star4
            // 
            this.Star4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Star4.BackgroundImage")));
            this.Star4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Star4.Location = new System.Drawing.Point(170, 5);
            this.Star4.Name = "Star4";
            this.Star4.Size = new System.Drawing.Size(38, 40);
            this.Star4.TabIndex = 24;
            this.Star4.TabStop = false;
            // 
            // Star5
            // 
            this.Star5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Star5.BackgroundImage")));
            this.Star5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Star5.Location = new System.Drawing.Point(224, 5);
            this.Star5.Name = "Star5";
            this.Star5.Size = new System.Drawing.Size(38, 40);
            this.Star5.TabIndex = 25;
            this.Star5.TabStop = false;
            // 
            // Star6
            // 
            this.Star6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Star6.BackgroundImage")));
            this.Star6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Star6.Location = new System.Drawing.Point(278, 5);
            this.Star6.Name = "Star6";
            this.Star6.Size = new System.Drawing.Size(38, 40);
            this.Star6.TabIndex = 26;
            this.Star6.TabStop = false;
            // 
            // Star7
            // 
            this.Star7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Star7.BackgroundImage")));
            this.Star7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Star7.Location = new System.Drawing.Point(332, 5);
            this.Star7.Name = "Star7";
            this.Star7.Size = new System.Drawing.Size(38, 40);
            this.Star7.TabIndex = 27;
            this.Star7.TabStop = false;
            // 
            // Star8
            // 
            this.Star8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Star8.BackgroundImage")));
            this.Star8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Star8.Location = new System.Drawing.Point(386, 5);
            this.Star8.Name = "Star8";
            this.Star8.Size = new System.Drawing.Size(38, 40);
            this.Star8.TabIndex = 28;
            this.Star8.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Star8);
            this.panel2.Controls.Add(this.Star7);
            this.panel2.Controls.Add(this.Star6);
            this.panel2.Controls.Add(this.Star5);
            this.panel2.Controls.Add(this.Star4);
            this.panel2.Controls.Add(this.Star3);
            this.panel2.Controls.Add(this.Star2);
            this.panel2.Controls.Add(this.Star1);
            this.panel2.Location = new System.Drawing.Point(115, 558);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(430, 60);
            this.panel2.TabIndex = 38;
            // 
            // frmMemoryGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1074, 717);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblWinningTimes);
            this.Controls.Add(this.lblLossTimes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblGame);
            this.Controls.Add(this.lblMemory);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.pbImage);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMemoryGame";
            this.Text = "XOGame";
            this.Load += new System.EventHandler(this.frmMemoryGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Star1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star8)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn10;
        private System.Windows.Forms.Button btn11;
        private System.Windows.Forms.Button btn12;
        private System.Windows.Forms.Button btn13;
        private System.Windows.Forms.Button btn14;
        private System.Windows.Forms.Button btn15;
        private System.Windows.Forms.Button btn16;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblLossTimes;
        private System.Windows.Forms.Label lblWinningTimes;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblGame;
        private System.Windows.Forms.Label lblMemory;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox Star1;
        private System.Windows.Forms.PictureBox Star2;
        private System.Windows.Forms.PictureBox Star3;
        private System.Windows.Forms.PictureBox Star4;
        private System.Windows.Forms.PictureBox Star5;
        private System.Windows.Forms.PictureBox Star6;
        private System.Windows.Forms.PictureBox Star7;
        private System.Windows.Forms.PictureBox Star8;
        private System.Windows.Forms.Panel panel2;
    }
}