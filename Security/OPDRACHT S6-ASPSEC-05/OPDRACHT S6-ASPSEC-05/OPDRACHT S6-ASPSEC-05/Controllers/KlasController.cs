using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OPDRACHT_S6_ASPSEC_05.Controllers
{
    [Authorize]
    public class KlasController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public KlasController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> IOSD1()
        {
            var user = await _userManager.GetUserAsync(User);
            var claims = await _userManager.GetClaimsAsync(user);

            if (claims.Any(c => c.Type == "Klas" && c.Value == "IOSD1"))
            {
                return View();
            }

            return Forbid(); // Geen toegang
        }
    }
}