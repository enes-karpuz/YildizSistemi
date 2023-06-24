using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YildizSistemi.DataAccessLayer.Model
{
    public class Gezegen
    {
        public int GezegenID { get; set; }
        public string? Isim { get; set; }
        public int YariCap { get; set; }
        public int YildizaUzaklik { get; set; }
        public int YorungeEgikligi { get; set; }
        public int UyduSayisi { get; set; }
        public int Sicaklik { get; set; }
    }
}
