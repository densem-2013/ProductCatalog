﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductCatalog.DAL.Entities
{
    [Table("User")]
    public class User : IBaseEntity, ISoftDelete
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
        public bool? Deleted { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
