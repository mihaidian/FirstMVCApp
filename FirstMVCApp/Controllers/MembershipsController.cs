using FirstMVCApp.Models;
using FirstMVCApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class MembershipsController : Controller
    {
        private readonly MembershipsRepository _repository;

        public MembershipsController(MembershipsRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var memberships= _repository.GetMemberships();
            return View("Index", memberships);
        }
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(IFormCollection collection) 
        {
            MembershipModel membership= new MembershipModel();
            TryUpdateModelAsync(membership);
            _repository.AddMembership(membership);
            return RedirectToAction("Index");
        }
    }
}
