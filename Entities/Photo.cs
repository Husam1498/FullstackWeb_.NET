using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Photo
    {
        
        public int? PhotoId { get; set; }

        public string url { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
