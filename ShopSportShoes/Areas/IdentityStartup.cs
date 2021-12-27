using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ShopSportShoes.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ShopSportShoes.Models.Identity;
using ShopSportShoes.Areas;
using ShopSportShoes.Areas.Identity.Data;

[assembly: HostingStartup(typeof(IdentityStartup))]
namespace ShopSportShoes.Areas
{
    public class IdentityStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<AppDbContext>(options => options.UseOracle(context.Configuration.GetConnectionString("DEV")));

                services.AddIdentity<IdentityUser, IdentityRole>()
                        .AddEntityFrameworkStores<ShopSportShoes.Areas.Identity.Data.AppDbContext>()
                        .AddDefaultTokenProviders();

                services.Configure<IdentityOptions>(options =>
                {
                    // Thiết lập về Password
                    options.Password.RequireDigit = false; // Không bắt phải có số
                    options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
                    options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
                    options.Password.RequireUppercase = false; // Không bắt buộc chữ in
                    //options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
                    //options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

                    // Cấu hình Lockout - khóa user
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
                    options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
                    options.Lockout.AllowedForNewUsers = true;

                    // Cấu hình về User.
                   
                    options.User.AllowedUserNameCharacters = String.Empty; // Set String.Empty để nhập tên với ký tự bất kỳ
                    options.User.RequireUniqueEmail = true;  // Email là duy nhất

                    // Cấu hình đăng nhập.
                    options.SignIn.RequireConfirmedEmail = false;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
                    options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại

                });

            });
        }
    }
}
