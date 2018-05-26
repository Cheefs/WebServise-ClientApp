using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIClient
{
    public interface IViev
    {
        IEnumerable<Departament> DepTemp { get; set; }
        IEnumerable<Employe> EmployeTemp { get; set; }
    }
}
