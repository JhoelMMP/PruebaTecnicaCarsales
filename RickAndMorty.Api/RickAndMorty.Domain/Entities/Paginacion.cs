using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Domain.Entities
{
    public class Paginacion
    {
        public int count { get; set; }

        public int pages { get; set; }
        
        public string next { get; set; }
        
        public string prev { get; set; }
    }
}
