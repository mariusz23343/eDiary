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
    public class GradeController : ControllerBase
    {
        private readonly IGradeTeacher _repository;
        private readonly IGradeTeacherMapper _mapper;

        public GradeController(IGradeTeacherMapper mapper, IGradeTeacher repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> edit([FromBody] GradeDTO dto)
        {
            var editedGrade = await _repository.ChangeGrande(dto);

            if (editedGrade == null)
            {
                return BadRequest("Couldn't Edit Data");
            }
            return Ok(_mapper.MapGradeChange(editedGrade));
        }
        [HttpPost]
        public async Task<IActionResult> put([FromBody] GradeViewOnlyDTO dto)
        {
            var addGrade = await _repository.PutGrade(dto);

            return Ok(_mapper.MapGradePut(addGrade));
        }

    }
}
