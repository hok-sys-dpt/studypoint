using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using StudyPoints.Models;

namespace StudyPoints.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Mapper.CreateMap<PointListDto, PointList>();
            Mapper.CreateMap<PointList, PointListDto>().ForMember(d => d.DateAdded, opt => opt.MapFrom(s => s.DateAdded.ToShortDateString()));
        }
    }
}