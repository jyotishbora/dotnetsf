using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conference.Data;
using Conference.Data.Entities;
using GraphQL.Types;

namespace ConferenceGraphql.Core.Schema.Types
{
    public class SpeakerType : ObjectGraphType<Speaker>
    {
        public SpeakerType(IConferenceRepository repository)
        {
            
            Field(s => s.Name);
            Field(s => s.Id);
            Field(s => s.Email);
            Field(s => s.Bio);
            Field(s => s.City);
            Field(s => s.Company);
            Field(s => s.TwitterHandle);
            Field<ListGraphType<SessionType>>().Name("sessions").ResolveAsync(async context => await GetAllSessionsForSpeaker(repository, context.Source.Id));
            //Field<ListGraphType<SessionType>>("sessions", resolve: (context) => GetAllSessionsForSpeaker(repository, context.Source.Id));

        }

        private static async Task<List<Session>> GetAllSessionsForSpeaker(IConferenceRepository repository, int speakerId)
        {
            return await repository.GetSpeakerSessionsAsync(speakerId);
        }
    }
}
