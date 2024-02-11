using Games_Project.Properties;
using System;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace Games_Project
{

    public partial class frmMemoryGame : Form
    {
        clsUser _User;

        SoundPlayer SoundEffect;

        private int Timer =60;

        Button[] arrButtons = new Button[16];
        Button[] arrCurrentButtons = new Button[2];

        public clsGamesResult GamesResult;
        public clsRegisteredGame RegisteredGame;

        public struct stUserGameInfo
        {
            public int WinningTimes;
            public int LossTimes;
            public int PlayTimes;
            public int CorrectStates;
            public DateTime RegisteredDate;
        }


        public stUserGameInfo UserGameInfo;


        private bool _isFirstClick = true;

        public frmMemoryGame(ref clsUser User,ref clsRegisteredGame registeredGame, ref clsGamesResult gamesResult)
        {
            InitializeComponent();
            _User = User;
            GamesResult = gamesResult;
            RegisteredGame = registeredGame;
            _InitializeGame();
        }

        private void _InitializeGame()
        {
            _FillButtonsInArray();
            _ShufleGameButtons(arrButtons);
            _ShowUserInfo();
            _HideScorePictures(false);
            _DisableControls(false);
            btnRestart.Enabled = false;
            _ShowGameResults();
        }

        private void _FillButtonsInArray()
        {
            arrButtons[0] = btn1;
            arrButtons[1] = btn2;
            arrButtons[2] = btn3;
            arrButtons[3] = btn4;
            arrButtons[4] = btn5;
            arrButtons[5] = btn6;
            arrButtons[6] = btn7;
            arrButtons[7] = btn8;
            arrButtons[8] = btn9;
            arrButtons[9] = btn10;
            arrButtons[10] = btn11;
            arrButtons[11] = btn12;
            arrButtons[12] = btn13;
            arrButtons[13] = btn14;
            arrButtons[14] = btn15;
            arrButtons[15] = btn16;
        }

        private void _Swap(ref Button btn1, ref Button btn2)
        {
            Button Temp = new Button();
            Temp.Tag = btn1.Tag;
            btn1.Tag = btn2.Tag;
            btn2.Tag = Temp.Tag;
        }

        private void _ShufleGameButtons(Button[] arrButtons)
        {
            Random rand = new Random();
            int Length = arrButtons.Length - 1;
            for (short i=0; i< Length; i++)
            {
                _Swap(ref arrButtons[rand.Next(0, Length)], ref arrButtons[rand.Next(0, Length)]);
            }
        }

        private void frmMemoryGame_Load(object sender, EventArgs e)
        {
            pbImage.ImageLocation = _User.ImagePath;
            lblFullName.Text = _User.FirstName + " " + _User.LastName;
        }

        private void _SetGameImages(Button btn)
        {
            switch (btn.Tag)
            {
                case "c":
                    btn.BackgroundImage = Resources.c;
                    break;
                case "cpp":
                    btn.BackgroundImage = Resources.cppp;
                    break;
                case "cs":
                    btn.BackgroundImage = Resources.cs;
                    break;
                case "php":
                    btn.BackgroundImage = Resources.php;
                    break;
                case "py":
                    btn.BackgroundImage = Resources.py;
                    break;
                case "java":
                    btn.BackgroundImage = Resources.java;
                    break;
                case "go":
                    btn.BackgroundImage = Resources.go;
                    break;
                case "react":
                    btn.BackgroundImage = Resources.react;
                    break;
            }
        }

        private void _DisableControls(bool ControlStauts)
        {
            foreach(Button button in panel1.Controls)
            {
                button.Enabled = ControlStauts;
            }
        }

        private void _HideScorePictures(bool  ControlStauts)
        {
            foreach(PictureBox pictureBox in panel2.Controls)
            {
                pictureBox.Visible = ControlStauts;
            }
        }

        private void _ShowScorePictures()
        {
            switch (++UserGameInfo.CorrectStates)
            {
                case 1:
                    Star1.Visible = true;
                    break;
                case 2:
                    Star2.Visible = true;
                    break;
                case 3:
                    Star3.Visible = true;
                    break;
                case 4:
                    Star4.Visible = true;
                    break;
                case 5:
                    Star5.Visible = true;
                    break;
                case 6:
                    Star6.Visible = true;
                    break;
                case 7:
                    Star7.Visible = true;
                    break;
                case 8:
                    Star8.Visible = true;
                    break;
            }

        }

        private void _EndGame()
        {
            if (UserGameInfo.CorrectStates == 8)
            {
                GamesResult.PlayTimes++;
                GamesResult.WinningTimes++;
                timer1.Stop();
                GamesResult.Save();
                clsSoundEffect._PlayEndSoundEffect(true);
                btnRestart.Enabled = true;
                GamesResult = clsGamesResult.Find(GamesResult.ResultID);
                _ShowGameResults();
            }


            if (Timer == 0)
            {
                
                GamesResult.PlayTimes++;
                GamesResult.LossTimes++;
                timer1.Stop();
                GamesResult.Save();
                clsSoundEffect._PlayEndSoundEffect(false);
                btnRestart.Enabled = true;
                GamesResult = clsGamesResult.Find(GamesResult.ResultID);
                _ShowGameResults();
            }

        }

        private void _CheckIfButtonMatch(Button button1, Button button2)
        {
            if(_isButtonTagEqual(button1, button2))
            {
                _ShowScorePictures();
                button1.Enabled = false;
                button2.Enabled = false;
                _EndGame();
                
            }
            else
            {
                button1.BackgroundImage = Resources.question;
                button2.Refresh();
                Thread.Sleep(1000);
                button2.BackgroundImage = Resources.question;
            }
        }

        private bool _isButtonTagEqual(Button btn1, Button btn2)
        {
            return btn1.Tag == btn2.Tag;
        }

        private void _ResetGameButtonsImage()
        {
            foreach(Button button in panel1.Controls)
            {
                button.BackgroundImage = Resources.question;
            }
        }
        
        private void _ShowGameResults()
        {
            lblWinningTimes.Text = GamesResult.WinningTimes.ToString();
            lblLossTimes.Text = GamesResult.LossTimes.ToString();
        }

        private void _ShowUserInfo()
        {
            lblFullName.Text = _User.FirstName + " " + _User.LastName;
            
        }

        private void _StartGame()
        {

            timer1.Start();
        }

        private void btnsClick(object sender, EventArgs e)
        {
            if (_isFirstClick)
            {
                arrCurrentButtons[0] = (Button)sender;
                _SetGameImages(arrCurrentButtons[0]);
                _isFirstClick = false;
                return;
            }

            if (!_isFirstClick)
            {
                arrCurrentButtons[1] = (Button)sender;
                _SetGameImages(arrCurrentButtons[1]);

                if (arrCurrentButtons[0] != arrCurrentButtons[1])
                {
                    _isFirstClick = true;
                    _CheckIfButtonMatch(arrCurrentButtons[0], arrCurrentButtons[1]);
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(Timer >= 0)
            {
                --Timer;
                lblTimer.Text = Timer.ToString();
                _EndGame();
            }
            _ChangeGameNameColor();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _StartGame();
            _DisableControls(true);
            btnStart.Enabled = false;
            btnRestart.Enabled = false; 
        }

        private void _Restset()
        {
            _ResetGameButtonsImage();
            btnStart.Enabled = true;
            btnRestart.Enabled = false;
            UserGameInfo.CorrectStates = 0;
            Timer = 60;
            lblTimer.Text = Timer.ToString();
            _HideScorePictures(false);
        }
        
        private void btnRestart_Click(object sender, EventArgs e)
        {
            _Restset();
        }

        private void _SwapLabel(ref Label label1, ref Label label2)
        {
            Label Temp = new Label();
            Temp.ForeColor = label1.ForeColor;
            label1.ForeColor = label2.ForeColor; 
            label2.ForeColor = Temp.ForeColor;

        }
        
        private void _ChangeGameNameColor()
        {
            if (Timer % 2 == 0)
            {
                _SwapLabel(ref lblMemory, ref lblGame);
                lblTimer.ForeColor = Color.Chartreuse;
            }
            else
            {
                _SwapLabel(ref lblGame, ref lblMemory);
                lblTimer.ForeColor = Color.White;

            }
        }
    }
}
