// <copyright file="UserLogin.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApplicationModelLayer
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Users Model For users Table.
    /// </summary>
    public class UserLogin
    {
        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Password.
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
