using Articles.Comments.Api.DataAdapters.Entities;

namespace Articles.Comments.Api.DataAdapters;

public interface ICommentsRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<CommentsDto>> GetAllCommentsByArticleId(int articleId, CancellationToken cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="commentid"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<CommentsDto> GetCommentById(int commentid, CancellationToken cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="commentsDto"></param>
    /// <returns></returns>
    Task<bool> AddComments(CommentsDto commentsDto);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="commentid"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    Task<bool> DeleteComment(int commentid);
}