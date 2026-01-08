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
    public class clsCountryData
    {
        public static DataTable GetAllCountry()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataSetting.ConnectionString);
            string query = "SELECT * FROM Countries";
            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static string GetCountryName(int CountryID)
        {
            string countryName = "";
            SqlConnection connection = new SqlConnection(DataSetting.ConnectionString);
            string query = @"SELECT CountryName FROM Countries WHERE CountryID = @CountryID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                countryName = result?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                // يمكنك تسجيل الخطأ هنا إذا لزم الأمر
            }
            finally
            {
                connection.Close();
            }
            return countryName;
        }

        public static bool Exists(int countryId)
        {
            using (SqlConnection conn = new SqlConnection(DataSetting.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Countries WHERE CountryID = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", countryId);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }
    }
}
