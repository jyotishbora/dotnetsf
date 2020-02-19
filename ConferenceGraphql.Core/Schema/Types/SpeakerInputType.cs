using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL.Types;

namespace ConferenceGraphql.Core.Schema.Types
{
    public class SpeakerInputType:InputObjectGraphType
    {
        public SpeakerInputType()
        {
            Name = "speakerInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("city");
            Field<NonNullGraphType<StringGraphType>>("email");
            Field<NonNullGraphType<StringGraphType>>("company");
            Field<StringGraphType>("bio");
            Field<StringGraphType>("twitterhandle");





        }
    }
}
