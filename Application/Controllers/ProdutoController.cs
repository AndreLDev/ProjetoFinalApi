using Application.Models.Request.Log;
using Application.Models.Request.Produto;
using Application.Models.Request.User;
using Application.Models.Response.Log;
using Application.Models.Response.Produto;
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
    public class ProdutoController : ControllerBase
    {
        private IBaseService<Produto> _baseProdutoService;

        public ProdutoController(IBaseService<Produto> baseProdutoService)
        {
            _baseProdutoService = baseProdutoService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateProdutoRequest produto)
        {
            if (produto == null)
                return NotFound();

            return Execute(() => _baseProdutoService.Add<CreateProdutoRequest, ProdutoResponse, ProdutoValidator>(produto));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateProdutoRequest produto)
        {
            if (produto == null)
                return NotFound();

            return Execute(() => _baseProdutoService.Update<UpdateProdutoRequest, ProdutoResponse, ProdutoValidator>(produto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseProdutoService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseProdutoService.Get<ProdutoResponse>());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseProdutoService.GetById<ProdutoResponse>(id));
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
