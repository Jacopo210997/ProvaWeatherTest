using AutoMapper;

namespace Acadeflix.Api.Profiles
{
    public class WatcherProfile : Profile
    {
        public WatcherProfile()
        {
            CreateMap<Watcher, GetWatcherResponse>();
            CreateMap<PatchWatcherRequest, Watcher>();
            CreateMap<Watcher, PatchWatcherResponse>();
        }
    }
}
