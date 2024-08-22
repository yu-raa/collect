namespace Collect.Data
{
    public class Topic
    {
        public int Id { get; set; }
        public string TopicName { get; set; } = null!;
        public virtual ICollection<Collection> Reviews { get; set; } = new List<Collection>();
    }
}
