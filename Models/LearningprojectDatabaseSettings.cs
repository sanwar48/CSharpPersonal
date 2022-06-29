namespace Learningproject.Models
{
    public class LearningprojectDatabaseSettings : ILearningprojectDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; }= null!;
        public string UsercollectionName { get; set; } = null!;
    }
}
