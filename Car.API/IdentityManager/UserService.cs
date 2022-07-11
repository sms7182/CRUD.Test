using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Car.API.IdentityManager
{
    public class UserService:IUserService
    {
        private List<User> _users = new List<User>
        {
            new User {  Username = "test-user", Password = "test1234" }
        };

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user= _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);
              
            

            if (user == null) return null;

            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }
        public User GetByUserName(string userName)
        {
           return _users.FirstOrDefault(d => d.Username == userName);
        }
        
        // helper methods

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 1 min
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim( "username", user.Username.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

       
    }
}
