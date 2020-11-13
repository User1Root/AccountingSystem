using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESMWeb.Models
{
    public class UserWithToken : User
    {

        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public UserWithToken(User user)
        {
            this.UserId = user.UserId;
            this.UserName = user.UserName;
            this.Role = user.Role;
            this.HireDate = user.HireDate;
        }
    }
}