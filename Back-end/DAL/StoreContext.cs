﻿using Microsoft.EntityFrameworkCore;
using WhiteLabelWebshopS3.DAL.Entities;


namespace WhiteLabelWebshopS3.DAL
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Address> Address { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Basket> Basket { get; set; }
    }
}
