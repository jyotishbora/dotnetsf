using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using GraphQL.Types;

namespace GraphQL.HelloWorld
{
    public class ConferenceSchema:Schema
    {
        public ConferenceSchema()
        {
            Query= new ConferenceQuery();
        }
    }

    public class ConferenceQuery : ObjectGraphType
    {
        public ConferenceQuery()
        {
            Name = "Query";
            Field("where", _ => "South FL");
            Field("when", _ => "Feb 29th, 2020");
            Field<MetadataType>().Name("metadata").Resolve(context => new Metadata()
            {
                NumberOfSessions = 50,
                NumberOfSpeakers = 30
                    
            });
        }
    }


    public class MetadataType : ObjectGraphType<Metadata>
    {
        public MetadataType()
        {
            Field(t => t.NumberOfSessions);
            Field(t => t.NumberOfSpeakers);
        }
    }


    public class Metadata
    {
        public int NumberOfSpeakers { get; set; }
        public int NumberOfSessions { get; set; }
    }

}
