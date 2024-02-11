using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class clsGamesType
{
    public enum enMode { AddNew, Update };
    public int TypeID {  get; set; }
    public string TypeName { get; set; }

    public enMode Mode;

    private clsGamesType(int TypeID, string TypeName)
    {
        this.TypeID = TypeID;
        this.TypeName = TypeName;
        

        Mode = enMode.Update;
    }

    public clsGamesType()
    {
        this.TypeID = -1;
        this.TypeName = "";

        Mode = enMode.AddNew;
    }

    public static clsGamesType Find(int TypeID)
    {
        string TypeName = "";


        if (clsGamesTypeData.Find(TypeID, ref TypeName))
        {
            return new clsGamesType(TypeID, TypeName);
        }
        else
        {
            return null;
        }
    }

    public static clsGamesType Find(string TypeName)
    {
        int TypeID = -1;


        if (clsGamesTypeData.Find(ref TypeID, TypeName))
        {
            return new clsGamesType(TypeID, TypeName);
        }
        else
        {
            return null;
        }
    }


    private bool _AddNewGameType()
    {
        this.TypeID = clsGamesTypeData.AddNewGameType(this.TypeName);

        return (this.TypeID > -1);
    }

    private bool _UpdateGameType()
    {
        return clsGamesTypeData.UpdateGameType(this.TypeID, this.TypeName);
    }

    public static bool DeleteGameType(int TypeID)
    {
        return clsGamesTypeData.DeleteGameType(TypeID);
    }

    public static DataTable GetAllGamesType()
    {
        return clsGamesTypeData.GetAllGamesType();
    }

    public static bool isGameTypeExist(int TypeID)
    {
        return clsGamesTypeData.isGameTypeExist(TypeID);
    }
    public bool Save()
    {
        switch (Mode)
        {
            case enMode.AddNew:
                if (_AddNewGameType())
                {
                    Mode = enMode.Update;
                    return true;
                }
                else
                {
                    return false;
                }

            case enMode.Update:
                return _UpdateGameType();
        }

        return false;
    }
}
