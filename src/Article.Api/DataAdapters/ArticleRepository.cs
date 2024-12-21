using Article.Api.Models;
using Article.Api.ServicesClients;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Article.Api.DataAdapters;

/// <summary>
/// 
/// </summary>
public class ArticleRepository(ArticleDbContext articleDbContext, IMapper mapper, ICommentsServiceClient commentsServiceClient) : IArticleRepository
{
    private readonly ArticleDbContext _articleDbContext = articleDbContext ?? throw new ArgumentNullException(nameof(articleDbContext));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    private readonly ICommentsServiceClient _commentsServiceClient = commentsServiceClient ?? throw new ArgumentNullException(nameof(commentsServiceClient));

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var articleEntity = _articleDbContext.Articles.FirstOrDefault(x => x.Id == id);
        if (articleEntity == null)
        {
            throw new Exception("Record not found");
        }
        _articleDbContext.Articles.Remove(articleEntity);
        var result = await _articleDbContext.SaveChangesAsync();
        return result > 0;
    }

    public async Task<List<ArticleDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var articles = await _articleDbContext.Articles.Select(x => _mapper.Map<ArticleDto>(x)).ToListAsync(cancellationToken);
        foreach (var article in articles)
        {
            article.Comments = await _commentsServiceClient.GetComments(article.Id);
        }
        return articles;
    }

    public Task<ArticleDto> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            var articleEntity = _articleDbContext.Articles.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<ArticleDto>(articleEntity);
        });
    }

    public async Task<ArticleDto> SaveAsync(ArticleDto articleDto)
    {
        var articleEntity = _mapper.Map<ArticleEntity>(articleDto);
        var entity = await _articleDbContext.Articles.AddAsync(articleEntity);
        await _articleDbContext.SaveChangesAsync();
        return _mapper.Map<ArticleDto>(articleEntity);
    }
}
