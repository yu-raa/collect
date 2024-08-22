using Azure;
using Microsoft.AspNetCore.Identity;

namespace Collect.Data
{
    public class Collection
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string DescriptionText { get; set; } = null!;
        public virtual Topic Topic { get; set; } = null!;
        public List<string> Items { get; set; } = new List<string>();
        public virtual IdentityUser Author { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
