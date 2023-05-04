using ClassLibrary;
using Instagramp_2.Models;
using Instagramp_2.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Instagramp_2.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPostDAO _postDAO;
        public SearchController(IPostDAO postDAO)
        {
            _postDAO = postDAO;
        }
        public IActionResult Index()
        {
            List<SearchTermModel> searchTerms = new List<SearchTermModel>();

            searchTerms.Add(new SearchTermModel("Family", "See posts about family!", "img/familypic.jpg"));
            searchTerms.Add(new SearchTermModel("Friends", "See posts about friends!", "img/dawgsoutpic.jpg"));
            searchTerms.Add(new SearchTermModel("Nature", "See posts about nature!", "img/naturepic.jpg"));
            searchTerms.Add(new SearchTermModel("Sports", "See posts about sports!", "img/sportspic.jpg"));
            searchTerms.Add(new SearchTermModel("Food", "See posts about food!", "img/foodpic.jpg"));
            searchTerms.Add(new SearchTermModel("Other", "See posts about all other topics!", "img/otherpic.jpg"));

            return View(searchTerms);
        }

        public IActionResult Filter(string categories)
        {
            // Redirect to the appropriate category action method based on selected categories
            if (categories.Contains("Family"))
            {
                return RedirectToAction("Family", new { categories = categories });
            }
            else if (categories.Contains("Friends"))
            {
                return RedirectToAction("Friends", new { categories = categories });
            }
            else if (categories.Contains("Nature"))
            {
                return RedirectToAction("Nature", new { categories = categories });
            }
            else if (categories.Contains("Sports"))
            {
                return RedirectToAction("Sports", new { categories = categories });
            }
            else if (categories.Contains("Food"))
            {
                return RedirectToAction("Food", new { categories = categories });
            }
            else if (categories.Contains("Other"))
            {
                return RedirectToAction("Other", new { categories = categories });
            }

            // If no categories are selected, you can handle it as desired (e.g., return an error view)
            return RedirectToAction("NoSearchTerms");
        }

        public IActionResult Family(string categories)
        {
            List<PostModel> filteredPosts = _postDAO.GetAll()
                .Where(p => categories.Contains(p.Category.ToString()))
                .ToList();

            return View(filteredPosts);
        }
        public IActionResult Friends(string categories)
        {
            List<PostModel> filteredPosts = _postDAO.GetAll()
                .Where(p => categories.Contains(p.Category.ToString()))
                .ToList();

            return View(filteredPosts);
        }
        public IActionResult Nature(string categories)
        {
            List<PostModel> filteredPosts = _postDAO.GetAll()
                .Where(p => categories.Contains(p.Category.ToString()))
                .ToList();

            return View(filteredPosts);
        }
        public IActionResult Sports(string categories)
        {
            List<PostModel> filteredPosts = _postDAO.GetAll()
                .Where(p => categories.Contains(p.Category.ToString()))
                .ToList();

            return View(filteredPosts);
        }
        public IActionResult Food(string categories)
        {
            List<PostModel> filteredPosts = _postDAO.GetAll()
                .Where(p => categories.Contains(p.Category.ToString()))
                .ToList();

            return View(filteredPosts);
        }
        public IActionResult Other(string categories)
        {
            List<PostModel> filteredPosts = _postDAO.GetAll()
                .Where(p => categories.Contains(p.Category.ToString()))
                .ToList();

            return View(filteredPosts);
        }
    }
}


  

