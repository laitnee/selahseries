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
            CreateMap<PostListViewModel, Post>().ReverseMap();
        }
    }
}
