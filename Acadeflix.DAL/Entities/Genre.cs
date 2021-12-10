using System.Collections.Generic;

namespace Acadeflix.DAL.Entities
{
    public class Genre
    {
        public string Name { get; set; }

        public int Id { get; set; }
        public List<Content> Contents { get; set; }
    }
}