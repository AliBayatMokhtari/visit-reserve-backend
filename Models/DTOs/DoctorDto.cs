using System.Collections.Generic;

namespace TodoApi.Models.DTOs
{
    public class DoctorDto
    {

        public DoctorDto(Doctor doctor)
        {
            Id = doctor.Id;
            Name = doctor.Name;
            Family = doctor.Family;
            VisitFee = doctor.VisitFee;
        }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string Family { get; set; }

        public double VisitFee { get; set; }
    }
}