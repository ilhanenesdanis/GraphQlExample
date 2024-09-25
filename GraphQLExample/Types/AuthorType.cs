using GraphQL.Types;
using GraphQLExample.Models;

namespace GraphQLExample.Types
{
    public class AuthorType: ObjectGraphType<Author>
    {
        public AuthorType()
        {
            Field(x => x.Id).Description("Identity No");
            Field(x => x.Name).Description("Author Name");
            Field(x => x.LastName).Description("Author Lastname");

        }
    }
}
