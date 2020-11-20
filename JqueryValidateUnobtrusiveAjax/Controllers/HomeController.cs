using System.Threading.Tasks;
using JqueryValidateUnobtrusiveAjax.Infra;
using JqueryValidateUnobtrusiveAjax.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JqueryValidateUnobtrusiveAjax.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("api/[Controller]/[Action]/{isNew:bool}")]
        public async Task<IActionResult> GetDialogContent(TestDto dto, bool isNew)
        {
            if (ModelState.IsValid == false)
            {
                if (isNew)
                {
                    ModelState.Clear();
                }

                var html = await this.RenderViewAsync("_TestDtoForm", dto);

                return Ok(new
                          {
                              IsValid = ModelState.IsValid,
                              Data    = html,
                          });
            }
            else
            {
                return Ok(new
                          {
                              IsValid = ModelState.IsValid,
                          });
            }
        }
    }
}
