using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confapi.Data;
using Confapi.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Confapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConferenceController : ControllerBase
    {
        private readonly IConferenceRepository _conferenceRepository;
        public ConferenceController(IConferenceRepository conferenceRepository)
        {
            _conferenceRepository = conferenceRepository;
        }
    

        [HttpGet("speakers")]
        public ActionResult<IEnumerable<Speaker>> GetAllSpeakers()
        {
            return Ok(_conferenceRepository.GetAllSpeakers());
        }

      
      
    }
}
