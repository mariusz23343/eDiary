using eDiaryAPI.Mappers;
using eDiaryAPI.Models.DTOs;
using eDiaryAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentChangeController : ControllerBase
    {
        private readonly IDataChange _repository;
        private readonly IDataChangeMapper _mapper;

        public StudentChangeController(IDataChange repository, IDataChangeMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> edit([FromBody] StudentDTO dto)
        {
            var editedStudent = await _repository.ChangeData(dto);

            if (editedStudent == null)
            {
                return BadRequest("Couldn't Edit Data");
            }
            return Ok(_mapper.MapResponse(editedStudent));
        }
        [HttpGet("id")]
        public async Task<IActionResult> get(int id)
        {
            var list = await _repository.GetStudent(id);
            if (list == null) return BadRequest();
            else
            {
                var mappedResponse = new List<StudentDTO>();
                foreach(var item in list)
                {
                    mappedResponse.Add(_mapper.MapResponse(item));
                }
                return Ok(mappedResponse);
            }
        }
        [HttpGet]
        public async Task<IActionResult> getAllStudents()
        {
            var studentsList = await _repository.GetAllStudent();
            var mappedResponse = new List<StudentDTO>();
            foreach (var item in studentsList)
            {
                mappedResponse.Add(_mapper.MapResponse(item));
            }
            return Ok(mappedResponse);
            
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _repository.DeleteStudent(id);
            if (student == null) return NoContent();
            else return Ok("Usunięto");
        }
        [HttpGet("GetStudentsWithoutClass")]
        public async Task<IActionResult> GetAllStudentsWithoutClass()
        {
            var list = await _repository.GetAllStudentWithoutClass();
            var mappedResponse = new List<StudentDTO>();
            foreach (var item in list)
            {
                mappedResponse.Add(_mapper.MapResponse(item));
            }
            return Ok(mappedResponse);
        }
        [HttpPut]
        public async Task<IActionResult> AddClassToStudent(PutStudentsClassDto dto)
        {
            var student = await _repository.PutStudentsClass(dto);
            return Ok();
        }
        [HttpGet("DeleteFromClass")]
        public async Task<IActionResult> DeleteStudentsRelationToClass(int id)
        {
            var student = await _repository.DeleteStudentFromClass(id);

            return Ok(student);
        }
    }
}
