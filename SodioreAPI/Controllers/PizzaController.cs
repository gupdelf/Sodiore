using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        private DataContext dc;

        public PizzaController(DataContext context)
        {
            this.dc = context;

        }

        [HttpPost("api")]
        public async Task<ActionResult> Create([FromBody] Pizza p)
        {
            dc.Pizzas.Add(p);
            await dc.SaveChangesAsync();

            // retorna um response 201 com um json do q foi inserido ao banco
            return Created("Objeto pizza", p);
        }

        [HttpGet("api")]
        public async Task<ActionResult> List()
        {
            var dados = await dc.Pizzas.ToListAsync();
            return Ok(dados);
        }

        [HttpGet("api/{id}")]
        public Pizza Filter(int id)
        {
            Pizza p = dc.Pizzas.Find(id);
            return p;
        }

        [HttpPut("api")]
        public async Task<ActionResult> Edit([FromBody] Pizza p)
        {
            dc.Pizzas.Update(p);
            await dc.SaveChangesAsync();

            return Ok(p);
        }

        [HttpDelete("api/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Pizza p = Filter(id);
            if (p==null){
                return NotFound();
            }
            else {
                dc.Pizzas.Remove(p);
                await dc.SaveChangesAsync();

                return Ok();
            }
        }
    }
}