using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniProject.Model;

namespace MiniProject.Data
{
    public class MiniProjectContext : DbContext
    {
        public MiniProjectContext (DbContextOptions<MiniProjectContext> options)
            : base(options)
        {
        }

        public DbSet<MiniProject.Model.Product_Info>? Product_Info { get; set; }
    }
}
