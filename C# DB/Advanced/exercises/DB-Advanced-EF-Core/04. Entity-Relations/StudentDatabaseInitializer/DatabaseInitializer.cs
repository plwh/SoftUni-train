namespace P01_StudentDatabase.Initalizer
{
    using P01_StudentSystem.Data;
    using P01_StudentDatabase.Generators.Student;
    using P01_StudentDatabaseInitializer.Generators.Course;
    using P01_StudentDatabaseInitializer.Generators.Resource;
    using P01_StudentDatabaseInitializer.Generators.StudentCourse;
    using System.Linq;
    using System.Collections.Generic;
    using P01_StudentDatabaseInitializer.Generators.Homework;

    public class DatabaseInitializer
    {
        public static void SeedStudent(StudentSystemContext context, int count)
        {
            for (int i = 0; i < count; i++)
            {
                context.Students.Add(StudentGenerator.NewStudent());
            }

            context.SaveChanges();
        }

        public static void SeedCourse(StudentSystemContext context, int count)
        {
            for (int i = 0; i < count; i++)
            {
                context.Courses.Add(CourseGenerator.NewCourse());
            }

            context.SaveChanges();
        }

        public static void SeedResources(StudentSystemContext context, int count)
        {
            for (int i = 0; i < count; i++)
            {
                context.Resources.Add(ResourceGenerator.NewResource(context));
            }

            context.SaveChanges();
        }

        public static void SeedStudentCourse(StudentSystemContext context, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var studentCourseToAdd = StudentCourseGenerator.NewCourse(context);

                if (i == 0)
                {
                    context.StudentCourses.Add(studentCourseToAdd);
                    context.SaveChanges();
                    continue;
                }

                int targetStudentId = studentCourseToAdd.StudentId;
                int targetCourseId = studentCourseToAdd.CourseId;

                var element = context.StudentCourses.SingleOrDefault(x => x.StudentId == targetStudentId && x.CourseId == targetCourseId);

                if (element == null)
                {
                    context.StudentCourses.Add(studentCourseToAdd);
                    context.SaveChanges();
                }
            }
        }

        public static void SeedHomework(StudentSystemContext context, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var homeworkToAdd = HomeworkGenerator.NewHomework(context);

                context.HomeworkSubmissions.Add(homeworkToAdd);

                context.SaveChanges();
            }
        }
    }
}
