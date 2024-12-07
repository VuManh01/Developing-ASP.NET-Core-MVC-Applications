using Microsoft.EntityFrameworkCore;
using ComicSystem.Data;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình DbContext sử dụng MySQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 30))
    ));

// Thêm dịch vụ cho controller
builder.Services.AddControllersWithViews(); // Dùng với Views nếu bạn sử dụng Razor Views

// Tạo ứng dụng
var app = builder.Build();

// Cấu hình Routing
app.UseRouting();

// Cấu hình các tuyến đường cho ứng dụng
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=ComicBooks}/{action=Index}/{id?}");
});

// Cấu hình Middleware
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
