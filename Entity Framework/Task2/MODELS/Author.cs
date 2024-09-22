using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITYFRAMEWORK.MODELS
{
    public class Author
    {
        public int id { get; set; }
        public string ? name { get; set; }
        public int ? age { get; set; }
        public string ? username { get; set; }
        public string ? password { get; set; }
        public string ? joindate { get; set; }
        public virtual List<News> news { set; get; } = new List<News>();
    }
}
