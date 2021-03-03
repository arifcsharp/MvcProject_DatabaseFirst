using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject_Arif.ViewModels
{
    public class EmployeeVM
    {
        public int EmployeeID { get; set; }
        [Required(ErrorMessage ="This field is required")]
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Contact No")]
        [DataType(DataType.PhoneNumber)]
        public string CellPhone { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
    }
}