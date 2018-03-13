namespace Inventory.ViewModels.Customers
{
    public class CustomerViewModel : ViewModelBase
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public long CustomerId { get; set; }
        public byte[] Thumbnail { get; set; }
        public string Initials { get; set; }
        public string FullName => string.Join(" ", FirstName, LastName);
        public string LastName { get; set; }
        public byte[] Picture { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get;set; }
        public string CountryName { get; set; }
        public string MiddleName { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; }
    }
}