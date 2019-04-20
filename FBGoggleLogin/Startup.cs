using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FBGoggleLogin.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Facebook;

namespace FBGoggleLogin
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //Start For Facebook
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];

                facebookOptions.ClaimActions.Clear();
                facebookOptions.UserInformationEndpoint = FacebookDefaults.UserInformationEndpoint;
                facebookOptions.SaveTokens = true;

                facebookOptions.ClaimActions.MapJsonKey("UserId", "id");
                facebookOptions.ClaimActions.MapJsonSubKey("urn:facebook:age_range_min", "age_range", "min");
                facebookOptions.ClaimActions.MapJsonSubKey("urn:facebook:age_range_max", "age_range", "max");
                facebookOptions.ClaimActions.MapJsonKey(ClaimTypes.DateOfBirth, "birthday");
                facebookOptions.ClaimActions.MapJsonKey("Email", "email");
                facebookOptions.ClaimActions.MapJsonKey("FullName", "name");
                facebookOptions.ClaimActions.MapJsonKey("FirstName", "first_name");
                facebookOptions.ClaimActions.MapJsonKey("LastName", "last_name");
                facebookOptions.ClaimActions.MapJsonKey("Gender", "gender");
                facebookOptions.ClaimActions.MapJsonKey("urn:facebook:link", "link");
                facebookOptions.ClaimActions.MapJsonSubKey("urn:facebook:location", "location", "name");
                facebookOptions.ClaimActions.MapJsonKey(ClaimTypes.Locality, "locale");
                facebookOptions.ClaimActions.MapJsonKey("urn:facebook:timezone", "timezone");

                // ...other options omitted
                facebookOptions.Fields.Add("picture");
                facebookOptions.Fields.Add("gender");


                facebookOptions.ClaimActions.MapCustomJson("PictureUrl",
                                 claim => (string)claim.SelectToken("picture.data.url"));

                facebookOptions.ClaimActions.MapCustomJson("Gender",
                                 claim => (string)claim.SelectToken("gender"));

            })
            //End For Facebook
            .AddCookie(options => {
                 options.LoginPath = "/auth/signin";
             })
             .AddGoogle(options =>
             {
                 options.ClientId = Configuration["Authentication:Google:ClientId"]; ;
                 options.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
                 
                 options.UserInformationEndpoint = "https://www.googleapis.com/oauth2/v2/userinfo";
                 options.ClaimActions.Clear();

                 options.Scope.Add("https://www.googleapis.com/auth/plus.login");
                 options.SaveTokens = true;

                 options.ClaimActions.MapJsonKey("Gender", "gender");
                 options.ClaimActions.MapJsonKey("UserId", "id");
                 options.ClaimActions.MapJsonKey("FullName", "name");
                 options.ClaimActions.MapJsonKey("FirstName", "given_name");
                 options.ClaimActions.MapJsonKey("LastName", "family_name");
                 options.ClaimActions.MapJsonKey("ProfileUrl", "link");
                 options.ClaimActions.MapJsonKey("Email", "email");


                 //options.Field.Add("image");
                 //options.ClaimActions.MapJsonKey("PictureUrl", "email");
                 options.ClaimActions.MapJsonKey("PictureUrl", "image:url");

                 options.ClaimActions.MapCustomJson("PictureUrl",
                                 claim => (string)claim.SelectToken("image:url"));


             });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
			

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
