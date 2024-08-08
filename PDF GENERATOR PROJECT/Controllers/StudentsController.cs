using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using PDF_GENERATOR_PROJECT.DTOs.Students;
using PDF_GENERATOR_PROJECT.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SelectPdf;

namespace PDF_GENERATOR_PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepo _studentRepo;
        private readonly IRazorViewEngine _razorViewEngine;
        private readonly ITempDataProvider _tempDataProvider;
        public StudentsController(IStudentRepo studentRepo,IRazorViewEngine razorViewEngine,ITempDataProvider tempDataProvider)
        {
             _studentRepo=studentRepo;
            _razorViewEngine = razorViewEngine;
            _tempDataProvider=tempDataProvider;
        }
        [HttpGet]
        [Route("Get all students")]
        public async Task<IActionResult> GetallStudents()
        {
            var allstudents = await _studentRepo.GetAllStudentsAsync();
            if (allstudents == null)
            {
                return NotFound("No students found");
            }
            return Ok(allstudents);
        }

        [HttpPost]
        [Route("Register student")]
        public async Task<IActionResult> RegisterStudent(CreateStudentsDTO create)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var register =await _studentRepo.RegisterStudentsAsync(create);
            if (register == null)
            {
                return BadRequest("please fields cannot be empty");
            }
            return Ok(register);
        }


        [HttpGet]
        [Route("CONVERT HTML TO PDF")]
        public async Task<IActionResult> PrintPDF()
        {

            var students = await _studentRepo.GetAllStudentsAsync();
            if (students == null)
            {
                return NotFound("No students found");
            }
            try
            {
                var htmlContent = await RenderViewToStringAsync("StudentsInfo", students);

                var converter = new HtmlToPdf();
                PdfDocument pdfDocument = null;

               //the below configures the page settings for the pdf 
                converter.Options.PdfPageSize = PdfPageSize.A4;
                converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
                converter.Options.MarginLeft = 30;
                converter.Options.MarginRight = 10;
                converter.Options.MarginTop = 20;
                converter.Options.MarginBottom = 20;

                pdfDocument = converter.ConvertHtmlString(htmlContent);

                byte[] pdf = pdfDocument.Save();
                  pdfDocument.Close();
               


                return File(pdf, "application/pdf", "ConvertedfromHtml1.pdf");
            }
           catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private async Task<string> RenderViewToStringAsync(string viewName, object model)
        {
            var actionContext = new ActionContext(HttpContext, RouteData, ControllerContext.ActionDescriptor);
            using (var sw = new StringWriter())
            {
                var viewResult = _razorViewEngine.FindView(actionContext, viewName, false);
                if (viewResult.View == null)
                {
                    throw new ArgumentNullException($"{viewName} does not match any available view");
                }

                var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = model
                };

                var viewContext = new ViewContext(
                    actionContext,
                    viewResult.View,
                    viewDictionary,
                    new TempDataDictionary(actionContext.HttpContext, _tempDataProvider),
                    sw,
                    new HtmlHelperOptions()
                );

                await viewResult.View.RenderAsync(viewContext);
                return sw.ToString();
            }
        }

        public static string GetPath()
        {
            return Directory.GetCurrentDirectory() + "/ConvertedfromHtml.pdf";
        }

    }
}
