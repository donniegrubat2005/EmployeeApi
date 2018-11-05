
using EmployeeApi.Data.Interface;
using EmployeeApi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeApi.Web.Controllers
{
    
    public class EmployeesController : ApiController
    {
        
        private readonly IEmployee _context;

            public EmployeesController(IEmployee context)
        {
            _context = context;

        }

        
        public IEnumerable<Employee> Get()
        {
            return _context.GetEmployee().ToList();
        }

        public HttpResponseMessage Get(int id)
        {
            var entity= _context.GetEmployee().FirstOrDefault(x => x.Id == id);

            if (entity != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            else {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee not found " + id.ToString() + " ");
            }
        }

        public HttpResponseMessage Post([FromBody] Employee emp)

        {
            try { 
            _context.Create(emp);

            var message = Request.CreateResponse(HttpStatusCode.Created, emp);
            message.Headers.Location= new Uri(Request.RequestUri + emp.Id.ToString());

             return message;

            } catch (Exception ex)

            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        } 
    }
}
