using GuardiaAPI.Entities;
using GuardiaAPI.Repositories;

namespace GuardiaAPI;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers().
            ConfigureApiBehaviorOptions(options => 
            {
                options.SuppressMapClientErrors = true;
            });
        //services.AddSingleton<IRepository<Contact, int>, InMemoryRepository>();
        services.AddSingleton<IRepository<Contact, int>, ContactProvider>();
        services.AddSingleton<IRepository<Sede, int>, SedeProvider>();
        services.AddSingleton<IRepository<User, int>, UserProvider>();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddCors(options =>
        {
            var frontendURL = Configuration.GetValue<string>("frontend_url");
            options.AddDefaultPolicy(builder =>
            {
                builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader();
            });
        });

        services.Configure<ConnectionStringList>(Configuration.GetSection("ConnectionStrings"));
        services.AddAutoMapper(typeof(Startup));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GuardiaAPI v1"));
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

}

