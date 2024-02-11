using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

public class clsGamesData
{
    public static bool Find(int GameID, ref string GameName)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Select * From Games Where GameID = @GameID";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@GameID", GameID);

        bool isFound = false;

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                isFound = true;
                if (reader["GameName"] != DBNull.Value)
                    GameName = (string)reader["GameName"];
                else
                    GameName = "";

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


    public static bool Find(ref int GameID, string GameName)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Select * From Games Where GameName = @GameName";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@GameName", GameName);

        bool isFound = false;

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                isFound = true;
                if (reader["GameID"] != DBNull.Value)
                    GameID = (int)reader["GameID"];
                else
                    GameID = -1;

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

    public static int AddNewGame(string GameName)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Insert Into Games 
                         
                             (GameName) 
                             Values 
                             (@GameName);

                         Select Scope_Identity()";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@GameName", GameName);

        int GameID = -1;

        try
        {
            connection.Open();

            object result = command.ExecuteScalar();

            if (result != null && int.TryParse(result.ToString(), out int Inserted))
            {
                GameID = Inserted;
            }
            else
            {
                GameID = -1;
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            connection.Close();
        }

        return GameID;
    }

    public static bool UpdateGame(int GameID, string GameName)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Update Games 
                        Set 
                        GameName = @GameName
                        Where GameID = @GameID";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@GameName", GameName);
        command.Parameters.AddWithValue("@GameID", GameID);

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

    public static bool DeleteGame(int GameID)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Delete From Games Where GameID = @GameID";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@GameID", GameID);

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

    public static DataTable GetAllGames()
    {
        DataTable dt = new DataTable();

        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Select * From Games";

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

    public static bool isGameExist(int GameID)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Select Found=1 From Games Where GameID = @GameID";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@GameID", GameID);

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
