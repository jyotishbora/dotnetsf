using System.Collections.Generic;
using Confapi.Data.Entities;

namespace Confapi.Data
{
    public interface IConferenceRepository
    {
        IEnumerable<Speaker> GetAllSpeakers();
    }
}