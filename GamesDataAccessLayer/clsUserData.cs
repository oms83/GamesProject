using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class clsUserData
{
    public static bool Find(int ID, ref string FirstName, ref string LastName, ref string UserName, ref string Email, 
        ref string Password, ref string Phone, ref string ImagePath, ref int CountryID, 
        ref DateTime BirthOfDate, ref int Permissions)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Select * From Users Where UserID = @ID";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@ID", ID);

        bool isFound = false;

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                isFound = true;

                //------------------------------------------------
                if (reader["FirstName"] != DBNull.Value)
                    FirstName = (string)reader["FirstName"];
                else
                    FirstName = "";


                //------------------------------------------------
                if (reader["LastName"] != DBNull.Value)
                    LastName = (string)reader["LastName"];
                else
                    LastName = "";


                //------------------------------------------------
                if (reader["UserName"] != DBNull.Value)
                    UserName = (string)reader["UserName"];
                else
                    UserName = "";

                    
                //------------------------------------------------
                if (reader["Email"] != DBNull.Value)
                    Email = (string)reader["Email"];
                else
                    Email = "";


                //------------------------------------------------
                if (reader["Password"] != DBNull.Value)
                    Password = (string)reader["Password"];
                else
                    Password = "";

                //------------------------------------------------
                if (reader["PhoneNumber"] != DBNull.Value)
                    Phone = (string)reader["PhoneNumber"];
                else
                    Phone = "";


                //------------------------------------------------
                if (reader["ImagePath"] != DBNull.Value)
                    ImagePath = (string)reader["ImagePath"];
                else
                    ImagePath = "";


                //------------------------------------------------
                if (reader["CountryID"] != DBNull.Value)
                    CountryID = (int)reader["CountryID"];
                else
                    CountryID = -1;


                //------------------------------------------------
                if (reader["Permissions"] != DBNull.Value)
                    Permissions = (int)reader["Permissions"];
                else
                    Permissions = 0;


                //------------------------------------------------
                if (reader["DateOfBirth"] != DBNull.Value)
                    BirthOfDate = (DateTime)reader["DateOfBirth"];
                else
                    BirthOfDate = DateTime.Now;

            }

            reader.Close();

        }
        catch (Exception ex)
        {
            isFound = false;
        }
        finally
        {
            connection.Close();
        }

        return isFound;
    }

    public static bool Find(ref int ID, ref string FirstName, ref string LastName, string UserName, ref string Email,
                            ref string Password, ref string Phone, ref string ImagePath, ref int CountryID, 
                            ref DateTime DateOfBirth, ref int Permissions)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Select * From Users Where UserName = @UserName";
                                
        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@UserName", UserName);

        bool isFound = false;

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                isFound = true;

                
                //------------------------------------------------
                if (reader["UserID"] != DBNull.Value)
                    ID = (int)reader["UserID"];
                else
                    ID = -1;


                //------------------------------------------------
                if (reader["LastName"] != DBNull.Value)
                    LastName = (string)reader["LastName"];
                else
                    LastName = "";


                //------------------------------------------------
                if (reader["FirstName"] != DBNull.Value)
                    FirstName = (string)reader["FirstName"];
                else
                    FirstName = "";


                //------------------------------------------------
                if (reader["Permissions"] != DBNull.Value)
                    Permissions = (int)reader["Permissions"];
                else
                    Permissions = 0;


                //------------------------------------------------
                if (reader["Email"] != DBNull.Value)
                    Email = (string)reader["Email"];
                else
                    Email = "";


                //------------------------------------------------
                if (reader["Password"] != DBNull.Value)
                    Password = (string)reader["Password"];
                else
                    Password = "";

                //------------------------------------------------
                if (reader["PhoneNumber"] != DBNull.Value)
                    Phone = (string)reader["PhoneNumber"];
                else
                    Phone = "";


                //------------------------------------------------
                if (reader["ImagePath"] != DBNull.Value)
                    ImagePath = (string)reader["ImagePath"];
                else
                    ImagePath = "";


                //------------------------------------------------
                if (reader["CountryID"] != DBNull.Value)
                    CountryID = (int)reader["CountryID"];
                else
                    CountryID = -1;


                //------------------------------------------------
                if (reader["DateOfBirth"] != DBNull.Value)
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                else
                    DateOfBirth = DateTime.Now;

            }

            reader.Close();

        }
        catch (Exception ex)
        {
            isFound = false;
        }
        finally
        {
            connection.Close();
        }

        return isFound;
    }

    public static bool FindByEmail(ref int ID, ref string FirstName, ref string LastName, ref string UserName, string Email,
                            ref string Password, ref string Phone, ref string ImagePath, ref int CountryID,
                            ref DateTime DateOfBirth, ref int Permissions)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Select * From Users Where Email = @Email";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@Email", Email);

        bool isFound = false;

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                isFound = true;


                //------------------------------------------------
                if (reader["UserID"] != DBNull.Value)
                    ID = (int)reader["UserID"];
                else
                    ID = -1;


                //------------------------------------------------
                if (reader["LastName"] != DBNull.Value)
                    LastName = (string)reader["LastName"];
                else
                    LastName = "";


                //------------------------------------------------
                if (reader["FirstName"] != DBNull.Value)
                    FirstName = (string)reader["FirstName"];
                else
                    FirstName = "";


                //------------------------------------------------
                if (reader["Permissions"] != DBNull.Value)
                    Permissions = (int)reader["Permissions"];
                else
                    Permissions = 0;


                //------------------------------------------------
                if (reader["UserName"] != DBNull.Value)
                    UserName = (string)reader["UserName"];
                else
                    UserName = "";


                //------------------------------------------------
                if (reader["Password"] != DBNull.Value)
                    Password = (string)reader["Password"];
                else
                    Password = "";

                //------------------------------------------------
                if (reader["PhoneNumber"] != DBNull.Value)
                    Phone = (string)reader["PhoneNumber"];
                else
                    Phone = "";


                //------------------------------------------------
                if (reader["ImagePath"] != DBNull.Value)
                    ImagePath = (string)reader["ImagePath"];
                else
                    ImagePath = "";


                //------------------------------------------------
                if (reader["CountryID"] != DBNull.Value)
                    CountryID = (int)reader["CountryID"];
                else
                    CountryID = -1;


                //------------------------------------------------
                if (reader["DateOfBirth"] != DBNull.Value)
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                else
                    DateOfBirth = DateTime.Now;

            }

            reader.Close();

        }
        catch (Exception ex)
        {
            isFound = false;
        }
        finally
        {
            connection.Close();
        }

        return isFound;
    }
    public static int AddNewUser(string FirstName, string LastName, string UserName, string Email, string Password,
                    string Phone, string ImagePath, int CountryID, DateTime DateOfBirth, int Permissions)
    {
        

        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Insert Into Users 

                        (FirstName, LastName, UserName, Email, Password, PhoneNumber, 
                            ImagePath, CountryID, DateOfBirth, Permissions) 

                        Values 

                        (@FirstName, @LastName, @UserName, @Email, @Password, @Phone, 
                            @ImagePath, @CountryID, @BirthOfDate, @Permissions);

                        Select Scope_Identity();";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@FirstName", FirstName);
        command.Parameters.AddWithValue("@LastName", LastName);
        command.Parameters.AddWithValue("@UserName", UserName);
        command.Parameters.AddWithValue("@Email", Email);
        command.Parameters.AddWithValue("@Password", Password);
        command.Parameters.AddWithValue("@Phone", Phone);
        command.Parameters.AddWithValue("@ImagePath", ImagePath);
        command.Parameters.AddWithValue("@CountryID", CountryID);
        command.Parameters.AddWithValue("@Permissions", Permissions);
        command.Parameters.AddWithValue("@BirthOfDate", DateOfBirth);

        int UserID = -1;

        try
        {
            connection.Open();

            object result = command.ExecuteScalar();

            if (result != null && int.TryParse(result.ToString(), out int Inserted))
            {
                UserID = Inserted;
            }
            else
            {
                UserID = -1;
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            connection.Close();
        }

        return UserID;
    }

    public static bool UpdateUser(int ID, string FirstName, string LastName, string UserName, string Email, 
                                    string Password, string Phone, string ImagePath, int CountryID,
                                    DateTime BirthOfDate, int Permissions)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Update Users

                            Set 
                                FirstName = @FirstName,
                                LastName = @LastName,
                                Email = @Email,
                                PhoneNumber = @Phone,
                                UserName = @UserName,
                                Password = @Password,
                                CountryID = @CountryID,
                                DateOfBirth = @BirthOfDate,
                                ImagePath = @ImagePath,
                                Permissions = @Permissions

                            Where UserID = @ID;   
                            ";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@ID", ID);
        command.Parameters.AddWithValue("@FirstName", FirstName);
        command.Parameters.AddWithValue("@LastName", LastName);
        command.Parameters.AddWithValue("@UserName", UserName);
        command.Parameters.AddWithValue("@Email", Email);
        command.Parameters.AddWithValue("@CountryID", CountryID);
        command.Parameters.AddWithValue("@Password", Password);
        command.Parameters.AddWithValue("@Phone", Phone);
        command.Parameters.AddWithValue("@ImagePath", ImagePath);
        command.Parameters.AddWithValue("@BirthOfDate", BirthOfDate);
        command.Parameters.AddWithValue("@Permissions", Permissions);

        int AffectedRows = 0;

        try
        {
            connection.Open();
            AffectedRows = command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            connection.Close();
        }

        return AffectedRows > 0;
    }

    public static bool Delete(int ID)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Delete From Users Where UserID = @ID";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@ID", ID);

        int AffectedRows = 0;

        try
        {
            connection.Open();
            AffectedRows = command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            connection.Close();
        }

        return AffectedRows > 0;

    }

    public static DataTable GetAllUsers()
    {
        DataTable dt = new DataTable();

        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Select * From Users";

        SqlCommand command = new SqlCommand(Query, connection);

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                dt.Load(reader);
            }

            reader.Close();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            connection.Close();
        }

        return dt;

    }

    public static bool isUserExist(int ID)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Select Found=1 From Users Where UsersID = @ID";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@ID", ID);

        bool isFound = false;

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            isFound = reader.HasRows;
            reader.Close();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            connection.Close();
        }

        return isFound;
    }

    public static bool isUserExist(string UserName)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Select Found=1 From Users Where UserName = @UserName";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@UserName", UserName);

        bool isFound = false;

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            isFound = reader.HasRows;
            reader.Close();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            connection.Close();
        }

        return isFound;
    }

    public static bool isUserEmailExist(string Email)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);
        string Query = "Select Found=1 From Users Where Email=@Email";
        SqlCommand command = new SqlCommand(Query, connection);
        command.Parameters.AddWithValue("@Email", Email);
        bool isFound = false;
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            isFound = reader.HasRows;
            reader.Close();
        }
        catch (Exception ex)
        {
            isFound = false;
        }
        finally 
        { 
            connection.Close(); 
        }

        return isFound;
    }
    public static bool isUserPhoneExist(string Phone)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);
        string Query = "Select Found=1 From Users Where PhoneNumber=@Phone";
        SqlCommand command = new SqlCommand(Query, connection);
        command.Parameters.AddWithValue("@Phone", Phone);
        bool isFound = false;
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            isFound = reader.HasRows;
            reader.Close();
        }
        catch (Exception ex)
        {
            isFound = false;
        }
        finally
        {
            connection.Close();
        }

        return isFound;
    }
}
