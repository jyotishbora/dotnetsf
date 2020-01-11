using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConferenceGraphql.Core.Schema.Queries;
using GraphQL;

namespace ConferenceGraphql.Core.Schema
{
    public class ConferenceSchema : GraphQL.Types.Schema
    {
        public ConferenceSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<Query>();
        }
    }
}
