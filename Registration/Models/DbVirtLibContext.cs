using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Registration.Models;


namespace Registration.Models
{
    public class DbVirtLibContext:DbContext
    {
        public DbSet<UserAccount> userAccount { get; set; }

    }
}