using DVLDDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataBussiness
{
    public class clsCountry
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        public static DataTable GetAllCountry()
        {
            return clsCountryData.GetAllCountry();
        }

        public static string GetCountryNameByID(int CountryID)
        {
            return clsCountryData.GetCountryName(CountryID);
        }

        public static bool IsCountryExist(short countryID)
        {
            return clsCountryData.Exists(countryID);
        }
    }
}
