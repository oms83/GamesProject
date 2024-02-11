namespace Games_Project
{
    partial class frmDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDashboard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnListAll = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.lblFullName = new System.Windows.Forms.Label();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbGame = new System.Windows.Forms.ComboBox();
            this.cmbGameType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMemoryGame = new System.Windows.Forms.Button();
            this.btnXOGame = new System.Windows.Forms.Button();
            this.btnMathGame = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmsUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlGames = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.cmsUsers.SuspendLayout();
            this.pnlGames.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnListAll);
            this.panel1.Controls.Add(this.btnAddNew);
            this.panel1.Controls.Add(this.lblFullName);
            this.panel1.Controls.Add(this.pbImage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(206, 791);
            this.panel1.TabIndex = 0;
            // 
            // btnListAll
            // 
            this.btnListAll.BackColor = System.Drawing.Color.Black;
            this.btnListAll.Font = new System.Drawing.Font("Cascadia Code", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListAll.ForeColor = System.Drawing.Color.White;
            this.btnListAll.Location = new System.Drawing.Point(25, 403);
            this.btnListAll.Name = "btnListAll";
            this.btnListAll.Size = new System.Drawing.Size(157, 46);
            this.btnListAll.TabIndex = 6;
            this.btnListAll.Text = "List All";
            this.btnListAll.UseVisualStyleBackColor = false;
            this.btnListAll.Click += new System.EventHandler(this.btnListAll_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.Black;
            this.btnAddNew.Font = new System.Drawing.Font("Cascadia Code", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.ForeColor = System.Drawing.Color.White;
            this.btnAddNew.Location = new System.Drawing.Point(25, 318);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(157, 46);
            this.btnAddNew.TabIndex = 5;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Cascadia Code", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.Location = new System.Drawing.Point(35, 241);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(65, 37);
            this.lblFullName.TabIndex = 1;
            this.lblFullName.Text = "---";
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(30, 49);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(146, 170);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.cmbGame);
            this.panel2.Controls.Add(this.cmbGameType);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(206, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(966, 159);
            this.panel2.TabIndex = 1;
            // 
            // cmbGame
            // 
            this.cmbGame.Font = new System.Drawing.Font("Cascadia Code", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGame.FormattingEnabled = true;
            this.cmbGame.Location = new System.Drawing.Point(536, 65);
            this.cmbGame.Name = "cmbGame";
            this.cmbGame.Size = new System.Drawing.Size(211, 32);
            this.cmbGame.TabIndex = 3;
            this.cmbGame.SelectedIndexChanged += new System.EventHandler(this.cmbGame_SelectedIndexChanged);
            // 
            // cmbGameType
            // 
            this.cmbGameType.Font = new System.Drawing.Font("Cascadia Code", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGameType.FormattingEnabled = true;
            this.cmbGameType.Location = new System.Drawing.Point(153, 65);
            this.cmbGameType.Name = "cmbGameType";
            this.cmbGameType.Size = new System.Drawing.Size(211, 32);
            this.cmbGameType.TabIndex = 2;
            this.cmbGameType.SelectedIndexChanged += new System.EventHandler(this.cmbGameType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Code", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(463, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Games";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Code", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Games Type";
            // 
            // btnMemoryGame
            // 
            this.btnMemoryGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMemoryGame.BackgroundImage")));
            this.btnMemoryGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMemoryGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemoryGame.Location = new System.Drawing.Point(492, 37);
            this.btnMemoryGame.Name = "btnMemoryGame";
            this.btnMemoryGame.Size = new System.Drawing.Size(183, 160);
            this.btnMemoryGame.TabIndex = 4;
            this.btnMemoryGame.UseVisualStyleBackColor = true;
            this.btnMemoryGame.Click += new System.EventHandler(this.btnMemoryGame_Click);
            // 
            // btnXOGame
            // 
            this.btnXOGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnXOGame.BackgroundImage")));
            this.btnXOGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnXOGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXOGame.Location = new System.Drawing.Point(250, 37);
            this.btnXOGame.Name = "btnXOGame";
            this.btnXOGame.Size = new System.Drawing.Size(183, 160);
            this.btnXOGame.TabIndex = 3;
            this.btnXOGame.UseVisualStyleBackColor = true;
            this.btnXOGame.Click += new System.EventHandler(this.btnXOGame_Click);
            // 
            // btnMathGame
            // 
            this.btnMathGame.BackgroundImage = global::Games_Project.Properties.Resources.maths2;
            this.btnMathGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMathGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMathGame.Location = new System.Drawing.Point(8, 37);
            this.btnMathGame.Name = "btnMathGame";
            this.btnMathGame.Size = new System.Drawing.Size(183, 160);
            this.btnMathGame.TabIndex = 2;
            this.btnMathGame.UseVisualStyleBackColor = true;
            this.btnMathGame.Click += new System.EventHandler(this.btnMathGame_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.cmsUsers;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(206, 595);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(966, 196);
            this.dataGridView1.TabIndex = 5;
            // 
            // cmsUsers
            // 
            this.cmsUsers.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsEdit,
            this.cmsDelete});
            this.cmsUsers.Name = "cmsUsers";
            this.cmsUsers.Size = new System.Drawing.Size(123, 52);
            // 
            // cmsEdit
            // 
            this.cmsEdit.Name = "cmsEdit";
            this.cmsEdit.Size = new System.Drawing.Size(122, 24);
            this.cmsEdit.Text = "Edit";
            this.cmsEdit.Click += new System.EventHandler(this.cmsEdit_Click);
            // 
            // cmsDelete
            // 
            this.cmsDelete.Name = "cmsDelete";
            this.cmsDelete.Size = new System.Drawing.Size(122, 24);
            this.cmsDelete.Text = "Delete";
            this.cmsDelete.Click += new System.EventHandler(this.cmsDelete_Click);
            // 
            // pnlGames
            // 
            this.pnlGames.Controls.Add(this.btnMemoryGame);
            this.pnlGames.Controls.Add(this.btnXOGame);
            this.pnlGames.Controls.Add(this.btnMathGame);
            this.pnlGames.Location = new System.Drawing.Point(333, 224);
            this.pnlGames.Name = "pnlGames";
            this.pnlGames.Size = new System.Drawing.Size(704, 246);
            this.pnlGames.TabIndex = 6;
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1172, 791);
            this.Controls.Add(this.pnlGames);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDashboard";
            this.Text = "frmDashboard";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.cmsUsers.ResumeLayout(false);
            this.pnlGames.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnMathGame;
        private System.Windows.Forms.Button btnXOGame;
        private System.Windows.Forms.Button btnMemoryGame;
        private System.Windows.Forms.Button btnListAll;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.ComboBox cmbGame;
        private System.Windows.Forms.ComboBox cmbGameType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip cmsUsers;
        private System.Windows.Forms.ToolStripMenuItem cmsEdit;
        private System.Windows.Forms.ToolStripMenuItem cmsDelete;
        private System.Windows.Forms.Panel pnlGames;
    }
}