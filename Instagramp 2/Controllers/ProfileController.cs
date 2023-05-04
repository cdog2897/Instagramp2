using System.Text;
using ClassLibrary;
using Instagramp_2.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Instagramp_2.Controllers
{
    public class ProfileController : Controller
    {
        PostDAO repo = new PostDAO();
        public IActionResult Index()
        {

            return View(repo.GetAll());
        }
        public IActionResult UploadImage()
        {
            return View("Upload");
        }

        public IActionResult PostSuccess(PostModel post)
        {
            // convert image to bits:
            //string imgRef = post.ImgURL;
            //byte[] imageBytes = System.IO.File.ReadAllBytes(post.ImgURL);
            //post.ImgURL = imageBytes.ToString();
            //Console.WriteLine(imageBytes.ToString());
            repo.Create(post);

            // delete local file
            //System.IO.File.Delete(imgRef);
            List<PostModel> allPosts = repo.GetAll();
            return View("Index", allPosts);
        }

        [HttpPost]
        public async Task<IActionResult> ProcessUpload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("", "Please select a file to upload.");
                return View();
            }

            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            ViewBag.Message = "File uploaded successfully.";



            byte[] imageBytes = System.IO.File.ReadAllBytes(filePath);
            string stringBytes = Convert.ToBase64String(imageBytes);
            ViewBag.FilePath = stringBytes;
            //Console.WriteLine(stringBytes);
            //ViewBag.FilePath = $"/uploads/{fileName}";
            System.IO.File.Delete(filePath);
            return View("AddPost");
        }

        public IActionResult AddPost()
        {
            return View();
        }
    }
}
