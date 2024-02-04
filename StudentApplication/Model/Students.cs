namespace StudentApplication.Model
{
    public class Students
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Gender SelectGender { get; set; } = Gender.Unknown;//if gender.unknown not specified bydefault it takes zeroth property i.e, male
    }

    public enum Gender
    {
        Male,Female,Unknown
    }

    
   
}
