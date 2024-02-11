using Games_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Games_Project
{
    public partial class frmLogin : Form
    {
        public clsUser User;
        bool Temp;

        public frmLogin()
        {
            InitializeComponent();
            rdUserName.Checked = true;
            _LoginMessageEnabelDisable(false);
            Temp = true;
        }


        private short NumberOfLoginTimes = 3;

        private void _LoginMessageEnabelDisable(bool Status)
        {
            lblLoginMessage.Visible = Status;
            lblTrailsMessage.Visible = Status;
        }
       
        private void _SetLoginTrailsMessage()
        {
            _LoginMessageEnabelDisable(true);
            NumberOfLoginTimes--;
            lblLoginMessage.Text = "Invalid Username Or Email Or Password";
            lblTrailsMessage.Text = "You Have " + NumberOfLoginTimes.ToString() + " Trial(s)";
            if(NumberOfLoginTimes == 0 )
            {
                if(MessageBox.Show
                 (@"This form will be canceled because you have exceeded your attempts", 
                    "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) 
                     == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }
       
        private void btnLogin_Click(object sender, EventArgs e)
        {

            if(rdUserName.Checked == true)
            {
                User = clsUser.Find(txtUserNameEmail.Text);
            }

            if(rdEmail.Checked == true)
            {
                User = clsUser.FindByEmail(txtUserNameEmail.Text);
            }

            if(User != null)
            {
                
                if( (User.UserName == txtUserNameEmail.Text && User.Password == txtPassword.Text) ||
                    (User.Email == txtUserNameEmail.Text && User.Password == txtPassword.Text) )
                {
                    frmDashboard frm = new frmDashboard(User);
                    frm.ShowDialog();
                    llRegister.Enabled = false;
                }
                else
                {
                    _SetLoginTrailsMessage();
                    MessageBox.Show("Invalid Username Or Email Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                _SetLoginTrailsMessage();
                MessageBox.Show($"User {txtUserNameEmail.Text} Not Found", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //frmRegister frm = new frmRegister(-1);
            //frm.ShowDialog();

            frmAddNewEdit frm = new frmAddNewEdit(-1, true);
            frm.ShowDialog();
        }

        private void rdUserName_CheckedChanged(object sender, EventArgs e)
        {
                label1.Text = "User Name";
        }

        private void rdEmail_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Email";
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            if(Temp)
            {
                txtPassword.UseSystemPasswordChar = true;
                btnShowPassword.BackgroundImage = Resources.eye;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
                btnShowPassword.BackgroundImage = Resources.eyelashes;
            }
            Temp = !Temp;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
