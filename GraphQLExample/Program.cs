using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using GraphQLExample.Abstract;
using GraphQLExample.Concrete;
using GraphQLExample.Schemas;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<ISchema, AuthorSchema>(opt => new AuthorSchema(new SelfActivatingServiceProvider(opt)));
builder.Services.AddGraphQL(opt => opt.ConfigureExecution((opt, next) =>
{
    opt.EnableMetrics = true;
    return next(opt);
}).AddSystemTextJson());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseGraphQLAltair();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.UseGraphQL<ISchema>();

app.MapControllers();

app.Run();
