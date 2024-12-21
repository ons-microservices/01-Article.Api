using Article.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Article.Api.DataAdapters;

/// <summary>
/// 
/// </summary>
public class ArticleDbContext: DbContext
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    public ArticleDbContext(DbContextOptions options)
        : base(options)
    {}

    /// <summary>
    /// 
    /// </summary>
    public DbSet<ArticleEntity> Articles { get; set; }
}
