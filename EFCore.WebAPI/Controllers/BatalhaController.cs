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
        public IEFCoreRepository _repo { get; }

        public BatalhaController(IEFCoreRepository repo)
        {
            _repo = repo;
        }
        // GET: api/<BatalhaController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(new Batalha());
            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e);
            }
        }

        // GET api/<BatalhaController>/5
        [HttpGet("{id}", Name = "GetBatalha")]
        public async Task<IActionResult> GetHerois(int id)
        {
            try
            {
                var herois = await _repo.GetAllHerois();
                return Ok(herois);
            }
            catch(Exception e)
            {
                return BadRequest("Erro: " + e);
            }
        }

        // POST api/<BatalhaController>
        [HttpPost]
        public async Task<IActionResult> Post(Batalha model)
        {
            try
            {

                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                    return Ok("Funciona");
                else
                    return Ok("Deu ruim");

            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e);
            }
        }

        // PUT api/<BatalhaController>/5
        /*[HttpPut("{id}")]
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
        }*/

        // DELETE api/<BatalhaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                //_repo.Delete(model);
                //if (await _repo.SaveChangesAsync())
                return Ok("Funciona");
                //else
                //  return Ok("Deu ruim");

            }
            catch (Exception e)
            {
                return BadRequest("Erro: " + e);
            }
        }
    }
}
