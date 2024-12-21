using Refit;

namespace Article.Api.ServicesClients;

/// <summary>
/// 
/// </summary>
public interface ICommentsServiceClient
{
    [Get("/v1/articles/{articleId}/comments")]
    Task<List<CommentsEntity>> GetComments(int articleId);
}
