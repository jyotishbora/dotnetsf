using Conference.Data;
using Conference.Data.Entities;
using GraphQL.Types;

namespace ConferenceGraphql.Core.Schema.Types
{
    public class SessionType:ObjectGraphType<Session>
    {
        public SessionType(IConferenceRepository repository)
        {

            Field(s => s.Id);
            Field(s => s.Title);
            Field(s => s.Track);
            Field(s => s.Location);
            Field<ListGraphType<CommentType>>("comments", resolve: context => repository.GetSessionComments(context.Source.Id));
        }
    }
}
