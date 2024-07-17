using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DataObject.RequestEntity
{
    public class EmpAwardRequestEntity
    {
        public int EmpAwardID { get; set; }
        public int EmpDetailID { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
    }
}
