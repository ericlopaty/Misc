using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;

namespace FluentValidationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var emp = new Employee();
            emp.FirstName = "Eric";
            emp.LastName = "Lopaty";
            emp.DOB = new DateTime(1961, 3, 30);
            emp.HireDate = new DateTime(2014, 6, 16);
            emp.Salary = 0;
            var validator = new EmployeeValidator();
            var result = validator.Validate(emp);
            if (result.IsValid)
                Console.WriteLine("Valid");
            else
                foreach (var failure in result.Errors)
                    Console.WriteLine("Property {0} failed: {1}", failure.PropertyName, failure.ErrorMessage);
            Console.Write("Press ENTER");
            Console.ReadLine();
        }
    }

    // {PropertyName}, {PropertyValue}, {ComparisonValue}, {MinLength}, {MaxLength}, {TotalLength}

    class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(employee => employee.FirstName)
                .NotNull()
                .NotEmpty()
                .Length(1, 20)
                .NotEqual("Last")
                .WithMessage("FirstName must be 1-20 chars.");

            RuleFor(employee => employee.HireDate)
                .GreaterThan(employee => employee.DOB)
                .WithMessage("HireDate must be after BirthDate.");

            RuleFor(employee => employee.LastName)
                .Must(lastName => "Lopaty".Equals(lastName))
                .WithMessage("{PropertyName} must be 'Lopaty'.");

            RuleFor(employee => employee.LastName)
                .Must((employee, lastName) => lastName != employee.FirstName);

            RuleFor(employee => employee.Salary)
                .GreaterThan(0)
                .When(employee => employee.LastName.Equals("Lopaty"))
                .Unless(employee => employee.DOB.Year == 1961);
        }
    }

    class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime DOB { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public decimal Salary { get; set; }
    }
}
