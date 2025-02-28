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
        private readonly Logger _logger;

        public UserRepository(DBActions context, Logger logger)
        {
            _context = context; // Initialize the context
            _logger = logger; // Initialize the logger
        }

        public async Task<IActionResult> CreateUser(User user)
        { 
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Name))
            {
                return new JsonResult(new { error = "Email and Name are required." });
            }

            try
            {
                var user_ = new User
                { 
                    ID = new Random().Next(1, 100000), 
                    Email = user.Email,
                    Name = user.Name
                }; 

                // Log the creation attempt
                _logger.LogInformation($"Creating user: {user_.Email}");

                // Save user to the database using the existing CreateUser method
                return await _context.CreateUser(user_);
            } 

            catch (Exception e)
            { 
                return new JsonResult(new {error = e.Message}); 
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
                return new JsonResult(new {error = e.Message}); 
            }
        } 

        public async Task<IActionResult> CheckUser(int id) 
        { 
            try 
            { 
                var user =  await _context.CheckUserD(id); 
                return new JsonResult(new {user = user});
            } 
            catch (Exception e) 
            { 
                return new JsonResult(new {error = e.Message});
            }
        }
    }
}
