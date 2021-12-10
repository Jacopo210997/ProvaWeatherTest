using AutoMapper;

namespace Acadeflix.Api.Profiles
{
    public class ContentProfile : Profile
    {
        public ContentProfile()
        {
            CreateMap<Content, GetContentResponse>();
        }
    }
}
