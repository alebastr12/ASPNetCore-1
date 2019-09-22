using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lesson1.Infrastructure.Interfaces;
using lesson1.Models;
using Microsoft.AspNetCore.Mvc;

namespace lesson1.Controllers
{
    public class EmployeeController : Controller
    {
        public string ErrorString { get; set; }
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public IActionResult Index()
        {
            //return Content("Привет изконтроллера!");
            return View(_employeeService.GetAll());
        }
        public IActionResult Details(int id)
        {
            return View(_employeeService.GetById(id));
        }
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return View(new EmployeeView());
            }
            var emp = _employeeService.GetById(id.Value);
            if (emp is null)
                return NotFound();
            return View(emp);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeView model)
        {
            model.ErrorString = "";
            if (string.IsNullOrEmpty(model.FirstName))
                model.ErrorString += "Введите имя. ";
            if (string.IsNullOrEmpty(model.SurName))
                model.ErrorString += "Введите фамилию. ";
            if (string.IsNullOrEmpty(model.Post))
                model.ErrorString += "Введите должность. ";
            if (!string.IsNullOrEmpty(model.ErrorString))
                return View(model);
            if (model.Id > 0)
            {
                var dbItem = _employeeService.GetById(model.Id);
                if (dbItem is null)
                    return NotFound();
                dbItem.FirstName = model.FirstName;
                dbItem.SurName = model.SurName;
                dbItem.Patronymic = model.Patronymic;
                dbItem.DateOfBirth = model.DateOfBirth;
                dbItem.Post = model.Post;
            }
            else
            {
                _employeeService.AddNew(model);
            }
            _employeeService.Commit();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            _employeeService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}