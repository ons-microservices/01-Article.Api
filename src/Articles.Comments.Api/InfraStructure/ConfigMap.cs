using Articles.Comments.Api.DataAdapters.Entities;
using AutoMapper;

namespace Articles.Comments.Api.InfraStructure;

public class ConfigMap: Profile
{
    public ConfigMap()
    {
        CreateMap<CommentsDto, CommentsEntity>().ReverseMap();
        CreateMap<ArticleEntity, ArticleDto>().ReverseMap();
    }
}
