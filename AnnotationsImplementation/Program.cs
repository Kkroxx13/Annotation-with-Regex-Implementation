using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AnnotationsImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            Author author = new Author();
            Console.WriteLine("Enter First Name");
            author.FirstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            author.LastName = Console.ReadLine();
            Console.WriteLine("Enter Phone Number #");
            author.PhoneNumber = Console.ReadLine();


            ValidationContext context = new ValidationContext(author, null, null);
            List<ValidationResult> validationResults = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(author, context, validationResults,true);
            if (!valid)
            {
                foreach(ValidationResult validationResult in validationResults)
                {
                    Console.WriteLine("{0}",validationResult.ErrorMessage);
                }
            }
            else
            {
                Console.WriteLine("First Name :"+author.FirstName);
                Console.WriteLine("Last Name :" + author.LastName);
                Console.WriteLine("Phone Number :" + author.PhoneNumber);

            }
            Console.ReadKey();
        }
    }

    public class Author
    {
        [Required(ErrorMessage ="{0} is required" )]
        [StringLength(50, MinimumLength = 3, ErrorMessage="FirstName should be minimum 3 characters and maximum 50 characters")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Z]{1}[a-z]$",ErrorMessage ="The first letter of the name should be capital")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "FirstName should be minimum 3 characters and maximum 50 characters")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Z]{1}[a-z]$", ErrorMessage = "The first letter of the lastname should be capital")]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Phone]
        [StringLength(10)]
        public string PhoneNumber { get; set; }
    }
}
