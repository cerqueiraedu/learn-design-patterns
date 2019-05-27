using SimUDuck.Behaviors;

namespace SimUDuck.Types
{
    public abstract class Duck
    {
        private IFlyBehavior _flyBehavior;
        private IQuackBehavior _quackBehavior;

        public Duck(IFlyBehavior flyBehavior, IQuackBehavior quackBehavior)
        {
            _flyBehavior = flyBehavior;
            _quackBehavior = quackBehavior;
        }

        public abstract string Display();
        public abstract string Swim();

        public string PerformFly() => _flyBehavior.Fly();

        public string PerformSound() => _quackBehavior.MakeSound();
    }
}
