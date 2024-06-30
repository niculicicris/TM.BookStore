using System.Reflection;
using BookStore.Data.Abstraction;
using BookStore.Data.Abstraction.Repository;
using BookStore.Data.MongoDB;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyModel;

namespace BookStore;

internal class Program
{
    private static Assembly[] Assemblies;
    
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var databaseConfiguration = new DatabaseConfiguration();

        Assemblies = LoadApplicationDependencies();
        
        builder.Services.AddFluentValidation(options =>
        {
            options.RegisterValidatorsFromAssemblies(Assemblies);
        });

        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assemblies));

        builder.Services.AddSingleton<IDatabaseConfiguration>(builder.Configuration.Get<DatabaseConfiguration>());
        builder.Services.AddControllers();
        
        builder.Configuration.Bind("DatabaseConfiguration", databaseConfiguration);
        builder.Services.AddSingleton<IDatabaseConfiguration>(databaseConfiguration);
        
        builder.Services.Scan(scan => scan.FromAssemblies(Assemblies)
            .AddClasses(type => type.AssignableTo(typeof(IDatabase)))
            .AsImplementedInterfaces()
            .WithSingletonLifetime()
            .AddClasses(type => type.AssignableTo(typeof(IBookRepository)))
            .AsImplementedInterfaces()
            .WithSingletonLifetime());
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var application = builder.Build();

        if (application.Environment.IsDevelopment())
        {
            application.UseSwagger();
            application.UseSwaggerUI();
        }

        application.UseHttpsRedirection();
        application.UseAuthorization();
        application.MapControllers();

        application.Run();
    }

    private static Assembly[] LoadApplicationDependencies()
    {
        var context = DependencyContext.Default;

        return context.RuntimeLibraries.SelectMany(library => library.GetDefaultAssemblyNames(context))
            .Where(assembly => assembly.FullName.Contains("BookStore"))
            .Select(Assembly.Load).ToArray();
    }
}