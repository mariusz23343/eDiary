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
        public async Task<IActionResult> Show(int id)
        {
            var shownGrade = await _repository.ShowGrade(id);

            if(shownGrade == null)
            {
                return BadRequest("Couldn't Show Grade");
            }
          
            return Ok((_mapper.showGrade(shownGrade)));
        }
        [HttpPost]
        public async Task<IActionResult> AddGrade(GradeDTO dto, int id)
        {
            
            Grade grade = _mapper.AddGrade(dto, id);
            var result = await _repository.AddGrade(grade);
            
            return Created("dodano", result);

        }
        [HttpGet]
        public async Task<IActionResult> GetSubjects()
        {
            var result = _repository.GetSubject();
            var response = new List<SubjectDTO>();
            foreach(var item in result.Result)
            {
                var dto = new SubjectDTO
                {
                    SubjectName = item.SubjectName,
                    Id = item.Id
                };
                response.Add(dto);
            }
            return Ok(response);
            
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var grade = await _repository.DeleteGrade(id);
            if (grade == null) return NotFound("Nie znaleziono oceny");
            else return Ok();
        }
    }

}
