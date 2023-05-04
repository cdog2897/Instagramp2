using Microsoft.AspNetCore.Mvc;
using ClassLibrary;
using Instagramp_2.Service;

namespace Instagramp_2.Controllers
{
    public class HomeController : Controller
    {
        PostDAO postDAO = new PostDAO();
        public IActionResult Index()
        {
            return View(postDAO.GetAll());
        }
        public IActionResult ShowPostEditForm(string Id)
        {
            return View(postDAO.GetById(Id));
        }
        public IActionResult ProcessPostEdit(PostModel post)
        {
            postDAO.Update(post.Id, post);
            return View("Index", postDAO.GetAll());
        }
        public IActionResult ShowPostDeleteForm(string Id)
        {
            return View(postDAO.GetById(Id));
        }
        public IActionResult ProcessPostDelete(string Id)
        {
            postDAO.Delete(Id);
            return View("Index", postDAO.GetAll());
        }
    }
}
