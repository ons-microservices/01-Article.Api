using Article.Api.Models;

namespace Article.Api.DataAdapters;

/// <summary>
/// 
/// </summary>
public interface IArticleRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<ArticleDto>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ArticleDto> GetByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="articleDto"></param>
    /// <returns></returns>
    Task<ArticleDto> SaveAsync(ArticleDto articleDto);
}