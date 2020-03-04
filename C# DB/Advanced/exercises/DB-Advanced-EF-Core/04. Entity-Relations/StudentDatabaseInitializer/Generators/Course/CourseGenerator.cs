namespace P01_StudentDatabaseInitializer.Generators.Course
{
    using P01_StudentDatabase.Generators;
    using P01_StudentSystem.Data.Models;

    public class CourseGenerator
    {
        public static Course NewCourse()
        {
            var course = new Course()
            {
                Name = CourseNameGenerator.GenerateName(),
                Description = DescriptionGenerator.GenerateDescription(),
                StartDate = DateGenerator.GenerateDate("startDate"),
                EndDate = DateGenerator.GenerateDate("endDate"),
                Price = PriceGenerator.GeneratePrice()
            };

            return course;
        }
    }
}
