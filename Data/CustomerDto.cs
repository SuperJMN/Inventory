namespace Inventory.Data
{
    public class CustomerDto
    {
        public string Name { get; set; }
        public byte[] Thumbnail { get; set; }
        public long CustomerId { get; set; }
        public string Email { get; set; }
    }
}