using Microsoft.AspNetCore; 
using Microsoft.AspNetCore.Mvc; 

namespace CloudST.Controller
{ 
    [ApiController] 
    [Route("api/cloud/")] 
    public class CloudController : ControllerBase    
    { 
        public CloudController() {}
        
        [HttpPost("upload")] 
        public async Task<IActionResult> UploadFile(Microsoft.AspNetCore.Http.IFormFile file) 
        { 
            try 
            { 
                return Ok("OK"); 
            } 
            catch (Exception ex) 
            { 
                return StatusCode(500, ex.Message);
            }
        } 
        
    }
}