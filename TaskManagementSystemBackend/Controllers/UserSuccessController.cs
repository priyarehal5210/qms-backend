using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystemBackend.Dto;
using TaskManagementSystemBackend.Models;
using TaskManagementSystemBackend.Repository.Interfaces;

namespace TaskManagementSystemBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,trainee")]
    public class UserSuccessController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserSuccessController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult getall()
        {
            var userSuccess = _unitOfWork.userSuccess.GetAll(IncludeProperties: "assignTasks,assignTasks.registeredUsers,assignTasks.tasks");
            return Ok(userSuccess);
        }
        [HttpPost]
        public IActionResult addsuccess([FromBody] UserSuccessDto userSuccessDto)
        {
            var usersuccess = _mapper.Map<UserSuccessDto, UsersSuccess>(userSuccessDto);
            if (usersuccess != null)
            {

                _unitOfWork.userSuccess.Add(usersuccess);
                _unitOfWork.userSuccess.Save();
                return Ok(usersuccess);
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult updatesuccess([FromBody] UserSuccessDto userSuccessDto)
        {
            var usersuccess = _mapper.Map<UserSuccessDto, UsersSuccess>(userSuccessDto);
            if (usersuccess != null)
            {
                _unitOfWork.userSuccess.Update(usersuccess);
                _unitOfWork.userSuccess.Save();
                return Ok();
            }
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public IActionResult deletesuccess(int id)
        {
            var succcessFromDb = _unitOfWork.userSuccess.GetById(id);
            if (succcessFromDb == null)
            {
                return BadRequest(new {message="no data found"});
            }
            else
            {
                _unitOfWork.userSuccess.Remove(succcessFromDb);
                _unitOfWork.userSuccess.Save();
                return Ok();
            }
        }
    }
}
