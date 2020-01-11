﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conference.Data;
using Conference.Data.Entities;
using GraphQL.Types;

namespace ConferenceGraphql.Core.Schema.Types
{
    public class SpeakerType:ObjectGraphType<Speaker>
    {
        public SpeakerType()
        {
            Field(s => s.Name);
            Field(s => s.Id);
            Field(s => s.Email);
            Field(s => s.Bio);
            Field(s => s.City);
            Field(s => s.Company);
            Field(s => s.TwitterHandle);

        }

    }
}