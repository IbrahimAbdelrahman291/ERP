using System.ComponentModel.DataAnnotations;

namespace EPR.ViewModel
{
    public class EmployeeViewModel
    {

        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Name { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
 
    }
}
