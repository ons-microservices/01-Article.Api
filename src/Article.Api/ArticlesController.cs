using Article.Api.DataAdapters;
using Article.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Article.Api;

/// <summary>
/// 
/// </summary>
/// <param name="articleRepository"></param>
[ApiController]
[Route("v1/articles")]
public class ArticlesController(IArticleRepository articleRepository)
    : ControllerBase
{
    private readonly IArticleRepository _articleRepository = articleRepository ?? throw new ArgumentNullException(nameof(articleRepository));

    [HttpGet]
    [Route("")]
    public Task<List<ArticleDto>> GetAll(CancellationToken cancellationToken)
        => _articleRepository.GetAllAsync(cancellationToken);

    [HttpGet]
    [Route("{id}")]
    public Task<ArticleDto> GetById(int id, CancellationToken cancellationToken)
        => _articleRepository.GetByIdAsync(id, cancellationToken);

    [HttpDelete]
    [Route("{id}")]
    public Task<bool> Delete(int id, CancellationToken cancellationToken)
        => _articleRepository.DeleteAsync(id, cancellationToken);

    [HttpPost]
    [Route("")]
    public Task<ArticleDto> Save(ArticleDto articleDto)
        => _articleRepository.SaveAsync(articleDto);
}
