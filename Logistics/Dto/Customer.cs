﻿using Logistics.Dto.Orders;

namespace Logistics.Dto
{
    public class Customer
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Order> Order { get; set; }
    }
}