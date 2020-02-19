using System.Collections.Generic;
using System.Threading.Tasks;
using Conference.Data.Entities;

namespace Conference.Data
{
    public interface IConferenceRepository
    {
        Task<List<Speaker>> GetAllSpeakersAsync();

        Task<Speaker> GetSpeakerAsync(int id);
        Task<List<Session>> GetSpeakerSessionsAsync(int id);
        Task<List<Comment>> GetSessionComments(int sessionId);
        Task<Speaker> CreateSpeaker(Speaker speaker);
    }
}