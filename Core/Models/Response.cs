using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Response
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
    }

    public class Response<T>
    {
        public T? Value { get; set; }
        public bool Status { get; set; }
        public string? Message { get; set; }
    }
}
