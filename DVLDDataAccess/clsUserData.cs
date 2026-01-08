using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace DVLDDataAccess
{
    public class clsUserData
    {
        public static int AddNewUser(int PersonID, string UserName, string Password, bool IsActive)
        {
            int UserID = -1;
            using (SqlConnection connection = new SqlConnection(DataSetting.ConnectionString))
            {
                string Query = @"INSERT INTO Users 
                    (PersonID, UserName, Password, IsActive)
                    VALUES 
                    (@PersonID, @UserName, @Password, @IsActive);
                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", (object)Password ?? DBNull.Value);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            UserID = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                        UserID = -1;
                    }
                }
            }
            return UserID;
        }


        public static bool FindUser(int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(DataSetting.ConnectionString))
            {
                string Query = @"SELECT PersonID, UserName, Password, IsActive
                    FROM Users
                    WHERE UserID = @UserID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                PersonID = reader["PersonID"] != DBNull.Value ? Convert.ToInt32(reader["PersonID"]) : 0;
                                UserName = reader["UserName"].ToString();
                                Password = reader["Password"] != DBNull.Value ? reader["Password"].ToString() : null;
                                IsActive = reader["IsActive"] != DBNull.Value ? Convert.ToBoolean(reader["IsActive"]) : false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.ToString()}");
                        isFound = false;
                    }
                }
            }
            return isFound;
        }

        public static bool FindUserWithUserName(string UserName, ref int UserID, ref int PersonID,
            ref string Password, ref bool IsActive)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(DataSetting.ConnectionString))
            {
                string Query = @"SELECT UserID, PersonID, Password, IsActive
                    FROM Users
                    WHERE UserName = @UserName";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", UserName);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                PersonID = reader["PersonID"] != DBNull.Value ? Convert.ToInt32(reader["PersonID"]) : 0;
                                UserID = reader["UserID"] != DBNull.Value ? Convert.ToInt32(reader["UserID"]) : 0;
                                Password = reader["Password"] != DBNull.Value ? reader["Password"].ToString() : null;
                                IsActive = reader["IsActive"] != DBNull.Value ? Convert.ToBoolean(reader["IsActive"]) : false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.ToString()}");
                        isFound = false;
                    }
                }
            }
            return isFound;
        }

        public static bool UpdateUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            bool isUpdated = false;
            using (SqlConnection connection = new SqlConnection(DataSetting.ConnectionString))
            {
                string Query = @"UPDATE Users 
                    SET PersonID = @PersonID,
                        UserName = @UserName,
                        Password = @Password,
                        IsActive = @IsActive
                    WHERE UserID = @UserID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", (object)Password ?? DBNull.Value);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        isUpdated = (rowsAffected > 0);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.ToString()}");
                        isUpdated = false;
                    }
                }
            }
            return isUpdated;
        }

        public static bool DeleteUser(int userId)
        {
            bool isDeleted = false;

            string query = "DELETE FROM Users WHERE UserID = @Id";

            using (SqlConnection conn = new SqlConnection(DataSetting.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", userId);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        isDeleted = rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.ToString()}");
                    }
                }
            }

            return isDeleted;
        }

        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(DataSetting.ConnectionString))
            {
                string query = @"SELECT 
                    [User ID] = UserID,
                    [Person ID] = Users.PersonID,
                    [Full Name] = COALESCE(People.FirstName + ' ', '') + 
                                 COALESCE(People.SecondName + ' ', '') + 
                                 COALESCE(People.ThirdName + ' ', '') + 
                                 COALESCE(People.LastName, ''),
                    UserName,
                    IsActive
                FROM Users
                INNER JOIN People ON Users.PersonID = People.PersonID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.ToString()}");
                    }
                }
            }
            return dt;
        }

        public static DataTable FilterByUserID(int UserID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(DataSetting.ConnectionString))
            {
                string query = @"SELECT 
                    [User ID] = UserID,
                    [Person ID] = Users.PersonID,
                    [Full Name] = COALESCE(People.FirstName + ' ', '') + 
                                 COALESCE(People.SecondName + ' ', '') + 
                                 COALESCE(People.ThirdName + ' ', '') + 
                                 COALESCE(People.LastName, ''),
                    UserName,
                    IsActive
                FROM Users
                INNER JOIN People ON Users.PersonID = People.PersonID
                WHERE UserID = @UserID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", (object)UserID ?? DBNull.Value);
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.ToString()}");
                    }
                }
            }
            return dt;
        }

        public static DataTable FilterByPersonID(int PersonID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(DataSetting.ConnectionString))
            {
                string query = @"SELECT 
                    [User ID] = UserID,
                    [Person ID] = Users.PersonID,
                    [Full Name] = COALESCE(People.FirstName + ' ', '') + 
                                 COALESCE(People.SecondName + ' ', '') + 
                                 COALESCE(People.ThirdName + ' ', '') + 
                                 COALESCE(People.LastName, ''),
                    UserName,
                    IsActive
                FROM Users
                INNER JOIN People ON Users.PersonID = People.PersonID
                WHERE Users.PersonID = @PersonID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.ToString()}");
                    }
                }
            }
            return dt;
        }

        public static DataTable FilterByFullName(string FullName)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(DataSetting.ConnectionString))
            {
                string query = @"SELECT 
                    [User ID] = UserID,
                    [Person ID] = Users.PersonID,
                    [Full Name] = COALESCE(People.FirstName + ' ', '') + 
                                 COALESCE(People.SecondName + ' ', '') + 
                                 COALESCE(People.ThirdName + ' ', '') + 
                                 COALESCE(People.LastName, ''),
                    UserName,
                    IsActive
                FROM Users
                INNER JOIN People ON Users.PersonID = People.PersonID
                WHERE COALESCE(People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName, '') LIKE @FullName + '%'";
                // استخدام LIKE مع % عشان يدعم البحث الجزئي

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FullName", (object)FullName ?? DBNull.Value);
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.ToString()}");
                    }
                }
            }
            return dt;
        }

        public static DataTable FilterByUserName(string UserName)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(DataSetting.ConnectionString))
            {
                string query = @"SELECT 
                    [User ID] = UserID,
                    [Person ID] = Users.PersonID,
                    [Full Name] = COALESCE(People.FirstName + ' ', '') + 
                                 COALESCE(People.SecondName + ' ', '') + 
                                 COALESCE(People.ThirdName + ' ', '') + 
                                 COALESCE(People.LastName, ''),
                    UserName,
                    IsActive
                FROM Users
                INNER JOIN People ON Users.PersonID = People.PersonID
                WHERE UserName LIKE @UserName + '%'";
                // استخدام LIKE مع % عشان يدعم البحث الجزئي

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", (object)UserName ?? DBNull.Value);
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.ToString()}");
                    }
                }
            }
            return dt;
        }

        public static bool IsUserExists(int personID)
        {
            bool exists = false;

            using (SqlConnection connection = new SqlConnection(DataSetting.ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", personID);

                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        exists = (count > 0);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                        exists = false;
                    }
                }
            }

            return exists;
        }


        public static void HashAllPassword() 
        {
          

            using (SqlConnection conn = new SqlConnection(DataSetting.ConnectionString))
            
            {

                conn.Open ();
                string SelectQuery = @"Select UserID , Password From USERS";
                using (SqlCommand cmd = new SqlCommand(SelectQuery, conn)) 
                {
                    using (SqlDataReader reader = cmd.ExecuteReader()) 
                    {

                        while (reader.Read()) 
                        {
                            int UserID = reader.GetInt32(0);
                            string Password = reader.GetString(1);
                            string HashedPassword = "";

                            using (SHA256 sHA256 = SHA256.Create()) 
                            {
                                
                                byte[] HashBytes = sHA256.ComputeHash(Encoding.UTF8.GetBytes(Password));
                                HashedPassword = BitConverter.ToString(HashBytes).Replace("-","").ToLower();

                            }



                            using (SqlConnection connection = new SqlConnection(DataSetting.ConnectionString)) 
                            {
                                connection.Open();
                                string UpdateQuery = @"Update Users set Password = @HashPassword Where USERID = @UserID " ;
                                using (SqlCommand command = new SqlCommand(UpdateQuery, connection)) 
                                {
                                    command.Parameters.AddWithValue("@HashPassword", HashedPassword);
                                    command.Parameters.AddWithValue("@UserID", UserID);

                                    int rawaffected = command.ExecuteNonQuery();
                                    

                                }  



                            }

                           

                        }

                    }

                }

              

            }

        }
      

    }
}