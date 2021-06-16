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
    }
}
