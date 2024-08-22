using Microsoft.AspNetCore.Identity;

namespace Collect.Data
{
    public class Comment
    {
        public int Id { get; set; }
        public virtual IdentityUser Author { get; set; } = null!;
        public virtual Collection OriginalPost { get; set; } = null!;
    }
}
