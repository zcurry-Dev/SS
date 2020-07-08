using System.Net;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using SS.Business.Interfaces;
using SS.Business.Mappings.Interfaces;
using SS.Business.Mappings.Repos;
using SS.Business.Repos;
using SS.Data;
using SS.Data.Interfaces;
using SS.Data.Models;
using SS.Data.Repos;
using SS.Helpers;

namespace SS.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(x =>
            {
                x.UseLazyLoadingProxies();
                x.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection"));
            });
            ConfigureServices(services);
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(x =>
             {
                 x.UseLazyLoadingProxies();
                 x.UseSqlServer(
                 Configuration.GetConnectionString("DefaultConnection"));
             });
            ConfigureServices(services);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Identity Section
            IdentityBuilder builder = services.AddIdentityCore<Ssuser>(opt =>
            {
                // to be changed, set up for development
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 4;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                //
            });

            builder = new IdentityBuilder(builder.UserType, typeof(Ssrole), builder.Services);
            builder.AddEntityFrameworkStores<DataContext>();
            builder.AddRoleValidator<RoleValidator<Ssrole>>();
            builder.AddRoleManager<RoleManager<Ssrole>>();
            builder.AddSignInManager<SignInManager<Ssuser>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                            .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            services.AddScoped<LogUserActivity>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
                options.AddPolicy("ModeratePhotoRole", policy => policy.RequireRole("Admin", "Moderator"));
                options.AddPolicy("Venue Manager", policy => policy.RequireRole("Venue Manager"));
            });
            //

            services.AddControllers(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                options.Filters.Add(new AuthorizeFilter(policy));
            })
            .AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddCors();

            // Data
            services.AddScoped<IAdminDataRepository, AdminDataRepository>();
            services.AddScoped<IArtistDataRepository, ArtistDataRepository>();
            services.AddScoped<IUserDataRepository, UserDataRepository>();
            services.AddScoped<IUtilityDataRepository, UtilityDataRepository>();
            services.AddScoped<IUserRoleDataRepository, UserRoleDataRepository>();
            services.AddScoped(typeof(IDataRepository<>), typeof(DataRepository<>));

            // Business
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUtilityRepository, UtilityRepository>();

            // Mappings
            services.AddScoped<IAdminMapping, AdminMapping>();
            services.AddScoped<IArtistMapping, ArtistMapping>();
            services.AddScoped<IUserMapping, UserMapping>();
            services.AddScoped<IUtilityMapping, UtilityMapping>();
            //
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToController("Index", "Fallback");
            });
        }
    }
}
