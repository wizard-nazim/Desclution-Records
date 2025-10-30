using AutoMapper;
using RecordManagerApi.DTOs;
using RecordManagerApi.Models;

namespace RecordManagerApi
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RecordItem, RecordDto>();
            CreateMap<CreateRecordDto, RecordItem>();
            CreateMap<UpdateRecordDto, RecordItem>();
        }
    }
}