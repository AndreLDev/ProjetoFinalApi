using Application.Models.Request.Log;
using Application.Models.Request.User;
using Application.Models.Response.Log;
using Application.Models.Response.User;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Validators;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateLogRequest log)
        {
            if (log == null)
                return NotFound();

            return Execute(() => _logService.Add<CreateLogRequest, LogResponse, LogValidator>(log));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateLogRequest log)
        {
            if (log == null)
                return NotFound();

            return Execute(() => _logService.Update<UpdateLogRequest, LogResponse, LogValidator>(log));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _logService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _logService.Get<LogResponse>());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _logService.GetById<LogResponse>(id));
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
