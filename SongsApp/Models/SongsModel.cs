using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongsApp.Models
{
    public class SongsModel
    {
        public string Title { get; set; }
    }

    public class Response
    {
        public string pattern { get; set; }
        public List<SongsModel> lstsong { get; set; }

        public Response()
        {
            lstsong = new List<SongsModel>();
        }
    }
}
