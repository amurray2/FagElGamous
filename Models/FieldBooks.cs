using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models
{
    public partial class FieldBooks
    {
        [Key]
        public int FieldBookId { get; set; }
        public int BurialId { get; set; }
        public string FieldBookUrl { get; set; }

        public virtual Burial Burial { get; set; }
    }
}
