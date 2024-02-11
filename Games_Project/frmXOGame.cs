using System;
using System.Drawing;
using System.Windows.Forms;
using Games_Project.Properties;
using System.Media;
using System.Threading;
using System.Drawing.Printing;

namespace Games_Project
{
    public partial class frmXOGame : Form
    {
        SoundPlayer SoundEffect;


        private clsUser _User;
        private clsRegisteredGame _RegisteredGame;
        private clsGamesResult _GamesResult;

        private struct stGameInfo
        {
            public int Player1Choice;
            public int Player2Choice;
        }

        stGameInfo _GameInfo;

        public frmXOGame(ref clsUser User, ref clsRegisteredGame RegisteredGame, ref clsGamesResult GamesResult)
        {
            InitializeComponent();

            _User = User;
            _GamesResult = GamesResult;
            _RegisteredGame = RegisteredGame;

            _InitializeGame();

        }

        private void _InitializeGame()
        {
            _SetGameInfo();
            _SetUserInfo();
            _EnableDisableControls(false);
            btnRestart.Enabled = false;
        }

        private void frmXOGame_Paint(object sender, PaintEventArgs e)
        {
            Color White = Color.FromArgb(255, 255, 255, 255);
            Pen pen = new Pen(White);

            pen.Width = 15;

            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(pen, 700, 150, 700, 500);
            e.Graphics.DrawLine(pen, 850, 150, 850, 500);

            e.Graphics.DrawLine(pen, 550, 267, 1000, 267);
            e.Graphics.DrawLine(pen, 550, 383, 1000, 383);
        }
        
        private void _ChangeBackgroundColorOfCorrectChoices(Button btn1, Button btn2, Button btn3)
        {
            btn1.BackColor = Color.Chartreuse;
            btn2.BackColor = Color.Chartreuse;
            btn3.BackColor = Color.Chartreuse;
        }
       
        private void _EnableDisableControls(bool ControlStatus)
        {
            foreach(Button button in panel1.Controls)
            {
                button.Enabled = ControlStatus;
            }
        }

        private bool _CheckToChoices(int Value, Button btn1, Button btn2, Button btn3)
        {
            return ( ((Value & Convert.ToInt16(btn1.Tag)) == Convert.ToInt16(btn1.Tag)) && 
                ((Value & Convert.ToInt16(btn2.Tag)) == Convert.ToInt16(btn2.Tag)) && 
                ((Value & Convert.ToInt16(btn3.Tag)) == Convert.ToInt16(btn3.Tag)));
        }
        
        private bool _GameEnd(int PlayerChoice)
        {
            if(_CheckToChoices(PlayerChoice, btn1, btn2, btn3))
            {
                _ChangeBackgroundColorOfCorrectChoices(btn1, btn2, btn3);
                return true;
            }
            if (_CheckToChoices(PlayerChoice, btn4, btn5, btn6))
            {
                _ChangeBackgroundColorOfCorrectChoices(btn4, btn5, btn6);
                return true;
            }
            if (_CheckToChoices(PlayerChoice, btn7, btn8, btn9))
            {
                _ChangeBackgroundColorOfCorrectChoices(btn7, btn8, btn9);
                return true;
            }
            if (_CheckToChoices(PlayerChoice, btn1, btn4, btn7))
            {
                _ChangeBackgroundColorOfCorrectChoices(btn1, btn4, btn7);
                return true;
            }
            if (_CheckToChoices(PlayerChoice, btn2, btn5, btn8))
            {
                _ChangeBackgroundColorOfCorrectChoices(btn2, btn5, btn8);
                return true;
            }
            if (_CheckToChoices(PlayerChoice, btn3, btn6, btn9))
            {
                _ChangeBackgroundColorOfCorrectChoices(btn3, btn6, btn9);
                return true;
            }
            if (_CheckToChoices(PlayerChoice, btn1, btn5, btn9))
            {
                _ChangeBackgroundColorOfCorrectChoices(btn1, btn5, btn9);
                return true;
            }
            if (_CheckToChoices(PlayerChoice, btn3, btn5, btn7))
            {
                _ChangeBackgroundColorOfCorrectChoices(btn3, btn5, btn7);
                return true;
            }
            return false;
        }

        private void _RefereshGameResult()
        {
            _GamesResult.Save();
            _GamesResult = clsGamesResult.Find(_GamesResult.ResultID);
            _SetGameInfo();
        }

        private void _SetEndGameSettings()
        {
            _RefereshGameResult();
            _EnableDisableControls(false);
            btnRestart.Enabled = true;
            _GameInfo.Player1Choice = 0;
            _GameInfo.Player2Choice = 0;
        }


        private short _Choice = 0;

        private void _ShowPictureOfPlayerChoice(Button btn)
        {
            _Choice++;

            if (_Choice % 2 != 0) 
            {
                btn.BackgroundImage = Resources.cs;
                _GameInfo.Player1Choice += Convert.ToInt32(btn.Tag);
                btn.Enabled = false;

                if(_GameEnd(_GameInfo.Player1Choice))
                {
                    _GamesResult.WinningTimes++;
                    _GamesResult.PlayTimes++;
                    _SetEndGameSettings();
                    clsSoundEffect._PlayEndSoundEffect(true);
                    return;
                }
            }
            else
            {
                btn.BackgroundImage = Resources.cppp;
                _GameInfo.Player2Choice += Convert.ToInt32(btn.Tag);
                btn.Enabled = false;

                if (_GameEnd(_GameInfo.Player2Choice))
                {
                    _GamesResult.LossTimes++;
                    _GamesResult.PlayTimes++;
                    _SetEndGameSettings();
                    clsSoundEffect._PlayEndSoundEffect(false);
                    return;
                }
            }

            if (_Choice == 9)
            {
                _GamesResult.PlayTimes++;
                MessageBox.Show("No Winner :-)", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _SetEndGameSettings();
                return;
            }
        }

        private void _SetUserInfo()
        {
            if(_User.ImagePath != "")
                pbImage.ImageLocation = _User.ImagePath;

            lblFullName.Text = _User.FirstName + " " + _User.LastName;
        }

        private void _SetGameInfo()
        {
            lblWinnginTimes.Text = _GamesResult.WinningTimes.ToString(); 
            lblLossTimes.Text = _GamesResult.LossTimes.ToString(); 
        }
        
        private void ChooseChoice(object sender, EventArgs e)
        {
            _ShowPictureOfPlayerChoice((Button)(sender));
        }

        private void _Start()
        {
            _EnableDisableControls(true);
            btnStart.Enabled = false;   
            btnRestart.Enabled = false;
        }
        
        private void btnStart_Click(object sender, EventArgs e)
        {
            _Start();
        }

        private void _ResetPicturesOfChoices()
        {
            foreach(Button btn in panel1.Controls)
            {
                btn.BackgroundImage = Resources.question;
                btn.BackColor = Color.Transparent;
            }
        }
        
        private void _Reset()
        {
            _ResetPicturesOfChoices();
            btnStart.Enabled = true;
            btnRestart.Enabled = false;
            _Choice = 0;
        }
        
        private void btnRestart_Click(object sender, EventArgs e)
        {
            _Reset();
        }
    }
}
