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
            //creating a DirectoryInfo object
            DirectoryInfo mydir = new DirectoryInfo(@fileDirectory);

            // getting the files in the directory, their names and size
            FileInfo[] f = mydir.GetFiles();
            foreach (FileInfo file in f)
            {
                Console.WriteLine("File Name: {0} Size: {1}", file.Name, file.Length);
            }
            Console.ReadKey();
        }
    }
}
