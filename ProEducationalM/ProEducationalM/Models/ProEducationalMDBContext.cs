using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProEducationalM.Models
{
    public class ProEducationalMDBContext: DbContext
    {
        public ProEducationalMDBContext()
            : base("ProEducationalMConnectionString1") { }
    }
}