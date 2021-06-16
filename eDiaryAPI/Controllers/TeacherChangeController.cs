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
    public class TeacherChangeController : ControllerBase
    {
        private readonly IDataChange _repository;
        private readonly IDataChangeMapper _mapper;
        public TeacherChangeController(IDataChange repository, IDataChangeMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> edit([FromBody] TeacherDTO dto)
        {
            var editedTeacher = await _repository.ChangeData(dto);

            if (editedTeacher == null)
            {
                return BadRequest("Couldn't Edit Data");
            }
            return Ok(_mapper.MapResponse(editedTeacher));
        }
    }
}
