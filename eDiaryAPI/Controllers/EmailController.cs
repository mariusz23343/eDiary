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
    public class EmailController : ControllerBase
    {
        private readonly IEmailRepo _repository;
        private readonly IEmailMapper _mapper;
        public EmailController(IEmailRepo repository, IEmailMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> SendEmail(String messageText, String messageSubject, [FromBody] EmailDTO emailDTO)
        {
            var sendedEmail = await _repository.SendEmail(messageText, messageSubject,emailDTO);

            if (sendedEmail == null)
            {
                return BadRequest("Couldn't Send Email");
            }
            return Ok(_mapper.MapResponse());
        }


        [HttpGet]
        public async Task<IList<IActionResult>> ViewEmailList([FromBody] EmailDTO emailDTO)
        {

        }

    }
}
