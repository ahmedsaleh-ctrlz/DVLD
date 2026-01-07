using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DVLDAccessLayer
{
    public class DataAccess
    {
     
        public static DataTable ListPeople() 
            {
                DataTable dt = new DataTable();
                SqlConnection conn = new SqlConnection(DataSetting.ConnectionString);
                string query = "Select PersonID,NationalNo,FirstName,LastName,DateOfBirth," +
                "\r\nGendor = case \r\nWHEN Gendor = 0 then 'Male'\r\nWHEN Gendor = 1 then 'Female'\r\nEND\r\n," +
                "Phone,Email,Countries.CountryName\r\nFROM People " +
                "INNER JOIN Countries on People.NationalityCountryID = Countries.CountryID;";
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

            // استخدام المعامل في SqlCommand
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
        public static DataTable ListPeopleWithNationalNumberLike(string NationalNo)
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

            // استخدام المعامل في SqlCommand
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

            // استخدام المعامل في SqlCommand
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







    }
}
