using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class clsUser
{
    public int ID {  get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public int CountryID { get; set; }
    public int Permissions { get; set; }
    public DateTime BirthOfDate { get; set; }
    public string ImagePath { get; set; }

    private enum enMode { AddNew, Update };

    private enMode _Mode;

    private clsUser(int ID, string FirstName, string LastName, string UserName, string Email, string Password, 
                    string Phone, string ImagePath, int CountryID, DateTime BirthOfDate, int Permissions) 
    {
        this.ID = ID;
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.UserName = UserName;
        this.Email = Email;
        this.Password = Password;
        this.Phone = Phone;
        this.ImagePath = ImagePath;
        this.CountryID = CountryID;
        this.BirthOfDate = BirthOfDate;
        this.Permissions = Permissions;

        _Mode = enMode.Update;
    }

    public clsUser()
    {
        this.ID = -1;
        this.FirstName = "";
        this.LastName = "";
        this.UserName = "";
        this.Email = "";
        this.Password = "";
        this.Phone = "";
        this.ImagePath = "";
        this.CountryID = -1;
        this.Permissions = 0;
        this.BirthOfDate = DateTime.Now;

        _Mode = enMode.AddNew;
    }

    public static clsUser Find(int ID)
    {
        string FirstName = "", LastName = "", UserName = "", Email = "", Password = "", Phone = "", ImagePath = "";
        int CountryID = -1, Permissions = 0;
        DateTime BirthOfDate = DateTime.Now;

        if(clsUserData.Find(ID, ref FirstName, ref LastName, ref UserName, ref Email, ref Password, ref Phone,
                            ref ImagePath, ref CountryID, ref BirthOfDate, ref Permissions))
        {
            return new clsUser(ID, FirstName, LastName, UserName, Email, Password, Phone, ImagePath,
                               CountryID, BirthOfDate, Permissions);
        }
        else
        {
            return null;
        }
    }

    public static clsUser Find(string UserName)
    {
        string LastName = "", FirstName = "", Email = "", Password = "", Phone = "", ImagePath = "";
        int CountryID = -1, ID=-1, Permissions = 0;
        DateTime BirthOfDate = DateTime.Now;

        if (clsUserData.Find(ref ID, ref FirstName, ref LastName, UserName, ref Email, ref Password, ref Phone,
                             ref ImagePath, ref CountryID, ref BirthOfDate, ref Permissions))
        {
            return new clsUser(ID, FirstName, LastName, UserName, Email, Password, Phone, ImagePath,
                               CountryID, BirthOfDate, Permissions);
        }
        else
        {
            return null;
        }
    }

    public static clsUser FindByEmail(string Email)
    {
        string LastName = "", FirstName = "", UserName = "", Password = "", Phone = "", ImagePath = "";
        int CountryID = -1, ID = -1, Permissions = 0;
        DateTime BirthOfDate = DateTime.Now;

        if (clsUserData.FindByEmail(ref ID, ref FirstName, ref LastName, ref UserName, Email, ref Password, ref Phone,
                             ref ImagePath, ref CountryID, ref BirthOfDate, ref Permissions))
        {
            return new clsUser(ID, FirstName, LastName, UserName, Email, Password, Phone, ImagePath,
                               CountryID, BirthOfDate, Permissions);
        }
        else
        {
            return null;
        }
    }

    private bool _AddNewUser()
    {
        this.ID = clsUserData.AddNewUser(this.FirstName, this.LastName, this.UserName, this.Email, this.Password,
            this.Phone, this.ImagePath, this.CountryID, this.BirthOfDate, this.Permissions);

        return this.ID > -1;
    }

    private bool _UpdateUser()
    {
        return clsUserData.UpdateUser(this.ID, this.FirstName, this.LastName, this.UserName, this.Email, this.Password,
            this.Phone, this.ImagePath, this.CountryID, this.BirthOfDate, this.Permissions);
    }

    public static DataTable GetAllUsers()
    {
        return clsUserData.GetAllUsers();
    }

    public static bool isUserExist(string UserName)
    {
        return clsUserData.isUserExist(UserName);
    }

    public static bool isUserExist(int ID)
    {
        return clsUserData.isUserExist(ID);
    }

    public static bool isUserEmailExist(string Email)
    {
        return clsUserData.isUserEmailExist(Email);
    }

    public static bool isUserPhoneExist(string Phone)
    {
        return clsUserData.isUserPhoneExist(Phone);
    }

    public static bool Delete(int ID)
    {
        return clsUserData.Delete(ID);
    }
    public bool Save()
    {
        switch(_Mode)
        {
            case enMode.AddNew:
                if(_AddNewUser())
                {
                    _Mode = enMode.Update;
                    return true;
                }
                else
                {
                    return false;
                }

            case enMode.Update:
                return _UpdateUser();
        }

        return false;
    }

}
