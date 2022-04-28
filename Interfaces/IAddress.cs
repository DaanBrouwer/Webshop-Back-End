using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WhiteLabelWebshopS3.DTOs;

namespace WhiteLabelWebshopS3.Controllers
{
    public interface IAddress
    {
        Task<IActionResult> DeleteAddress(int id);
        Task<ActionResult> GetAllAddresses();
        Task<ActionResult> GetSingleAddress(int id);
        Task<ActionResult> NewAddress(AddressDTO addressDTO);
        Task<ActionResult> UpdateAddress(AddressDTO addressDTO);
    }
}