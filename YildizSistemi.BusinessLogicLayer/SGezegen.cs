using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YildizSistemi.DataAccessLayer;
using YildizSistemi.DataAccessLayer.Model;

namespace YildizSistemi.BusinessLogicLayer
{
    public class SGezegen
    {
        public SGezegen()
        {
            
        }

        public List<Gezegen> GetirGezegenListesi()
        {
            EGezegen eGezegen = new EGezegen();
            return eGezegen.GetirGezegen();            
        }
        public bool EkleGezegen(Gezegen gezegen)
        {
            EGezegen eGezegen = new EGezegen();
            eGezegen.EkleGezegen(gezegen);
            return true;
        }
        public Gezegen OkuGezegen(int id)
        {
            EGezegen eGezegen = new EGezegen();
            return eGezegen.OkuGezegen(id);
        }
        public bool GuncelleGezegen(Gezegen gezegen)
        {
            EGezegen eGezegen = new EGezegen();
            eGezegen.GuncelleGezegen(gezegen);
            return true;
        }
        public bool SilGezegen(int id)
        {
            EGezegen eGezegen = new EGezegen();
            eGezegen.SilGezegen(id);
            return true;
        }
    }
}
