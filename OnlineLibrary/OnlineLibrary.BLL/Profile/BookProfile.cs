using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLibrary.BLL.Models;

namespace OnlineLibrary.BLL.Profile
{
    public class BookProfile : AutoMapper.Profile
    {
        public BookProfile()
        {
            CreateMap<BookFromApi, Book>()
                .ForMember(dest =>
                        dest.Title,
                    opt => opt.MapFrom(src => src.title))
                .ForMember(dest =>
                    dest.Author,
                    opt => opt.MapFrom(src => src.bookAuthor))
                .ForMember(dest =>
                        dest.BookType,
                    opt => opt.MapFrom(src => src.genre))
                .ForMember(dest =>
                        dest.ImageUrl,
                    opt => opt.MapFrom(src => src.simple_thumb))
                .ForMember(dest => dest.Epoch,
                opt => opt.MapFrom(src => src.epoch));
        }
    }
}