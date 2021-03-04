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
    public class BatalhaController : ControllerBase
    {
        private readonly HeroiContexto _context;

        public BatalhaController(HeroiContexto context)
        {
            _context = context;
        }
        // GET: api/<BatalhaController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(new Batalha());
            }
            catch(Exception e)
            {
                return BadRequest("Erro: " + e);
            }
        }

        // GET api/<BatalhaController>/5
        [HttpGet("{id}", Name = "GetBatalha")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BatalhaController>
        [HttpPost]
        public ActionResult Post(Batalha model)
        {
            try
            {
                _context.Batalhas.Add(model);
                _context.SaveChanges();

                return Ok("Funciona");
            }
            catch(Exception e)
            {
                return BadRequest("Erro: " + e);
            }
        }

        // PUT api/<BatalhaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id,Batalha model)
        {
            try
            {
                if(_context.Batalhas.AsNoTracking().FirstOrDefault(h => h.Id == id) != null)
                {
                    _context.Update(model);
                    _context.SaveChanges();
                    return Ok("Funciona");
                }
                return Ok("Não encontrado");
            }
            catch(Exception e)
            {
                return BadRequest("Erro: " + e);
            }
        }

        // DELETE api/<BatalhaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
