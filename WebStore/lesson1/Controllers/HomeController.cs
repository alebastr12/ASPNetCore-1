using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lesson1.Models;
using Microsoft.AspNetCore.Mvc;

namespace lesson1.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<EmployeeView> _employeeViews = new List<EmployeeView> {
            new EmployeeView {
                Id=1,
                FirstName="Иван",
                SurName="Петров",
                Patronymic="Вячеславович",
                DateOfBirth=DateTime.Parse("10.12.1956"),
                Post="Директор"
            },
            new EmployeeView
            {
                Id = 2,
                FirstName = "Александр",
                SurName = "Иванов",
                Patronymic = "Петрович",
                DateOfBirth = DateTime.Parse("11.02.1959"),
                Post = "Уборщик"
            },
            new EmployeeView
            {
                Id = 3,
                FirstName = "Виктория",
                SurName = "Сидоркина",
                Patronymic = "Альбертовна",
                DateOfBirth = DateTime.Parse("08.03.1989"),
                Post = "Секретарша"
            }
        };
        public IActionResult Index()
        {
            //return Content("Привет изконтроллера!");
            return View(_employeeViews);
        }
        public IActionResult Details(int? id)
        {
            return View(_employeeViews.FirstOrDefault(e => e.Id == id));
        }
    }
}