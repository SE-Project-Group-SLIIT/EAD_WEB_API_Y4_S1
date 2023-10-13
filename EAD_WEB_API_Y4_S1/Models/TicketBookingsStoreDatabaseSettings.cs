////////////////////////////////////////////////////////////////////////////////////////////////////////

//FileName: TicketBookingStoreDatabase.cs

//FileType: Visual C# Source file

//Author : Madiwilage I.E

//Created On : 2/10/20123 9:56:39 AM

//Last Modified On :  13/10/20123 10:53:23 AM

//Copy Rights : N/A

//Description : TicketBooking class for model

////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace EAD_WEB_API_Y4_S1.Models
{
    public class TicketBookingsStoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string TrainBookingCollectionName { get; set; } = null!;
    }
}
