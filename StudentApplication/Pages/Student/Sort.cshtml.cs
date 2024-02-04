using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentApplication.Model;
using System.Data.SqlClient;

namespace StudentApplication.Pages.Student
{
    public class SortModel : PageModel
    {
        private readonly IConfiguration configuration;
        public List<Students> students { get; set; }=new List<Students>();

        public SortModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [BindProperty(SupportsGet =true)]   //sorting for ascending or descending
       public string SortOrder { get; set; }
        public List<SelectListItem> SortOrderOptions { get; } = new List<SelectListItem>() 
        {
            new SelectListItem("Ascending","asc"),
            new SelectListItem("Descending","desc")
        };



        [BindProperty(SupportsGet =true)]
        public string SortBy { get; set; }
        public List<SelectListItem> SortByOptions { get; set; } = new List<SelectListItem>() 
        {
            new SelectListItem("ID","Id"),
            new SelectListItem("FirstName","FirstName")
        };





        public void OnGet()
        {
            DataAccessLayer dal=new DataAccessLayer();
            students=dal.getStudents(configuration);

            if(SortOrder == "asc")
            {
                switch (SortBy)
                {
                    case "Id":
                        students=students.OrderBy(s=>s.Id).ToList();
                        break;

                    case "FirstName":
                        students=students.OrderBy(s=>s.FirstName).ToList();
                        break;
                }
            }
            else if(SortOrder=="desc")
            {
                switch (SortBy)
                {
                    case "Id":
                        students = students.OrderByDescending(s => s.Id).ToList();
                        break;


                    case "FirstName":
                        students = students.OrderByDescending(s => s.FirstName).ToList();
                        break;
                }
            }
        }
    }
}
