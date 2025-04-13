using Supabase;
using Supabase.Postgrest.Attributes;

namespace CloudST.Models 
{ 
    public class User: Supabase.Postgrest.Models.BaseModel
    { 
        [PrimaryKey("ID")]
        public int ID {get; set; } 
        [Column("Name")]
        public string Name {get; set; } 
        [Column("Email")]
        public string Email {get; set; } 
        [Column("Password")]
        public string Password {get; set; } 
        [Column("file_links")]
        public List<int> file_links {get; set; } = new List<int>(); 
    } 
    public class UserDTO
    { 
        public string Email {get; set; } 
        public string Password {get; set; } 
    }
}