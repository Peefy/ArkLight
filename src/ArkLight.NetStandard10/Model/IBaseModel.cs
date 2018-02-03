using System;

namespace ArkLight.Model
{
    internal interface IBaseModel
    {
        /// <summary>
        /// Id for item
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Azure created at time stamp
        /// </summary>
        DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Azure UpdateAt timestamp for online/offline sync
        /// </summary>
        DateTimeOffset UpdatedAt { get; set; }

        /// <summary>
        /// Azure version for online/offline sync
        /// </summary>
        string AzureVersion { get; set; }
    }

}
