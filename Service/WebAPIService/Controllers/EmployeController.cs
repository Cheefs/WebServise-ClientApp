using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIService.Models;

namespace WebAPIService.Controllers
{
    public class EmployeController : ApiController
    {
        private GetEmploye e = new GetEmploye();
        //api/Employe
        public List<Employe> Get()
        {
            return e.GetAll();
        }
        //api/Employe/id
        public Employe GetID(int id)
        {
            return e.EmpId(id);
        }

    }
}
