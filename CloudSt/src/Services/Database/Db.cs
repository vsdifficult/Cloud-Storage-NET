using CloudST.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloudST.Database 
{ 
    public class DBService
    { 
        private readonly SupabaseClient _sup; 
        public DBService (SupabaseClient sup) 
        { 
            _sup = sup; 
        } 
        public async Task<IActionResult> CreateUser(UserDTO user) 
        { 
            var client = await _sup.supaClient(); 
            var _user = new User
            {
                Email = user.Email,
                Password = user.Password,
                file_links = new List<int>()
            }; 
            try 
            { 
                await client.From<User>().Insert(_user); 
                return new JsonResult(new {message = "Ok"}); 
            } 
            catch (Exception ex) 
            { 
                return new JsonResult(new {error = ex.Message}); 
            }
        }
        public async Task<IActionResult> AddFile(string url, int user_id)
        { 
            try 
            { 
                var client = await _sup.supaClient(); 
                var _file = new Files
                { 
                    UserID = user_id,
                    URL = url
                };  
                try 
                { 
                    await client.From<Files>().Insert(_file); 
                    return new JsonResult(new {message = "Ok"}); 
                }
                catch (Exception ex) 
                { 
                    return new JsonResult(new {error = ex.Message}); 
                }
            }
            catch (Exception ex) 
            { 
                return new JsonResult(new {error = ex.Message}); 
            }
        }
        public async Task<IActionResult> GetUserFiles(string user_id) 
        { 
            try
            { 
                var client = await _sup.supaClient(); 
                var search_files = client.From<Files>().Filter("UserID", Supabase.Postgrest.Constants.Operator.Equals, user_id); 
                try 
                { 
                    return new JsonResult(new {message = search_files}); 
                }
                catch (Exception ex) 
                { 
                    return new JsonResult(new {error = ex.Message}); 
                }
            } 
            catch (Exception ex) 
            { 
                return new JsonResult(new {error = ex.Message}); 
            }
        }
    }
}