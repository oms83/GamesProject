using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class clsGamesTypeData
{
    public static bool Find(int TypeID, ref string TypeName)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Select * From GameTypes Where TypeID = @TypeID";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@TypeID", TypeID);

        bool isFound = false;

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                isFound = true;


                //------------------------------------------------
                if (reader["TypeName"] != DBNull.Value)
                    TypeName = (string)reader["TypeName"];
                else
                    TypeName = "";
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

    public static bool Find(ref int TypeID, string TypeName)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Select * From GameTypes Where TypeName = @TypeName";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@TypeName", TypeName);

        bool isFound = false;

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                isFound = true;


                //------------------------------------------------
                if (reader["TypeID"] != DBNull.Value)
                    TypeID = (int)reader["TypeID"];
                else
                    TypeID = -1;
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

    public static int AddNewGameType(string TypeName)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Insert Into GameTypes 
                         
                             (TypeName) 
                             Values 
                             (@TypeName);

                         Select Scope_Identity()";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@TypeName", TypeName);

        int GameTypeID = -1;

        try
        {
            connection.Open();

            object result = command.ExecuteScalar();

            if (result != null && int.TryParse(result.ToString(), out int Inserted))
            {
                GameTypeID = Inserted;
            }
            else
            {
                GameTypeID = -1;
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            connection.Close();
        }

        return GameTypeID;
    }

    public static bool UpdateGameType(int TypeID, string TypeName)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Update GameTypes 
                        Set 
                        TypeName = @TypeName
                        Where TypeID = @TypeID";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@TypeName", TypeName);
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

    public static bool DeleteGameType(int TypeID)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Delete From GameTypes Where TypeID = @TypeID";

        SqlCommand command = new SqlCommand(Query, connection);

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

    public static DataTable GetAllGamesType()
    {
        DataTable dt = new DataTable();

        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Select * From GameTypes";

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

    public static bool isGameTypeExist(int TypeID)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Select Found=1 From GameTypes Where TypeID = @TypeID";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@TypeID", TypeID);

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
