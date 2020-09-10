// <copyright file="ParkingType.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApplicationModelLayer
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Model Class For ParkingType.
    /// </summary>
    public class ParkingType
    {
        /// <summary>
        /// Gets or sets parking Type ID.
        /// </summary>
        public int ParkingTypeId { get; set; }

        /// <summary>
        /// Gets or sets Parking Types.
        /// </summary>
        [Required(ErrorMessage = "Parking type is required")]
        [RegularExpression(@"^[0-9]{1,}$", ErrorMessage = "Please enter a valid parking type")]
        public int ParkingTypes { get; set; }

        /// <summary>
        /// Gets or sets Parking charges.
        /// </summary>
        [Required]
        public int ParkingCharge { get; set; }
    }
}
