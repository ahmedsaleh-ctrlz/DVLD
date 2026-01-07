using DVLDAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBussinessLayer
{
    public class DataBussiness
    {
        public static DataTable GetAllPeople() 
        {

            return DataAccess.ListPeople();

        }
        public static DataTable GetPeopleWithId(int id) 
        {

            return DataAccess.ListPeopleWithIdLike(id);

        }
        public static DataTable GetPeopleWithNationalNo(string NationalNo)
        {

            return DataAccess.ListPeopleWithNationalNumberLike(NationalNo);

        }
        public static DataTable GetPeopleWithName(string FirstName)
        {

            return DataAccess.ListPeopleWithNameLike(FirstName);

        }



    }
}
