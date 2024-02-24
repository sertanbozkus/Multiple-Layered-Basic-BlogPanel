using BilgeBlog.Business.Managers;
using BilgeBlog.Business.Services;
using BilgeBlog.Data.Context;
using BilgeBlog.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<BilgeBlogContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
builder.Services.AddScoped<ICategoryService, CategoryManager>();
// Her ICategoryService istendiðinde bana yeni bir tane CategoryManager nesnesi vereceksin.

builder.Services.AddScoped(typeof(IPostRepository), typeof(PostRepository));
builder.Services.AddScoped<IPostService, PostManager>();

var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();
