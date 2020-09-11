// <copyright file="IUserService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApplicationServiceLayer
{
    using System;
    using System.Collections.Generic;
    using ApplicationModelLayer;

    /// <summary>
    /// Interface for Owner service.
    /// </summary>
    public interface IUserService
    {
        string Login(UserLogin login);
        Boolean AddUser(Users userDetails);
    }
}
