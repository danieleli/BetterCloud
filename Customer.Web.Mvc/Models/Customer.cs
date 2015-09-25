using System.ComponentModel.DataAnnotations;

namespace Customer.Web.Mvc.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, MinLength(3), Display(Name= "Last Name")]
        public string LastName { get; set; }

        public string Address { get; set; }
        
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }


}