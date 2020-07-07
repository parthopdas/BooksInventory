using AutoMapper;
using IA.BooksInventory.Persistence;

namespace IA.BooksInventory.Application
{
    public class BaseQueryHandler
    {
        public BaseQueryHandler(IDataService db, IMapper mapper)
        {
            Db = db;
            Mapper = mapper;
        }

        protected IDataService Db { get; private set; }

        protected IMapper Mapper { get; private set; }
    }
}
