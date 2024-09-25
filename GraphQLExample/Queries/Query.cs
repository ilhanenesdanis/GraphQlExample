using GraphQL;
using GraphQL.Types;
using GraphQLExample.Abstract;
using GraphQLExample.Types;

namespace GraphQLExample.Queries
{
    public class Query : ObjectGraphType<object>
    {
        public Query(IAuthorRepository repository)
        {
            Name = "AuthorQuery";
            Field<ListGraphType<AuthorType>>("authors").ResolveAsync(async cont => await repository.GetAllAsync());

            Field<AuthorType>("author")
                .Arguments(new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }))
                .ResolveAsync(async cont => await repository.GetByIdAsync(cont.GetArgument<int>("id")));
           
        }
    }
}
