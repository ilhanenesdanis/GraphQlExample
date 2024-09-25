using GraphQL.Types;
using GraphQLExample.Queries;

namespace GraphQLExample.Schemas
{
    public class AuthorSchema : Schema
    {
        public AuthorSchema(IServiceProvider services) : base(services)
        {

            Description = "Author schema";

            Query = services.GetRequiredService<Query>();
        }
    }
}
