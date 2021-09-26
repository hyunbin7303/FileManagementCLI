using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleDirveApi
{
    class Program
    {
        // If modifying these scopes, delete your previously saved credentials and token.json
        // at ~/.credentials/drive-dotnet-quickstart.json
        static string ApplicationName = "Drive API .NET";

        static void Main(string[] args)
        {
            
            UserCredential credential = Function.Credential();

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            
            // /// File upload
            // Stream streamtest = new FileStream("test2019.txt", FileMode.Create);
            // string uploadfilename="test2019_2.txt";
            // string parent_file="1DNyRBKHyI8aIjjdZvwZrB4c6LU6xzL0p";
            // Function.Upload(uploadfilename, streamtest, parent_file, ref service);

            // List files.
            int pagesize=10;
            Function.FileList(pagesize, ref service);


            // // create folder
            // string foldername= "kevin comes korea";
            // string parent_folder= "1DNyRBKHyI8aIjjdZvwZrB4c6LU6xzL0p";
            // Console.WriteLine(Function.CreateFolder(foldername, parent_folder, ref service));


            string fileId = "1TWKeZwahlSoj_btFhAOj7hq1G2TDOCxoEH9U5PZZ-Kk";
            Function.Download(fileId, ref service);

            //
  

            
            

        }
    }
}