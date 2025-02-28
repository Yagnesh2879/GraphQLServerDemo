using GraphQLServer;
using GraphQLServer.GraphQL;
using GraphQLServer.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

// Add database Context
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 40))));

//Add HotChocolate GraphQL Services
builder.Services.AddGraphQLServer()
    //.AddDbContextFactory<AppDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 40))))
    .AddType<Customer>()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    //.AddSubscriptionType<Subscription>()
    //.RegisterDbContextFactory<AppDbContext>()
    .AddSorting()
    .AddFiltering();


var app = builder.Build();

app.UseStaticFiles(); //to run client.html file from wwwroot folder

app.MapGraphQL("/GraphQL/");

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();


app.Run();
