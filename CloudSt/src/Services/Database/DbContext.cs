using System.Threading.Tasks;
using Supabase; 

namespace CloudST.Database 
{ 
    public class SupabaseClient 
    { 
        public async Task<Supabase.Client> supaClient()
        { 
            var url = ""; 
            var key = ""; 
            var supoptions = new SupabaseOptions 
            {   
                AutoConnectRealtime = true
            }; 
            var supabase = new Supabase.Client(url, key, supoptions); 
            try
            {
                await supabase.InitializeAsync(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing Supabase client: {ex.Message}");
            }
            return supabase; 

        }
    }
}