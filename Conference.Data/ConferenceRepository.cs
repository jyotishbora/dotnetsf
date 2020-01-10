using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confapi.Data;
using Conference.Data.Entities;
using Microsoft.Extensions.Logging;

namespace Conference.Data
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

        public async Task<IEnumerable<Speaker>> GetAllSpeakersAsync()
        {
            try
            {
                _logger.LogInformation("GetAllSpeaker is called");
                return await Task.FromResult(_ctx.Speakers.AsEnumerable());
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get all speakers: {e}");
                return null;
            }
        }

        public async Task<Speaker> GetSpeakerAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetSpeakerAsync is called");
                return await Task.FromResult(_ctx.Speakers.FirstOrDefault(s=>s.Id==id));
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get all speaker: {e}");
                return null;
            }
        }

        public async Task<IEnumerable<Session>> GetSpeakerSessionsAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetSpeakerSessionsAsync is called");
                return await Task.FromResult(_ctx.Sessions.Where(s => s.Speaker.Id == id));
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get all sessions: {e}");
                return null;
            }
        }
    }
}
