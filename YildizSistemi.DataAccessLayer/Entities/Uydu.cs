using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YildizSistemi.DataAccessLayer.Model
{
    public class Uydu
    {
        public int UyduID { get; set; }
        public string Isim { get; set; }
        public int YariCap { get; set; }
        public string Gezegeni { get; set; }
        public int GezegenID { get; set; }
    }
}
