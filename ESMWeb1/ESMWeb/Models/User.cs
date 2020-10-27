using System;
using System.Collections.Generic;

namespace ESMWeb.Models
{
    public partial class User
    {
        public User()
        {
            Token = new HashSet<Token>();
        }

        public long UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public short RoleId { get; set; }
        public DateTime? HireDate { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Token> Token { get; set; }
    }
}
