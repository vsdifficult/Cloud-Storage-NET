using Microsoft.AspNetCore.Mvc; 
using CloudST.Database; 
using CloudST.Models; 

namespace CloudST.Services
{ 
    public class StorageService: IStorageService 
    { 
        private readonly DBActions _context; 

        public StorageService(DBActions context) 
        { 
            _context = context; 
        }
        public async Task<IActionResult> UploadFileAsync(Files file)
        { 
            try 
            { 
                await _context.UploadFileToBase(file); 
                return new JsonResult(new {message = "File uploaded successfully"}); 
            } 
            catch (Exception ex) 
            { 
                return new JsonResult(new {erorr = ex}); 
            }
        } 
        public async Task<IActionResult> DownloadFileAsync(Files file) 
        { 
            return new JsonResult(new {message = "Not found "}); 
        } 
        public async Task<IActionResult> DeleteFileAsync(int id)
        { 
            try 
            { 
                await _context.DeleteFileInBase(id);
                return new JsonResult(new {message = "File deleted successfully"});
            } 
            catch (Exception ex)
            { 
                return new JsonResult(new {error = ex.Message});
            }
        }
    }
}