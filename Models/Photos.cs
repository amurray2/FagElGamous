using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models
{
    public partial class Photos
    {
        [Key]
        public int PhotoId { get; set; }
        public int BurialId { get; set; }
        public string PhotoUrl { get; set; }

        public virtual Burial Burial { get; set; }
    }
}
