using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using DATN.Infastructure.Persistence;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DATN.Infastructure;
using DATN.Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DATN.Application.Middleware;

namespace DATN
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
			services.AddAutoMapper(typeof(Startup));

			// Register the MediatR request handlers
			services.AddCors();
			services.AddControllers();
			services.RegisterRepositories();
			services.RegisterRequestHandlers();
			//services.AddDbContext<ApplicationDbContext>(option =>
			//{
			//	option.UseSqlServer(Configuration.GetConnectionString("MyDb"),
			//		b => b.MigrationsAssembly("DATN.Api"));
			//});
			services.AddDbContext<ApplicationDbContext>(options =>
			   options.UseNpgsql(
			   Configuration.GetConnectionString("MyDb"),
			   b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

			services.AddHttpContextAccessor()
					.AddAuthorization()
					.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
					.AddJwtBearer(options =>
					{
						options.RequireHttpsMetadata = false;
						options.SaveToken = true;
						options.TokenValidationParameters = new TokenValidationParameters
						{
							ValidateIssuer = true,
							ValidateAudience = true,
							ValidateLifetime = true,
							ValidateIssuerSigningKey = true,
							ValidIssuer = Configuration["Jwt:Issuer"],
							ValidAudience = Configuration["Jwt:Audience"],
							IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
						};
					});

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "DATN", Version = "v1" });
			});

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DATN v1"));
			}
			app.UseCors(x => x
				.AllowAnyMethod()
				.AllowAnyHeader()
				.SetIsOriginAllowed(origin => true) // allow any origin
				.AllowCredentials()); // allow credentials
			app.UseMiddleware<ErrorHandlerMiddleware>();
			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
