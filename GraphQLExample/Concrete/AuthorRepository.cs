using GraphQLExample.Abstract;
using GraphQLExample.Models;

namespace GraphQLExample.Concrete
{
    public class AuthorRepository : IAuthorRepository
    {
        private List<Author> _authors;
        public AuthorRepository()
        {
            _authors = new List<Author>()
            {
                new Author
                {
                    Id=1,
                    LastName="Danis",
                    Name="İlhan Enes"
                },
                new Author
                {
                    Id=2,
                    Name="Ramazan",
                    LastName="Danis"
                }
            };
        }
        public async Task<Author> AddAsync(Author entity)
        {
            entity.Id = _authors.Count + 1;
            _authors.Add(entity);

            return await Task.FromResult(entity);
        }

        public async Task<List<Author>> GetAllAsync()
        {
            return await Task.FromResult(_authors);
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            return await Task.FromResult(_authors.Find(a => a.Id == id));
        }
    }
}
