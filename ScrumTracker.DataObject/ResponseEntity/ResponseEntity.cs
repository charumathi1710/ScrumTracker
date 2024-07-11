using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DataObject.ResponseEntity
{
    public class ResponseEntity<T>
    {
        public T? Result { get; set; }
        public bool IsSuccess { get; set; }
        public string? StatusMessage { get; set; }
        public int StatusCode { get; set; }
        public string? ResponseMessage { get; set; }
    }
}
