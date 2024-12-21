using Articles.Comments.Api.DataAdapters;
using Articles.Comments.Api.DataAdapters.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Articles.Comments.Api.Controllers;

/// <summary>
/// 
/// </summary>
[ApiController]
[Route("v1")]
public class CommentsController(ICommentsRepository commentsRepository): ControllerBase
{
    private readonly ICommentsRepository _commentsRepository = commentsRepository?? throw new ArgumentNullException(nameof(commentsRepository));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="articleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("articles/{articleId}/comments")]
    public Task<List<CommentsDto>> GetComments(int articleId, CancellationToken cancellationToken)
        => _commentsRepository.GetAllCommentsByArticleId(articleId, cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="commentId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("comments/{commentId}")]
    public Task<CommentsDto> GetCommentById(int commentId, CancellationToken cancellationToken)
        => _commentsRepository.GetCommentById(commentId, cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="commentsDto"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("comments")]
    public Task<bool> AddComments(CommentsDto commentsDto)
        => _commentsRepository.AddComments(commentsDto);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="commentId"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("comments/{commentId}")]
    public Task<bool> DeleteComment(int commentId)
        => _commentsRepository.DeleteComment(commentId);
}
