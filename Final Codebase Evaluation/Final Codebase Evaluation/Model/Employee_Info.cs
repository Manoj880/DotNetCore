using System.ComponentModel.DataAnnotations;
namespace Final_Codebase_Evaluation.Model
{
    public class Employee_Info
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
    }
}
