using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models
{
    public partial class Files
    {
        [Key]
        public int FileId { get; set; }
        public int BurialId { get; set; }
        public string FileUrl { get; set; }

        public string Type { get; set; }

        public virtual Burial Burial { get; set; }
    }
}
