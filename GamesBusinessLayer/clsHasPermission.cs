using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class clsHasPermission
{
    public enum enMode { AddNew, Update };
    public int ID { get; set; }
    public int UserID { get; set; }
    public int PermissionID { get; set; }

    public enMode Mode;

    private clsHasPermission(int ID, int UserID, int PermissionID)
    {
        this.ID = ID;
        this.UserID = UserID;
        this.PermissionID = PermissionID;

        Mode = enMode.Update;
    }

    public clsHasPermission()
    {
        this.ID = -1;
        this.UserID = -1;
        this.PermissionID = -1;

        Mode = enMode.AddNew;
    }

    public static clsHasPermission Find(int ID)
    {
        int UserID = -1, PermissionID = -1;

        if (clsHasPermissionData.Find(ID, ref UserID, ref PermissionID))
        {
            return new clsHasPermission(ID, UserID, PermissionID);
        }
        else
        {
            return null;
        }
    }


    private bool _AddNewHasPermission()
    {
        this.ID = clsHasPermissionData.AddNewHasPermission(this.UserID, this.PermissionID);

        return (this.ID > -1);
    }

    private bool _UpdateHasPermission()
    {
        return clsHasPermissionData.UpdateHasPermission(this.ID, this.UserID, this.PermissionID);
    }

    public static bool DeleteHasPermission(int ID)
    {
        return clsHasPermissionData.DeleteHasPermission(ID);
    }

    public static DataTable GetAllHasPermissions()
    {
        return clsHasPermissionData.GetAllHasPermissions();
    }


    public static bool isHasPermissionExist(int ID)
    {
        return clsHasPermissionData.isHasPermissionExist(ID);
    }

    public bool Save()
    {
        switch (Mode)
        {
            case enMode.AddNew:
                if (_AddNewHasPermission())
                {
                    Mode = enMode.Update;
                    return true;
                }
                else
                {
                    return false;
                }

            case enMode.Update:
                return _UpdateHasPermission();
        }

        return false;
    }


}
