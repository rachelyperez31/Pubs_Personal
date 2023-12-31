using Microsoft.EntityFrameworkCore;
using Pubs_Infrastructure.Context;
using Pubs_Infrastructure.Interfaces;
using Pubs_Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add context dependencies
builder.Services.AddDbContext<PubsContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PubsContext")));

// Repositories dependencies
builder.Services.AddTransient<IAuthorRepository, AuthorRepository>();
builder.Services.AddTransient<IDiscountRepository, DiscountRepository>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IJobRepository, JobRepository>();
builder.Services.AddTransient<IPub_InfoRepository, Pub_InfoRepository>();
builder.Services.AddTransient<IPublisherRepository, PublisherRepository>();
builder.Services.AddTransient<IRoyschedRepository, RoyschedRepository>();
builder.Services.AddTransient<ISaleRepository, SaleRepository>();
builder.Services.AddTransient<IStoreRepository, StoreRepository>();
builder.Services.AddTransient<ITitleAuthorRepository, TitleAuthorRepository>();
builder.Services.AddTransient<ITitleRepository, TitleRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
