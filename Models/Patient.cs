using System.Collections.Generic;
using TodoApi.Models.Data;

namespace TodoApi.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Family { get; set; }

        public string PhoneNumber { get; set; }

        public string MobileNumber { get; set; }

        public int Age { get; set; }

        public IList<Reserve> Reserves { get; set; } = new List<Reserve>();
    }
}