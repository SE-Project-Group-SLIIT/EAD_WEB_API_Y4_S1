////////////////////////////////////////////////////////////////////////////////////////////////////////

//FileName: TravelerStoreDatabaseSettings.cs

//FileType: Visual C# Source file

//Author : Randika Batawala

//Created On : 8/8/2023 9:56:39 AM

//Last Modified On : 10/13/2023 15:26:23 PM

//Copy Rights : N/A

//Description : Class batabase for defining database related functions

////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace EAD_WEB_API_Y4_S1.Models
{
    public class TravelerStoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string TravelerCollectionName { get; set; } = null!;

    }
}
