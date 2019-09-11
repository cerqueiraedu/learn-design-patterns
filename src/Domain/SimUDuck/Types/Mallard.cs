using SimUDuck.Behaviors;

namespace SimUDuck.Types
{
    public class Mallard : Duck
    {
        public Mallard(IFlyBehavior flyBehavior, IQuackBehavior quackBehavior) : base(flyBehavior, quackBehavior) { }
        public override string Display() => "I'm a Mallard Duck!";
        public override string Swim() => "I'm swimming!";
    }
}