using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YildizSistemi.DataAccessLayer.Model;
using YildizSistemi.DataAccessLayer;

namespace YildizSistemi.BusinessLogicLayer
{
    public class SUydu
    {
        public SUydu()
        {

        }
        public List<Uydu> GetirUyduListesi()
        {
            EUydu eUydu = new EUydu();
            return eUydu.GetirUydu();
        }
        public bool EkleUydu(Uydu uydu)
        {
            EUydu eUydu = new EUydu();
            eUydu.EkleUydu(uydu);
            return true;
        }
        public Uydu OkuUydu(int uyduId)
        {
            EUydu eUydu = new EUydu();
            return eUydu.OkuUydu(uyduId);
        }
        public bool GuncelleUydu(Uydu uydu)
        {
            EUydu eUydu = new EUydu();
            eUydu.GuncelleUydu(uydu);
            return true;
        }
        public bool SilUydu(int uyduId)
        {
            EUydu eUydu = new EUydu();
            eUydu.SilUydu(uyduId);
            return true;
        }
    }
}
