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


            /// File upload
            Stream streamtest = new FileStream("test2019.txt", FileMode.Create);
            string uploadfilename="test2019_2.txt";
            Function.Upload(uploadfilename, streamtest, ref service);

            // List files.
            int pagesize=10;
            Function.FileList(pagesize, ref service);


            // // Define parameters of request.
            // FilesResource.ListRequest listRequest = service.Files.List();
            // listRequest.PageSize = 10;
            // listRequest.Fields = "nextPageToken, files(id, name)";

            // // List files.
            // IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
            //     .Files;
            // Console.WriteLine("Files:");
            // if (files != null && files.Count > 0)
            // {
            //     foreach (var file in files)
            //     {
            //         Console.WriteLine("{0} ({1})", file.Name, file.Id);
            //     }
            // }
            // else
            // {
            //     Console.WriteLine("No files found.");
            // }
            // Console.Read();

            //
  

            
            

        }
    }
}