using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Mail;
using System.Text;
using System.Text.Encodings.Web;
using TaskManagementSystemBackend.Dto;
using TaskManagementSystemBackend.Models;
using TaskManagementSystemBackend.Repository.Interfaces;

namespace TaskManagementSystemBackend.Controllers
{
    [Route("api/register")]
    [ApiController]
    public class RegisterUserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoginUser _loginUser;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        public RegisterUserController(IUnitOfWork unitOfWork,IMapper mapper, ILoginUser loginUser,
            IEmailSender emailSender
            )
        {
            _emailSender= emailSender;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _loginUser = loginUser;
        }
        [HttpGet]
        public IActionResult GetAllUsers() 
        {
            var UsersFromDB = _unitOfWork.register.GetAll();
            var dUsersFromDb = UsersFromDB.Select(u => new
            {
                u.Id,
                u.Username,
                u.Email,
                Password = decrypt(u.Password),
                ConfirmPassword = decrypt(u.ConfirmPassword),
                u.Approved,
                u.Role
            }) ; 
            return Ok(dUsersFromDb);
        }
        [HttpPost]
        public async Task< IActionResult> AddUser([FromBody] RegisteredUsersDto registeredUsersDto)
        {
            var AllUsers = _unitOfWork.register.GetAll();
            var User = _mapper.Map<RegisteredUsersDto, RegisteredUsers>(registeredUsersDto);
            var ePassword = encrypt(User.Password);
            var eConfirmPassword=encrypt(User.ConfirmPassword);

            if (AllUsers.Any(u => u.Username == User.Username))
            {
                return BadRequest("user in use");
            } 
            if (User != null && User.Id==0)
            {
                if (AllUsers.Any(u => u.Role == "Admin"))
                {
                    User.Role = "trainee";

                }
                else
                {
                    User.Approved = true;
                    User.Role = "Admin";
                }
                var userindb = new RegisteredUsers
                {
                    Username = User.Username,
                    Email = User.Email,
                    Role = User.Role,
                    Password = ePassword,
                    ConfirmPassword = eConfirmPassword,
                    Approved= User.Approved,
                //    Token= User.Token,
                };
                //if (User.EmailConfirm == false)
                //{
                //    var subject = "Confirm your Email";
                //    var callbackUrl = Url.Action("LoginUser");
                //    string htmlMessege = $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.";
                //    _emailSender.SendEmailAsync(userindb.Email, subject, htmlMessege);
                //}
                _unitOfWork.register.Add(userindb);
                _unitOfWork.register.Save();
                return Ok(new {message="added" });
            }
            
            return BadRequest();
        }
        [HttpPost("Login")]
        public IActionResult LoginUser([FromBody] UserLoginVm userLoginVm)
        {

            var user=_loginUser.Login(userLoginVm.Email,userLoginVm.Password);
           if(user!=null)
            {
                if (user.Email == userLoginVm.Email)
                {
                    if (user.Password == userLoginVm.Password)
                    {
                        return Ok(user);

                    }
                    else
                    {
                        return BadRequest("password is incorrect");
                    }
                }
                else
                {
                    return BadRequest("user does't exist");
                }
            }
            return BadRequest();
        }

        //apis for approving
        [HttpPost("Approve")]
        public IActionResult User([FromBody]ApproveVm approveVm)
        {
            var user = _loginUser.approveUser(approveVm.Id,approveVm.username, approveVm.email.ToString(), approveVm.password, approveVm.confirmPassword, approveVm.role, approveVm.approved);
            _unitOfWork.register.Save();
            return Ok(approveVm);
        }
        //methods for encryption and decryption
        public static string encrypt(string name)
        {
            byte[] storename = ASCIIEncoding.ASCII.GetBytes(name);
            string encryptname = Convert.ToBase64String(storename);
            return encryptname;
        }
        public static string decrypt(string name)
        {
            byte[] entname = Convert.FromBase64String(name);
            string decryptname = ASCIIEncoding.ASCII.GetString(entname);
            return decryptname;
        }
    }
}
