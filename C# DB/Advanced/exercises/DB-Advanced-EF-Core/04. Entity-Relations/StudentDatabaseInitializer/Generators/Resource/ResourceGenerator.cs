

namespace P01_StudentDatabaseInitializer.Generators.Resource
{
    using P01_StudentSystem.Data;
    using P01_StudentSystem.Data.Models;
    using System;
    using System.Linq;

    public class ResourceGenerator
    {
        internal static Resource NewResource(StudentSystemContext context)
        {
            Random rnd = new Random();

            int[] allCourseIds = context.Courses.Select(c => c.CourseId).ToArray();
            int courseId = allCourseIds[rnd.Next(0, allCourseIds.Length)];

            ResourceType[] types = new ResourceType[] { ResourceType.Document, ResourceType.Other, ResourceType.Presentation, ResourceType.Video };
            ResourceType resourceType = types[rnd.Next(0, types.Length)];

            var resource = new Resource()
            {
                Name = ResourceNameGenerator.GenerateName(),
                Url = UrlGenerator.GenerateUrl(),
                ResourceType = resourceType,
                CourseId = courseId
            };

            return resource;
        }
    }
}
