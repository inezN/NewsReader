using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsReader.Persistance.Entities;
using NewsReader.Persistance.Repository.Interfaces;


namespace NewsReader.Persistance.Repository
{
     public class SourceEntitiesRepository : ISourceEntitiesRepository
     {
         private readonly NewsReaderContext _context;

         public SourceEntitiesRepository(NewsReaderContext context)
         {
             _context = context;
         }

         public void SaveSourceEntitiesInDb(List<Source> list)
         {
            _context.AddRange(list);
            _context.SaveChanges();
         }

        public async Task<List<Source>> GetSourceEntitiesOfDB()
        {
            return await _context.Source.ToListAsync();
        }

    }
}
