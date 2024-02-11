using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class clsHasPermissionData
{
        
    public static bool Find(int ID, ref int UserID, ref int PermissionID)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Select * From HasPermissions Where ID = @ID";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@ID", ID);
            
        bool isFound = false;

        try
        {
            connection.Open();
                
            SqlDataReader reader = command.ExecuteReader();

            if(reader.Read())
            {
                isFound = true;

                if (reader["PermissionID"] != DBNull.Value)
                    PermissionID = (int)reader["PermissionID"];
                else
                    PermissionID = -1;


                if (reader["UserID"] != DBNull.Value)
                    UserID = (int)reader["UserID"];
                else
                    UserID = -1;

            }

            reader.Close();

        }
        catch(Exception ex)
        {
            isFound = false;
        }
        finally
        {
            connection.Close();
        }
            
        return isFound;
    }

    public static int AddNewHasPermission(int UserID, int PermissionID)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Insert Into HasPermissions (UserID, PermissionID) Values (@UserID, @PermissionID);
                        Select Scope_Identity()";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@PermissionID", PermissionID);
        command.Parameters.AddWithValue("@UserID", UserID);

        int ID = -1;

        try
        {
            connection.Open();

            object result = command.ExecuteScalar();

            if (result != null && int.TryParse(result.ToString(), out int Inserted))
            {
                ID = Inserted;
            }
            else
            {
                ID = -1;
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            connection.Close();
        }

        return ID;
    }

    public static bool UpdateHasPermission(int ID, int UserID, int PermissionID)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Update HasPermissions 
                            Set 
                            UserID = @UserID,
                            PermissionID = @PermissionID
                            Where ID = @ID";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@UserID", UserID);
        command.Parameters.AddWithValue("@PermissionID", PermissionID);
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

    public static bool DeleteHasPermission(int ID)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Delete From HasPermissions Where ID = @ID";

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

    public static DataTable GetAllHasPermissions()
    {
        DataTable dt = new DataTable();

        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Select * From HasPermissions";

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

    public static bool isHasPermissionExist(int ID)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Select Found=1 From HasPermissions Where ID = @ID";

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

}
