using Microsoft.EntityFrameworkCore; 
using Microsoft.AspNetCore.Mvc;
using CloudST.Models;

namespace CloudST.Database 
{
    public class DBActions 
    { 
        private readonly DataBaseContext _context; 
        public DBActions(DataBaseContext context) 
        { 
            _context = context; 
        } 
        public async Task<IActionResult> CreateUser(User user)
        { 
            try 
            { 
                await _context.Users.AddAsync(user); 
                return new JsonResult(new {message = "User added"}); 
            } 
            catch (Exception ex) 
            { 
                return new JsonResult(new {erorr = ex}); 
            }
        }
        public async Task<IActionResult> DeleteUser(User user)
        { 
            try 
            { 
                _context.Users.Remove(user); 
                return new JsonResult(new {message = "User deleted"}); 
            } 
            catch (Exception ex) 
            { 
                return new JsonResult(new {erorr = ex}); 
            }
        } 
        public async Task<IActionResult> CheckUserD(int user_id)
        { 
            try 
            { 
                var user_ = _context.Users.FindAsync(user_id); 
                return new JsonResult(new {message = user_}); 
            } 
            catch (Exception ex) 
            { 
                return new JsonResult(new {erorr = ex}); 
            }
        } 
        public async Task<IActionResult> UploadFileToBase(Files file)
        { 
            try 
            { 
                await _context.Files_.AddAsync(file); 
                return new JsonResult(new {message = "File added"}); 
            } 
            catch (Exception ex) 
            { 
                return new JsonResult(new {erorr = ex}); 
            }
        } 
        public async Task<IActionResult> DeleteFileInBase(int id)
        { 
            try 
            { 
                var file = await _context.Files_.FindAsync(id);
                _context.Files_.Remove(file); 
                return new JsonResult(new {message = "File deleted"}); 
            } 
            catch (Exception ex) 
            { 
                return new JsonResult(new {erorr = ex}); 
            }
        }  
        public async Task<IActionResult> GetFileById(int id )
        { 
            try 
            { 
                var file = await _context.Files_.FindAsync(id); 
                return new JsonResult(new {message = file});
            } 
            catch (Exception ex) 
            { 
                return new JsonResult(new {erorr = ex});
            }
        }

    }
}