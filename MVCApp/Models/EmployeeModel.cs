using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCApp.Models
{
    public class EmployeeModel
    {
        [Display(Name = "Employee ID")]
        [Range(100000,999999, ErrorMessage ="Please Enter a valid EmployeeID")]
        public int EmployeeID { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage ="You need to provide us with your First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You need to provide us with your Last Name")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "You need to provide us with your email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage ="You need to have a long enough password")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength =8, ErrorMessage ="You need to provide a long enough passowrd")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Your passwords do not match")]
        public string ConfimPassword { get; set; }

    }
}