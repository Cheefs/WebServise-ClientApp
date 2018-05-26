using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIService.Models;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WebAPIService.Controllers
{

    public class DepartamentController : ApiController
    {
        private GetDep d = new GetDep();

        //[Route("getdep")]
        public List<Departament> GetDep()
        {
            return d.GetAll();
        }

       // [Route("getdep/{id}")]
        public Departament Get(int id)
        {
            return d.DepId(id);
        }
    }
}
