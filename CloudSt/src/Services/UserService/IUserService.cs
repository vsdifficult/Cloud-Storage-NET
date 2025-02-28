using CloudST.Models;
using Microsoft.AspNetCore.Mvc; 

namespace CloudST.Services
{ 
    public interface IUserService
    { 
        Task<IActionResult> CreateUser(User user); 
        Task<IActionResult> DelUser(User user); 
        Task<IActionResult> CheckUser(int id); 
    }
}