namespace EAD_WEB_API_Y4_S1.Models
{
    public class TrainScheduleStoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string TrainScheduleCollectionName { get; set; } = null!;
    }
}
