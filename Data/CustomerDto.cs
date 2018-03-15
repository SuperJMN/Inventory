namespace Inventory.Data
{
    public class CustomerDto
    {
        public string FirstName { get; set; }
        public byte[] Thumbnail { get; set; }
        public long CustomerId { get; set; }
        public string Email { get; set; }
        public byte[] Picture { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string CountryName { get; set; }
        public string MiddleName { get; set; }
    }
}