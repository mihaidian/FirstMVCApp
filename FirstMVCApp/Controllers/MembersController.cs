using FirstMVCApp.Models;
using FirstMVCApp.Repositories;
using FirstMVCApp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class MembersController : Controller
    {

        private readonly MembersRepository _repository;

        public MembersController(MembersRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var members = _repository.GetMembers();
            return View("Index",members);
        }
        public IActionResult Create() 
        {
            return View("Create");
        }
		[HttpPost]
		public IActionResult Create(IFormCollection collection)
		{
			MemberModel member = new MemberModel();
			TryUpdateModelAsync(member); // se apeleaza datele din formular pe modelul announcement
			_repository.Add(member);
			return RedirectToAction("Index");
		}
		public IActionResult Edit(Guid id)
		{
			MemberModel model = _repository.GetMemberById(id);
			return View("Edit", model);
		}
		[HttpPost]
		public IActionResult Edit(Guid id, IFormCollection collection)
		{
			MemberModel model = new MemberModel();
			TryUpdateModelAsync(model);
			_repository.Update(model);
			return RedirectToAction("Index");
		}
		public ActionResult DetailsWithCodeSnippets(Guid id)
		{
			MemberCodeSnippetsViewModel viewModel=_repository.GetMemberCodeSnippets(id);
			return View("DetailsWithCodeSnippets",viewModel);
		}
		public IActionResult Details(Guid id) 
		{
			MemberModel member=_repository.GetMemberById(id);
			return View("Details", member);
		}
	}
}
