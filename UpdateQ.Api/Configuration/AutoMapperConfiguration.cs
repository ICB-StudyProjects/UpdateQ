namespace UpdateQ.Api.Configuration
{
    using AutoMapper;
    using UpdateQ.Model.DTOs;
    using UpdateQ.Model.Entities;

    public static class AutoMapperConfiguration
    {
        public static IMapper Mapper { get; private set; }

        public static MapperConfiguration MapperConfiguraton { get; private set; }

        public static void Initialize()
        {
            MapperConfiguraton = new MapperConfiguration(cfg =>
            {
                // Add mappings here
                cfg.CreateMap<TimeSeriesNode, NodeTimeSeriesReadDTO>();
                cfg.CreateMap<InfoNode, NodesReadDTO>()
                        .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.ChildInfoNodes))
                        .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Name))
                        .ForMember(dest => dest.TSNodes, opt => opt.MapFrom(src => src.TimeSeriesNodes));
            });

            Mapper = MapperConfiguraton.CreateMapper();
        }
    }
}
