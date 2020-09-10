// <copyright file="Users.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApplicationModelLayer
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Users Model For users Table.
    /// </summary>
    public class Users
    {
        /// <summary>
        /// Gets or sets User ID.
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets Roles.
        /// </summary>
        [Required]
        public int Roles { get; set; }

        /// <summary>
        /// Gets or sets Username.
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets Password.
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
