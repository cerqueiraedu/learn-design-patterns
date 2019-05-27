using SimUDuck.Types;
using System.Collections.Generic;

namespace SimUDuck.Services
{
    public interface IDuckService
    {
        IEnumerable<Duck> GetAll();

        Duck GetRubberDuck();

        Duck GetMallardDuck();
    }
}
