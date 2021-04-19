using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class PhotographUrlResolver : IValueResolver<Photograph, PhotographToReturnDto, string>
    {
        private readonly IConfiguration _config;
        public PhotographUrlResolver(IConfiguration config)
        {
            _config = config;
        }
        public string Resolve(Photograph sourcePhoto, PhotographToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(sourcePhoto.Url))
            {
                return _config["ApiUrl"] + sourcePhoto.Url;
            }
            return null;
        }
    }
}