using System;
using System.Collections.Generic;

namespace ESMWeb.Models
{
    public partial class Token
    {
        public long TokenId { get; set; }
        public long UserId { get; set; }
        public string Token1 { get; set; }
        public DateTime ExpireDate { get; set; }

        public virtual User User { get; set; }
    }
}
