using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models.DTOs
{
    public class PatientDto
    {

        public PatientDto(Patient patient)
        {
            Id = patient.Id;
            Name = patient.Name;
            Family = patient.Family;
            PhoneNumber = patient.PhoneNumber;
            MobileNumber = patient.MobileNumber;
            Age = patient.Age;
        }


        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Family { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string MobileNumber { get; set; }

        [Required]
        public int Age { get; set; }
    }
}