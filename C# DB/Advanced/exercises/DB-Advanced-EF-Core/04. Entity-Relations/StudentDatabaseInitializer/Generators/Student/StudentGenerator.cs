namespace P01_StudentDatabase.Generators.Student
{
    using P01_StudentSystem.Data.Models;

    public class StudentGenerator
    {
        internal static Student NewStudent()
        {
            var student = new Student()
            {
                Name = StudentNameGenerator.GenerateName(),
                Birthday = DateGenerator.GenerateDate("birthDate"),
                RegisteredOn = DateGenerator.GenerateDate("registrationDate"),
                PhoneNumber = PhoneNumberGenerator.GenerateNumber()
            };

            return student;
        }
    }
}
