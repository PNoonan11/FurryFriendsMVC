using FurryFriendsMVC.Data;
using FurryFriendsMVC.Services.Comment;
using FurryFriendsMVC.Services.Post;
using FurryFriendsMVC.Services.User;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
           builder.Configuration.GetConnectionString("DefaultConnection")
       ));
builder.Services.AddScoped<ICommentServices, CommentServices>();
builder.Services.AddScoped<IPostServices, PostServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
