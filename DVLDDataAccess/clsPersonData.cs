using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDDataAccess
{
    public class clsPersonData
    {
        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(DataSetting.ConnectionString);

            string query = "SELECT PersonID, NationalNo, FirstName ,LastName, DateOfBirth, " +
                           "Gender = CASE " +
                           "    WHEN Gendor = 0 THEN 'Male' " +
                           "    WHEN Gendor = 1 THEN 'Female' " +
                           "END, " +
                           "Phone, Email, Countries.CountryName " +
                           "FROM People " +
                           "INNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID";

            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error {ex.ToString()}");
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        public static DataTable ListPeopleWithIdLike(int personId)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(DataSetting.ConnectionString);
            string query = "SELECT PersonID, NationalNo, FirstName, LastName, DateOfBirth, " +
                           "Gendor = CASE " +
                           "    WHEN Gendor = 0 THEN 'Male' " +
                           "    WHEN Gendor = 1 THEN 'Female' " +
                           "END, " +
                           "Phone, Email, Countries.CountryName " +
                           "FROM People " +
                           "INNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID " +
                           "WHERE PersonID LIKE @PersonID;";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@PersonID", "%" + personId.ToString() + "%");

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error {ex.ToString()}");
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        public static DataTable ListPeopleWithNameLike(string Name)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(DataSetting.ConnectionString);
            string query = "SELECT PersonID, NationalNo, FirstName, LastName, DateOfBirth, " +
                           "Gendor = CASE " +
                           "    WHEN Gendor = 0 THEN 'Male' " +
                           "    WHEN Gendor = 1 THEN 'Female' " +
                           "END, " +
                           "Phone, Email, Countries.CountryName " +
                           "FROM People " +
                           "INNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID " +
                           "WHERE FirstName LIKE @Name;";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", "%" + Name + "%");

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error {ex.ToString()}");
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        public static DataTable ListPeopleWithNationalNoLike(string NationalNo)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(DataSetting.ConnectionString);
            string query = "SELECT PersonID, NationalNo, FirstName, LastName, DateOfBirth, " +
                           "Gendor = CASE " +
                           "    WHEN Gendor = 0 THEN 'Male' " +
                           "    WHEN Gendor = 1 THEN 'Female' " +
                           "END, " +
                           "Phone, Email, Countries.CountryName " +
                           "FROM People " +
                           "INNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID " +
                           "WHERE NationalNo LIKE @NationalNo;";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@NationalNo", "%" + NationalNo + "%");

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error {ex.ToString()}");
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName, string ThirdName,
        string LastName, DateTime DateOfBirth, short Gendor, string Address, string Phone,
        string Email, short NationalityCountryID, string ImagePath)
        {
            //OLD WAY
            /* int PersonID = -1;

             SqlConnection connection = new SqlConnection(DataSetting.ConnectionString);
             string Query = @"INSERT INTO People 
                     (NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath)
                     VALUES 
                     (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gendor, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath);
                     SELECT SCOPE_IDENTITY();";

             try
             {
                 connection.Open();
                 using (SqlCommand command = new SqlCommand(Query, connection))
                 {
                     command.Parameters.AddWithValue("@NationalNo", NationalNo);
                     command.Parameters.AddWithValue("@FirstName", FirstName);
                     command.Parameters.AddWithValue("@SecondName", SecondName ?? (object)DBNull.Value);
                     command.Parameters.AddWithValue("@ThirdName", ThirdName ?? (object)DBNull.Value);
                     command.Parameters.AddWithValue("@LastName", LastName);
                     command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                     command.Parameters.AddWithValue("@Gendor", Gendor);
                     command.Parameters.AddWithValue("@Address", Address ?? (object)DBNull.Value);
                     command.Parameters.AddWithValue("@Phone", Phone ?? (object)DBNull.Value);
                     command.Parameters.AddWithValue("@Email", Email ?? (object)DBNull.Value);
                     command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                     command.Parameters.AddWithValue("@ImagePath", ImagePath ?? (object)DBNull.Value);

                     object result = command.ExecuteScalar();
                     if (result != null)
                     {
                         PersonID = Convert.ToInt32(result);
                     }
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message.ToString());
                 PersonID = -1;
             }
             finally
             {
                 connection.Close();
             }

             return PersonID;
             */
            //New Way=>
            int PersonID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataSetting.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_AddNewPerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        //Add Params
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);
                        command.Parameters.AddWithValue("@FirstName", FirstName);
                        command.Parameters.AddWithValue("@SecondName", SecondName ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@ThirdName", ThirdName ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@LastName", LastName);
                        command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                        command.Parameters.AddWithValue("@Gendor", Gendor);
                        command.Parameters.AddWithValue("@Address", Address ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Phone", Phone ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Email", Email ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@NationalCountryID", NationalityCountryID);
                        command.Parameters.AddWithValue("@ImagePath", ImagePath ?? (object)DBNull.Value);

                        SqlParameter output = new SqlParameter("@NewPersonID", SqlDbType.Int)
                        { Direction = ParameterDirection.Output };
                        command.Parameters.Add(output);

                        command.ExecuteNonQuery();
                        PersonID = (int)command.Parameters["@NewPersonID"].Value;

                    }
                }

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            return PersonID;


        }

        public static bool FindPerson(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName,
        ref string LastName, ref DateTime DateOfBirth, ref short Gendor, ref string Address, ref string Phone,
        ref string Email, ref short NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataSetting.ConnectionString);
            string Query = @"SELECT NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath
                    FROM People
                    WHERE PersonID = @PersonID";

            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            NationalNo = reader["NationalNo"].ToString();
                            FirstName = reader["FirstName"].ToString();
                            SecondName = reader["SecondName"] == DBNull.Value ? null : reader["SecondName"].ToString();
                            ThirdName = reader["ThirdName"] == DBNull.Value ? null : reader["ThirdName"].ToString();
                            LastName = reader["LastName"].ToString();
                            DateOfBirth = Convert.ToDateTime(reader"DateOfBirth"]);
                            Gendor = Convert.ToInt16(reader["Gendor"]);
                            Address = reader["Address"] == DBNull.Value ? null : reader["Address"].ToString();
                            Phone = reader["Phone"] == DBNull.Value ? null : reader["Phone"].ToString();
                            Email = reader["Email"] == DBNull.Value ? null : reader["Email"].ToString();
                            NationalityCountryID = Convert.ToInt16(reader["NationalityCountryID"]);
                            ImagePath = reader["ImagePath"] == DBNull.Value ? null : reader["ImagePath"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool FindPersonByNationalNo(string NationalNo, ref int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName,
        ref string LastName, ref DateTime DateOfBirth, ref short Gendor, ref string Address, ref string Phone,
        ref string Email, ref short NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataSetting.ConnectionString);
            string Query = @"SELECT PersonID, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath
                    FROM People
                    WHERE NationalNo = @NationalNo";

            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            PersonID = Convert.ToInt32(reader["PersonID"]);
                            FirstName = reader["FirstName"].ToString();
                            SecondName = reader["SecondName"] == DBNull.Value ? null : reader["SecondName"].ToString();
                            ThirdName = reader["ThirdName"] == DBNull.Value ? null : reader["ThirdName"].ToString();
                            LastName = reader["LastName"].ToString();
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                            Gendor = Convert.ToInt16(reader["Gendor"]);
                            Address = reader["Address"] == DBNull.Value ? null : reader["Address"].ToString();
                            Phone = reader["Phone"] == DBNull.Value ? null : reader["Phone"].ToString();
                            Email = reader["Email"] == DBNull.Value ? null : reader["Email"].ToString();
                            NationalityCountryID = Convert.ToInt16(reader["NationalityCountryID"]);
                            ImagePath = reader["ImagePath"] == DBNull.Value ? null : reader["ImagePath"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool UpdatePerson(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName,
            string LastName, DateTime DateOfBirth, short Gendor, string Address, string Phone,
            string Email, short NationalityCountryID, string ImagePath)
        {
            bool isUpdated = false;

            SqlConnection connection = new SqlConnection(DataSetting.ConnectionString);
            string Query = @"UPDATE People 
                    SET NationalNo = @NationalNo,
                        FirstName = @FirstName,
                        SecondName = @SecondName,
                        ThirdName = @ThirdName,
                        LastName = @LastName,
                        DateOfBirth = @DateOfBirth,
                        Gendor = @Gendor,
                        Address = @Address,
                        Phone = @Phone,
                        Email = @Email,
                        NationalityCountryID = @NationalityCountryID,
                        ImagePath = @ImagePath
                    WHERE PersonID = @PersonID";

            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ThirdName", ThirdName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gendor", Gendor);
                    command.Parameters.AddWithValue("@Address", Address ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Phone", Phone ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Email", Email ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                    command.Parameters.AddWithValue("@ImagePath", ImagePath ?? (object)DBNull.Value);

                    int rowsAffected = command.ExecuteNonQuery();
                    isUpdated = (rowsAffected > 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                isUpdated = false;
            }
            finally
            {
                connection.Close();
            }

            return isUpdated;
        }

        public static bool DeletePerson(int PersonID)
        {
            int rawAffected = 0;
            SqlConnection connection = new SqlConnection(DataSetting.ConnectionString);
            string query = @"DELETE FROM People WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                rawAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot Delete this Person Becasuse another data linked to it", "Info", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                connection.Close();
            }
            return rawAffected > 0;
        }

        public static bool IsNationalNoExists(string NationalNo, int excludePersonID = -1)
        {
            bool exists = false;
            using (SqlConnection connection = new SqlConnection(DataSetting.ConnectionString))
            {
                string query = @"SELECT COUNT(1) 
                                FROM People 
                                WHERE NationalNo = @NationalNo 
                                AND (@excludePersonID = -1 OR PersonID != @excludePersonID)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@excludePersonID", excludePersonID);

                    try
                    {
                        connection.Open();
                        exists = Convert.ToInt32(command.ExecuteScalar()) > 0;
                    }
                    catch (Exception)
                    {
                        exists = false;
                    }
                }
            }
            return exists;
        }
    }
}