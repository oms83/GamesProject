using System;
using System.Windows.Forms;

namespace Games_Project
{
    public partial class frmListAllUsers : Form
    {
        private clsUser User;

        public frmListAllUsers(clsUser user)
        {
            InitializeComponent();
            dataGridView1.DataSource = clsUser.GetAllUsers();
            User = user;
        }

        private bool _CheckToPermissions(int Value)
        {
            return (User.Permissions & Value) == Value;
        }
       
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_CheckToPermissions(clsPermission.Find("UpdateUser").Value))
            {
                int UserID = (int)dataGridView1.CurrentRow.Cells[0].Value;
                frmAddNewEdit frm = new frmAddNewEdit(UserID, false);
                frm.ShowDialog();
                _RefereshUsersDetails();
            }
            else
            {
                MessageBox.Show("Access Denied! Contact Your Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool _isUserRegisteredInGame(int GameID, ref clsUserManages UserManages, int UserID)
        {
            UserManages = clsUserManages.GetGameDetails(UserID, GameID);
            return UserManages != null;
        }
        private void _DeleteUserResultsInGames(int GameID, int UserID)
        {
            clsUserManages UserManages = new clsUserManages();
            if (_isUserRegisteredInGame(GameID, ref UserManages, UserID))
            {
                clsGamesResult.DeleteGameResult(UserManages.ResultID);
                clsRegisteredGame.DeleteRegistered(UserManages.RegisteredID);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_CheckToPermissions(clsPermission.Find("DeleteUser").Value))
            {
                int UserID = (int)dataGridView1.CurrentRow.Cells[0].Value;

                _DeleteUserResultsInGames(3, UserID);
                _DeleteUserResultsInGames(4, UserID);
                _DeleteUserResultsInGames(5, UserID);

                if (clsUser.Delete(UserID))
                {
                    MessageBox.Show("User Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("User Is Not Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                _RefereshUsersDetails();
            }
            else
            {
                MessageBox.Show("Access Denied! Contact Your Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void _RefereshUsersDetails()
        {
            dataGridView1.DataSource = clsUser.GetAllUsers();
        }
        
    }
}
