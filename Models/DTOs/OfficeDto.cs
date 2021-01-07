using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models.DTOs
{
    public class OfficeDto
    {

        public OfficeDto(Office office)
        {
            Id = office.Id;
            PhoneNumber = office.PhoneNumber;
            Address = office.Address;
            Floor = office.Floor;
            Unit = office.Unit;
            GeoLatitude = office.GeoLatitude;
            GeoLongitude = office.GeoLongitude;
            IsOpen = office.IsOpen;
            DoctorId = office.DoctorId;
        }
        
        public int Id { get; set; }
        
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int Floor { get; set; }

        [Required]
        public int Unit { get; set; }
        
        public string GeoLatitude { get; set; }

        public string GeoLongitude { get; set; }

        public bool IsOpen { get; set; } = true;

        [Required]
        public int DoctorId { get; set; }

    }
}