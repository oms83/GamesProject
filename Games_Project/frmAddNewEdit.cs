using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Games_Project
{
    public partial class frmAddNewEdit : Form
    {
        private clsUser _User;

        private int _Permissions = 0;
        private enum enMode { AddNew, Update };

        private enMode _Mode;

        private int _UserID;

        private bool _isRegisterForm = false;
        
        public frmAddNewEdit(int userID, bool isRegisterForm)
        {
            InitializeComponent();
            _UserID = userID;
            _isRegisterForm = isRegisterForm;

            if(_isRegisterForm)
                gbPermissions.Visible = false;


            if(_UserID > -1)
            {
                lblMode.Text = "Edit User " + userID.ToString();
                _Mode = enMode.Update;
            }
            else
            {
                _Mode = enMode.AddNew;
            }
            _FillAllCountries();
            _Load();
        }

        private void _FillAllCountries()
        {
            DataTable Country = clsCountry.GetAllCountries();

            foreach (DataRow Row in Country.Rows)
            {
                cmbCountry.Items.Add(Row["CountryName"]);
            }
        }

        private void _LoadPermission()
        {
            int Value = Convert.ToInt32(cbAddNew.Tag);

            if ((_User.Permissions & Value) == Value)
                cbAddNew.Checked = true;



            Value = Convert.ToInt32(cbUpdate.Tag);
            
            if ((_User.Permissions & Value) == Value)
                cbUpdate.Checked = true;



            Value = Convert.ToInt32(cbListAll.Tag);
            
            if ((_User.Permissions & Value) == Value)
                cbListAll.Checked = true;
            


            Value = Convert.ToInt32(cbDelete.Tag);

            if ((_User.Permissions & Value) == Value)
                cbDelete.Checked = true;

        }
        
        private void _Load()
        {
            if(_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New User";
                _User = new clsUser();
                return;
            }

            _User = clsUser.Find(_UserID);

            if( _User == null )
            {
                MessageBox.Show("This From Will Be Cancel Because User is Deleted","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            lblUserID.Text = _User.ID.ToString();
            lblMode.Text = "Edit Mode UserID  " + _User.ID.ToString();
            txtFirstName.Text = _User.FirstName;
            txtLastName.Text = _User.LastName;
            txtEmail.Text = _User.Email;
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtPhone.Text = _User.Phone;    
            dtpBirthOfDate.Value = _User.BirthOfDate;

            if (!_isRegisterForm)
                _LoadPermission();


            if (_User.ImagePath != "")
            {
                pbImage.ImageLocation = _User.ImagePath;
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
            _User.BirthOfDate = dtpBirthOfDate.Value;
            
            _User.Permissions = _Permissions;

            if (_isRegisterForm)
            {
                _User.Permissions = 0;
            }

            else
            {
                if (_Permissions == 30)
                    _User.Permissions = -1;

                else
                    _User.Permissions = _Permissions;
            }


            if (pbImage.ImageLocation != "")
            {
                _User.ImagePath = pbImage.ImageLocation;
            }
            else
            {
                _User.ImagePath = "";
            }

            if(_User.Save())
            {
                MessageBox.Show("User is Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("User Is Not Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _Mode = enMode.Update;
            lblMode.Text = "Edit Mode UserID  " + _User.ID.ToString();
            lblUserID.Text = _User.ID.ToString();
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
                
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ImagePath = openFileDialog1.FileName;
                pbImage.Load(ImagePath);

            }

            llRemoveIamge.Visible = pbImage.ImageLocation != "";


        }

        private void llRemoveIamge_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImage.ImageLocation = null;
            llRemoveIamge.Visible = false;
        }

        private void _AddPemissions(CheckBox checkBox)
        {
            //if (cbAddNew.Checked)
            //    _Permissions += Convert.ToInt32(cbAddNew.Tag);
            //if (cbUpdate.Checked)
            //    _Permissions += Convert.ToInt32(cbUpdate.Tag);
            //if (cbDelete.Checked)
            //    _Permissions += Convert.ToInt32(cbDelete.Tag);
            //if (cbListAll.Checked)
            //    _Permissions += Convert.ToInt32(cbListAll.Tag);

            if(checkBox.Checked)
                _Permissions += Convert.ToInt32(checkBox.Tag);
            else
                _Permissions -= Convert.ToInt32(checkBox.Tag);

        }

        private void _SetPerissions(object sender, EventArgs e)
        {
            _AddPemissions((CheckBox)(sender));
        }

        private void _SetError(object sender, CancelEventArgs e, string message, params Control[] controls)
        {
            foreach(Control control in controls)
            {
                if(control is TextBox textbox && string.IsNullOrWhiteSpace(textbox.Text))
                {
                    e.Cancel = true;
                    control.Focus();
                    btnSave.Enabled = false;
                    errorProvider1.SetError(control, message + " should have a value");
                }


                if (control is ComboBox comboBox && comboBox.SelectedItem == null)
                {
                    e.Cancel = true;
                    control.Focus();
                    btnSave.Enabled = false;
                    errorProvider1.SetError(control, message + " should have a value");
                }
            }
            btnSave.Enabled = true;
        }
        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _SetError(sender, e, "Email", txtEmail);
            if(clsUser.isUserEmailExist(txtEmail.Text))
            {
                e.Cancel= true;
                txtEmail.Focus();
                btnSave.Enabled = false;
                errorProvider1.SetError(txtEmail, "this email already is exist");
            }
            else
            {
                e.Cancel = false; 
                btnSave.Enabled= true;
            }
        }

        private void txtUserName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _SetError(sender, e, "UserName", txtUserName);
            if (clsUser.isUserExist(txtUserName.Text))
            {
                e.Cancel = true;
                txtEmail.Focus();
                btnSave.Enabled = false;
                errorProvider1.SetError(txtUserName, "this username already is exist");
            }
            else
            {
                e.Cancel = false;
                btnSave.Enabled = true;
            }
        }

        private void txtPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _SetError(sender, e, "Password", txtPassword);
        }

        private void txtPhone_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _SetError(sender, e, "Phone", txtPhone);
            if (clsUser.isUserPhoneExist(txtPhone.Text))
            {
                e.Cancel = true;
                txtEmail.Focus();
                btnSave.Enabled = false;
                errorProvider1.SetError(txtPhone, "this phone number already is exist");
            }
            else
            {
                btnSave.Enabled = true;
                e.Cancel = false;
            }
        }

        private void cmbCountry_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _SetError(sender, e, "Country", cmbCountry);
        }

        private void txtFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _SetError(sender, e, "First Name", txtFirstName);
        }

        private void txtLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _SetError(sender, e, "Last Name", txtLastName);
        }
    }
}
