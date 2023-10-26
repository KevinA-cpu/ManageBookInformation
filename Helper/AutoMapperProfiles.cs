using AutoMapper;
using ManageBookInformation.DTOs;
using ManageBookInformation.Models;

namespace ManageBookInformation.Helper
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles() {
            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>();
        }
    }
}
