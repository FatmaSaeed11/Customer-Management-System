namespace CustomerManagementWebAPI.Models
{
    public class AddCustomerRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
