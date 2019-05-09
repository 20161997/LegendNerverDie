namespace LND.Web.Models
{
    public class ContactDetailViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { set; get; }

        public string Email { set; get; }

        public string Website { get; set; }

        public string Phone { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public bool Status { get; set; }
    }
}