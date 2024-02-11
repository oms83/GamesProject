using System;
using System.Data;
using System.Windows.Forms;

namespace Games_Project
{
    public partial class frmDashboard : Form
    {
        public clsUser User;

        private clsUser UserManages;
        private clsGamesResult gamesResult;
        private clsRegisteredGame registeredGame;
        private clsPermission Permission;
        public frmDashboard(clsUser _User)
        {
            InitializeComponent();
            User = _User;
            _FillGameDetailsInComboBox();
            _ShowUserInfo();
            _RefereshUsersDetails();
            _InitializeDashboard();
        }

        private void _InitializeDashboard()
        {
            _VisableButtons(false);
        }

        private void _RefereshUsersDetails()
        {
            dataGridView1.DataSource = clsUserManages.GetAllUsersDetailsForAdmin();
        }

        private void _FillGameDetailsInComboBox()
        {
            DataTable Games = clsGames.GetAllGames();
            DataTable GameTyps = clsGamesType.GetAllGamesType();

            foreach(DataRow Row in Games.Rows)
            {
                cmbGame.Items.Add(Row["GameName"]);
            }

            foreach (DataRow Row in GameTyps.Rows)
            {
                cmbGameType.Items.Add(Row["TypeName"]);
            }
        }

        private void _ShowUserName()
        {
            lblFullName.Text = User.FirstName + " " + User.LastName;

        }

        private void _ShowUserPicture()
        {
            if (User.ImagePath != "")
            {
                pbImage.ImageLocation = User.ImagePath;
            }
        }
        
        private void _ShowUserInfo()
        {
            _ShowUserName();
            _ShowUserPicture();
        }

        private bool _CheckToPermissions(int Value)
        {
            return (User.Permissions & Value) == Value;
        }

        private void btnListAll_Click(object sender, EventArgs e)
        {
            if (_CheckToPermissions(clsPermission.Find("ListAllUsers").Value))
            {
                frmListAllUsers frm = new frmListAllUsers(User);
                frm.ShowDialog();
                User = clsUser.Find(User.ID);
                _ShowUserPicture();
            }
            else
            {
                MessageBox.Show("Access Denied! Contact Your Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (_CheckToPermissions(clsPermission.Find("AddNewUser").Value))
            {
                frmAddNewEdit frm = new frmAddNewEdit(-1, false);
                frm.ShowDialog();
                _RefereshUsersDetails();
            }
            else
            {
                MessageBox.Show("Access Denied! Contact Your Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
       
        private void cmsEdit_Click(object sender, EventArgs e)
        {
            if (_CheckToPermissions(clsPermission.Find("UpdateUser").Value))
            {
                int UserID = (int)dataGridView1.CurrentRow.Cells[0].Value;
                frmAddNewEdit frm = new frmAddNewEdit(UserID, false);
                frm.ShowDialog();
                _ShowUserPicture();
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
        private void cmsDelete_Click(object sender, EventArgs e)
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
        
        private void _RegisteredUserInTheGame(int GameID)
        {
            clsUserManages UserManages = clsUserManages.GetGameDetails(User.ID, GameID);


            if (UserManages == null)
            {
                gamesResult = new clsGamesResult();
                registeredGame = new clsRegisteredGame();


                gamesResult.GameID = GameID;
                gamesResult.WinningTimes = 0;
                gamesResult.LossTimes = 0;
                gamesResult.PlayTimes = 0;


                if(gamesResult.Save())
                {
                    MessageBox.Show("The game result has been successfully initialized for the new user", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    registeredGame.GameID = GameID;
                    registeredGame.UserID = User.ID;
                    registeredGame.RegisteredDate = DateTime.Now;
                    registeredGame.ResultID = gamesResult.ResultID;

                    if(registeredGame.Save())
                    {
                        MessageBox.Show("The user has been successfully registered in the game", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("The user has not been successfully registered in the game", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The game result has not been successfully initialized for the new user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                registeredGame = clsRegisteredGame.Find(UserManages.RegisteredID);

                gamesResult = clsGamesResult.Find(UserManages.ResultID);

                //label2.Text = UserManages.RegisteredID.ToString();
                //label3.Text = UserManages.ResultID.ToString();
                lblFullName.Text = User.FirstName + " " + User.LastName ;
            }

            
        }
        
        private void btnMathGame_Click(object sender, EventArgs e)
        {
            _RegisteredUserInTheGame(5);
            frmMathGame frm = new frmMathGame(ref User, ref registeredGame, ref gamesResult);
            frm.ShowDialog();
            _RefereshUsersDetails();

        }

        private void btnMemoryGame_Click(object sender, EventArgs e)
        {
            _RegisteredUserInTheGame(4);
            frmMemoryGame frm = new frmMemoryGame(ref User, ref registeredGame, ref gamesResult);
            frm.ShowDialog();
            _RefereshUsersDetails();
        }

        private void _VisableButtons(bool Status)
        {
            foreach(Button btn in pnlGames.Controls)
            {
                btn.Visible = Status;
            }
        }

        private void btnXOGame_Click(object sender, EventArgs e)
        {
            _RegisteredUserInTheGame(3);
            frmXOGame frm = new frmXOGame(ref User, ref registeredGame, ref gamesResult);
            frm.ShowDialog();
            _RefereshUsersDetails();

        }

        private void _FilteringByGameTypeName()
        {
            cmbGame.Text = "";
            if(clsGamesType.Find(cmbGameType.Text).TypeName == "IQ")
            {
                _VisableButtons(false);
                btnMemoryGame.Visible = true;
                return;
            }
            if (clsGamesType.Find(cmbGameType.Text).TypeName == "Mathematical")
            {
                _VisableButtons(false);
                btnMathGame.Visible = true; 
                return;
            }
            if (clsGamesType.Find(cmbGameType.Text).TypeName == "Challenge")
            {
                _VisableButtons(false);
                btnXOGame.Visible = true;
                return;
            }
        }

        private void cmbGameType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilteringByGameTypeName();
        }

        private void _FilteringByGameName()
        {
            cmbGameType.Text = "";
            if (clsGames.Find(cmbGame.Text).GameName == "XO Game")
            {
                _VisableButtons(false);
                btnXOGame.Visible = true;
                return;
            }
            if (clsGames.Find(cmbGame.Text).GameName == "Memory Game")
            {
                _VisableButtons(false);
                btnMemoryGame.Visible = true;
                return;
            }
            if (clsGames.Find(cmbGame.Text).GameName == "Math Game")
            {
                _VisableButtons(false);
                btnMathGame.Visible = true;
                return;
            }
        }
        
        private void cmbGame_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilteringByGameName();
        }

    }
}
