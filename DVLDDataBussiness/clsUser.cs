using DVLDDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DVLDDataBussiness
{
    public class clsUser
    {
        private enum enMode { AddNew, Update }
        private enMode _Mode;

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public int PersonID { get; set; }
        public clsPerson PersonInfo;

        public clsUser()
        {
            UserID = -1;
            UserName = "";
            Password = "";
            IsActive = false;
            _Mode = enMode.AddNew;
        }

        private clsUser(int userID,int PersonID,string userName, string password, bool isActive)
           
        {
            this.UserID = userID;
            this.PersonID = PersonID;
            this.UserName = userName;
            this.Password = password;
            this.IsActive = isActive;
            PersonInfo = clsPerson.Find(PersonID);
            _Mode = enMode.Update;
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.PersonID, this.UserName, clsSecuirty.ComputeHash(this.Password), this.IsActive);
            return (UserID != -1);
        }

        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.UserID, this.PersonID, this.UserName, clsSecuirty.ComputeHash(this.Password), this.IsActive);
        }

        public bool SaveUser()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateUser();

                default:
                    return false;
            }
        }

        public static clsUser FindUser(int userID)
        {
            int personID = -1;
            string userName = "";
            string password = "";
            bool isActive = false;

            if (clsUserData.FindUser(userID, ref personID, ref userName, ref password, ref isActive))
            {
                // هجيب بيانات الشخص
                clsPerson person = clsPerson.Find(personID);

                if (person != null)
                {
                    return new clsUser(userID, personID,userName, password, isActive);
                }
            }

            return null;
        }


        public static clsUser FindUserWithUserName(string UserName)
        {
            int userID = -1;
            int personID = -1;

            string password = "";
            bool isActive = false;

            if (clsUserData.FindUserWithUserName(UserName, ref userID, ref personID, ref password, ref isActive))
            {
                // هجيب بيانات الشخص
                clsPerson person = clsPerson.Find(personID);

                if (person != null)
                {
                    return new clsUser(userID, personID, UserName, password, isActive);
                }
            }

            return null;
        }


        public static bool DeleteUser(int userID)
        {
           return clsUserData.DeleteUser(userID);
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static DataTable FilterUserByUserID(int UserID)
        {
            return clsUserData.FilterByUserID(UserID);
        }

        public static DataTable FilterUserByPersonID(int PersonID)
        {
            return clsUserData.FilterByPersonID(PersonID);
        }

        public static DataTable FilterUserByUserName(string UserName)
        {
            return clsUserData.FilterByUserName(UserName);
        }

        public static DataTable FilterUserByName(string Name)
        {
            return clsUserData.FilterByFullName(Name);
        }

        public static bool IsUserExist(int PersonID) 
        {
            return clsUserData.IsUserExists(PersonID);
        }


        public static void HashAllPassword()
        { clsUserData.HashAllPassword(); }   
    }

}
