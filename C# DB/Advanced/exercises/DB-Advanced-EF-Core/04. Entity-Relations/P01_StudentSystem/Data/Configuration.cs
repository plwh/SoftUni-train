namespace P01_StudentSystem.Data
{
    public class Configuration
    {
        public static string ConnectionString { get; set; } = @"Server=(localdb)\v12.0;Database={0};Integrated Security=True;";
    }
}
