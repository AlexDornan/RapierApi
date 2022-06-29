using System.Collections.Generic;

namespace RapierApi.Models
{
    public class Artist
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
        public string Gender { get; set; }

        public ICollection<Album> Albums{ get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
