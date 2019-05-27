using LearnDesignPatterns.Api.ViewModels;
using SimUDuck.Types;

namespace LearnDesignPatterns.Api.Mappers
{
    public static class DuckMapper
    {
        public static DuckVM ToApi(this Duck duck)
        {
            return new DuckVM
            {
                Display = duck.Display(),
                Swim = duck.Swim(),
                Fly = duck.PerformFly(),
                MakeSound = duck.PerformSound()
            };
        }
    }
}
