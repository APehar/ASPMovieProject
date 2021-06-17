using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MovieRents.API.Core;
using MovieRents.Application.Executors;
using MovieRents.Application.ICommands.CategoryCommands;
using MovieRents.Application.ICommands.GenreCommands;
using MovieRents.Application.ICommands.MovieCommands;
using MovieRents.Application.ICommands.MovieGenreCommands;
using MovieRents.Application.ICommands.OrderCommands;
using MovieRents.Application.ICommands.ReviewCommands;
using MovieRents.Application.ICommands.UserCommands;
using MovieRents.Application.ICommands.UserUseCaseCommands;
using MovieRents.Application.Interfaces;
using MovieRents.Application.IQueries;
using MovieRents.Application.IQueries.CategoryQueries;
using MovieRents.Application.IQueries.GenreQueries;
using MovieRents.Application.IQueries.LogQueries;
using MovieRents.Application.IQueries.MovieQueries;
using MovieRents.Application.IQueries.OrderQueries;
using MovieRents.Application.IQueries.ReviewQueries;
using MovieRents.Application.IQueries.UserQueries;
using MovieRents.DataAccess;
using MovieRents.Implementation.Commands;
using MovieRents.Implementation.Commands.CategoryCommands;
using MovieRents.Implementation.Commands.CategtoryCommands;
using MovieRents.Implementation.Commands.GenreCommands;
using MovieRents.Implementation.Commands.MovieCommands;
using MovieRents.Implementation.Commands.MovieGenreCommands;
using MovieRents.Implementation.Commands.OrderCommands;
using MovieRents.Implementation.Commands.ReviewCommand;
using MovieRents.Implementation.Commands.UserCommands;
using MovieRents.Implementation.Commands.UserUseCaseCommands;
using MovieRents.Implementation.Email;
using MovieRents.Implementation.Logging;
using MovieRents.Implementation.Queries.CategoryQueries;
using MovieRents.Implementation.Queries.GenreQueries;
using MovieRents.Implementation.Queries.LogQueries;
using MovieRents.Implementation.Queries.MovieQueries;
using MovieRents.Implementation.Queries.OrderQueries;
using MovieRents.Implementation.Queries.ReviewQueries;
using MovieRents.Implementation.Queries.UserQueries;
using MovieRents.Implementation.Validators;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRents.API
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
            services.AddDbContext<CinemaContext>();
            services.AddTransient<UseCaseExecutor>();
            services.AddTransient<JwtManager>();
            services.AddTransient<CategoryValidator>();
            services.AddTransient<EditCategoryValidator>();
            services.AddTransient<CreateUserValidator>();
            services.AddTransient<EditUserValidator>();
            services.AddTransient<CreateGenreValidator>();
            services.AddTransient<EditGenreValidator>();
            services.AddTransient<CreateMovieValidator>();
            services.AddTransient<EditMovieValidator>();
            services.AddTransient<CreateMovieGenreValidator>();
            services.AddTransient<CreateReviewValidator>();
            services.AddTransient<EditReviewValidator>();
            services.AddTransient<CreateOrderValidator>();
            services.AddTransient<AddMovieGenreValidator>();
            services.AddTransient<CreateUserUseCaseValidator>();

            services.AddHttpContextAccessor();
            //Lazni admin actor koji ima prava na sve komande
            //services.AddTransient<IApplicationActor, FakeAdminActor>();
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();

                var user = accessor.HttpContext.User;
                if (user.FindFirst("ActorData") == null)
                {
                    return new AnonymousActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);
                return actor;
            });

            services.AddTransient<IUseCaseLogger, DataBaseUseCaseLogger>();
            services.AddTransient<ICreateCategoryCommand, CreateCategoryCommand>();
            services.AddTransient<IEditCategoryCommand, EditCategoryCommand>();
            services.AddTransient<ICreateUserCommand, CreateUserCommand>();
            services.AddTransient<IEditUserCommand, EditUserCommand>();
            services.AddTransient<ICreateGenreCommand, CreateGenreCommand>();
            services.AddTransient<IEditGenreCommand, EditGenreCommand>();
            services.AddTransient<ICreateMovieCommand, CreateMovieCommand>();
            services.AddTransient<IEditMovieCommand, EditMovieCommand>();
            services.AddTransient<ICreateReviewCommand, CreateReviewCommand>();
            services.AddTransient<IEditReviewCommand, EditReviewCommand>();
            services.AddTransient<ICreateOrderCommand, CreateOrderCommand>();
            services.AddTransient<IAddMovieGenreCommand, AddMovieGenreCommand>();
            services.AddTransient<ICreateUserUseCaseCommand, CreateUserUseCaseCommand>();
            services.AddTransient<IUploadMoviePosterCommand, UploadMoviePosterCommand>();

            services.AddTransient<IGetCategoriesQuery, GetCategoriesQuery>();
            services.AddTransient<IGetOneCategoryQuery, GetOneCategoryQuery>();
            services.AddTransient<IGetGenresQuery, GetGenreQuery>();
            services.AddTransient<IGetOneGenreQuery, GetOneGenreQuery>();
            services.AddTransient<IGetOneMovieQuery, GetOneMovieQuery>();
            services.AddTransient<IGetMoviesQuery, GetMoviesQuery>();
            services.AddTransient<IGetReviewsQuery, GetReviewsQuery>();
            services.AddTransient<IGetOneReviewQuery, GetOneReviewQuery>();
            services.AddTransient<IGetOneUserQuery, GetOneUserQuery>();
            services.AddTransient<IGetUsersQuery, GetUsersQuery>();
            services.AddTransient<IGetOrdersQuery, GetOrdersQuery>();
            services.AddTransient<IGetOneOrderQuery, GetOneOrderQuery>();
            services.AddTransient<IGetLogsQuery, GetLogsQuery>();

            services.AddTransient<IDeleteCategoryCommand, DeleteCategoryCommand>();
            services.AddTransient<IDeleteGenreCommand, DeleteGenreCommand>();
            services.AddTransient<IDeleteMovieCommand, DeleteMovieCommand>();
            services.AddTransient<IDeleteReviewCommand, DeleteReviewCommand>();
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
            services.AddTransient<IDeleteOrderCommand, DeleteOrderCommand>();
            services.AddTransient<IDeleteMovieGenreCommand, DeleteMovieGenreCommand>();
            services.AddTransient<IDeleteUserUseCaseCommand, DeleteUserUseCaseCommand>();


            services.AddTransient<IEmailSender, SmtpEmailSender>();

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "asp_api",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();

            app.UseMiddleware<GlobalExceptionHandler>();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
