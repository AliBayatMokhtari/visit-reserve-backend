namespace TodoApi.Models
{
    public class Office
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public int Floor { get; set; }

        public int Unit { get; set; }

        public string GeoLatitude { get; set; }

        public string GeoLongitude { get; set; }

        public bool IsOpen { get; set; } = true;

        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }
    }
}