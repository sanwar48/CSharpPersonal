namespace Learningproject.Models
{
    public interface ILearningprojectDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string UsercollectionName { get; set; }
    }
}
