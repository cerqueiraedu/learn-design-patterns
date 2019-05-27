using SimUDuck.Types;
using System.Collections.Generic;
using System.Linq;

namespace SimUDuck.Services
{
    public class DuckService : IDuckService
    {
        private readonly IEnumerable<Duck> _ducks;

        public DuckService(IEnumerable<Duck> ducks)
        {
            _ducks = ducks;
        }

        public IEnumerable<Duck> GetAll()
        {
            return _ducks;
        }

        public Duck GetRubberDuck()
        {
            return _ducks.FirstOrDefault(duck => duck is Rubber);
        }

        public Duck GetMallardDuck()
        {
            return _ducks.FirstOrDefault(duck => duck is Mallard);
        }
    }
}
