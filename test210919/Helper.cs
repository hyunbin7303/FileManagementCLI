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
    class Helper
    {
        public static UserCredential credential()
        {   //You can change the Scope of drive service.
            string[] Scopes = { DriveService.Scope.Drive };
            UserCredential credential;
        
            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);

                return credential;
            }
            
        }

        public static void upload(string uploadfilename, Stream streamtest, ref DriveService service)
        {
            string fileMime ="[*/*]]";
            var driveFile = new Google.Apis.Drive.v3.Data.File();
            driveFile.Name = uploadfilename;
            // driveFile.Description = fileDescription;
            driveFile.MimeType = fileMime;
            // driveFile.Parents = new string[] { "./" };
            
            var request = service.Files.Create(driveFile, streamtest, fileMime);
            request.Fields = "id";
            
            var response = request.Upload();
            if (response.Status != Google.Apis.Upload.UploadStatus.Completed)
                throw response.Exception;
        }

        public static void filelist(int pagesize, ref DriveService service)
        {

            // Define parameters of request.
            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.PageSize = pagesize;
            listRequest.Fields = "nextPageToken, files(id, name)";

            // List files.
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
                .Files;
            Console.WriteLine("Files:");
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    Console.WriteLine("{0} ({1})", file.Name, file.Id);
                }
            }
            else
            {
                Console.WriteLine("No files found.");
            }
            Console.Read();
        }


    }
}