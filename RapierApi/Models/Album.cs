using System.Collections.Generic;

namespace RapierApi.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
