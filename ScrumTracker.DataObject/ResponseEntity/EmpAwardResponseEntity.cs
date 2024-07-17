using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DataObject.ResponseEntity
{
    public class EmpAwardResponseEntity
    {
        public int EmpAwardID { get; set; }
        public int EmpDetailId { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public string EmpName { get; set; }
        public string EmpDept { get; set; }
    }
}
