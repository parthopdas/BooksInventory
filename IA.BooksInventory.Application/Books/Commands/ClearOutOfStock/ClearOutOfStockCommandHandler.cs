using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using IA.BooksInventory.Persistence;
using MediatR;

namespace IA.BooksInventory.Application.Books.Commands.ClearOutOfStock
{
    public sealed class GetAllBooksQueryHandler : BaseQueryHandler, IRequestHandler<ClearOutOfStockCommand, Unit>
    {
        public GetAllBooksQueryHandler(IDataService db, IMapper mapper) : base(db, mapper)
        {
        }

        public Task<Unit> Handle(ClearOutOfStockCommand request, CancellationToken cancellationToken)
        {
            Db.ClearOutOfStockBooks();

            return Unit.Task;
        }
    }
}
