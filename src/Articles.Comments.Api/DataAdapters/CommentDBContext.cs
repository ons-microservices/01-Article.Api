

using Articles.Comments.Api.DataAdapters.Entities;
using Microsoft.EntityFrameworkCore;

namespace Articles.Comments.Api.DataAdapters;

public class CommentDBContext: DbContext
{
    public CommentDBContext(DbContextOptions options): base(options) 
    {}

    public DbSet<CommentsEntity> Comments { get; set; }
}
