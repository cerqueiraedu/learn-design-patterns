using LearnDesignPatterns.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SimUDuck.Services;
using System.Collections.Generic;
using System.Linq;
using LearnDesignPatterns.Api.Mappers;

namespace LearnDesignPatterns.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuckController : ControllerBase
    {
        private readonly IDuckService _duckService;

        public DuckController(IDuckService duckService)
        {
            _duckService = duckService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DuckVM>> Get()
        {
            return _duckService
                .GetAll()
                .Select(duck => duck.ToApi())
                .ToList();
        }

        [Route("rubber")]
        [HttpGet]
        public ActionResult<DuckVM> GetRubberDuck()
        {
            return _duckService.GetRubberDuck().ToApi();
        }

        [Route("mallard")]
        [HttpGet]
        public ActionResult<DuckVM> GetMallardDuck()
        {
            return _duckService.GetMallardDuck().ToApi();
        }
    }
}
