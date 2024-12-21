namespace Articles.Comments.Api.DataAdapters.Entities;

/// <summary>
/// 
/// </summary>
public class ArticleEntity
{
    /// <summary>
    /// 
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public List<CommentsEntity>? Comments { get; set; }
}
