using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models.ViewModels
{
    public class SavePhotoViewModel
    {
        public IFormFile PhotoFile { get; set; }
        public string Type { get; set; }
        public Burial Burial { get; set; }
    }
}
