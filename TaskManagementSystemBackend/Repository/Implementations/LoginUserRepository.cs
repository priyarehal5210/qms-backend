using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagementSystemBackend.Models;
using TaskManagementSystemBackend.Repository.Interfaces;

namespace TaskManagementSystemBackend.Repository.Implementations
{
    public class LoginUserRepository : ILoginUser
    {
        private readonly ApplicationDbContext _context;
        private readonly AppSettings _jwt;
        public LoginUserRepository(ApplicationDbContext context,IOptions<AppSettings> jwt)
        {
            _jwt = jwt.Value;
            _context= context;
        }
        public RegisteredUsers Login(string email, string password)
        {
            var UserOfSameNameCheck = _context.registeredUsers.FirstOrDefault(u => u.Email ==email);
            if (UserOfSameNameCheck==null)
            {
                return null;
            }
            else if(UserOfSameNameCheck.Approved==true)
            {
                var dPassoword = decrypt(UserOfSameNameCheck.Password);
                var dConfirmPassword = decrypt(UserOfSameNameCheck.ConfirmPassword);
                UserOfSameNameCheck.Password = dPassoword;
                UserOfSameNameCheck.ConfirmPassword = dConfirmPassword;
       
                //here generate token
                var TokenHandeler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwt.secret);
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name,UserOfSameNameCheck.Id.ToString()),
                    new Claim(ClaimTypes.Role,UserOfSameNameCheck.Role)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key)
                   , SecurityAlgorithms.HmacSha256Signature)

                };
                var token = TokenHandeler.CreateToken(tokenDescriptor);
                UserOfSameNameCheck.Token = TokenHandeler.WriteToken(token);
                return UserOfSameNameCheck;
            }
            return null;
        }
    

        //decrypt method
        public static string decrypt(string password)
        {
            byte[] entname = Convert.FromBase64String(password);
            string decryptname = ASCIIEncoding.ASCII.GetString(entname);
            return decryptname;
        }

        public ApproveVm approveUser(int Id, string username, string email, string password, string confirmPassword, string role, bool approved)
        {
            var CheckUser = _context.registeredUsers.FirstOrDefault(e => e.Id==Id);

            if (CheckUser != null)
            {
                CheckUser.Approved = true;
            }

            return null;
        }
    }
}
