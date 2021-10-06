using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;
using Google.Apis.Download;

namespace FileManager.Infrastructure._3rd_Parties
{
    public class GoogleDocClient
    {
        public static DriveService Getservice()
        {
            string ApplicationName = "Drive API .NET";
            //You can change the Scope of drive service.
            string[] Scopes = { DriveService.Scope.Drive};
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
            }
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });    
            return service;        
        }
        public static void upload(string uploadfilename, Stream streamtest, string parent)
        {
            var service = Getservice();
            string fileMime ="[*/*]]";
            var driveFile = new Google.Apis.Drive.v3.Data.File();
            driveFile.Name = uploadfilename;
            // driveFile.Description = fileDescription;
            driveFile.MimeType = fileMime;
            driveFile.Parents = new string[] { parent };
            
            var request = service.Files.Create(driveFile, streamtest, fileMime);
            request.Fields = "id";
            
            var response = request.Upload();
            if (response.Status != Google.Apis.Upload.UploadStatus.Completed)
                throw response.Exception;
        }

        public static void filelist(int pagesize)
        {
            var service = Getservice();
            // Define parameters of request.
            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.PageSize = pagesize;
            listRequest.Fields = "nextPageToken, files(id, name, mimeType)";

            // List files.
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute().Files;
            Console.WriteLine("Files:");
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    Console.WriteLine("{0} ({1}) ({2})", file.Name, file.Id, file.MimeType);
                }
            }
            else
            {
                Console.WriteLine("No files found.");
            }
        }

        public static string createfolder(string foldername, string parent)
        {
            var service = Getservice();
            var driveFolder = new Google.Apis.Drive.v3.Data.File();
            driveFolder.Name = foldername;
            driveFolder.MimeType = "application/vnd.google-apps.folder";
            driveFolder.Parents = new string[] { parent };
            var command = service.Files.Create(driveFolder);
            var file = command.Execute();
            return file.Id;          
        }

        public static void download(string FileId)
        {
            var service = Getservice();            
            var fileId= FileId;
            var request = service.Files.Get(fileId);
            string Filename= request.Execute().Name;
            string MimeType= request.Execute().MimeType;
            Console.WriteLine("{0}",Filename);
            Console.WriteLine("{0}",MimeType);
            var stream = new System.IO.MemoryStream();
            string doc_mimetype="text/plain" ;

            if(!MimeType.Contains("google"))
            {
                // Add a handler which will be notified on progress changes.
                // It will notify on each chunk download and when the
                // download is completed or failed.
                request.MediaDownloader.ProgressChanged +=
                    (IDownloadProgress progress) =>
                {
                    switch (progress.Status)
                    {
                        case DownloadStatus.Downloading:
                            {
                                Console.WriteLine(progress.BytesDownloaded);
                                break;
                            }
                        case DownloadStatus.Completed:
                            {
                                Console.WriteLine("Download complete.");
                                FileStream file = new FileStream("C:/Users/choifamm/Desktop/종윤/C#/test210919//"+Filename, FileMode.Create, FileAccess.Write);
                                stream.WriteTo(file);
                                break;
                            }
                        case DownloadStatus.Failed:
                            {
                                Console.WriteLine("Download failed.");
                                break;
                            }
                    }
                };
                request.Download(stream);
            }

            else
            {   
                
                switch (MimeType)
                {
                    case ("application/vnd.google-apps.document"):
                        {
                            doc_mimetype="text/plain";
                            if(!Filename.Contains(".txt"))
                            {
                                Filename=Filename+".txt";
                            }
                            break;
                        }
                    case ("application/vnd.google-apps.spreadsheet"):
                        {
                            doc_mimetype="application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            if(!Filename.Contains(".xlsx"))
                            {
                                Filename=Filename+".xlsx";
                            }                            
                            break;
                        }
                    case ("application/vnd.google-apps.presentation"):
                        {
                            doc_mimetype="application/vnd.openxmlformats-officedocument.presentationml.presentation";
                            if(!Filename.Contains(".pptx"))
                            {
                                Filename=Filename+".pptx";
                            }                            
                            break;
                        }                    
                }
                FilesResource.ExportRequest request_1 = service.Files.Export(fileId,doc_mimetype);

                // Add a handler which will be notified on progress changes.
                // It will notify on each chunk download and when the
                // download is completed or failed.
                request_1.MediaDownloader.ProgressChanged +=
                    (IDownloadProgress progress) =>
                {
                    switch (progress.Status)
                    {
                        case DownloadStatus.Downloading:
                            {
                                Console.WriteLine(progress.BytesDownloaded);
                                break;
                            }
                        case DownloadStatus.Completed:
                            {
                                Console.WriteLine("Download complete.");
                                FileStream file = new FileStream("C:/Users/choifamm/Desktop/종윤/C#/test210919/"+Filename, FileMode.Create, FileAccess.Write);
                                stream.WriteTo(file);
                                break;
                            }
                        case DownloadStatus.Failed:
                            {
                                Console.WriteLine("Download failed.");
                                break;
                            }
                    }
                };
                request_1.Download(stream);
            }
        }        
    }
}
