using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Final_Codebase_Evaluation.Model;

namespace Final_Codebase_Evaluation.Data
{
    public class Final_Codebase_EvaluationContext : DbContext
    {
        public Final_Codebase_EvaluationContext (DbContextOptions<Final_Codebase_EvaluationContext> options)
            : base(options)
        {
        }

        public DbSet<Final_Codebase_Evaluation.Model.Employee_Info>? Employee_Info { get; set; }
    }
}
