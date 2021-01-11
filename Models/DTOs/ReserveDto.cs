using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models.DTOs
{
    public class ReserveDto
    {

        public ReserveDto(Reserve reserve)
        {
            Id = reserve.Id;
            ReserveDate = reserve.ReserveDate;
            PatientId = reserve.PatientId;
            DoctorId = reserve.DoctorId;
        }

        public int Id { get; set; }

        [Required]
        public DateTime ReserveDate { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }
    }
}