using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class clsGamesHasTypeData
{
    public static bool Find(int HasTypeID, ref int TypeID, ref int GameID)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Select * From GamesHasType Where HasTypeID = @HasTypeID";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@HasTypeID", HasTypeID);

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
                if (reader["TypeID"] != DBNull.Value)
                    TypeID = (int)reader["TypeID"];
                else
                    TypeID = -1;

                //------------------------------------------------
                if (reader["HasTypeID"] != DBNull.Value)
                    HasTypeID = (int)reader["HasTypeID"];
                else
                    HasTypeID = -1;
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

    public static int AddNewGamesHasType(int TypeID, int GameID)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Insert Into GamesHasType 
                         
                             (TypeID, GameID) 
                             Values 
                             (@TypeID, @GameID);

                         Select Scope_Identity()";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@GameID", GameID);
        command.Parameters.AddWithValue("@TypeID", TypeID);

        int GamesHasTypeID = -1;

        try
        {
            connection.Open();

            object result = command.ExecuteScalar();

            if (result != null && int.TryParse(result.ToString(), out int Inserted))
            {
                GamesHasTypeID = Inserted;
            }
            else
            {
                GamesHasTypeID = -1;
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            connection.Close();
        }

        return GamesHasTypeID;
    }

    public static bool UpdateGamesHasType(int HasTypeID, int TypeID, int GameID)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Update GamesHasType 
                        Set 
                        GameID = @GameID,
                        TypeID = @TypeID
                        Where HasTypeID = @HasTypeID";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@GameID", GameID);
        command.Parameters.AddWithValue("@HasTypeID", HasTypeID);
        command.Parameters.AddWithValue("@TypeID", TypeID);

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

    public static bool DeleteGamesHasType(int HasTypeID)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Delete From GamesHasType Where HasTypeID = @HasTypeID";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@HasTypeID", HasTypeID);

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

    public static DataTable GetAllGamesHasType()
    {
        DataTable dt = new DataTable();

        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Select * From GamesHasType";

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

    public static bool isGamesHasTypeExist(int HasTypeID)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Select Found=1 From GamesHasType Where HasTypeID = @HasTypeID";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@HasTypeID", HasTypeID);

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
