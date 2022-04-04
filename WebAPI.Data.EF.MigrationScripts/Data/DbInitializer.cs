using System;
using System.Linq;
using WebAPI.Data.EF.Models;

namespace WebAPI.Data.EF.MigrationScripts
{
    public static class DbInitializer
    {
        public static void Initialize(EmployeeMigrationContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Employees.Any())
            {
                var employees = new EmployeeDataModel[]
                {
                    new EmployeeDataModel{FirstName="Carlos",LastName="Jones",BirthDate=DateTime.Parse("01/01/1980")},
                    new EmployeeDataModel{FirstName="Charlie",LastName="Jones",BirthDate=DateTime.Parse("01/02/1980")},
                    new EmployeeDataModel{FirstName="John",LastName="Charles",BirthDate=DateTime.Parse("01/03/1980")},
                    new EmployeeDataModel{FirstName="John",LastName="Carlos",BirthDate=DateTime.Parse("01/04/1980")},
                    new EmployeeDataModel{FirstName="John'Charly",LastName="Thompson",BirthDate=DateTime.Parse("01/05/1980")},
                    new EmployeeDataModel{FirstName="Michael",LastName="Jordan",BirthDate=DateTime.Parse("02/17/1963")},
                    new EmployeeDataModel{FirstName="Peter",LastName="Charles",BirthDate=DateTime.Parse("01/07/1980")},
                    new EmployeeDataModel{FirstName="Michael",LastName="Jackson",BirthDate=DateTime.Parse("08/29/1958")},
                    new EmployeeDataModel{FirstName="Michael",LastName="Tyson",BirthDate=DateTime.Parse("06/30/1966")},
                };

                foreach (var employee in employees)
                {
                    context.Employees.Add(employee);
                }
                context.SaveChanges();
            }

            if (!context.PhoneNumber.Any())
            {
                var phoneNumbers = new PhoneNumberDataModel[]
                {

                    new PhoneNumberDataModel{EmployeeId=1,PhoneNumber="(555) 555-5555", IsActive=true},
                    new PhoneNumberDataModel{EmployeeId=2,PhoneNumber="(555) 555-5555", IsActive=true},
                    new PhoneNumberDataModel{EmployeeId=3,PhoneNumber="(555) 555-5555", IsActive=true},
                    new PhoneNumberDataModel{EmployeeId=4,PhoneNumber="(555) 555-5555", IsActive=true},
                    new PhoneNumberDataModel{EmployeeId=5,PhoneNumber="(555) 555-5555", IsActive=true},
                    new PhoneNumberDataModel{EmployeeId=6,PhoneNumber="(555) 555-5555", IsActive=true},
                    new PhoneNumberDataModel{EmployeeId=7,PhoneNumber="(555) 555-5555", IsActive=true}
                };
                foreach (var phoneNumber in phoneNumbers)
                {
                    context.PhoneNumber.Add(phoneNumber);
                }
                context.SaveChanges();
            }

            if (!context.Addresses.Any())
            {
                var addresses = new AddressDataModel[]
                {
                    new AddressDataModel{EmployeeId=1, Address="123 Main St.", ZipCode="99999", IsActive=true, City="Fictional City", State="Texas", Country="United States"},
                    new AddressDataModel{EmployeeId=2, Address="123 Main St.", ZipCode="99999", IsActive=true, City="Fictional City", State="Texas", Country="United States"},
                    new AddressDataModel{EmployeeId=3, Address="123 Main St.", ZipCode="99999", IsActive=true, City="Fictional City", State="Texas", Country="United States"},
                    new AddressDataModel{EmployeeId=4, Address="123 Main St.", ZipCode="99999", IsActive=true, City="Fictional City", State="Texas", Country="United States"},
                    new AddressDataModel{EmployeeId=5, Address="123 Main St.", ZipCode="99999", IsActive=true, City="Fictional City", State="Texas", Country="United States"},
                    new AddressDataModel{EmployeeId=6, Address="123 Main St.", ZipCode="99999", IsActive=true, City="Fictional City", State="Texas", Country="United States"},
                    new AddressDataModel{EmployeeId=7, Address="123 Main St.", ZipCode="99999", IsActive=true, City="Fictional City", State="Texas", Country="United States"},
                    new AddressDataModel{EmployeeId=8, Address="123 Main St.", ZipCode="99999", IsActive=true, City="Fictional City", State="Texas", Country="United States"},
                };
                foreach (var address in addresses)
                {
                    context.Addresses.Add(address);
                }
                context.SaveChanges();
            }
        }
    }
}
