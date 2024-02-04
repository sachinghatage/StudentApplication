using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using StudentApplication.Model;

namespace StudentApplication.Pages.Student
{
    public class GetModel : PageModel
    {
        private readonly IConfiguration configuration;
       

        public GetModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public Students Student { get; set; }
        public void OnGet()
        {
            DataAccessLayer dal = new DataAccessLayer();
            Student = dal.GetStudent(Id, configuration);
        }

       
    }
}
