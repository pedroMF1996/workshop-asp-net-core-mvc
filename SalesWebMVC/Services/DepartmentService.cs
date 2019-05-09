using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMVCContext _conext;

        public DepartmentService(SalesWebMVCContext conext)
        {
            _conext = conext;
        }

        public List<Departments> FindAll()
        {
            return _conext.Departments.OrderBy(a => a.Nome).ToList();
        }
    }
}
