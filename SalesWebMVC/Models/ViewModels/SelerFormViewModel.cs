using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Models.ViewModels
{
    public class SelerFormViewModel
    {
        public Seller Seller { get; set; }
        public List<Departments> Departments { get; set; }
        public int MyProperty { get; set; }
    }
}
