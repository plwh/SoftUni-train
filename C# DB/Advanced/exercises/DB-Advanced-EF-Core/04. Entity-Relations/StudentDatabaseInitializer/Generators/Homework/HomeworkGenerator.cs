namespace P01_StudentDatabaseInitializer.Generators.Homework
{
    using P01_StudentSystem.Data;
    using P01_StudentSystem.Data.Models;
    using System;
    using System.Linq;

    public class HomeworkGenerator
    {
        internal static Homework NewHomework(StudentSystemContext context)
        {
            Random rnd = new Random();

            ContentType[] types = new ContentType[] { ContentType.Application, ContentType.Pdf, ContentType.Zip };
            ContentType contentType = types[rnd.Next(0, types.Length)];

            int[] allStudentsIds = context.Students.Select(s => s.StudentId).ToArray();
            int[] allCoursesIds = context.Courses.Select(c => c.CourseId).ToArray();

            int studentId = allStudentsIds[rnd.Next(0, allStudentsIds.Length)];
            int courseId = allCoursesIds[rnd.Next(0, allCoursesIds.Length)];

            var homework = new Homework()
            {
                Content = null,
                ContentType = contentType,
                SubmissionTime = null,
                StudentId = studentId,
                CourseId = courseId,
            };

            return homework;
        }
    }
}
