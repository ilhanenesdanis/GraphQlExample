namespace GraphQLExample.Models
{
    public sealed class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
    }
}
