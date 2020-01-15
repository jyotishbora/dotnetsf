using Conference.Data.Entities;
using GraphQL.Types;

namespace ConferenceGraphql.Core.Schema.Types
{
    public class SessionType:ObjectGraphType<Session>
    {
        public SessionType()
        {
            
            Field(s => s.Id);
            Field(s => s.Title);
            Field(s => s.Track);
            Field(s => s.Location);
        }
    }
}
