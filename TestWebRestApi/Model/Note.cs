using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebRestApi.Model
{
    public class Note
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public string Text { get; set; }

        public Note(string text) : this()
        {
            Text = text;
        }

        public Note() { 
            Id = Guid.NewGuid().ToString();
            Created = DateTime.Now;
        }
    }
}
