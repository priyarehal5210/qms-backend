using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TaskManagementSystemBackend.Dto;
using TaskManagementSystemBackend.Models;
using TaskManagementSystemBackend.Repository.Interfaces;

namespace TaskManagementSystemBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class TasksController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TasksController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var allTasks = _unitOfWork.Tasks.GetAll();


            return Ok(allTasks);
        }
        [HttpPost]
        public IActionResult AddTask([FromBody]TaskDto taskDto)
        {
            var task = _mapper.Map<TaskDto, Tasks>(taskDto);
            if(task != null)
            {
                _unitOfWork.Tasks.Add(task);

                _unitOfWork.Tasks.Save();
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdateTask([FromBody]TaskDto taskDto)
        {
            var task=_mapper.Map<TaskDto, Tasks>(taskDto);
            if(task != null)
            {
                _unitOfWork.Tasks.Update(task);
                _unitOfWork.Tasks.Save();
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("{id:int}")]
        public IActionResult deletesuccess(int id)
        {
            var taskFromDb = _unitOfWork.Tasks.GetById(id);
            if (taskFromDb == null)
            {
                return BadRequest(new { message = "no data found" });
            }
            else
            {
                _unitOfWork.Tasks.Remove(taskFromDb);
                _unitOfWork.userSuccess.Save();
                return Ok();
            }
        }

    }
}
