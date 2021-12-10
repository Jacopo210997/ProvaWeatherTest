using System.Collections.Generic;

namespace Acadeflix.DAL.Entities
{
    public class Cast
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public int Id { get; set; }
        public List<Credit> Credits { get; set; }
    }
}