using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Web_my_pham.Data;
using Web_my_pham.Services.AdminServices;
using Web_my_pham.Services.ClientServices;
using Web_my_pham.Services.ClientServices.Irepository;
using Web_my_pham.Services.ClientServices.Repository;
using Microsoft.IdentityModel.Tokens;
using Web_my_pham.Models;
using Web_my_pham.Services.AdminServices.Irepository;
using Web_my_pham.Services.AdminServices.Repository;

namespace Web_my_pham
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("MyDb"));
            });
            services.Configure<Appsetting>(Configuration.GetSection("Appsettings"));
            var secretkey = Configuration["Appsettings:Secretkey"];
            var secretkeyBytes = Encoding.UTF8.GetBytes(secretkey);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(otp=> {
                otp.TokenValidationParameters = new TokenValidationParameters
                {
                    //tự cấp token
                    ValidateIssuer = false,
                    ValidateAudience = false,

                    //ký vào token
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretkeyBytes),

                    ClockSkew = TimeSpan.Zero
                };
            });
            services.AddHttpContextAccessor();


            services.AddScoped<IDanhMucSanPhamRepository, DanhMucSanPhamRepository>();
            services.AddScoped<IAnhSanPhamRepository, AnhSanPhamRepository>();
            services.AddScoped<ISanPhamChiTietRepository, SanPhamChiTietRepository>();
            services.AddScoped<IChucVuRepository, ChucVuRepository>();
            services.AddScoped<ISanPhamRepositorty, SanPhamRepository>();
            services.AddScoped<IDanhMucRepositoryClient, DanhMucRepositoryClient>();
            services.AddScoped<IShopingCartRepository, ShopingCartRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IHoaDonRepository, HoaDonRepository>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web_my_pham", Version = "v1" });
            });
            //AllowSpecificOrigin
            services.AddDistributedMemoryCache(); // Dùng cache trong bộ nhớ

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(100); // Thời gian hết hạn session
                options.Cookie.HttpOnly = true; // Bảo mật cookie
                options.Cookie.IsEssential = true;
                //the
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.SameSite = SameSiteMode.None;
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                /*options.Cookie.SecurePolicy = CookieSecurePolicy.Always;*/// Cho phép cookie session khi không có sự đồng ý của người dùng
            });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200") // Địa chỉ Angular
                               .AllowAnyMethod()
                               .AllowAnyHeader()
                               .AllowCredentials();// moi
                    });
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline. .AllowAnyOrigin()
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web_my_pham v1"));
            }
            app.UseCors("AllowAllOrigins");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseSwagger();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
