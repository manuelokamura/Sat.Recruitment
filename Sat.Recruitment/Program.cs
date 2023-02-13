using Microsoft.EntityFrameworkCore;
using Sat.Recruitment;
using Sat.Recruitment.DataViewModels;
using Sat.Recruitment.Models;
using Sat.Recruitment.Repository;
using Sat.Recruitment.Repository.Interfaces;
using Sat.Recruitment.Services;
using Sat.Recruitment.Services.Interface;
using Sat.Recruitment.Services.Services;
using System.Diagnostics.CodeAnalysis;

[assembly: ExcludeFromCodeCoverage]
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<SATContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<RepositoryContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

builder.Services.AddTransient<IServiceAdd<AddressVM>, AddressServiceAdd>();
builder.Services.AddTransient<IServiceDelete, AddressServiceDelete>();
builder.Services.AddTransient<IServiceGet<Address>, AddressServiceGet>();
builder.Services.AddTransient<IServiceUpdate<AddressVM>, AddressServiceUpdate>();

builder.Services.AddTransient<IServiceAdd<UserVM>, UserServiceAdd>();
builder.Services.AddTransient<IServiceDelete, UserServiceDelete>();
builder.Services.AddTransient<IServiceGet<UserVMResponse>, UserServiceGet>();
builder.Services.AddTransient<IServiceUpdate<UserVM>, UserServiceUpdate>();

builder.Services.AddTransient<IServiceAdd<UserTypeVM>, UserTypeServiceAdd>();
builder.Services.AddTransient<IServiceDelete, UserTypeServiceDelete>();
builder.Services.AddTransient<IServiceGet<UserType>, UserTypeServiceGet>();
builder.Services.AddTransient<IServiceUpdate<UserTypeVM>, UserTypeServiceUpdate>();

builder.Services.AddTransient<IServiceValidation, ServiceValidation>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.UseHttpsRedirection();



app.Run();