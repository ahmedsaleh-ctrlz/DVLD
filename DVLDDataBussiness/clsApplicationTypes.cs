using DVLDDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DVLDDataBussiness
{
    public class clsApplicationTypes
    {
        public int ApplicationTypeID { get; }
        
        public string ApplicationTitle { get; set; }

        public float ApplicationFee {  get; set; }
        

        public static DataTable GetAllApplicationsType() 
        {
            return clsApplicationTypesData.GetAllApplicationTypes();
        }

        public clsApplicationTypes ( int ID , string title,float fees) 
        {
            this.ApplicationTypeID = ID;
            this.ApplicationTitle = title;  
            this.ApplicationFee = fees;
        }

        public static clsApplicationTypes Find(int ID) 
        {
            string title = ""; float Fees = 0;
            
            if(clsApplicationTypesData.Find(ID,ref title,ref Fees)) 
            {
                return new clsApplicationTypes(ID,title,Fees);
            }
            else return null;
        }


        public bool Update()
        {
            return clsApplicationTypesData.Update(this.ApplicationTypeID, this.ApplicationTitle, this.ApplicationFee);
        }


    }
}
