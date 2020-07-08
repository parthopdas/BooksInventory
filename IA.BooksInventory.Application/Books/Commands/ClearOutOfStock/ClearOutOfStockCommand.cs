using MediatR;

namespace IA.BooksInventory.Application.Books.Commands.ClearOutOfStock
{
    public sealed class ClearOutOfStockCommand : IRequest<Unit>
    {
    }
}
