using Microsoft.Extensions.DependencyInjection;
using SimUDuck.Behaviors;
using SimUDuck.Behaviors.Implementations;
using SimUDuck.Services;
using SimUDuck.Types;
using System;
using System.Linq;

namespace SimUDuck
{
    public static class SimUDuckExtension
    {
        public static void AddSimUDuckDomain(this IServiceCollection services)
        {
            services.AddScoped<IFlyBehavior, FlyWithWings>();
            services.AddScoped<IFlyBehavior, FlyNoWay>();
            
            services.AddScoped<IQuackBehavior, Quack>();
            services.AddScoped<IQuackBehavior, Squeak>();

            services.AddScoped<Duck, Mallard>(x => x.GetMallardDuck());
            services.AddScoped<Duck, Rubber>(x => x.GetRubberDuck());

            services.AddScoped<IDuckService, DuckService>();
        }

        private static Mallard GetMallardDuck(this IServiceProvider serviceProvider)
        {
            return new Mallard(
                serviceProvider.GetServices<IFlyBehavior>().FirstOrDefault(x => x is FlyWithWings),
                serviceProvider.GetServices<IQuackBehavior>().FirstOrDefault(x => x is Quack));
        }

        private static Rubber GetRubberDuck(this IServiceProvider serviceProvider)
        {
            return new Rubber(
                serviceProvider.GetServices<IFlyBehavior>().FirstOrDefault(x => x is FlyNoWay),
                serviceProvider.GetServices<IQuackBehavior>().FirstOrDefault(x => x is Squeak));
        }
    }
}