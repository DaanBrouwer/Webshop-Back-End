using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WhiteLabelWebshopS3.DTOs;

namespace WhiteLabelWebshopS3.BAL.Interfaces
{
    public interface IUser
    {
        Task<ActionResult> Authenticate(UserDTO userDto);
        Task<ActionResult> Register(UserDTO userDto);
    }
}