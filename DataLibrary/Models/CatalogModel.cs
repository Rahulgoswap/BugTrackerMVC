using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class CatalogModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }
        public string DeadlineFinal { get; set; }
        public string Status { get; set; }
        public string Username { get; set; }
    }
}
