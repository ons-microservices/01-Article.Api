namespace Articles.Comments.Api.DataAdapters.Entities;

/// <summary>
/// 
/// </summary>
public class ArticleDto
{
    /// <summary>
    /// 
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public List<CommentsDto>? Comments { get; set; }
}
