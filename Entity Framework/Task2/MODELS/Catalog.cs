using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITYFRAMEWORK.MODELS
{
    public class Catalog { 
     public int id { get; set; }
     public string  ?name { get; set; }
     public string ? desc { get; set; }
        public virtual List<News>News { get; set; } = new List<News>();
    }
}
