﻿using AutoMapper;
using GlobalTickets.Services.EventCatalog.Entities;
using GlobalTickets.Services.EventCatalog.Models;

namespace GlobalTickets.Services.EventCatalog.Profiles
{
    public class EventProfile: Profile
    {
        public EventProfile()
        {
            CreateMap<EventEntity, EventModel>()
                .ForMember(dest => dest.CategoryName, opts => opts.MapFrom(src => src.Category.Name));
        }
    }
}
