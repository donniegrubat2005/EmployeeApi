using EmployeeApi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApi.Data.Interface
{
    public interface IEmployee

    {
        IEnumerable<Employee> GetEmployee();
        void Create(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
        Employee FindId(int id);

    }
}
