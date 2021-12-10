using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadeflix.DAL.Entities
{
    public class Credit
    {
        public Cast Cast { get; set; }
        public int CastId { get; set; }
        public Content Content { get; set; }
        public int ContentId { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }
    }
}
