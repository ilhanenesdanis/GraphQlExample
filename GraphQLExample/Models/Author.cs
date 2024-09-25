namespace GraphQLExample.Models
{
    public sealed class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Book> Books { get; set; }
    }
}
