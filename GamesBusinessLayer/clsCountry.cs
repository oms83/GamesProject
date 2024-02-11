using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class clsCountry
{
    public enum enMode { AddNew, Update };
    public int CountryID { get; set; }
    public string CountryName { get; set; }

    public enMode Mode;

    private clsCountry(int ID, string CountryName)
    {
        this.CountryID = ID;
        this.CountryName = CountryName;

        Mode = enMode.Update;
    }

    public clsCountry()
    {
        this.CountryID = -1;
        this.CountryName = "";

        Mode = enMode.AddNew;
    }

    public static clsCountry Find(int ID)
    {
        string CountryName = "";

        if (clsCountryData.Find(ID, ref CountryName))
        {
            return new clsCountry(ID, CountryName);
        }
        else
        {
            return null;
        }
    }

    public static clsCountry Find(string CountryName)
    {
        int CountryID = -1;

        if (clsCountryData.Find(ref CountryID, CountryName))
        {
            return new clsCountry(CountryID, CountryName);
        }
        else
        {
            return null;
        }
    }
    private bool _AddNewCountry()
    {
        this.CountryID = clsCountryData.AddNewCountry(this.CountryName);

        return (this.CountryID > -1);
    }

    private bool _UpdateCountry()
    {
        return clsCountryData.UpdateCountry(this.CountryID, this.CountryName);
    }

    public static bool DeleteCountry(int ID)
    {
        return clsCountryData.DeleteCountry(ID);
    }

    public static DataTable GetAllCountries()
    {
        return clsCountryData.GetAllCountries();
    }

    public static bool isCountryExistByID(int ID)
    {
        return clsCountryData.isCountryExistByID(ID);
    }

    public static bool isCountryExistByName(string CountryName)
    {
        return clsCountryData.isCountryExistByName(CountryName);
    }

    public bool Save()
    {
        switch (Mode)
        {
            case enMode.AddNew:
                if (_AddNewCountry())
                {
                    Mode = enMode.Update;
                    return true;
                }
                else
                {
                    return false;
                }

            case enMode.Update:
                return _UpdateCountry();
        }

        return false;
    }


}
