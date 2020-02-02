using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confapi.Data;
using Conference.Data.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Conference.Data
{
    public class ConferenceRepository : IConferenceRepository
    {
       
        private readonly ILogger<ConferenceRepository> _logger;
        private readonly IServiceProvider _serviceProvider;

        public ConferenceRepository(IServiceProvider serviceProvider, ILogger<ConferenceRepository> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task<List<Speaker>> GetAllSpeakersAsync()
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    _logger.LogInformation("GetAllSpeaker is called");
                    var dbCtx = scope.ServiceProvider.GetService<ConferenceDbContext>();
                    return await Task.FromResult(dbCtx.Speakers.ToList());
                }

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
                using (var scope = _serviceProvider.CreateScope())
                {

                    _logger.LogInformation("GetSpeakerAsync is called");
                    var dbCtx = scope.ServiceProvider.GetService<ConferenceDbContext>();
                    return await Task.FromResult(dbCtx.Speakers.FirstOrDefault(s => s.Id == id));
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get all speaker: {e}");
                return null;
            }
        }

        public async Task<List<Session>> GetSpeakerSessionsAsync(int id)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    _logger.LogInformation("GetSpeakerSessionsAsync is called");
                    var dbCtx = scope.ServiceProvider.GetService<ConferenceDbContext>();
                    return await Task.FromResult(dbCtx.Sessions.Where(s => s.Speaker.Id == id).ToList());
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get all sessions: {e}");
                return null;
            }
        }

        public async Task<List<Comment>> GetSessionComments(int sessionId)
        {

            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    _logger.LogInformation("GetSpeakerSessionsAsync is called");
                    var dbCtx = scope.ServiceProvider.GetService<ConferenceDbContext>();
                    return await Task.FromResult(dbCtx.Comments.Where(s => s.Session.Id == sessionId).ToList());
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get all sessions: {e}");
                return null;
            }
        }
    }
}
