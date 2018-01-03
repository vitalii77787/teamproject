using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDtoLib
{
   public class MarkerTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] MarkersCollection { get; set; }
    }
}
