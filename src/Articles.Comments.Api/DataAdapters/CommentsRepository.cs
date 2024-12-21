using Articles.Comments.Api.DataAdapters.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Articles.Comments.Api.DataAdapters;

/// <summary>
/// 
/// </summary>
public class CommentsRepository(CommentDBContext commentDBContext, IMapper mapper): ICommentsRepository
{
    private readonly CommentDBContext _commentDBContext = commentDBContext?? throw new ArgumentNullException(nameof(commentDBContext));
    private readonly IMapper _mapper = mapper?? throw new ArgumentNullException(nameof(mapper));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<CommentsDto>> GetAllCommentsByArticleId(int articleId, CancellationToken cancellationToken)
    {
        var articles = await _commentDBContext.Comments.Where(x => x.ArticleId == articleId).ToListAsync();
        return _mapper.Map<List<CommentsDto>>(articles);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="commentid"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<CommentsDto> GetCommentById(int commentid, CancellationToken cancellationToken)
    {
        var comment = await _commentDBContext.Comments.FirstOrDefaultAsync(x => x.Id == commentid);
        return _mapper.Map<CommentsDto>(comment);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="commentsDto"></param>
    /// <returns></returns>
    public async Task<bool> AddComments(CommentsDto commentsDto)
    {
        var commentEntity = _mapper.Map<CommentsEntity>(commentsDto);
        _commentDBContext.Comments.Add(commentEntity);
        var i = await _commentDBContext.SaveChangesAsync();
        return i > 0;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="commentid"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<bool> DeleteComment(int commentid)
    {
        var commentEntity = await _commentDBContext.Comments.FirstOrDefaultAsync(x => x.Id == commentid);
        if(commentEntity == null)
        {
            throw new Exception("Entity not found");
        }
        _commentDBContext.Comments.Remove(commentEntity);
        await _commentDBContext.SaveChangesAsync();
        return true;
    }
}
