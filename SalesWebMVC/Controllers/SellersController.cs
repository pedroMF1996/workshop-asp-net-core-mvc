using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Services;
using SalesWebMVC.Services.Exceptions;

namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public object SellerFromViewModel { get; private set; }

        public SellersController(SellerService sellerService,DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            return View(_sellerService.FindAll());
        }

        public IActionResult Create()
        {
            List<Departments> departments = _departmentService.FindAll();
            var viewModel = new SelerFormViewModel { Departments = departments };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                var viewModel = new SelerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }

            if (seller.BirthDate != null && seller.BaseSalary != null && seller.Nome != null && seller.Email!= null)
            {
                _sellerService.Insert(seller);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { msg = "Id Not Provided" }); ;
            }

            Seller obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { msg = "Id Not Found" }); ;
            }

            return View(obj);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { msg = "Id Not Provided" }); ;
            }

            Seller obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { msg = "Id Not Found" }); ;
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { msg = "Id Not Provided"});
            }
            Seller obj = _sellerService.FindById(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { msg = "Id not Found" });
            }

            List<Departments> departments = _departmentService.FindAll();
            SelerFormViewModel viewModel = new SelerFormViewModel { Seller = obj, Departments = departments };

            return View(viewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                var viewModel = new SelerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }                                       
            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { msg = "Id missmatch" });
            }
             
            try
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)//UpCasting
            {
                return RedirectToAction(nameof(Error), new { msg = e.Message}); ;
            }
        }

        public IActionResult Error(string msg)
        {
            ErrorViewModel viewModel = new ErrorViewModel
            {
                Message = msg,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }

    }
}