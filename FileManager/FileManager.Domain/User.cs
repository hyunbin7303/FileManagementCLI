using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Permission { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
    }
}
