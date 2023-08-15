using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Cafe_DeTerunjing.Pages
{
    public class UploadImageModel : PageModel
    {
        private readonly ILogger<UploadImageModel> _logger;
        private readonly IHostingEnvironment _environment;

        [BindProperty]
        public IFormFile UploadedFile { get; set; }

        public UploadImageModel(ILogger<UploadImageModel> logger, IHostingEnvironment environment)
        {
            _logger = logger;   
            _environment = environment; 
        }
        public void OnGet()
        {

        }

        public async Task OnPostAsync()
        {
            if (UploadedFile == null || UploadedFile.Length == 0)
            {
                return;
            }
            _logger.LogInformation($"Upload {UploadedFile.FileName}");
            var id = Request.Query["id"];
            string extension = Path.GetExtension(UploadedFile.FileName);
            string newFileName = id + extension;
            string targetFileName = $"{_environment.ContentRootPath}/wwwroot/images/{newFileName}";

            using (var stream = new FileStream(targetFileName, FileMode.Create))
            {
                await UploadedFile.CopyToAsync(stream); 
            }


        }
        
        

    }
}
