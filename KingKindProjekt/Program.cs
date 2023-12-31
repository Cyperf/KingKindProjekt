using KingKindProjekt.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<JsonFileService<KingKindProjekt.Models.Item>>();
builder.Services.AddSingleton<ItemService, ItemService>();
builder.Services.AddSingleton<CartService, CartService>();
builder.Services.AddTransient<JsonFileService<KingKindProjekt.Models.Account>>();
builder.Services.AddSingleton<AccountService, AccountService>();
builder.Services.AddTransient<JsonFileService<KingKindProjekt.Models.Sale>>();
builder.Services.AddSingleton<SaleService, SaleService>();
builder.Services.AddTransient<JsonFileService<KingKindProjekt.Models.Coupon>>();
builder.Services.AddSingleton<CouponService, CouponService>();

builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.Run();
