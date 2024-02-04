using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using StudentApplication.Model;

namespace StudentApplication.Pages.Student
{
    public class DisplaySingleModel : PageModel
    {

        public DisplaySingleModel(IConfiguration configuration) 
        {
            this.configuration = configuration;
        }
      
        private readonly IConfiguration configuration;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public Students student { get; set; } = new Students();
        public void OnGet()
        {
            if(Id!=null)
            {
                DataAccessLayer dal = new DataAccessLayer();
                student = dal.getStudent(Id, configuration);
            }
            else
            {
                Console.WriteLine("Student  not found with id");
            }
           
        }
    }
}
