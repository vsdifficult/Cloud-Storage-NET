using Supabase.Postgrest.Attributes;

namespace CloudST.Models 
{ 
    public class Files: Supabase.Postgrest.Models.BaseModel
    { 
        [PrimaryKey("ID")]
        public int ID {get; set; } 
        [Column("UserID")]
        public int UserID {get; set; } 
        [Column("URL")]
        public string URL {get; set; }
    }
    public class AddFileDTO
    { 
        public string AWS_Link {get; set; } 
        public int User_ID { get; set; }
    }
}