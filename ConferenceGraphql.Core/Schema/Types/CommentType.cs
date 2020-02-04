using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conference.Data.Entities;
using GraphQL.Types;

namespace ConferenceGraphql.Core.Schema.Types
{
    public class CommentType:ObjectGraphType<Comment>
    {
        public CommentType()
        {
            Field(c => c.Id);
            Field(c => c.CommenterName);
            Field(c => c.CommentText);
            Field(c => c.CommentTimeStamp);
        }
    }
}
