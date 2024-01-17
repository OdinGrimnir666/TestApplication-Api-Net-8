using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataBase
{
    public class ApplicationConext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public ApplicationConext(DbContextOptions<ApplicationConext> options)
            : base(options)
        {
        }
    }
}
