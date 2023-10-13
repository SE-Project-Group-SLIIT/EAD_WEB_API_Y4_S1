////////////////////////////////////////////////////////////////////////////////////////////////////////
// FileName: UserStoreDatabaseSettings.cs
// FileType: C# Source file
// Size: 26206
// Author: Lalitha Maddumage
// Created On: 10/08/2023 9:08:21 AM
// Last Modified On: 10/10/2023 10:28:23 AM
// Copy Rights: N/A
// Description: Configuration class for database connection settings
////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace EAD_WEB_API_Y4_S1.Models
{
    public class UserStoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string UserCollectionName { get; set; } = null!;

    }
}
