using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YildizSistemi.BusinessLogicLayer;
using YildizSistemi.DataAccessLayer.Model;

namespace YildizSistemi.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GezegenController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Gezegen> GetirGezegenListesi()
        {
            SGezegen sGezegen = new SGezegen();
            return sGezegen.GetirGezegenListesi();
        }

        [HttpPost]
        public bool EkleGezegen(Gezegen gezegen)
        {
            SGezegen sGezegen = new SGezegen();
            return sGezegen.EkleGezegen(gezegen);
        }
        [HttpPut]
        public bool GuncelleGezegen(Gezegen gezegen)
        {
            SGezegen sGezegen = new SGezegen();
            sGezegen.GuncelleGezegen(gezegen);
            return true;
        }
        [HttpGet("Id")]
        public Gezegen OkuGezegen(int id)
        {
            SGezegen sGezegen = new SGezegen();
            return sGezegen.OkuGezegen(id);            
        }
        [HttpDelete("Id")]
        public bool SilGezegen(int id)
        {
            SGezegen sGezegen = new SGezegen();
            sGezegen.SilGezegen(id);
            return true;
        }
    }
}
