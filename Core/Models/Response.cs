using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Response
    {
        public bool Status { get; set; } = false;
        public string Message { get; set; } = string.Empty;
    }

    public class Response<T>
    {
        public T? Value { get; set; }
        public bool Status { get; set; } = false;
        public string? Message { get; set; } 
   }
}
