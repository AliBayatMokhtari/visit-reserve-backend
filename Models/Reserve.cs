using System;

namespace TodoApi.Models
{
    public class Reserve
    {
        public int Id { get; set; }

        public DateTime ReserveDate { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public Patient Patient { get; set; }

        public Doctor Doctor { get; set; }
    }
}