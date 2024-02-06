
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using Castle.DynamicProxy;//
using Core.DependencyResolvers;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Core.Extensions;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //ioc konteyner constructor çalýþtýðýnda hazý referanslerý newliyor
            // builder.Services.AddSingleton<ICarService , CarManeger>();
            // builder.Services.AddSingleton<ICarDal , EfCarDal>();
            //  builder.Services.AddSingleton<IBrandService, BrandManeger>();
            //   builder.Services.AddSingleton<IBrandDal,EfBrandDal>();
            //  builder.Services.AddSingleton<IColorService ,ColorManeger>();
            // builder.Services.AddSingleton<IColorDal , EfColorDal>();
            // builder.Services.AddSingleton<ICustomerService , CustumerManeger>();
            //builder.Services.AddSingleton<ICostomer , EfCostomerDal>();
            //builder.Services.AddSingleton<IRentalService , RentalManeger>();
            // builder.Services.AddSingleton<IRental,EfRentalDal>();
            //builder.Services.AddSingleton<IUserService , UserManeger>();
            //builder.Services.AddSingleton<IUser ,EfUser>();




            //ÖNEMLÝ 
            //burada artýk .net e diyoruz ki ben artýk yeni bir teknoojiye geçtim onu kulanýyorum(Autofac):
            //AutofacBusinessModule busnis katmanýndakini istiyorum
            builder.Host.UseServiceProviderFactory(services => new AutofacServiceProviderFactory())
                     .ConfigureContainer<ContainerBuilder>(builder =>
                     {
                         builder.RegisterModule(new AutofacBusinessModule());
                     });

            //   builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddCors();
            var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)//otantikasyon olarak jwt token kulanulacak asp net web api diyoruz ki jwt kulanýlacak 
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHalper.CreatSecurityKey(tokenOptions.SecurityKey)
                    };
                });
            // Core.Utilities.IoC.ServiceTool.Create(builder.Services);
            builder.Services.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule(),
            });

            //  builder.Services.AddDependencyResolvers(new ICoreModule[]
            //{
            //      new CoreModule(),
            //});


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
          
            }

            app.ConfigureCustomExceptionMiddleware();
            app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());//angulurdan buna bir istek gelirse izin ver 

            app.UseAuthentication();//midel way deniyor asp net yaþam döngüsünde hangilerinin sýrasýyal devre gireceðimizi beliyoruz 
            app.UseHttpsRedirection();
        
            app.UseAuthorization();

            


            app.MapControllers();

            app.Run();
        }
    }
}