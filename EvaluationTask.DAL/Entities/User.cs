using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationTask.DAL.Entities
{
    public class User
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
