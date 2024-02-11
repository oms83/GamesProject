using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class clsPermissionData
{
    public static bool Find(int PermissionID, ref int Value, ref string Name)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Select * From Permissions Where PermissionID = @PermissionID";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@PermissionID", PermissionID);

        bool isFound = false;

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                isFound = true;
                

                //-------------------------------------
                if (reader["Name"] != DBNull.Value)
                    Name = (string)reader["Name"];
                else
                    Name = "";


                //-------------------------------------
                if (reader["Value"] != DBNull.Value)
                    Value = (int)reader["Value"];
                else
                    Value = 0;

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

    public static bool Find(ref int PermissionID, ref int Value, string Name)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Select * From Permissions Where Name = @Name";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@Name", Name);

        bool isFound = false;

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                isFound = true;


                //-------------------------------------
                if (reader["PermissionID"] != DBNull.Value)
                    PermissionID = (int)reader["PermissionID"];
                else
                    PermissionID = -1;


                //-------------------------------------
                if (reader["Value"] != DBNull.Value)
                    Value = (int)reader["Value"];
                else
                    Value = 0;

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

    public static int AddNewPermission(int Value, string Name)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Insert Into Permissions (Value, Name) Values (@Value, @Name);
                    Select Scope_Identity()";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@Value", Value);
        command.Parameters.AddWithValue("@Name", Name);

        int PermissionID = -1;

        try
        {
            connection.Open();

            object result = command.ExecuteScalar();

            if (result != null && int.TryParse(result.ToString(), out int Inserted))
            {
                PermissionID = Inserted;
            }
            else
            {
                PermissionID = -1;
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            connection.Close();
        }

        return PermissionID;
    }

    public static bool UpdatePermission(int PermissionID, int Value, string Name)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Update Permissions 
                        Set 
                        Value = @Value,
                        Name = @Name
                        Where PermissionID = @PermissionID";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@PermissionID", PermissionID);
        command.Parameters.AddWithValue("@Value", Value);
        command.Parameters.AddWithValue("@Name", Name);

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

    public static bool DeletePermission(int PermissionID)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Delete From Permissions Where PermissionID = @PermissionID";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@PermissionID", PermissionID);

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

    public static DataTable GetAllPermissions()
    {
        DataTable dt = new DataTable();

        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Select * From Permissions";

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

    public static bool isPermissionExist(int PermissionID)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Select Found=1 From Permissions Where PermissionID = @PermissionID";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@PermissionID", PermissionID);

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
