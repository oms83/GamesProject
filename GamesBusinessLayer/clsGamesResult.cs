using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class clsGamesResult
{
    public enum enMode { AddNew, Update };
    public int WinningTimes { get; set; }
    public int LossTimes { get; set; }
    public int PlayTimes { get; set; }
    public int GameID { get; set; }
    public int ResultID { get; set; }


    public enMode Mode;

    private clsGamesResult(int ResultID, int GameID, int WinningTimes, int LossTimes, int PlayTimes)
    {
        this.ResultID = ResultID;
        this.GameID = GameID;
        this.LossTimes = LossTimes;
        this.WinningTimes = WinningTimes;
        this.PlayTimes = PlayTimes;


        Mode = enMode.Update;
    }

    public clsGamesResult()
    {
        this.ResultID = -1;
        this.GameID = -1;
        this.LossTimes = 0;
        this.WinningTimes = 0;
        this.PlayTimes = 0;

        Mode = enMode.AddNew;
    }

    public static clsGamesResult Find(int ResultID)
    {
        int PlayTimes = 0, LossTimes = 0, WinningTimes = 0, GameID = -1;

        if (clsGamesResultDate.Find(ResultID, ref GameID, ref WinningTimes, ref LossTimes, ref PlayTimes))
        {
            return new clsGamesResult(ResultID, GameID, WinningTimes, LossTimes, PlayTimes);
        }
        else
        {
            return null;
        }
    }


    private bool _AddNewGameResult()
    {
        this.ResultID = clsGamesResultDate.AddNewGameResult(this.GameID, this.WinningTimes, this.LossTimes, this.PlayTimes);

        return (this.ResultID > -1);
    }

    private bool _UpdateGameResult()
    {
        return clsGamesResultDate.UpdateGameResult(this.ResultID, this.GameID, this.WinningTimes, this.LossTimes, this.PlayTimes);
    }

    public static bool DeleteGameResult(int ResultID)
    {
        return clsGamesResultDate.DeleteGameResult(ResultID);
    }

    public static DataTable GetAllGamesResult()
    {
        return clsGamesResultDate.GetAllGamesResult();
    }

    public static bool isGameResultExist(int ResultID)
    {
        return clsGamesResultDate.isGameResultExist(ResultID);
    }

    public bool Save()
    {
        switch (Mode)
        {
            case enMode.AddNew:
                if (_AddNewGameResult())
                {
                    Mode = enMode.Update;
                    return true;
                }
                else
                {
                    return false;
                }

            case enMode.Update:
                return _UpdateGameResult();
        }

        return false;
    }
}

