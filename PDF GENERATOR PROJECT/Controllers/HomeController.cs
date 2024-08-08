using Microsoft.AspNetCore.Mvc;
using PDF_GENERATOR_PROJECT.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace PDF_GENERATOR_PROJECT.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepo _studentRepo;
        private readonly IRazorViewEngine _razorViewEngine;
        private readonly ITempDataProvider _tempDataProvider;


        public HomeController(
            IStudentRepo studentRepo,
            IRazorViewEngine razorViewEngine,
            ITempDataProvider tempDataProvider,
            IServiceProvider serviceProvider)
        {
            _studentRepo = studentRepo;
            _razorViewEngine = razorViewEngine;
            _tempDataProvider = tempDataProvider;

        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentRepo.GetAllStudentsAsync();
            if (students == null)
            {
                return NotFound("No students found");
            }

            return View(students);

        }
        
    }
}
