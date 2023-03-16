using FirstMVCApp.Models;
using FirstMVCApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class MembershipTypesController : Controller
    {
        private readonly MembershipTypesRepository _repository;
        public MembershipTypesController(MembershipTypesRepository repository)
        {
            _repository = repository;
        }
        
        public IActionResult Index()
        {
            var memTypes=_repository.GetMembershipTypes();
            return View("Index",memTypes);
        }
		public IActionResult Create()
		{
			return View("Create");
		}
        [HttpPost]
		public IActionResult Create(IFormCollection collection)
		{
			MembershipTypeModel membership = new MembershipTypeModel();
			TryUpdateModelAsync(membership); // se apeleaza datele din formular pe modelul announcement
            _repository.AddMembershipType(membership);
			return RedirectToAction("Index");
		}
		public IActionResult Edit(Guid id)
		{
			MembershipTypeModel model = _repository.GetMembershipTypeById(id);
			return View("Edit", model);
		}
		[HttpPost]
		public IActionResult Edit(Guid id, IFormCollection collection)
		{
			MembershipTypeModel model = new MembershipTypeModel();
			TryUpdateModelAsync(model);
			_repository.Update(model);
			return RedirectToAction("Index");
		}
        public IActionResult Details(Guid id)
        {
            MembershipTypeModel membership = _repository.GetMembershipTypeById(id);
            return View("Details", membership);
        }
    }
}
