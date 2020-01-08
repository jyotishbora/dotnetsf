using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confapi.Data.Entities;
using Microsoft.Extensions.Logging;

namespace Confapi.Data
{
    public class ConferenceRepository : IConferenceRepository
    {
        private readonly ConferenceDbContext _ctx;
        private readonly ILogger<ConferenceRepository> _logger;

        public ConferenceRepository(ConferenceDbContext ctx, ILogger<ConferenceRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public IEnumerable<Speaker> GetAllSpeakers()
        {
            try
            {
                _logger.LogInformation("GetAllSpeaker is called");
                return _ctx.Speakers.AsEnumerable();
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get all speakers: {e}");
                return null;
            }
        }

    }
}
