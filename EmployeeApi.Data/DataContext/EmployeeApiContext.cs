
using EmployeeApi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmployeeApi.Data.DataContext
{
    public class EmployeeApiContext : DbContext
    {

        public EmployeeApiContext() : base("name=EmployeeApiContext") { }

        public DbSet<Employee> Employees { get; set; }

    }
}
