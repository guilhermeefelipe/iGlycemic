using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGlycemic.Core.Models
{
    public class Response
    {

        public Array Data { get; set; }
        public string Errors { get; set; }

        public Response(Array data)
        {
            this.Data = data;
        }
    }
}
