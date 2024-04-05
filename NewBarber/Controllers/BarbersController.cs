using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewBarber.Models;

namespace NewBarber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarbersController : ControllerBase
    {
        private readonly BarberDbContext _context;

        public BarbersController(BarberDbContext context)
        {
            _context = context;
        }
        [HttpPost("create-barbers")]
        public IActionResult CreateBarber([FromBody] Barbers barberData)
        {
            if (barberData == null)
            {
                return BadRequest("Geçersiz veri: BarberCreate verisi boş.");
            }
        }

    }
}
