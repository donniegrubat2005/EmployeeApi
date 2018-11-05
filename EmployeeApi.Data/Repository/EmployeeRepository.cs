using EmployeeApi.Data.DataContext;
using EmployeeApi.Data.Interface;
using EmployeeApi.Entities.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApi.Data.Repository
{
    public class EmployeeRepository : IEmployee
    {

        private readonly EmployeeApiContext _context;

        public EmployeeRepository(EmployeeApiContext context)
        {
            _context = context;
        }

        public void Create(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Employee employee = _context.Employees.Find(id);

            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

        public void Delete(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee FindId(int id)
        {
            var find = _context.Employees.Where(x => x.Id == id).SingleOrDefault();
            return find;
        }

        public IEnumerable<Employee> GetEmployee()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployee(int id)
        {
            return _context.Employees.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
