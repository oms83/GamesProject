using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class clsPermission
{
    public enum enMode { AddNew, Update };
    public int PermissionID { get; set; }
    public int Value { get; set; }
    public string Name { get; set; }

    public enMode Mode;

    private clsPermission(int PermissionID, int Value, string Name)
    {
        this.PermissionID = PermissionID;
        this.Value = Value;
        this.Name = Name;

        Mode = enMode.Update;
    }

    public clsPermission()
    {
        this.PermissionID = -1;
        this.Value = 0;
        this.Name = "";

        Mode = enMode.AddNew;
    }

    public static clsPermission Find(int PermissionID)
    {
        int Value = 0;
        string Name = "";

        if (clsPermissionData.Find(PermissionID, ref Value, ref Name))
        {
            return new clsPermission(PermissionID, Value, Name);
        }
        else
        {
            return null;
        }
    }

    public static clsPermission Find(string Name)
    {
        int Value = 0, PermissionID = -1;

        if (clsPermissionData.Find(ref PermissionID, ref Value, Name))
        {
            return new clsPermission(PermissionID, Value, Name);
        }
        else
        {
            return null;
        }
    }


    private bool _AddNewPermission()
    {
        this.PermissionID = clsPermissionData.AddNewPermission(this.Value, this.Name);

        return (this.PermissionID > -1);
    }

    private bool _UpdatePermission()
    {
        return clsPermissionData.UpdatePermission(this.PermissionID, this.Value, this.Name);
    }

    public static bool DeletePermission(int PermissionID)
    {
        return clsPermissionData.DeletePermission(PermissionID);
    }

    public static DataTable GetAllPermissions()
    {
        return clsPermissionData.GetAllPermissions();
    }

    public static bool isPermissionExist(int PermissionID)
    {
        return clsPermissionData.isPermissionExist(PermissionID);
    }


    public bool Save()
    {
        switch (Mode)
        {
            case enMode.AddNew:
                if (_AddNewPermission())
                {
                    Mode = enMode.Update;
                    return true;
                }
                else
                {
                    return false;
                }

            case enMode.Update:
                return _UpdatePermission();
        }

        return false;
    }

}
