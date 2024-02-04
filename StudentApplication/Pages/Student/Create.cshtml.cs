using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentApplication.Model;

namespace StudentApplication.Pages.Student
{
    public class CreateModel : PageModel
    {
       
        public Students students = new Students();
    
        public string successMessage = string.Empty;
        public string failureMessage = string.Empty;

        private readonly IConfiguration configuration;

        public CreateModel(IConfiguration configuration)
        {

            this.configuration = configuration;

        }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            //student properties
            students.FirstName = Request.Form["FirstName"];
            students.LastName = Request.Form["LastName"];
            students.Email = Request.Form["Email"];
            string selectGender = Request.Form["Gender"];

           

            if (Enum.TryParse(selectGender, out Gender genderEnum)) //converting string format back to enum

            {
                students.SelectGender = genderEnum;
            }
            else
            {
                
                //logger.LogError($"Invalid gender value: {selectGender}");
            }


            



            if (students.FirstName.Length == 0 || students.LastName.Length == 0)
            {
                failureMessage = "All fields are required";
                return;  //to exit block and stop further execution
            }

            try
            {
                DataAccessLayer dal = new DataAccessLayer();
                dal.AddStudent(students,configuration);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                failureMessage = ex.Message;
                return;   
            }

            

            
            Response.Redirect("/Student/Index");
        }
    }
}
