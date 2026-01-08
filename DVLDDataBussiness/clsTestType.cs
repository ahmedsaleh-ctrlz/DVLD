using DVLDDataAccess;
using System;
using System.Data;

namespace DVLDDataBussiness
{
    public class clsTestType
    {
        public int TestTypeID { get; }

        public string TestTypeTitle { get; set; }

        public string TestTypeDescription { get; set; }

        public float TestTypeFees { get; set; }

        public clsTestType(int id, string title, string description, float fees)
        {
            this.TestTypeID = id;
            this.TestTypeTitle = title;
            this.TestTypeDescription = description;
            this.TestTypeFees = fees;
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypeData.GetAllTestTypes();
        }

        public static clsTestType Find(int id)
        {
            string title = "";
            string description = "";
            float fees = 0;

            if (clsTestTypeData.Find(id, ref title, ref description, ref fees))
            {
                return new clsTestType(id, title, description, fees);
            }
            else
                return null;
        }

        public bool Update()
        {
            return clsTestTypeData.Update(this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
        }
    }
}
