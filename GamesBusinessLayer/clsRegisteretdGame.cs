using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class clsRegisteredGame
{
    public enum enMode { AddNew, Update };
    public int ID { get; set; }
    public int GameID { get; set; }
    public int ResultID { get; set; }
    public int UserID { get; set; }
    public DateTime RegisteredDate { get; set; }

    public enMode Mode;

    private clsRegisteredGame(int ID, int UserID, int GameID, DateTime RegisteredDate, int ResultID)
    {
        this.ID = ID;
        this.UserID = UserID;
        this.GameID = GameID;
        this.ResultID = ResultID;
        this.RegisteredDate = RegisteredDate;

        Mode = enMode.Update;
    }

    public clsRegisteredGame()
    {
        this.ID = -1;
        this.UserID = -1;
        this.ResultID = -1;
        this.GameID = -1;
        this.RegisteredDate = DateTime.Now;

        Mode = enMode.AddNew;
    }

    public static clsRegisteredGame Find(int ID)
    {
        int UserID = -1, GameID = -1, ResultID = -1;
        DateTime RegisteredDate = DateTime.Now;

        if (clsRegisteredGameData.Find(ID, ref UserID, ref GameID, ref RegisteredDate, ref ResultID))
        {
            return new clsRegisteredGame(ID, UserID, GameID, RegisteredDate, ResultID);
        }
        else
        {
            return null;
        }
    }


    private bool _AddNewRegistered()
    {
        this.ID = clsRegisteredGameData.AddNewRegistered(this.UserID, this.GameID, this.RegisteredDate, this.ResultID);

        return (this.ID > -1);
    }

    private bool _UpdateRegistered()
    {
        return clsRegisteredGameData.UpdateRegistered(this.ID, this.UserID, this.GameID, this.RegisteredDate, this.ResultID);
    }

    public static bool DeleteRegistered(int ID)
    {
        return clsRegisteredGameData.DeleteRegistered(ID);
    }

    public static DataTable GetAllRegistered()
    {
        return clsRegisteredGameData.GetAllRegistered();
    }

    public static bool isRegisteredExist(int ID)
    {
        return clsRegisteredGameData.isRegisteredExist(ID);
    }

    public bool Save()
    {
        switch (Mode)
        {
            case enMode.AddNew:
                if (_AddNewRegistered())
                {
                    Mode = enMode.Update;
                    return true;
                }
                else
                {
                    return false;
                }

            case enMode.Update:
                return _UpdateRegistered();
        }

        return false;
    }
}

