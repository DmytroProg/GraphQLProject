using GraphQL.AspNet.Configuration;
using GraphQLProject.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Local")));
builder.Services.AddGraphQL();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseGraphQL();

app.Run();