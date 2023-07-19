using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YildizSistemi.DataAccessLayer.Model
{
    public class Uydu
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public int YariCap { get; set; }
        public int GezegenId { get; set; }
    }
}
