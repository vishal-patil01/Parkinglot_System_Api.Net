// <copyright file="Parking.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApplicationModelLayer
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Model Class For ParkingType.
    /// </summary>
    public class Parking
    {
        /// <summary>
        /// Gets or sets parking Type ID.
        /// </summary>
        public int ParkingId { get; set; }

        /// <summary>
        /// Gets or sets Parking charges.
        /// </summary>
        public int ParkingCharge { get; set; }

        /// <summary>
        /// Gets or sets vehicle Number.
        /// </summary>
        [Required]
        public string VehicleNumber { get; set; }

        /// <summary>
        /// Gets or sets Parking Type.
        /// </summary>
        [Required(ErrorMessage = "Parking type is required")]
        [RegularExpression(@"^[0-9]{1,}$", ErrorMessage = "Please enter a valid parking type")]
        public int ParkingType { get; set; }

        /// <summary>
        /// Gets or sets Driver Type.
        /// </summary>
        [Required(ErrorMessage = "Driver type is required")]
        [RegularExpression(@"^[0-9]{1,}$", ErrorMessage = "Please enter a valid driver type")]
        public int DriverType { get; set; }

        /// <summary>
        /// Gets or sets Vehicle Type.
        /// </summary>
        [Required(ErrorMessage = "Vehicle type is required")]
        [RegularExpression(@"^[0-9]{1,}$", ErrorMessage = "Please enter a valid vehicle type")]
        public int VehicleType { get; set; }

        /// <summary>
        /// Gets or sets EntryTime.
        /// </summary>
        [Required]
        public string EntryTime { get; set; }

        /// <summary>
        /// Gets or sets ExitTime.
        /// </summary>
        public string ExitTime { get; set; }

        /// <summary>
        /// Gets or sets SlotId.
        /// </summary>
        [Required]
        public int SlotId { get; set; }
    }
}
