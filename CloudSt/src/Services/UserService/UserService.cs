using Microsoft.EntityFrameworkCore; 
using System.ComponentModel.Design.Serialization;
using Microsoft.AspNetCore.Mvc; 
using CloudST.Models; 
using System.Text.Json.Serialization; 
using System.Text.Json;
using CloudST.Database; 

namespace CloudST.Services
{ 
    public class UserRepository: IUserService 
    { 
        private readonly DBActions _context;
        public UserRepository()
        { 

        } 
        public async Task<IActionResult> CreateUser(User user)
        { 
            try
            {
                var user_ = new User
                { 
                    ID = new Random().Next(1, 100000), 
                    Email = user.Email,
                    Name = user.Name
                }; 

                return new JsonResult(new {message = "User has created"}); 
            } 
            catch (Exception e)
            { 
                return new JsonResult(new {erorr = e}); 
            }
        } 
        public async Task<IActionResult> DelUser(User user)
        { 
            try 
            { 
                await _context.DeleteUser(user); 
                return new JsonResult(new {message = "User has been deleted"}); 
            }
            catch (Exception e)
            { 
                return new JsonResult(new {erorr = e}); 
            }
        } 
        public async Task<IActionResult> CheckUser(int id) 
        { 
            try 
            { 
                var user =  _context.CheckUserD(id); 
                return new JsonResult(new {user = user});
            } 
            catch (Exception e) 
            { 
                return new JsonResult(new {erorr = e});
            }
        }
    }
}