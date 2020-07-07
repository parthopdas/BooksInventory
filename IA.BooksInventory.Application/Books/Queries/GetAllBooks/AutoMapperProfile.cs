using AutoMapper;
using IA.BooksInventory.Domain.Entities;

namespace IA.BooksInventory.Application.Books.Queries.GetAllBooks
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookVM>();
        }
    }
}
