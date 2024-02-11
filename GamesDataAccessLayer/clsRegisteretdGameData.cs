using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

public class clsRegisteredGameData
{
    public static bool Find(int ID, ref int UserID, ref int GameID, ref DateTime RegisteredDate, ref int ResultID)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Select * From RegisteredGames Where ID = @ID";

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
                
                //-------------------------------------
                if (reader["UserID"] != DBNull.Value)
                    UserID = (int)reader["UserID"];
                else
                    UserID = -1;


                //-------------------------------------
                if (reader["GameID"] != DBNull.Value)
                    GameID = (int)reader["GameID"];
                else
                    GameID = -1;


                //-------------------------------------
                if (reader["ResultID"] != DBNull.Value)
                    ResultID = (int)reader["ResultID"];
                else
                    ResultID = -1;



                //-------------------------------------
                if (reader["RegisteredDate"] != DBNull.Value)
                    RegisteredDate = (DateTime)reader["RegisteredDate"];
                else
                    RegisteredDate = DateTime.Now;

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

    public static int AddNewRegistered(int UserID, int GameID, DateTime RegisteredDate, int ResultID)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Insert Into RegisteredGames 
                         
                             (UserID, GameID, RegisteredDate, ResultID) 
                             Values 
                             (@UserID, @GameID, @RegisteredDate, @ResultID);

                         Select Scope_Identity()";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@UserID", UserID);
        command.Parameters.AddWithValue("@GameID", GameID);
        command.Parameters.AddWithValue("@ResultID", ResultID);
        command.Parameters.AddWithValue("@RegisteredDate", RegisteredDate);

        int RegisteredID = -1;

        try
        {
            connection.Open();

            object result = command.ExecuteScalar();

            if (result != null && int.TryParse(result.ToString(), out int Inserted))
            {
                RegisteredID = Inserted;
            }
            else
            {
                RegisteredID = -1;
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            connection.Close();
        }

        return RegisteredID;
    }

    public static bool UpdateRegistered(int RegisteredID, int UserID, int GameID, DateTime RegisteredDate, int ResultID)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Update RegisteredGames 
                        Set 
                        UserID = @UserID,
                        GameID = @GameID,
                        ResultID = @ResultID,
                        RegisteredDate = @RegisteredDate
                        Where RegisteredID = @RegisteredID";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@RegisteredID", RegisteredID);
        command.Parameters.AddWithValue("@RegisteredDate", RegisteredDate);
        command.Parameters.AddWithValue("@GameID", GameID);
        command.Parameters.AddWithValue("@UserID", UserID);
        command.Parameters.AddWithValue("@ResultID", ResultID);

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

    public static bool DeleteRegistered(int RegisteredID)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Delete From RegisteredGames Where ID = @RegisteredID";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@RegisteredID", RegisteredID);

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

    public static DataTable GetAllRegistered()
    {
        DataTable dt = new DataTable();

        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Select * From RegisteredGames";

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

    public static bool isRegisteredExist(int RegisteredID)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Select Found=1 From RegisteredGames Where ID = @RegisteredID";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@RegisteredID", RegisteredID);

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

}
