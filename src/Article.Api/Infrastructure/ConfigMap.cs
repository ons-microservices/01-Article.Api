using Article.Api.Models;
using AutoMapper;

namespace Article.Api.Infrastructure;

/// <summary>
/// 
/// </summary>
public class ConfigMap: Profile
{
    public ConfigMap()
    {
        CreateMap<ArticleDto, ArticleEntity>().ReverseMap();
    }
}
