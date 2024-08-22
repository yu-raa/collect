namespace Collect.Data
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}
