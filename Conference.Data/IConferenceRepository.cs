using System.Collections.Generic;
using System.Threading.Tasks;
using Conference.Data.Entities;

namespace Conference.Data
{
    public interface IConferenceRepository
    {
        Task<IEnumerable<Speaker>> GetAllSpeakersAsync();

        Task<Speaker> GetSpeakerAsync(int id);
        Task<IEnumerable<Session>> GetSpeakerSessionsAsync(int id);
    }
}