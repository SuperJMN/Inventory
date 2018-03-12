namespace Inventory.ViewModels.Customers
{
    public class CustomerViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public long CustomerId { get; set; }
        public byte[] Thumbnail { get; set; }
    }
}