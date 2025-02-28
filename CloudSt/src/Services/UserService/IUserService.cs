using CloudCT.Models;
using Microsoft.AspNetCore.Mvc; 

namespace CloudCT.Services
{ 
    public interface IUserService
    { 
        Task<IActionResult> CreateUser(User user); 
        Task<IActionResult> DelUser(int id); 
        Task<IActionResult> CheckUser(int id); 
    }
}