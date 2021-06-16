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
    public class SchoolClassController : ControllerBase
    {
        private readonly IClassManagement _repository;
        private readonly IClassManagementMapper _mapper;

        public SchoolClassController(IClassManagement repository, IClassManagementMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> add([FromBody] ClassDTO dto)
        {
            var addedClass = await _repository.AddClass(dto);

            if (addedClass == null)
            {
                return BadRequest("Couldn't Create School  Class");
            }
            return Ok(_mapper.MappClassAdd(addedClass));
        }

    }
}
