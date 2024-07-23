using Furniture.BusinessLayer.Abstract;
using Furniture.BusinessLayer.Concrete;
using Furniture.DataLayer.Abstract;
using Furniture.DataLayer.Concrete;
using Furniture.DataLayer.EntityFramework;
using Furniture.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

// Configurations
#region Services
builder.Services.AddScoped<Context>();
//builder.Services.AddScoped(typeof(IRepository<>), typeof(EfCoreGenericRepository< Product,EfCoreContext>));

builder.Services.AddScoped(typeof(ICardDal), typeof(EfCardDal));
builder.Services.AddScoped(typeof(IBrandDal), typeof(EfBrandDal));
builder.Services.AddScoped(typeof(IProductDal), typeof(EfProductDal));
builder.Services.AddScoped(typeof(IOrderDal), typeof(EfOrderDal));
builder.Services.AddScoped(typeof(ICategoryDal), typeof(EfCategoryDal));
builder.Services.AddScoped(typeof(ICardItemDal), typeof(EfCardItemDal));
builder.Services.AddScoped(typeof(IAppUserDal), typeof(EfAppUserDal));

builder.Services.AddScoped(typeof(ICardService), typeof(CardManager));
builder.Services.AddScoped(typeof(IBrandService), typeof(BrandManager));
builder.Services.AddScoped(typeof(IProductService), typeof(ProductManager));
builder.Services.AddScoped(typeof(IOrderService), typeof(OrderManager));
builder.Services.AddScoped(typeof(ICategoryService), typeof(CategoryManager));
builder.Services.AddScoped(typeof(ICardItemService), typeof(CardItemManager));
builder.Services.AddScoped(typeof(IAppUserService), typeof(AppUserManager));
builder.Services.AddScoped(typeof(IOrderItemService), typeof(OrderItemManager));
//ContactUsController için (admin-ContactUsController):
builder.Services.AddScoped<IContactUsService, ContactUsManager>();
builder.Services.AddScoped<IContactUsDal, EfContactUsDal>();
#endregion

builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();

//authorization islemi:
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.AddMvc();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/SignIn/";
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LogoutPath = "/Login/LogOut/";
                });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//404 error sayfasýna yönlendirmek için:
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
