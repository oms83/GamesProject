using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;

public class clsUserManagesData
{
   
    public static DataTable GetAllUsersDetailsForAdmin()
    {
        DataTable dt = new DataTable();

        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"select 

                        Users.UserID, Users.FirstName, Users.LastName, 
                        Games.GameName, GameResults.WinningTimes, 
	                    GameResults.LossTimes, GameResults.PlayTimes, 
                        Countries.CountryID, RegisteredGames.RegisteredDate  

                        From Users

	                    Inner Join RegisteredGames On Users.UserID = RegisteredGames.UserID
	                    Inner Join Games On Games.GameID = RegisteredGames.GameID
	                    Inner Join GameResults On RegisteredGames.ResultID = GameResults.ResultID
	                    Inner Join Countries On Countries.CountryID = Users.CountryID

                    ";

        SqlCommand command = new SqlCommand(Query, connection);

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if(reader.HasRows)
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

    public static bool GetUserDetails(int UserID, ref string FirstName, ref string LastName, 
        ref string UserName, ref int LossTimes, ref int PlayTimes, ref int WinningTimes, ref string ImagePath,
        ref int CountryID, ref DateTime RegisteredDate)
    {
        DataTable dt = new DataTable();

        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"select 

                        Users.UserID, Users.FirstName, Users.LastName, 
                        Games.GameName, GameResults.WinningTimes, 
	                    GameResults.LossTimes, GameResults.PlayTimes, 
                        Countries.CountryID, RegisteredGames.RegisteredDate, Users.ImagePath

                        From Users

	                    Inner Join RegisteredGames On Users.UserID = RegisteredGames.UserID
	                    Inner Join Games On Games.GameID = RegisteredGames.GameID
	                    Inner Join GameResults On RegisteredGames.ResultID = GameResults.ResultID
	                    Inner Join Countries On Countries.CountryID = Users.CountryID

                        Where Users.UserID = @UserID;
                    ";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@UserID", UserID);

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
                if (reader["CountryID"] != DBNull.Value)
                    CountryID = (int)reader["CountryID"];
                else
                    CountryID = 0;

                //------------------------------------------------
                if (reader["LossTimes"] != DBNull.Value)
                    LossTimes = (int)reader["LossTimes"];
                else
                    LossTimes = 0;

                //------------------------------------------------
                if (reader["ImagePath"] != DBNull.Value)
                    ImagePath = (string)reader["ImagePath"];
                else
                    ImagePath = "";


                //------------------------------------------------
                if (reader["PlayTimes"] != DBNull.Value)
                    PlayTimes = (int)reader["PlayTimes"];
                else
                    PlayTimes = 0;


                //------------------------------------------------
                if (reader["WinningTimes"] != DBNull.Value)
                    WinningTimes = (int)reader["WinningTimes"];
                else
                    WinningTimes = 0;


                //------------------------------------------------
                if (reader["RegisteredDate"] != DBNull.Value)
                    RegisteredDate = (DateTime)reader["RegisteredDate"];
                else
                    RegisteredDate = DateTime.Now;
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

        return isFound;
    }


    public static bool GetGameDetails(int UserID, int GameID, ref string FirstName, ref string LastName,
        ref string UserName, ref int LossTimes, ref int PlayTimes, ref int WinningTimes, ref string ImagePath,
        ref int CountryID, ref DateTime RegisteredDate, ref int ResultID, ref int RegisteredID)
    {

        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"select 

                        Users.UserID, Users.FirstName, Users.LastName, Users.UserName, 
                        Games.GameName, GameResults.WinningTimes, 
	                    GameResults.LossTimes, GameResults.PlayTimes, 
                        Countries.CountryID, RegisteredGames.RegisteredDate, Users.ImagePath, 
                        RegisteredGames.ResultID, RegisteredGames.ID

                        From Users

	                    Inner Join RegisteredGames On Users.UserID = RegisteredGames.UserID
	                    Inner Join Games On Games.GameID = RegisteredGames.GameID
	                    Inner Join GameResults On RegisteredGames.ResultID = GameResults.ResultID
	                    Inner Join Countries On Countries.CountryID = Users.CountryID

                        Where Users.UserID = @UserID And  Games.GameID = @GameID;
                    ";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@UserID", UserID);
        command.Parameters.AddWithValue("@GameID", GameID);

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
                if (reader["ID"] != DBNull.Value)
                    RegisteredID = (int)reader["ID"];
                else
                    RegisteredID = -1;


                
                //------------------------------------------------
                if (reader["ResultID"] != DBNull.Value)
                    ResultID = (int)reader["ResultID"];
                else
                    ResultID = -1;


                //------------------------------------------------
                if (reader["CountryID"] != DBNull.Value)
                    CountryID = (int)reader["CountryID"];
                else
                    CountryID = -1;

                //------------------------------------------------
                if (reader["LossTimes"] != DBNull.Value)
                    LossTimes = (int)reader["LossTimes"];
                else
                    LossTimes = 0;

                //------------------------------------------------
                if (reader["ImagePath"] != DBNull.Value)
                    ImagePath = (string)reader["ImagePath"];
                else
                    ImagePath = "";


                //------------------------------------------------
                if (reader["PlayTimes"] != DBNull.Value)
                    PlayTimes = (int)reader["PlayTimes"];
                else
                    PlayTimes = 0;


                //------------------------------------------------
                if (reader["WinningTimes"] != DBNull.Value)
                    WinningTimes = (int)reader["WinningTimes"];
                else
                    WinningTimes = 0;


                //------------------------------------------------
                if (reader["RegisteredDate"] != DBNull.Value)
                    RegisteredDate = (DateTime)reader["RegisteredDate"];
                else
                    RegisteredDate = DateTime.Now;
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

        return isFound;
    }

}

