using Application.Models.Request.User;
using Application.Models.Request.Utils;
using Application.Models.Response.BenchMarking;
using Application.Models.Response.User;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilController : ControllerBase
    {
        private IUtilService _utilService;

        public UtilController(IUtilService utilService)
        {
            _utilService = utilService;
        }


        [HttpGet("/api/Util/Benckmarking/{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _utilService.GetBenchMarkinById<ProdutoScraperResponse>(id));
        }


        [HttpPost("/api/Util/SendEmail")]
        public IActionResult SendEmail([FromBody] EmailRequest email)
        {
            if (email == null)
                return NotFound();

            return Execute(() => _utilService.SendEmail<EmailRequest, EmailRequest>(email));
        }


        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
