using System.Collections.Generic;

namespace TodoApi.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Family { get; set; }

        public double VisitFee { get; set; }

        public IList<Office> Offices { get; set; } = new List<Office>();

        public IList<Patient> Patients { get; set; } = new List<Patient>();
    }
}