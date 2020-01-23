using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class BugModel : IComparable<BugModel>, IComparer<BugModel>
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public string DateCreated { get; set; }
        public string Deadline1 { get; set; }
        public string Deadline2 { get; set; }
        public string DeadLineFinal { get; set; }
        public string ErrorMsg { get; set; }
        public string AssignTeam { get; set; }
        public string PatchDetails { get; set; }
        public string IsResolved { get; set; }
        public string Status { get; set; }

        public int Compare(BugModel x, BugModel y)
        {
            if (x == null || y == null)
            {
                return 0;
            }
            return x.CompareTo(y);
        }

        public int CompareTo(BugModel other)
        {

            if (other == null) return 1;


            return ((Convert.ToDateTime(Deadline1)).Month).CompareTo((Convert.ToDateTime(other.Deadline1)).Month);
        }


        public static bool operator >(BugModel operand1, BugModel operand2)
        {
            return operand1.CompareTo(operand2) == 1;
        }


        public static bool operator <(BugModel operand1, BugModel operand2)
        {
            return operand1.CompareTo(operand2) == -1;
        }


        public static bool operator >=(BugModel operand1, BugModel operand2)
        {
            return operand1.CompareTo(operand2) >= 0;
        }


        public static bool operator <=(BugModel operand1, BugModel operand2)
        {
            return operand1.CompareTo(operand2) <= 0;
        }

    }
}
