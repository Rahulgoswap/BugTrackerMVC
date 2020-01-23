using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCApp.Models
{
    public class BugModel
    {
        [Display(Name = "Bug Title")]
        public string Title { get; set; }
        [Display(Name = "Project")]
        public string Source { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public DateTime Deadline1 { get; set; }
        public string Deadline2 { get; set; } = null;
        public DateTime DeadLineFinal { get; set; }
        [Display(Name = "Error Details/StackTrace")]
        public string ErrorMsg { get; set; }
        [Display(Name = "Team")]
        public string AssignTeam { get; set; }
        public string PatchDetails { get; set; }
        public Boolean IsResolved { get; set; } = false;
        public string Status { get; set; } = "Pending";
    }
}