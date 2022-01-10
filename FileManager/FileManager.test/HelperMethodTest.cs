using FileManager.Infrastructure.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.test
{
    public class HelperMethodTest
    {

        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void Test()
        {
            string fileName = "trial.jpg";
            string mime = MimeTypeMap.GetMimeType(fileName);
            Assert.IsNotNull(mime);
        }
    }
}
