using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;

//  https://fluentvalidation.codeplex.com/documentation

namespace FluentValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Console.WriteLine("Validate Customer/Address/Orders, standard validations with embedded object and collection validators");
                var customer = new Customer { Surname = "foo" };
                customer.Address = new Address { Postcode = null };
                customer.Orders = new List<Order>
                {
                    new Order {ProductName = "Foo"},
                    new Order {Cost = 5}
                };
                var customerValidator = new CustomerValidator();
                var customerResult = customerValidator.Validate(customer);
                DumpValidationErrors(customerResult);
                //validator.ValidateAndThrow(customer);

                Console.WriteLine("Validate Person with named RuleSets");
                var person = new Person();
                var personValidator = new PersonValidator();
                var personResult = personValidator.Validate(person, ruleSet: "Names,default");
                DumpValidationErrors(personResult);

                Console.WriteLine("Validate all built-in validators");
                var demo = new DemoObject();
                demo.StringValue1 = "undesired value";
                demo.StringValue4 = "AA";
                demo.StringValue5 = "desired value";
                demo.Email = "foo@bar. com";
                demo.MustTest1 = 11;
                demo.MustTest2 = 10;
                var demoResult = new DemoObjectValidator().Validate(demo);
                DumpValidationErrors(demoResult);

                Console.WriteLine("Testing custom validator");
                var p = new Person();
                p.Pets = new List<Pet>
                {
                    new Pet() {Name = "Fluffy"},new Pet() {Name = "Spike"},new Pet() {Name = "A"},new Pet() {Name = "B"},new Pet() {Name = "C"},new Pet() {Name = "D"},
                    new Pet() {Name = "E"},new Pet() {Name = "F"},new Pet() {Name = "G"},new Pet() {Name = "H"},new Pet() {Name = "I"},new Pet() {Name = "J"},
                };
                var r2 = new PersonValidator2().Validate(p);
                DumpValidationErrors(r2);

            }
            catch (ValidationException vex)
            {
                foreach (var e in vex.Errors)
                    Console.WriteLine("Caught... {0}: {1}", e.PropertyName, e.ErrorMessage);
            }
            catch (Exception)
            {
                throw;
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Display all validation messages
        /// </summary>
        /// <param name="vr"></param>
        private static void DumpValidationErrors(ValidationResult vr)
        {
            Console.WriteLine("Valid: {0}", vr.IsValid);
            if (vr.Errors.Count > 0)
                foreach (var e in vr.Errors)
                    Console.WriteLine("{0}: {1}", e.PropertyName, e.ErrorMessage);
            Console.WriteLine();
        }
    }

    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Surname).NotNull().NotEqual("foo");
            RuleFor(customer => customer.Address).NotNull();
            RuleFor(customer => customer.Address).SetValidator(new AddressValidator());
            RuleFor(customer => customer.Orders).SetCollectionValidator(new OrderValidator())
                .Where(x => x.Cost != null);
        }
    }

    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(address => address.Postcode).NotNull();
        }
    }

    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(x => x.ProductName).NotNull();
            RuleFor(x => x.Cost).GreaterThan(0);
        }
    }

    /// <summary>
    /// Named RuleSets
    /// </summary>
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleSet("Names", () =>
            {
                RuleFor(x => x.Surname).NotNull();
                RuleFor(x => x.Forename).NotNull();
            });

            RuleFor(x => x.Id).NotNull().NotEqual(0);
        }
    }

    /// <summary>
    /// Try out all the built-in validators
    /// </summary>
    public class DemoObjectValidator : AbstractValidator<DemoObject>
    {
        public DemoObjectValidator()
        {
            // null value
            RuleFor(x => x.StringValue1).NotNull();
            // null/zero-length/whitespace
            RuleFor(x => x.StringValue1).NotEmpty();
            // Equal, not Equals
            RuleFor(x => x.StringValue1).Equal("desired value");
            RuleFor(x => x.StringValue1).NotEqual("undesired value");
            // Pass in lambda expression to compare against other properties
            RuleFor(x => x.StringValue1).NotEqual(x => x.OtherStringValue);
            // Length, fixed or range, values are inclusive
            RuleFor(x => x.StringValue1).Length(5);
            RuleFor(x => x.StringValue1).Length(1, 20);
            // Numeric or string comparisons (anything implementing IComparable)
            RuleFor(x => x.NumericValue).LessThan(100);
            RuleFor(x => x.NumericValue).LessThanOrEqualTo(100);
            RuleFor(x => x.NumericValue).LessThan(x => x.OtherNumericValue);
            RuleFor(x => x.NumericValue).GreaterThan(10);
            RuleFor(x => x.NumericValue).GreaterThanOrEqualTo(10);
            RuleFor(x => x.NumericValue).GreaterThan(x => x.OtherNumericValue);
            // Email format
            RuleFor(x => x.Email).EmailAddress();
            // Pass in an expression via a lambda
            RuleFor(x => x.StringValue5).Must(y => "desired value".Equals(y));
            // Multi-property validation
            RuleFor(x => x.MustTest1)
                .Must((parent, x) => x < parent.MustTest2)
                .WithMessage("{PropertyName} is {PropertyValue} which is not less than MustTest2");
            // Regex
            RuleFor(x => x.StringValue4).Matches("[0-9][0-9]").WithMessage("{PropertyName} is not a 2 digit value.");
        }
    }

    /// <summary>
    /// Calling a custom validator
    /// </summary>
    public class PersonValidator2 : AbstractValidator<Person>
    {
        public PersonValidator2()
        {
            RuleFor(person => person.Pets).SetValidator(new ListMustContainFewerThanTenItemsValidator<Pet>());
            RuleFor(person => person.Pets).MustContainFewerThanTenItems();
            // calling a custom validator with an anonymous function.
            Custom(person =>
            {
                return person.Pets.Count >= 10 ? new ValidationFailure("Pets", "More than 9 pets is not allowed") : null;
            });

            RuleFor(person => person.Pets).Must(HaveFewerThanTenPets).WithMessage("You have more than 9 pets");
        }

        private bool HaveFewerThanTenPets(IList<Pet> pets)
        {
            return pets.Count < 10;
        }
    }

    /// <summary>
    /// Custom validator by deriving from PropertyValidator
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListMustContainFewerThanTenItemsValidator<T> : FluentValidation.Validators.PropertyValidator
    {
        public ListMustContainFewerThanTenItemsValidator()
            : base("Property {PropertyName} contains ten or more items!")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var list = context.PropertyValue as IList<T>;
            if (list != null && list.Count >= 10)
            {
                return false;
            }
            return true;
        }
    }

    /// <summary>
    /// Define extension to call custom validator without using SetValidator
    /// </summary>
    public static class MyValidatorExtensions
    {
        public static IRuleBuilderOptions<T, IList<TElement>> MustContainFewerThanTenItems<T, TElement>(this IRuleBuilder<T, IList<TElement>> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new ListMustContainFewerThanTenItemsValidator<TElement>());
        }
    }




    // Class definitions for validation

    public class DemoObject
    {
        public string StringValue1 { get; set; }
        public string StringValue2 { get; set; }
        public string StringValue3 { get; set; }
        public string StringValue4 { get; set; }
        public string StringValue5 { get; set; }
        public string OtherStringValue { get; set; }
        public int NumericValue { get; set; }
        public int OtherNumericValue { get; set; }
        public string Email { get; set; }
        public int MustTest1 { get; set; }
        public int MustTest2 { get; set; }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; }
        public IList<Pet> Pets { get; set; }
    }

    public class Pet
    {
        public string Name { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; }
        public decimal Discount { get; set; }
        public Address Address { get; set; }
        public IList<Order> Orders { get; set; }
    }

    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
    }

    public class Order
    {
        public string ProductName { get; set; }
        public decimal? Cost { get; set; }
    }
}
