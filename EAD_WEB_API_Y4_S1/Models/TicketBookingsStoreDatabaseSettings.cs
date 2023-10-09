namespace EAD_WEB_API_Y4_S1.Models
{
    public class TicketBookingsStoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string TrainBookingCollectionName { get; set; } = null!;
    }
}
