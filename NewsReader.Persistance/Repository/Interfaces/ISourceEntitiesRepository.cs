using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewsReader.Persistance.Entities;

namespace NewsReader.Persistance.Repository.Interfaces
{
    public interface ISourceEntitiesRepository
    {
        void SaveSourceEntitiesInDb(List<Source> list);
        Task<List<Source>> GetSourceEntitiesOfDB();
    }
}
