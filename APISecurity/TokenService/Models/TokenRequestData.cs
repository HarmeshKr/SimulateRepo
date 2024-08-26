namespace TokenService.Models
{
    public class TokenRequestData
    {
     
            public AppUser User { get; set; }
            public IEnumerable<string> Role { get; set; }
        
    }
}
