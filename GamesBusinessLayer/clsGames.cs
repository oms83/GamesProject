using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class clsGames
{
    public enum enMode { AddNew, Update };
    public int GameID { get; set; }
    public string GameName { get; set; }

    public enMode Mode;

    private clsGames(int GameID, string GameName)
    {
        this.GameID = GameID;
        this.GameName = GameName;

        Mode = enMode.Update;
    }

    public clsGames()
    {
        this.GameID = -1;
        this.GameName = ""; 

        Mode = enMode.AddNew;
    }

    public static clsGames Find(int GameID)
    {
        string GameName = "";


        if (clsGamesData.Find(GameID, ref GameName))
        {
            return new clsGames(GameID, GameName);
        }
        else
        {
            return null;
        }
    }

    public static clsGames Find(string GameName)
    {
        int GameID = -1;


        if (clsGamesData.Find(ref GameID, GameName))
        {
            return new clsGames(GameID, GameName);
        }
        else
        {
            return null;
        }
    }


    private bool _AddNewGame()
    {
        this.GameID = clsGamesData.AddNewGame(this.GameName);

        return (this.GameID > -1);
    }

    private bool _UpdateGame()
    {
        return clsGamesData.UpdateGame(this.GameID, this.GameName);
    }

    public static bool DeleteGame(int GameID)
    {
        return clsGamesData.DeleteGame(GameID);
    }

    public static DataTable GetAllGames()
    {
        return clsGamesData.GetAllGames();
    }

    public static bool isGameExist(int GameID)
    {
        return clsGamesData.isGameExist(GameID);
    }

    public bool Save()
    {
        switch (Mode)
        {
            case enMode.AddNew:
                if (_AddNewGame())
                {
                    Mode = enMode.Update;
                    return true;
                }
                else
                {
                    return false;
                }

            case enMode.Update:
                return _UpdateGame();
        }

        return false;
    }

}

