namespace CloudST.Models 
{ 
    public class User 
    { 
        public int ID {get; set; } 
        public string Name {get; set; } 
        public string Email {get; set; } 
        public string Password {get; set; } 
        public List<Files> file_links {get; set; } = new List<Files>(); 
    }
}