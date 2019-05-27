using NUnit.Framework;
using SimUDuck.Types;
using SimUDuck.Behaviors;
using Moq;

namespace SimUDuckTests.Types
{
    public class MallardTests
    {
        Duck _duck;
        Mock<IFlyBehavior> _flyBehaviorMock;
        Mock<IQuackBehavior> _quackBehaviorMock;

        [SetUp]
        public void Setup()
        {
            _flyBehaviorMock = new Mock<IFlyBehavior>();
            _quackBehaviorMock = new Mock<IQuackBehavior>();

            _duck = new Mallard(_flyBehaviorMock.Object, _quackBehaviorMock.Object);
        }

        [Test]
        public void DisplayTest()
        {
            Assert.AreEqual("I'm a Mallard Duck!", _duck.Display());
            Assert.Pass();
        }

        [Test]
        public void SwimTest()
        {
            Assert.AreEqual("I'm swimming!", _duck.Swim());
            Assert.Pass();
        }

        [Test]
        public void PerformFlyTest()
        {
            _duck.PerformFly();
            _flyBehaviorMock.Verify(x => x.Fly(), Times.Once);
            Assert.Pass();
        }

        [Test]
        public void PerformSoundTest()
        {
            _duck.PerformSound();
            _quackBehaviorMock.Verify(x => x.MakeSound(), Times.Once);
            Assert.Pass();
        }
    }
}