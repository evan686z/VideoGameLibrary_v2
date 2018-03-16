using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoGameLibrary_v2.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string context { get; set; }

        public int VideoGameId { get; set; }
    }
}