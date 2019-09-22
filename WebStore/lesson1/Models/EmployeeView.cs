using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lesson1.Models
{
    public class EmployeeView
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }
        public string Post { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ErrorString { get; set; }
    }
}
