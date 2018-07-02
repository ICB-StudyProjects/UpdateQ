namespace UpdateQ.Api.Configuration
{
    using AutoMapper;
    using UpdateQ.Model.DTOs;
    using UpdateQ.Model.Entities;

    public static class AutoMapperConf
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TimeSeriesNode, NodeTimeSeriesReadDTO>();
                cfg.CreateMap<InfoNode, NodesReadDTO>()
                        .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.ChildInfoNodes))
                        .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Name))
                        .ForMember(dest => dest.TSNodes, opt => opt.MapFrom(src => src.TimeSeriesNodes));
            });
        }
    }
}
