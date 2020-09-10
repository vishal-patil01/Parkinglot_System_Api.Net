// <copyright file="Roles.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApplicationModelLayer
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Roles Model for Roles Table.
    /// </summary>
    public class Roles
    {
        /// <summary>
        /// Gets or sets RoleID.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets Role type.
        /// </summary>
        [Required(ErrorMessage = "Driver type is required")]
        [RegularExpression(@"^[0-9]{1,}$", ErrorMessage = "Please enter a valid driver type")]
        public int RoleType { get; set; }

        /// <summary>
        /// Gets or sets Charge.
        /// </summary>
        [Required]
        public int Charge { get; set; }
    }
}
