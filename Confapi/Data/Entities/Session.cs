using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confapi.Data.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Track { get; set; }
        public string Location { get; set; }
        public Speaker Speaker { get; set; }

    }
}
