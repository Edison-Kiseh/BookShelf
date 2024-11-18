using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelf.Classes.Picture
{
    public class Picture
    {
        public string ImageUrl { get; set; }       // URL or file path for the image
        public string Name { get; set; }          // Name of the artwork
        public string ShortDescription { get; set; } // A brief description
    }
}
