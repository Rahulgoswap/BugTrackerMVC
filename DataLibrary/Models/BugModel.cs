using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
   public class BugModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public string Deadline1 { get; set; }
        public string Deadline2 { get; set; }
        public string DeadLineFinal { get; set; }
        public string ErrorMsg { get; set; }
        public string AssignTeam { get; set; }
        public string PatchDetails { get; set; }
        public string IsResolved { get; set; }
        public string Status { get; set; } 
    }
}
