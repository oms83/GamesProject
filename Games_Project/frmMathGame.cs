using Games_Project.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace Games_Project
{
    public partial class frmMathGame : Form
    {
        private SoundPlayer SoundEffect;

        private enum _enOperations { eSum, eSub, eMul, eDiv, eMix };

        private enum _enLevel { Easy, Middle, Hard, Mix };

        private struct _stGameInfo
        {
            public int GameOpreation;
            public int Level;
            public int RigthAnswer;
            public int WrongAnswer;
            public int Number1;
            public int Number2;
            public int NumbertOfQuestions;
        }

        _stGameInfo GameInfo;

        _enLevel Level;
        _enOperations Operation;

        private clsUser _User;
        private clsGamesResult _GameResult;
        private clsRegisteredGame _RegisteredGame;

        private List<string> lstLevel = ["Easy", "Middle", "Hard", "Mix"];
        private List<string> lstOperation = ["Sum", "Sub", "Mul", "Div", "Mix"];

        public frmMathGame(ref clsUser User, ref clsRegisteredGame RegisteredGame, ref clsGamesResult GamesResult)
        {
            InitializeComponent();

            _User = User;
            _GameResult = GamesResult;
            _RegisteredGame = RegisteredGame;
            IntializeGame();
        }

        private void IntializeGame()
        {
            _Rest();
            _ShowGameResults();
            _ShowUserInfo();
        }


        Random Rand = new Random();
        
        private int _GetRandomNumber(int From, int To)
        {
            return Rand.Next(From, To);
        }
        
        private bool _isResultsEqual(int Op)
        {
            if(!string.IsNullOrWhiteSpace(txtAnswer.Text) )
                return Convert.ToInt32(txtAnswer.Text) == _GameOperation(Op);
            else
                return false;
        }

        private int _SetLevelOfNumber(int Level)
        {
            switch (Level)
            {
                case (int)_enLevel.Easy:
                    return _GetRandomNumber(1, 15);
                case (int)_enLevel.Middle:
                    return _GetRandomNumber(15, 40);
                case (int)_enLevel.Hard:
                    return _GetRandomNumber(40, 101);
            }
            return -1;
        }

        private void _ShowNumbers()
        {
            lblNum1.Text = GameInfo.Number1.ToString();
            lblNum2.Text = GameInfo.Number2.ToString();
        }

        private void _SetNumbers()
        {
            if (GameInfo.Level == (int)_enLevel.Mix)
            {
                int TempLevel = _GetRandomNumber(0, 3);

                GameInfo.Number1 = _SetLevelOfNumber(TempLevel);
                GameInfo.Number2 = _SetLevelOfNumber(TempLevel);
                _ShowNumbers();
            }
            else
            {
                GameInfo.Number1 = _SetLevelOfNumber(GameInfo.Level);
                GameInfo.Number2 = _SetLevelOfNumber(GameInfo.Level);
                _ShowNumbers();
            }
        }

        private int _GameOperation(int Op)
        {
            switch (Op)
            {
                case (int)_enOperations.eSum:
                    return GameInfo.Number1 + GameInfo.Number2;
                case (int)_enOperations.eSub:
                    return GameInfo.Number1 - GameInfo.Number2;
                case (int)_enOperations.eMul:
                    return GameInfo.Number1 * GameInfo.Number2;
                case (int)_enOperations.eDiv:
                    return GameInfo.Number1 / GameInfo.Number2;

            }
            return -1;
        }
        
        private void _SetOperationSymbol(int OpSymbol)
        {
            switch(OpSymbol) 
            {
                case 0:
                    btnOperation.BackgroundImage = Resources.add; 
                    break;
                case 1:
                    btnOperation.BackgroundImage = Resources.minus;
                    break;
                case 2:
                    btnOperation.BackgroundImage = Resources.multiplication;
                    break;
                case 3:
                    btnOperation.BackgroundImage = Resources.division;
                    break;

            }
        }

        int TempOperation;
        private void _SetGameOperation()
        {
            if(GameInfo.GameOpreation == (int)_enOperations.eMix)
            {
                TempOperation = _GetRandomNumber(0, 4);
                _SetOperationSymbol(TempOperation);
            }
            else
            {
                TempOperation = GameInfo.GameOpreation;
                _SetOperationSymbol(TempOperation);
            }
        }
       
        private void frmMathGame_Paint(object sender, PaintEventArgs e)
        {
            Color White = Color.FromArgb(255, 255, 255, 255);
            Pen pen = new Pen(White);

            pen.Width = 10;

            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(pen, 400, 400, 700, 400);
        }

        private void _ColorEffectOfAnswerStatus(bool isRigthAnswer)
        {
            if(isRigthAnswer )
            {
                panel1.BackColor = Color.Chartreuse;
                panel1.Refresh();
                Thread.Sleep(1000);
            }
            else
            {
                panel1.BackColor = Color.Red;
                panel1.Refresh();
                Thread.Sleep(1000);
            }
            panel1.BackColor = Color.Transparent;

        }

        private void _ShowUserInfo()
        {
            lblFullName.Text = _User.FirstName + " " + _User.LastName; 
            if(_User.ImagePath != "")
            {
                pbImage.Load(_User.ImagePath);
            }
        }

        private void _ShowGameResults()
        {
            lblWinnginTimes.Text = _GameResult.WinningTimes.ToString();
            lblLossTimes.Text = _GameResult.LossTimes.ToString();
        }

        private void _RefershGameResults()
        {
            _GameResult = clsGamesResult.Find(_GameResult.ResultID);
            _ShowGameResults();
        }

        private bool _EndGame()
        {
            if(--GameInfo.NumbertOfQuestions==0)
            {
                _GameResult.PlayTimes++;
                btnRestart.Enabled = true;
                btnOperation.Enabled = false;


                if (GameInfo.RigthAnswer >= GameInfo.WrongAnswer)
                {
                    _GameResult.WinningTimes++;
                    _GameResult.Save();
                    _RefershGameResults();
                    clsSoundEffect._PlayEndSoundEffect(true);
                    return true;
                }
                else
                {
                    _GameResult.LossTimes++;
                    _GameResult.Save();
                    _RefershGameResults();
                    clsSoundEffect._PlayEndSoundEffect(false);
                    return false;

                }

            }

            return false;
        }

        private void _SetNumberOfQuestion()
        {
            lblNumberOfQuestion.Text = GameInfo.NumbertOfQuestions.ToString();

            if(GameInfo.NumbertOfQuestions == 0)
                lblNumberOfQuestion.Text = 1.ToString();


        }
        
        private void btnOperation_Click(object sender, EventArgs e)
        {


            if (_isResultsEqual(TempOperation))
            {
                GameInfo.RigthAnswer++;
                lblRigthAnswer.Text = GameInfo.RigthAnswer.ToString();
                _ColorEffectOfAnswerStatus(true);
            }
            else
            {
                GameInfo.WrongAnswer++;
                lblWrongAnswer.Text = GameInfo.WrongAnswer.ToString();
                _ColorEffectOfAnswerStatus(false);
            }


            if (GameInfo.GameOpreation == (int)_enOperations.eMix)
                _SetGameOperation();


            if(!_EndGame())
            {
                _SetNumbers();
            }

            _SetNumberOfQuestion();
        }

        private void _DisableEnableControls(GroupBox groupBox, bool Status)
        {
            foreach(RadioButton radio in groupBox.Controls)
            {
                radio.Enabled = Status;
            }
        }

        private void _StartGame()
        {
            _SetNumbers();
            _SetGameOperation();
            _DisableEnableControls(gbLevels, false);
            _DisableEnableControls(gbOperations, false);

            nudNumberOfQuestion.Enabled = false;
            btnStart.Enabled = false;
            btnRestart.Enabled = false;
            btnOperation.Enabled = true;
            txtAnswer.Enabled = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _StartGame();
        }

        private void _GetLevel(RadioButton radio)
        {
            GameInfo.Level = Convert.ToInt16(radio.Tag);
            lblLevel.Text = lstLevel[GameInfo.Level];
        }

        private void RadioButtonLevel(object sender, EventArgs e)
        {
            _GetLevel((RadioButton)(sender));
        }

        private void _GetOperation(RadioButton radio)
        {
            GameInfo.GameOpreation = Convert.ToInt16(radio.Tag);
            lblOperation.Text = lstOperation[GameInfo.GameOpreation];

        }
       
        private void RadioButtonOperation(object sender, EventArgs e)
        {
            _GetOperation((RadioButton)(sender));
        }

        private void _CheckedUnCheckedRB(GroupBox groupBox, bool CheckedStatus)
        {
            foreach(RadioButton radio in groupBox.Controls)
            {
                radio.Checked = CheckedStatus;
            }
        }
        
        private void _Rest()
        {
            btnRestart.Enabled = false;
            btnStart.Enabled = true;
            nudNumberOfQuestion.Enabled = true;
            btnOperation.Enabled = false;
            txtAnswer.Enabled = false;

            _DisableEnableControls(gbLevels, true);
            _DisableEnableControls(gbOperations, true);

            _CheckedUnCheckedRB(gbLevels, false);
            _CheckedUnCheckedRB(gbOperations, false);

            rbOpSum.Checked = true;
            rbLvlEasy.Checked = true;


            lblLevel.Text = "--";
            lblOperation.Text = "--";
            lblRigthAnswer.Text = "--";
            lblWrongAnswer.Text = "--";
            lblNum1.Text = "--";
            lblNum2.Text = "--";

            _GetLevel(rbLvlEasy);
            _GetOperation(rbOpSum);

            GameInfo.NumbertOfQuestions = 0;
            GameInfo.RigthAnswer = 0;
            GameInfo.WrongAnswer = 0;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            _Rest();
        }

        private void nudNumberOfQuestion_ValueChanged(object sender, EventArgs e)
        {
            GameInfo.NumbertOfQuestions = (int)nudNumberOfQuestion.Value;
            _SetNumberOfQuestion();
        }
    }
}
