using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CodeBaseTest5.Models;

namespace CodeBaseTest5.Data
{
    public class CodeBaseTest5Context : DbContext
    {
        public CodeBaseTest5Context (DbContextOptions<CodeBaseTest5Context> options)
            : base(options)
        {
        }

        public DbSet<CodeBaseTest5.Models.Student> Student { get; set; }
    }
}
