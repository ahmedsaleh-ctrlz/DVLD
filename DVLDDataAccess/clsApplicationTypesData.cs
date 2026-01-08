using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DVLDDataAccess
{
    public class clsApplicationTypesData
    {

        public static DataTable GetAllApplicationTypes() 
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataSetting.ConnectionString);
            string Query = "Select * FROM ApplicationTypes";
            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

            }

            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

            return dt;
        }

        public static bool Find(int ID, ref string Title, ref float Fees) 
        {
            bool isFound = false;
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataSetting.ConnectionString);
            string Query = @"SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    Title = (string)reader["ApplicationTypeTitle"];
                    Fees = Convert.ToSingle(reader["ApplicationFees"]);
                }

            }
            catch (Exception ex) 
            {
                isFound=false;  
                MessageBox.Show(ex.Message);    
            }

            return isFound;

        }


        public static bool Update(int ID, string Title, float Fees)
        {
            bool isUpdated = false;
            SqlConnection connection = new SqlConnection(DataSetting.ConnectionString);
            string Query = @"UPDATE ApplicationTypes 
                     SET ApplicationTypeTitle = @Title, 
                         ApplicationFees = @Fees
                     WHERE ApplicationTypeID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                isUpdated = (rowsAffected > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return isUpdated;
        }





    }
}
