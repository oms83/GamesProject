using System;
using System.Data;
using System.Windows.Forms;

namespace Games_Project
{
    public partial class frmRegister : Form
    {
        private int _UserID;
        
        private clsUser _User;
        private enum _enMode { AddNew, Update };

        _enMode Mode;
        public frmRegister(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            if (_UserID > -1)
            {
                Mode = _enMode.Update;
            }
            else
            {
                lblMode.Text = "Add New Mode";
                Mode = _enMode.AddNew;
            }

            _FillAllCountries();
            _Load();
        }

        private void _FillAllCountries()
        {
            DataTable dataTable = clsCountry.GetAllCountries();
            foreach (DataRow row in dataTable.Rows) 
            {
                cmbCountry.Items.Add(row["CountryName"]);
            }
        }

        private void _Load()
        {
            if(Mode == _enMode.AddNew)
            {
                _User = new clsUser();
                return;
            }

            lblUserID.Text = _User.ID.ToString();
            lblMode.Text = "Edit Mode UserID : " + _User.ID;
            txtEmail.Text = _User.Email;
            txtFirstName.Text = _User.FirstName;
            txtLastName.Text = _User.LastName;
            txtPassword.Text = _User.Password;
            txtPhone.Text = _User.Phone;
            txtUserName.Text = _User.UserName;
            dtpBithOfDate.Value = _User.BirthOfDate;

            if(_User.ImagePath != "")
            {
                pbImage.ImageLocation = _User.ImagePath;
            }
            else
            {
                pbImage.ImageLocation = "";
            }

            cmbCountry.SelectedIndex = cmbCountry.FindString(clsCountry.Find(_User.CountryID).CountryName);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            int CountryID = clsCountry.Find(cmbCountry.Text).CountryID;

            _User.FirstName = txtFirstName.Text;
            _User.LastName = txtLastName.Text;
            _User.Email = txtEmail.Text;
            _User.UserName = txtUserName.Text;
            _User.Password = txtPassword.Text;
            _User.Phone = txtPhone.Text;
            _User.CountryID = CountryID;
            _User.BirthOfDate = dtpBithOfDate.Value;
            _User.Permissions = 0;

            if (pbImage != null)
            {
                _User.ImagePath = pbImage.ImageLocation;
            }
            else
            {
                _User.ImagePath = "";
            }

            if (_User.Save())
            {
                MessageBox.Show("User is Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("User Is Not Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Mode = _enMode.Update;
            lblMode.Text = "Edit Mode UserID  " + _User.ID.ToString();
            lblUserID.Text = _User.ID.ToString();
        }

        private void llRemoveIamge_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImage.ImageLocation = null;
            llRemoveIamge.Visible = false;
        }

        private void llSetIamge_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Images File|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ImagePath = openFileDialog1.FileName;
                pbImage.Load(ImagePath);

            }

            llRemoveIamge.Visible = pbImage.ImageLocation != "";
        }
    }
}
