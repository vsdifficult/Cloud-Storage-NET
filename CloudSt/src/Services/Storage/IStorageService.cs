using CloudST.Models;
using Microsoft.AspNetCore.Mvc; 

namespace CloudST.Services 
{ 
    public interface IStorageService
    { 
        Task<IActionResult> UploadFileAsync(Files file); 
        Task<IActionResult> DownloadFileAsync(Files file); 
        Task<IActionResult> DeleteFileAsync(int id ); 
    }
}