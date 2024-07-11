using Microsoft.EntityFrameworkCore;
using Liskov_Substitution_Principle.DatabaseContext;
using Liskov_Substitution_Principle.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configure the DbContext classes
builder.Services.AddDbContext<MortgageDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MortgageDatabase")));

builder.Services.AddDbContext<CurrentAccountDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CurrentAccountDatabase")));

builder.Services.AddDbContext<SavingsAccountDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SavingsAccountDatabase")));

// Register the repositories and services
builder.Services.AddScoped<ICustomerRepository, MortgageCustomerRepository>();
builder.Services.AddScoped<ICustomerRepository, CurrentAccountCustomerRepository>();
builder.Services.AddScoped<ICustomerRepository, SavingsAccountCustomerRepository>();
builder.Services.AddScoped<CustomerService>();


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
