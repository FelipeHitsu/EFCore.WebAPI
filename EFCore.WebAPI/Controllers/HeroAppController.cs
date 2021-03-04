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
    public class HeroAppController : ControllerBase
    {
        public readonly HeroiContexto _context;
        public HeroAppController(HeroiContexto context)
        {
            _context = context;
        }
        // GET: api/<HeroAppController>
        [HttpGet("filtro/{nome}")]
        public ActionResult GetFiltro(string nome)
        {
            //var listHeroi = _context.Herois.ToList();
            //var listHeroi = (from heroi in _context.Herois select heroi).ToList();
            //var listHeroi = (from heroi in _context.Herois where heroi.Nome.Contains(nome) select heroi).ToList();
            //var listHeroi = _context.Herois.Where(h => h.Nome.Contains(nome)).ToList();
            var listHeroi = _context.Herois.Where(h => EF.Functions.Like(h.Nome,$"%{nome}%")).ToList();
            return Ok(listHeroi);
        }

        // GET api/<HeroAppController>/5
        [HttpGet("Atualizar/{heroName}")]
        public ActionResult Get(string heroName)
        {
            //var heroi = new Heroi { Nome = heroName };

            var heroi = _context.Herois.Where(h => h.Id == 3).FirstOrDefault();
            heroi.Nome = heroName;
            //_context.Herois.Add(heroi);
            _context.SaveChanges();

            return Ok();
        }

        

        [HttpGet("AddRange")]
        public ActionResult GetAddRange()
        {
            _context.AddRange(
                new Heroi { Nome = "Capitão América" },
                new Heroi { Nome = "Feiticeira Escarlate" },
                new Heroi { Nome = "Nick Fury" },
                new Heroi { Nome = "Viúva Negra" },
                new Heroi { Nome = "Hulk" },
                new Heroi { Nome = "Gavião Arqueiro" },
                new Heroi { Nome = "Capitã Marvel" }
                );
            _context.SaveChanges();

            return Ok();
        }


        // POST api/<HeroAppController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HeroAppController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HeroAppController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var heroi = _context.Herois.Where(h => h.Id == id).Single();
            _context.Herois.Remove(heroi);
            _context.SaveChanges();
        }
    }
}
