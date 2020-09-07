using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conference.Data;
using Conference.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Confapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConferenceController : ControllerBase
    {
        private readonly IConferenceRepository _conferenceRepository;
        private readonly ILogger<ConferenceController> _logger;
        private readonly IConfService _confService;

        public ConferenceController(ILogger<ConferenceController> logger, IConferenceRepository conferenceRepository, IConfService confService)
        {
            _logger = logger;
            _conferenceRepository = conferenceRepository;
            _confService = confService;
        }


        [HttpGet("speakers")]
        public async Task<ActionResult<IEnumerable<Speaker>>> GetAllSpeakers()
        {
            _logger.LogInformation("/speakers endpoint is called");
            _confService.GetInfo();
            return Ok(await _conferenceRepository.GetAllSpeakersAsync());
        }

        [HttpGet("speakers/{id}")]
        public async Task<ActionResult<Speaker>> GetSpeaker(int id)
        {
            var speaker = await _conferenceRepository.GetSpeakerAsync(id);
            if (speaker == null) return NotFound();
            return Ok(speaker);
        }

        [HttpGet("speakers/{speakerId}/sessions")]
        public async Task<ActionResult<List<Session>>> GetSpeakerSessions(int speakerId)
        {
            var sessions = await _conferenceRepository.GetSpeakerSessionsAsync(speakerId);
            if (sessions == null) return NotFound();
            return Ok(sessions);
        }

        [HttpGet("sessions/{sessionId}/comments")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetSessionComments(int sessionId)
        {
            try
            {
                var comments = await _conferenceRepository.GetSessionComments(sessionId);
                return Ok(comments);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e, null);
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }


        }
    }
}
