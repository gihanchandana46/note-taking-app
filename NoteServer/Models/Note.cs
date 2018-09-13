using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteServer.Models
{
    public class Note
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public String title { get; set; }
        public String body { get; set; }
        public String username { get; set; }
    }
}