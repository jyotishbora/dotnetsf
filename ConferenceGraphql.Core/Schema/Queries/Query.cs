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
            Name = "Query";
            Field<ListGraphType<SpeakerType>>("speakers", resolve: context => repository.GetAllSpeakersAsync());
        }

    }
}
