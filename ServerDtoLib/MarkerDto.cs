using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDtoLib
{
    public class MarkerDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string MarkerType { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public byte[] Picture { get; set; }
        public string UserName { get; set; }
        public string[] Contacts { get; set; }
    }
}
