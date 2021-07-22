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
    public class GradeStudentController : ControllerBase
    {
        private readonly IGradeStudent _repository;
        private readonly IGradeStudentMapper _mapper;

        public GradeStudentController(IGradeStudent repository, IGradeStudentMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet("id")]
        public async Task<IActionResult> show(int id)
        {
            var shownGrade = await _repository.ShowGrade(id);

            if(shownGrade == null)
            {
                return BadRequest("Couldn't Show Grade");
            }
          
            return Ok((_mapper.showGrade(shownGrade)));
        }
    }

}
