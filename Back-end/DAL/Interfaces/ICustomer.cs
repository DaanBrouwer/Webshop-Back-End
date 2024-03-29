﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteLabelWebshopS3.DTOs;
using WhiteLabelWebshopS3.DAL.Entities;

namespace WhiteLabelWebshopS3.BAL.Interfaces
{
    public interface ICustomer
    {
        Task<ActionResult> GetAddressesAccount(int id);
        Task<ActionResult<Customer>> GetCustomer(int id);
        Task<ActionResult<List<Customer>>> GetCustomers();
        Task<ActionResult> NewCustomer(CustomerDTO customerDTO);
        Task<ActionResult<Customer>> UpdateCustomer(CustomerDTO customerDTO);
    }
}