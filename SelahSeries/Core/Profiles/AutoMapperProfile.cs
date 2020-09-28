using AutoMapper;
using SelahSeries.Models;
using SelahSeries.Models.DTOs;
using SelahSeries.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Core.Profiles
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PostCreateViewModel, Post>().ReverseMap();
            CreateMap<Post, PostListViewModel>();
            CreateMap<BookCreateViewModel, Book>().ReverseMap();
            CreateMap<Book, BookListViewModel>();
            CreateMap<EventCreateViewModel, Event>().ReverseMap();
            CreateMap<Event, EventListViewModel>();
            CreateMap<TestimonialCreateViewModel, Testimonial>().ReverseMap();
            CreateMap<Testimonial, TestimonyListViewModel>();
            CreateMap<GalleryCreateViewModel, Picture>().ReverseMap();
            CreateMap<Picture, GalleryCreateViewModel>();
            CreateMap<Picture, GalleryListViewModel>();
        }
    }
}
