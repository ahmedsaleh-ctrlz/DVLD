using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDDataBussiness
{
    public class clsUtil

    {

        public static string GenerateGuid()
        {
            return Guid.NewGuid().ToString();
        }

        public static string ReplaceFileNameWithGUID(string sourcefile) 
        {
            string fileName = sourcefile;
            FileInfo File = new FileInfo(fileName); 
            string extn = File.Extension;
            return GenerateGuid() + extn;
        } 
       

        public static bool CopyImageToProjectFile(ref string SourceFile)
        {
            string DestinationFolder = "C:\\MyC\\DVLD_Images\\";
            string DestinationFile = DestinationFolder + ReplaceFileNameWithGUID(SourceFile);

            try 
            {
                File.Copy(SourceFile, DestinationFile, true);
               
            }

            catch (IOException ex) 
            {
                MessageBox.Show(ex.Message);
                return false;       
            }
            SourceFile = DestinationFile;
            return true;

        }


    }


}
