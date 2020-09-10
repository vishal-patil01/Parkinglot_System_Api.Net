// <copyright file="VehiclesCategory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApplicationModelLayer
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Vehicles Model For Vehicle table.
    /// </summary>
    public class VehiclesCategory
    {
        /// <summary>
        /// Gets or sets Vehicle id.
        /// </summary>
        public int VehicleId { get; set; }

        /// <summary>
        /// Gets or sets Vehicle types.
        /// </summary>
        [Required(ErrorMessage = "Vehicle type is required")]
        [RegularExpression(@"^[0-9]{1,}$", ErrorMessage = "Please enter a valid Vehicle type")]
        public int VehicleType { get; set; }

        /// <summary>
        /// Gets or sets vehicle charges.
        /// </summary>
        [Required]
        public string VehicleCharge { get; set; }
    }
}
