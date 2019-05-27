using SimUDuck.Behaviors;

namespace SimUDuck.Types
{
    public class Rubber : Duck
    {
        public Rubber(IFlyBehavior flyBehavior, IQuackBehavior quackBehavior) : base(flyBehavior, quackBehavior) { }
        public override string Display() => "I'm a Rubber Duck!";
        public override string Swim() => "I'm floating, actually!";
    }
}
