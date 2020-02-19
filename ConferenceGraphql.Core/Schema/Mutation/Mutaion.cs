using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conference.Data;
using Conference.Data.Entities;
using ConferenceGraphql.Core.Schema.Types;
using GraphQL.Types;

namespace ConferenceGraphql.Core.Schema.Mutation
{
    public class ConferenceDataMutaion:ObjectGraphType<object>
    {
        public ConferenceDataMutaion(IConferenceRepository repository)
        {
            Name = "MutationRoot";
            FieldAsync<SpeakerType>("createspeaker",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<SpeakerInputType>>{Name = "newspeaker"}),
                resolve: async context =>
                {
                    var speaker = context.GetArgument<Speaker>("newspeaker");
                    return await repository.CreateSpeaker(speaker);
                }

            );

        }
    }
}
