// <copyright file="IMSMQService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApplicationServiceLayer
{
    using Experimental.System.Messaging;

    /// <summary>
    /// Interface for Owner service.
    /// </summary>
    public interface IMSMQService
    {
        /// <summary>
        /// Method to add message to MSMQ.
        /// </summary>
        /// <param name="message"></param>
        void AddToQueue(string message);

        /// <summary>
        /// Method to fetch message from MSMQ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        void ReceiveFromQueue(object sender, ReceiveCompletedEventArgs eventArgs);
    }
}
