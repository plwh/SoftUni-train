namespace StudentStartup
{
    using P01_StudentDatabase.Initalizer;
    using P01_StudentSystem.Data;

    public class StartUp
    {
        static void Main(string[] args)
        {
            using (var context = new StudentSystemContext())
            {
                DatabaseInitializer.SeedStudent(context, 5);
                DatabaseInitializer.SeedCourse(context, 5);
                DatabaseInitializer.SeedResources(context, 5);
                DatabaseInitializer.SeedStudentCourse(context, 5);
                DatabaseInitializer.SeedHomework(context, 5);
            }
        }
    }
}
