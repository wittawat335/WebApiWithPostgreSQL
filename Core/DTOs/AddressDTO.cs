using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class AddressDTO
    {
        public int address_id { get; set; }

        public string address1 { get; set; } = null!;

        public string? address2 { get; set; }

        public string district { get; set; } = null!;

        public short city_id { get; set; }

        public string? postal_code { get; set; }

        public string phone { get; set; } = null!;

        public DateTime last_update { get; set; }
    }
}
