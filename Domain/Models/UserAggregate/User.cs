using Domain.Exceptions.ArgumentException;
using Domain.SharedKernel;
using System.Text.RegularExpressions;

namespace Domain.Models.UserAggregate
{
    public class User : Aggregate<Guid>
    {
        private User(){}
        private User(
            string firstName,
            string lastName,
            string patronymic,
            string email,
            string phone,
            int age,
            int weight,
            int height
            ) : this()
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            Email = email;
            Phone = phone;
            Age = age;
            Weight = weight;
            Height = height;
        }

        public string FirstName { get; private set; } = null!;
        public string LastName { get; private set; } = null!;
        public string Patronymic { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string Phone { get; private set; } = null!;
        public int Age { get; private set; }
        public int Weight { get; private set; }
        public int Height { get; private set; }

        public static User Create(
            string firstName,
            string lastName,
            string patronymic,
            string email,
            string phone,
            int age,
            int weight,
            int height)
        {
            ValidateName(firstName);
            ValidateName(lastName);
            ValidateName(patronymic);
            ValidateEmail(email);
            ValidatePhone(phone);
            ValidateAge(age);
            ValidateWeight(weight);
            ValidateHeight(height);

            return new User(
                firstName.Trim(),
                lastName.Trim(),
                patronymic.Trim(),
                email.Trim(),
                phone.Trim(),
                age,
                weight,
                height
                );
        }

        public void UpdateContactInfo(string email, string phone)
        {
            ValidateEmail(email);
            ValidatePhone(phone);
            Email = email.Trim();
            Phone = phone.Trim();
        }

        private static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ValueIsRequiredException($"{nameof(name)} cannot be null");

            if (!Regex.IsMatch(name, @"^[\p{L} \-]+$"))
                throw new ValueIsInvalidException($"{name} содержит недопустимые символы");
        }

        private static void ValidateAge(int age)
        {
            if (age < 18 || age > 49)
                throw new ValueOutOfRangeException($"{nameof(age)} should be between 18 and 49 years");
        }

        private static void ValidateWeight(int weight)
        {
            if (weight < 30 || weight > 300)
                throw new ValueOutOfRangeException($"{nameof(weight)} should be between 30 and 300 kg");
        }

        private static void ValidateHeight(int height)
        {
            if (height < 100 || height > 250)
                throw new ValueOutOfRangeException($"{nameof(height)} should be between 100 and 250 cm");
        }

        private static void ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) 
                throw new ValueIsRequiredException($"{nameof(email)} cannot be null or White space");
            if (!Regex.IsMatch(email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
                throw new ValueIsInvalidException($"{nameof(email)} cannot be invalid or null, email must be this view: someemail@mail.com");
        }

        private static void ValidatePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) 
                throw new ValueIsRequiredException($"{nameof(phone)} cannot be null or White space");
            if (!Regex.IsMatch(phone, @"(^8|7|\+7)((\d{10})|(\s\(\d{3}\)\s\d{3}\s\d{2}\s\d{2}))"))
                throw new ValueIsInvalidException(
                $"{nameof(phone)} cannot be invalid or null, phone must be this view: +79008007060, 79008007060 or 89008007060");
        }
    }
}
