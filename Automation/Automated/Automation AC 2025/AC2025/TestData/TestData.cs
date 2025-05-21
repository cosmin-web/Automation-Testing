using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC2025.TestData
{
    public static class TestData
    {
        public const string BaseUrl = "https://automationexercise.com/";

        public static User NewUniqueUser()
        {
            var unique = DateTime.Now.Ticks.ToString();
            return new User
            {
                Name = "TestUser" + unique,
                Email = $"test{unique}@example.com",
                Password = "Password123",
                FirstName = "Test",
                LastName = "User",
                Address1 = "123 Street",
                Country = "Canada",
                State = "Ontario",
                City = "Toronto",
                ZipCode = "12345",
                Mobile = "1234567890",
                BirthDay = "10",
                BirthMonth = "5",
                BirthYear = "1990"
            };
        }

        public static readonly User ExistingUser = new User
        {
            Name = Resource1.username,
            Email = Resource1.email,
            Password = Resource1.password,
            CardNumber = Resource1.CardNumber,
            CardCVC = Resource1.CardCVC,
            CardMonth = Resource1.CardMonth,
            CardYear = Resource1.CardYear
        };

        public static readonly Review ReviewData = new Review
        {
            ProductName = "Pure Cotton Neon Green Tshirt",
            ReviewerName = "Vasile Popescu",
            ReviewerEmail = "vasile.popescu@test.com",
            Text = "Foarte comfortabil si de calitate!"
        };
    }

    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Mobile { get; set; }
        public string BirthDay { get; set; }
        public string BirthMonth { get; set; }
        public string BirthYear { get; set; }
        public string CardNumber { get; set; }
        public string CardCVC { get; set; }
        public string CardMonth { get; set; }
        public string CardYear { get; set; }
    }

    public class Review
    {
        public string ProductName { get; set; }
        public string ReviewerName { get; set; }
        public string ReviewerEmail { get; set; }
        public string Text { get; set; }
    }
}
