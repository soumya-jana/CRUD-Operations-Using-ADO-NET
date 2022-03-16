using System.ComponentModel.DataAnnotations;

namespace CRUD_ADO_NET.Models
{
    public class Customer
    {
        [Key]
        [Display(Name ="ID")]
        public int CustomerID { get; set; }


        [Required(ErrorMessage ="Please enter your name.")]
        [Display(Name = "Name")]
        public string CustomerName { get; set; }


        [Required(ErrorMessage ="Please enter your email address.")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Invalid email address.")]
        [Display(Name = "Email")]
        public string CustomerEmail { get; set; }



        [Display(Name = "Gender")]
        public string CustomerGender { get; set; }




        [Display(Name = "DOB")]
        public string CustomerDOB { get; set; }



        [Required(ErrorMessage = "Please enter your phone no.")]
        [RegularExpression("\\+[0-9]{2}\\s+[0-9]{5}\\s+[0-9]{5}", ErrorMessage = "Please enter correct phone no.")]
        [Display(Name = "Phone")]
        public string CustomerPhone { get; set; }




        [Display(Name = "Survey")]
        public string CustomerSurvey { get; set; }


    }
}
