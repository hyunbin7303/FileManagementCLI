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
    class Function
    {
        public static UserCredential Credential()
        {
            UserCredential credential = Helper.credential();
            return credential;
        }

        public static void Upload(string uploadfilename, Stream streamtest, ref DriveService service)
        {
            Helper.upload(uploadfilename, streamtest, ref service);
        }
        
        public static void FileList(int pagesize, ref DriveService service)
        {
            Helper.filelist(pagesize, ref service);
        }
    }


}