using DVLDBuisness;
using DVLDDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataBussiness
{
    public class clsTestAppointment

    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;


        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public clsTestType testTypeInfo {  get; set; }       
        public int LocalDrivingLicenseApplicationID { get; set; }
        public clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication { get; set; }     
        public DateTime AppointmentDate { get; set; }
        public int CreatedByUserID {  get; set; }
        public clsUser CreatedByUserInfo { get; set; }
        bool IsLocked { get; set; }

        public float PaidFees { set; get; }


        public clsTestAppointment()

        {
            this.TestAppointmentID = -1;
            this.TestTypeID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;

        }

        public clsTestAppointment(int TestAppointmentID, int TestTypeID,
           int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, float PaidFees,
           int CreatedByUserID, bool IsLocked)

        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            testTypeInfo = clsTestType.Find(TestTypeID);    

            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);   
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            CreatedByUserInfo = clsUser.FindUser(CreatedByUserID);
            this.IsLocked = IsLocked;
            Mode = enMode.Update;
        }




        public static DataTable GetAllTestAppointments()
        {
            return clsTestAppointmentData.GetAllTestAppointments();
        }

        public static DataTable GetTestAppointmentsForLocalDrivingLicenseID(int LocalDrivingLicenseID,int TestTypeID)
        {
            return clsTestAppointmentData.GetTestAppointmentsForLocalDrivingLicenseID(LocalDrivingLicenseID,TestTypeID);
        }




    }
}
