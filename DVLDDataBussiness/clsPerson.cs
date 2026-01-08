using DVLDDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataBussiness
{
    public class clsPerson
    {
        private enum enMode { AddNew, Update }
        private enMode _Mode;

        public int ID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public short Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public short NationalCountryID { get; set; }
        public string ImagePath { get; set; }

        public string PersonFullName 
        {
            get 
            {
                return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; 
            }
        }

        public clsPerson()
        {
            ID = -1;
            NationalCountryID = -1;
            NationalNo = "";
            FirstName = "";
            LastName = "";
            SecondName = "";
            ThirdName = "";
            DateOfBirth = DateTime.Now;
            Gender = 0;
            Address = "";
            Phone = "";
            Email = "";
            ImagePath = "";
            _Mode = enMode.AddNew;
        }

        protected clsPerson(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName,
            string LastName, DateTime DateOfBirth, short Gender, string Address, string Phone,
            string Email, short NationalCountryID, string ImagePath)
        {
            this.ID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalCountryID = NationalCountryID;
            this.ImagePath = ImagePath;
            this._Mode = enMode.Update;
        }

        private bool _AddNewPerson()
        {
            this.ID = clsPersonData.AddNewPerson(NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address,
                Phone, Email, NationalCountryID, ImagePath);
            return (ID != -1);
        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(ID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                Gender, Address, Phone, Email, NationalCountryID, ImagePath);
        }

        public static clsPerson Find(int PersonID)
        {
            string NationalNo = "";
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            short Gender = 0;
            string Address = "";
            string Phone = "";
            string Email = "";
            short NationalCountryID = -1;
            string ImagePath = "";

            if (clsPersonData.FindPerson(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName,
                ref LastName, ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email, ref NationalCountryID, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, Phone, Email, NationalCountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }

        public static bool Delete(int PersonID)
        {
            return clsPersonData.DeletePerson(PersonID);
        }

        public bool Save()
        {
            // تحقق من أن الدولة موجودة
            if (!clsCountry.IsCountryExist(NationalCountryID))
                throw new Exception("الدولة المختارة غير موجودة في قاعدة البيانات.");

            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdatePerson();

                default:
                    return false;
            }
        }

        public static bool IsNationalNoExist(string NationalNo, int excludePersonID)
        {
            return clsPersonData.IsNationalNoExists(NationalNo, excludePersonID);
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }

        public static DataTable FilterPeopleByName(string name)
        {
            return clsPersonData.ListPeopleWithNameLike(name);
        }

        public static DataTable FilterPeopleByNationalNo(string NationalNo)
        {
            return clsPersonData.ListPeopleWithNationalNoLike(NationalNo);
        }

        public static DataTable FilterPeopleByPersonID(int PersonID)
        {
            return clsPersonData.ListPeopleWithIdLike(PersonID);
        }

        public static clsPerson Find (string NationalNo) 
        {
            int PersonID = -1;
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            short Gender = 0;
            string Address = "";
            string Phone = "";
            string Email = "";
            short NationalCountryID = -1;
            string ImagePath = "";

            if (clsPersonData.FindPersonByNationalNo(NationalNo, ref PersonID, ref FirstName, ref SecondName, ref ThirdName,
                ref LastName, ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email, ref NationalCountryID, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, Phone, Email, NationalCountryID, ImagePath);
            }
            else
            {
                return null;
            }

        }
    }
}
