using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Domain.Models
{
    public enum UserPermission
    {
        Guest,
        Normal,
        Admin
    }
    public class User : Base
    {
        public User(){ }
        public User(string userId, int usergroupId, string name, string domain, UserPermission permission, string email, bool isActive)
        {
            UserId = userId;
            UsergroupId = usergroupId;
            Name = name;
            Domain = domain ?? null;
            Permission = permission;
            Email = email;
            IsActive = isActive;
        }

        public string UserId { get; set; }
        public int UsergroupId { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public UserPermission Permission { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
