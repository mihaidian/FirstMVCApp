using FirstMVCApp.Models;
using FirstMVCApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
	public class CodeSnippetsController : Controller
	{
		// GET: HomeController1
		private readonly CodeSnippetsRepository _repository;
		private readonly MembersRepository _membersRepository;

		public CodeSnippetsController(CodeSnippetsRepository repository, MembersRepository membersRepository)
		{
			_repository = repository;
			_membersRepository = membersRepository;
		}
		public ActionResult Index()
		{
			var codeSnippets=_repository.GetCodeSnippets();
			return View("Index",codeSnippets);
		}

		// GET: HomeController1/Details/5
		public ActionResult Details(Guid id)
		{
			var codeSnippet=_repository.GetCodeSnippetById(id);
			return View("Details",codeSnippet);
		}

		// GET: HomeController1/Create
		public ActionResult Create()
		{
			var members = _membersRepository.GetMembers();
			ViewBag.data = members;
			return View("Create");
		}

		// POST: HomeController1/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			CodeSnippetModel model = new CodeSnippetModel();
			TryUpdateModelAsync(model);
			_repository.AddCodeSnippet(model);
			return RedirectToAction("Index");
		}

		// GET: HomeController1/Edit/5
		public ActionResult Edit(Guid id)
		{
			CodeSnippetModel model=_repository.GetCodeSnippetById(id);
			return View("Edit",model);
		}

		// POST: HomeController1/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Guid id, IFormCollection collection)
		{
			CodeSnippetModel model=new CodeSnippetModel();
			TryUpdateModelAsync(model);
			_repository.UpdateCodeSnippet(model);
			return RedirectToAction("Index");
		}

		// GET: HomeController1/Delete/5
		public ActionResult Delete(Guid id)
		{
			CodeSnippetModel model = _repository.GetCodeSnippetById(id);
			return View("Delete", model);
		}

		// POST: HomeController1/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(Guid id, IFormCollection collection)
		{

			_repository.DeleteCodeSnippet(id);
			return RedirectToAction("Index");
		}
	}
}
