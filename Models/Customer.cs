﻿namespace CustomerManagementWebAPI.Models
{
    public class Customer
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
