using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using IA.BooksInventory.Persistence;
using MediatR;
using AutoMapper.QueryableExtensions;
using System.Linq;

namespace IA.BooksInventory.Application.Books.Queries.GetAllBooks
{
    public sealed class GetAllBooksQueryHandler : BaseQueryHandler, IRequestHandler<GetAllBooksQuery, ICollection<BookVM>>
    {
        public GetAllBooksQueryHandler(IDataService db, IMapper mapper) : base(db, mapper)
        {
        }

        public async Task<ICollection<BookVM>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await Db.GetAllBooks(request.CsvFile);


            return books
                .ProjectTo<BookVM>(Mapper.ConfigurationProvider)
                .ToList();
        }
    }
}
