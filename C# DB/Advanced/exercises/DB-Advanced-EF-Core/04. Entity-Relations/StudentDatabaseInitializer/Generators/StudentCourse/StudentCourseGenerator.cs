namespace P01_StudentDatabaseInitializer.Generators.StudentCourse
{
    using P01_StudentSystem.Data;
    using P01_StudentSystem.Data.Models;
    using System;
    using System.Linq;

    public class StudentCourseGenerator
    {
        internal static StudentCourse NewCourse(StudentSystemContext context)
        {
            Random rnd = new Random();

            int[] allStudentsIds = context.Students.Select(s => s.StudentId).ToArray();
            int[] allCoursesIds = context.Courses.Select(c => c.CourseId).ToArray();

            int studentId = allStudentsIds[rnd.Next(0, allStudentsIds.Length)];
            int courseId = allCoursesIds[rnd.Next(0, allCoursesIds.Length)];

            var studentCourse = new StudentCourse()
            {
                StudentId = studentId,
                CourseId = courseId
            };

            return studentCourse;
        }
    }
}
