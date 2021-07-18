using eDiaryAPI.Mappers;
using eDiaryAPI.Models.DbModels;
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
    public class StudentController : ControllerBase
    {
        private readonly IDataChange _repository;
        private readonly IDataChangeMapper _mapper;

        public StudentController(IDataChange repository, IDataChangeMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut]
        public async Task<IActionResult> edit([FromBody] StudentDTO dto)
        {
            var editedStudent = await _repository.ChangeData(dto);

            if (editedStudent == null)
            {
                return BadRequest("Couldn't Edit Data");
            }
            return Ok(_mapper.MapResponse(editedStudent));
        }
        [HttpPost("id")]
        public async Task<IActionResult> getStudentsFromClass(int id)
        {
            var students = await _repository.getStudents(id);
            if (students == null) return BadRequest("Brak studentów w tej klasie");

            var studentsResponse = new List<Student>();
            foreach (var item in students)
            {
                studentsResponse.Add(item);
            }
            return Ok(studentsResponse);
        }

    }
}
