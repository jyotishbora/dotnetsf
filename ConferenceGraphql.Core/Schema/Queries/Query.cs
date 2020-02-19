using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conference.Data;
using Conference.Data.Entities;
using ConferenceGraphql.Core.Schema.Types;
using GraphQL.Types;

namespace ConferenceGraphql.Core.Schema.Queries
{
    public class Query:ObjectGraphType<object>
    {
        public Query(IConferenceRepository repository)
        {
            Name = "Root";
            Field<ListGraphType<SpeakerType>>("allSpeakers", resolve: context => repository.GetAllSpeakersAsync());

            FieldAsync<SpeakerType>("speaker",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>>{ Name = "id"}),
                resolve:   async context =>
                {
                    var id = context.GetArgument<int>("id");
                    return await repository.GetSpeakerAsync(id);

                });
        }

    }
}
