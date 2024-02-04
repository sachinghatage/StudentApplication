using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentApplication.Model;

namespace StudentApplication.Pages.Student
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration configuration;
        public List<Students> listStudents = new List<Students>();

        public IndexModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void OnGet()
        {
            DataAccessLayer dal = new DataAccessLayer();
            listStudents = dal.getStudents(configuration);
        }
    }
}
