using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YildizSistemi.BusinessLogicLayer;
using YildizSistemi.DataAccessLayer.Model;

namespace YildizSistemi.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UyduController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Uydu> GetirUyduListesi()
        {
            SUydu sUydu = new SUydu();
            return sUydu.GetirUyduListesi();
        }

        [HttpPost]
        public bool EkleUydu(Uydu uydu)
        {
            SUydu sUydu = new SUydu();
            return sUydu.EkleUydu(uydu);
        }

        [HttpPut]
        public bool GuncelleUydu(Uydu uydu)
        {
            SUydu sUydu = new SUydu();
            sUydu.GuncelleUydu(uydu);
            return true;
        }

        [HttpGet("Id")]
        public Uydu OkuUydu(int id)
        {
            SUydu sUydu = new SUydu();
            return sUydu.OkuUydu(id);
        }
        
        [HttpDelete("Id")]
        public bool SilUydu(int id)
        {
            SUydu sUydu = new SUydu();
            sUydu.SilUydu(id);
            return true;
        }
    }
}
