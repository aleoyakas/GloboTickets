using AutoMapper;
using GlobalTickets.Services.EventCatalog.Entities;
using GlobalTickets.Services.EventCatalog.Models;

namespace GlobalTickets.Services.EventCatalog.Profiles
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryEntity, CategoryModel>().ReverseMap();
        }
    }
}
