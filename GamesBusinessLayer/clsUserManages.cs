using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class clsUserManages
{
    public int UserID { get; set; }
    public int GameID { get; set; }
    public int PlayTimes { get; set; }
    public int LossTimes { get; set; }
    public int ResultID { get; set; }
    public int RegisteredID { get; set; }
    public int WinningTimes { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string UserName { get; set; }
    public int CountryID { get; set; }
    public DateTime RegisteredDate { get; set; }
    public string ImagePath { get; set; }

    private enum enMode { AddNew, Update };

    private enMode _Mode;

    private clsUserManages(int UserID, string FirstName, string LastName, string UserName, int LossTimes, 
        int PlayTimes, int WinningTimes, string ImagePath, int CountryID, DateTime RegisteredDate)
    {
        this.UserID = UserID;
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.CountryID = CountryID;
        this.UserName = UserName;
        this.LossTimes = LossTimes;
        this.WinningTimes = WinningTimes;
        this.PlayTimes = PlayTimes;
        this.ImagePath = ImagePath;
        this.RegisteredDate = RegisteredDate;

        _Mode = enMode.Update;
    }

    private clsUserManages(int UserID, int GameID, string FirstName, string LastName, string UserName, int LossTimes,
        int PlayTimes, int WinningTimes, string ImagePath, int CountryID, DateTime RegisteredDate, int ResultID, int RegisteredID)
    {
        this.UserID = UserID;
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.CountryID = CountryID;
        this.UserName = UserName;
        this.LossTimes = LossTimes;
        this.WinningTimes = WinningTimes;
        this.PlayTimes = PlayTimes;
        this.ImagePath = ImagePath;
        this.RegisteredDate = RegisteredDate;
        this.GameID = GameID;
        this.RegisteredID = RegisteredID;
        this.ResultID = ResultID;

        _Mode = enMode.Update;
    }

    public clsUserManages()
    {
        this.UserID = -1;
        this.FirstName = "";
        this.LastName = "";
        this.CountryID = -1;
        this.UserName = "";
        this.LossTimes = 0;
        this.WinningTimes = 0;
        this.PlayTimes = 0;
        this.ImagePath = "";
        this.RegisteredDate = DateTime.Now;

        _Mode = enMode.AddNew;
    }

    public static clsUserManages GetUserDetails(int UserID)
    {
        int CountryID = -1, LossTimes = 0, WinningTimes = 0, PlayTimes = 0;
        string FirstName = "", LastName = "", UserName = "", ImagePath = "";
        DateTime RegisteredDate = DateTime.Now;

        if (clsUserManagesData.GetUserDetails(UserID, ref FirstName, ref LastName, ref UserName, 
                ref LossTimes, ref PlayTimes, ref WinningTimes, ref ImagePath, 
                ref CountryID, ref RegisteredDate))
        {
            return new clsUserManages(UserID, FirstName, LastName, UserName, LossTimes, 
                PlayTimes, WinningTimes, ImagePath, CountryID, RegisteredDate);
        }
        else
        {
            return null;
        }
    }

    public static clsUserManages GetGameDetails(int UserID, int GameID)
    {
        int CountryID = -1, LossTimes = 0, WinningTimes = 0, PlayTimes = 0, ResultID = -1, RegisteredID = -1;
        string FirstName = "", LastName = "", UserName = "", ImagePath = "";
        DateTime RegisteredDate = DateTime.Now;

        if (clsUserManagesData.GetGameDetails(UserID, GameID, ref FirstName, ref LastName, ref UserName,
                ref LossTimes, ref PlayTimes, ref WinningTimes, ref ImagePath,
                ref CountryID, ref RegisteredDate, ref ResultID, ref RegisteredID))
        {
            return new clsUserManages(UserID, GameID, FirstName, LastName, UserName, LossTimes,
                PlayTimes, WinningTimes, ImagePath, CountryID, RegisteredDate, ResultID, RegisteredID);
        }
        else
        {
            return null;
        }
    }

    public static DataTable GetAllUsersDetailsForAdmin()
    {
        return clsUserManagesData.GetAllUsersDetailsForAdmin();
    }
 
}

