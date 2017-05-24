using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WithFeatureFolders.Core.Interfaces;
using WithFeatureFolders.Core.Model;
using WithFeatureFolders.Features.Ninjas.Ninjas;

namespace WithFeatureFolders.Features.Ninjas
{
    public class NinjasController : Controller
    {
        private readonly IRepository<Ninja> _ninjaRepository;

        public NinjasController(IRepository<Ninja> ninjaRepository)
        {
            _ninjaRepository = ninjaRepository;
        }

        public IActionResult Index()
        {
            var entities = _ninjaRepository.List();

            var viewModel = new NinjaListViewModel();
            viewModel.Ninjas.AddRange(entities
                .Select(e => new NinjaViewModel()
                { Id = e.Id, Name = e.Name })
                .ToList());
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var entity = _ninjaRepository.GetById(id);

            var viewmodel = new NinjaViewModel() { Id = entity.Id, Name = entity.Name };
            return View(viewmodel);
        }

        public IActionResult Add()
        {
            var entity = new Ninja()
            {
                Name = "Random Ninja"
            };
            _ninjaRepository.Add(entity);

            return RedirectToAction("Index");
        }
    }
}