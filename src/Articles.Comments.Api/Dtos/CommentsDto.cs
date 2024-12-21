namespace Articles.Comments.Api.DataAdapters.Entities;

/// <summary>
/// 
/// </summary>
public class CommentsDto
{
    /// <summary>
    /// 
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? CommentText { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string User { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int ArticleId { get; set; }
}
