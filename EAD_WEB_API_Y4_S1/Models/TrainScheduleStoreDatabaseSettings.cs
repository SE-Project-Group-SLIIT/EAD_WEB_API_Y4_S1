////////////////////////////////////////////////////////////////////////////////////////////////////////

//FileName: TrainScheduleStoreDatabaseSettings.cs

//FileType: Visual C# Source file

//Author : J.A.M.G.Jayakody

//Created On : 8/8/2023 9:56:39 AM

//Last Modified On : 10/13/2023 15:26:23 PM

//Copy Rights : N/A

//Description : Class controller for defining database related functions

////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace EAD_WEB_API_Y4_S1.Models
{
    public class TrainScheduleStoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string TrainScheduleCollectionName { get; set; } = null!;
    }
}
