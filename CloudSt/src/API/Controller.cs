using Microsoft.AspNetCore; 
using Microsoft.AspNetCore.Mvc; 
using CloudST.Database; 
using CloudST.Models;

namespace CloudST.Controller
{ 
    [ApiController] 
    [Route("api/cloud/")] 
    public class CloudController : ControllerBase    
    { 
        private readonly DBService dBService; 
        public CloudController(DBService dB) {dBService = dB; }
        
        [HttpPost("upload")] 
        public async Task<IActionResult> UploadFile(AddFileDTO FileDTO) 
        { 
            try 
            { 
                await dBService.AddFile(url: FileDTO.AWS_Link, user_id: FileDTO.User_ID); 
                try 
                { 
                    return Ok("OK");  
                } 
                catch (Exception ex) 
                { 
                    return StatusCode(500, ex.Message);
                }
            } 
            catch (Exception ex) 
            { 
                return StatusCode(500, ex.Message);
            }
        } 
        [HttpPost("register")] 
        public async Task<IActionResult> RegisterUser(UserDTO user)
        { 
            try 
            { 
                await dBService.CreateUser(user); 
                try 
                { 
                    return Ok(); 
                }
                catch (Exception ex) 
                { 
                    return StatusCode(500, ex.Message);
                }
            }
            catch (Exception ex) 
            { 
                return StatusCode(500, ex.Message);
            }
        }
    } 
    
}