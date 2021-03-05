using EFCore.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repo
{
    public class EFCoreRepository : IEFCoreRepository
    {
        private readonly HeroiContexto _context;

        public EFCoreRepository(HeroiContexto context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return(await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Heroi> GetHeroiById(int id)
        {
            IQueryable<Heroi> query = _context.Herois.Include(h => h.IdentidadeSecreta).Include(h => h.Armas);
            query = query.Include(h => h.HeroisBatalhas).ThenInclude(hb => hb.Batalha);
            query = query.AsNoTracking().OrderBy(h => h.Id);
            return await query.FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<Heroi[]> GetHeroisByNome(string nome)
        {
            IQueryable<Heroi> query = _context.Herois.Include(h => h.IdentidadeSecreta).Include(h => h.Armas);
            query = query.Include(h => h.HeroisBatalhas).ThenInclude(hb => hb.Batalha);
            query = query.AsNoTracking().Where(h => h.Nome.Contains(nome)).OrderBy(h => h.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Heroi[]> GetAllHerois()
        {
            IQueryable<Heroi> query = _context.Herois.Include(h => h.IdentidadeSecreta).Include(h => h.Armas);
            query = query.Include(h => h.HeroisBatalhas).ThenInclude(hb => hb.Batalha);
            query = query.AsNoTracking().OrderBy(h => h.Id);
            return await query.ToArrayAsync();
        }
    }
}
