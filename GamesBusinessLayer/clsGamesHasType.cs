using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class clsGamesHasType
{
    public enum enMode { AddNew, Update };
    public int HasTypeID { get; set; }
    public int TypeID { get; set; }
    public int GameID { get; set; }

    public enMode Mode;

    private clsGamesHasType(int HasTypeID, int TypeID, int GameID)
    {
        this.GameID = GameID;
        this.TypeID = TypeID;
        this.HasTypeID = HasTypeID;


        Mode = enMode.Update;
    }

    public clsGamesHasType()
    {
        this.GameID = -1;
        this.TypeID = -1;
        this.HasTypeID = -1;

        Mode = enMode.AddNew;
    }

    public static clsGamesHasType Find(int HasTypeID)
    {
        int GameID = -1, TypeID = -1;


        if (clsGamesHasTypeData.Find(HasTypeID, ref TypeID, ref GameID))
        {
            return new clsGamesHasType(HasTypeID, TypeID, GameID);
        }
        else
        {
            return null;
        }
    }


    private bool _AddNewGamesHasType()
    {
        this.HasTypeID = clsGamesHasTypeData.AddNewGamesHasType(this.TypeID, this.GameID);

        return (this.HasTypeID > -1);
    }

    private bool _UpdateGamesHasType()
    {
        return clsGamesHasTypeData.UpdateGamesHasType(this.HasTypeID, this.TypeID, this.GameID);
    }

    public static bool DeleteGamesHasType(int HasTypeID)
    {
        return clsGamesHasTypeData.DeleteGamesHasType(HasTypeID);
    }

    public static DataTable GetAllGamesHasType()
    {
        return clsGamesHasTypeData.GetAllGamesHasType();
    }

    public static bool isGamesHasTypeExist(int HasTypeID)
    {
        return clsGamesHasTypeData.isGamesHasTypeExist(HasTypeID);
    }
    public bool Save()
    {
        switch (Mode)
        {
            case enMode.AddNew:
                if (_AddNewGamesHasType())
                {
                    Mode = enMode.Update;
                    return true;
                }
                else
                {
                    return false;
                }

            case enMode.Update:
                return _UpdateGamesHasType();
        }

        return false;
    }
}
