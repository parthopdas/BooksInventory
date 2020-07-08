using AutoMapper;
using IA.BooksInventory.Persistence;

namespace IA.BooksInventory.Application
{
    public class BaseQueryHandler
    {
        protected BaseQueryHandler(IDataService db, IMapper mapper)
        {
            Db = db;
            Mapper = mapper;
        }

        protected IDataService Db { get; }

        protected IMapper Mapper { get; }
    }
}
