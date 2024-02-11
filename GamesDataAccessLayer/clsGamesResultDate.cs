using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class clsGamesResultDate
{
    public static bool Find(int ResultID, ref int GameID, ref int WinningTimes, ref int LossTimes,
                            ref int PlayTimes)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Select * From GameResults Where ResultID = @ResultID";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@ResultID", ResultID);

        bool isFound = false;

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                isFound = true;

                //------------------------------------------------
                if (reader["GameID"] != DBNull.Value)
                    GameID = (int)reader["GameID"];
                else
                    GameID = -1;

                
                //------------------------------------------------
                if (reader["LossTimes"] != DBNull.Value)
                    LossTimes = (int)reader["LossTimes"];
                else
                    LossTimes = 0;

                
                //------------------------------------------------
                if (reader["WinningTimes"] != DBNull.Value)
                    WinningTimes = (int)reader["WinningTimes"];
                else
                    WinningTimes = 0;


                //------------------------------------------------
                if (reader["PlayTimes"] != DBNull.Value)
                        PlayTimes = (int)reader["PlayTimes"];
                else
                    PlayTimes = 0;

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

    public static int AddNewGameResult(int GameID, int WinningTimes, int LossTimes, int PlayTimes)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Insert Into GameResults 
                         
                             (WinningTimes, LossTimes, PlayTimes, GameID) 
                             Values 
                             (@WinningTimes, @LossTimes, @PlayTimes, @GameID);

                         Select Scope_Identity()";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@WinningTimes", WinningTimes);
        command.Parameters.AddWithValue("@LossTimes", LossTimes);
        command.Parameters.AddWithValue("@GameID", GameID);
        command.Parameters.AddWithValue("@PlayTimes", PlayTimes);

        int GameResultID = -1;

        try
        {
            connection.Open();

            object result = command.ExecuteScalar();

            if (result != null && int.TryParse(result.ToString(), out int Inserted))
            {
                GameResultID = Inserted;
            }
            else
            {
                GameResultID = -1;
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            connection.Close();
        }

        return GameResultID;
    }

    public static bool UpdateGameResult(int ResultID, int GameID, int WinningTimes, int LossTimes,
                                  int PlayTimes)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Update GameResults 
                        Set 
                        WinningTimes = @WinningTimes,
                        LossTimes = @LossTimes,
                        PlayTimes = @PlayTimes,
                        GameID = @GameID
                        Where ResultID = @ResultID";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@WinningTimes", WinningTimes);
        command.Parameters.AddWithValue("@LossTimes", LossTimes);
        command.Parameters.AddWithValue("@PlayTimes", PlayTimes);
        command.Parameters.AddWithValue("@GameID", GameID);
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

    public static bool DeleteGameResult(int ResultID)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Delete From GameResults Where ResultID = @ResultID";

        SqlCommand command = new SqlCommand(Query, connection);

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

    public static DataTable GetAllGamesResult()
    {
        DataTable dt = new DataTable();

        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Select * From GameResults";

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

    public static bool isGameResultExist(int ResultID)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Select Found=1 From GameResults Where ResultID = @ResultID";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@ResultID", ResultID);

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
