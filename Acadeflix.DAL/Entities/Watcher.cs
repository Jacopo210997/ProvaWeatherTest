using System.Collections.Generic;

namespace Acadeflix.DAL.Entities
{
    public class Watcher
    {
        public string Nickname { get; set; }
        public string AvatarUrl { get; set; }
        public string Email { get; set; }

        public int Id { get; set; }
        public List<Content> Contents { get; set; }
    }
}