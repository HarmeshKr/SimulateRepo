namespace TokenService.Models
{
    public class TokenResponseData
    {
        public string Token {  get; set; }
        public string[] Role { get; set; }
        public string? Error { get; set; }
    }
}
