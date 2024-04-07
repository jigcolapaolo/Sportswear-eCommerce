using API.Entities;
using API.Entities.Identity;
using API.Profiles;
using API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// My Services
builder.Services.AddAutoMapper(typeof(EcommerceProfile));
builder.Services.AddScoped<IBrandRepository, BrandRepository>();

// Register DbContext in services
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Identity
builder.Services.AddDbContext<AppIdentityDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
});
builder.Services.AddIdentityCore<AppUser>(opt =>
{
    // add identity options here
})
.AddEntityFrameworkStores<AppIdentityDbContext>()
.AddSignInManager<SignInManager<AppUser>>();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();


builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();

app.Run();
