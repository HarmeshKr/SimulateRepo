using System.Data.SqlClient;
using TokenService.Models;

namespace TokenService.Services
{
    public interface IAuthenticationService
    {
        AppUser AuthenticateUser(string username, string password);
    }
    public class AuthenticationService : IAuthenticationService
    {
        SqlConnection SqlConnection { get; set; }
        SqlCommand? SqlCommand { get; set; }
        
        public AuthenticationService(IConfiguration config)
        {
            SqlConnection = new SqlConnection();
            SqlConnection.ConnectionString = config.GetValue<string>("ConnectionStrings:cstr");
        }
        public AppUser AuthenticateUser(string username, string password)
        {
            AppUser user=null;
            SqlCommand = new SqlCommand();
            SqlCommand.Connection = SqlConnection;
            SqlCommand.CommandText = "ValidateuserProc";
            SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlCommand.Parameters.AddWithValue("@email", username);
            SqlCommand.Parameters.AddWithValue("password", password);
            SqlConnection.Open();

            SqlDataReader reader= SqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            if(reader.HasRows)
            {
                reader.Read();
                user=new AppUser ();
                user.Role = reader["role"].ToString()!;
                user.UserName = reader["username"].ToString()!;
                user.Email = reader["email"].ToString()!;
                user.Id = reader["id"].ToString()!;
            }
            SqlConnection.Close();
            return user;
        }
    }
}
