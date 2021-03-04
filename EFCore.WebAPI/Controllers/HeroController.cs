using EFCore.Dominio;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        public readonly HeroiContexto _context;

        public HeroController(HeroiContexto context)
        {
            _context = context;
        }
        // GET: api/<HeroController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(new Heroi());
            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e.Message);
            }

        }

        // GET api/<HeroController>/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            return Ok("value");
        }

        // POST api/<HeroController>
        [HttpPost]
        public ActionResult Post(Heroi model)
        {
            try
            {
                _context.Herois.Add(model);
                _context.SaveChanges();
                return Ok("Funcionando");
            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e.Message);
            }
        }

        // PUT api/<HeroController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id,Heroi model)
        {
            try
            {
                var heroi = _context.Herois.Where(h => h.Id == id)
                    .Include(p => p.IdentidadeSecreta)
                    .FirstOrDefault();

                if ( heroi != null)
                {
                    heroi.IdentidadeSecreta = model.IdentidadeSecreta;

                    _context.SaveChanges();
                    return Ok("Funcionando");
                }
                return Ok("Não encontrado");
            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e);
            }
        }

        // DELETE api/<HeroController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
