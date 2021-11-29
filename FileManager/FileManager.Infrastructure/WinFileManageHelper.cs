using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Infrastructure
{
    public class WinFileManageHelper
    {
        public WinFileManageHelper()
        {

        }

        public static void FileDisplay(string fileDirectory)
        {
            try
            {
                //creating a DirectoryInfo object
                DirectoryInfo mydir = new DirectoryInfo(@fileDirectory);
                // getting the files in the directory, their names and size
                FileInfo[] f = mydir.GetFiles();
                foreach (FileInfo file in f)
                {
                    Console.WriteLine("File Name: {0} Size: {1}", file.Name, file.Length);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static IEnumerable<FileInfo> GetAllFiles(string fileDirectory)
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(@fileDirectory);
                List<FileInfo> files = new List<FileInfo>();
                var f = directoryInfo.GetFiles().AsEnumerable();
                return f;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
