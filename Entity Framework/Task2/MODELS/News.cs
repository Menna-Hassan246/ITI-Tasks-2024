using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITYFRAMEWORK.MODELS
{
    public class News
    {
        public int id { get; set; }
        public string ? title { get; set; }
        public string ? bref { get; set; }
        public string  ?desc { get; set; }
        public DateTime ? time { get; set; }
        public DateTime ? date { get; set; }
        [ForeignKey("Author")]

        public int? author_id { get; set; }
        [ForeignKey("Catalog")]
        public int ?cat_id { get; set; }
        public virtual Author Author { get; set; } = new Author();
        public virtual Catalog Catalog { get; set; } = new Catalog();
    }
}
