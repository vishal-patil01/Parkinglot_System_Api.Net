// <copyright file="MSMQService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApplicationServiceLayer
{
    using System;
    using System.IO;
    using Experimental.System.Messaging;

    /// <summary>
    /// Service Layer for Owner.
    /// </summary>
    public class MSMQService : IMSMQService
    {
        private readonly MessageQueue messageQueue = new MessageQueue();

        public MSMQService()
        {
            this.messageQueue.Path = @".\private$\parkingbills";

            if (MessageQueue.Exists(this.messageQueue.Path))
            {
            }
            else
            {
                // Creates the new queue named "Bills"
                MessageQueue.Create(this.messageQueue.Path);
            }
        }

        /// <summary>
        /// Method to add message to MSMQ.
        /// </summary>
        /// <param name="message">Message Text.</param>
        public void AddToQueue(string message)
        {
            this.messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });

            this.messageQueue.ReceiveCompleted += this.ReceiveFromQueue;

            this.messageQueue.Send(message);

            this.messageQueue.BeginReceive();

            this.messageQueue.Close();
        }

        /// <summary>
        /// Method to fetch message from MSMQ.
        /// </summary>
        /// <param name="sender">Object data.</param>
        /// <param name="eventArgs">ReceiveCompletedArgs Object.</param>
        public void ReceiveFromQueue(object sender, ReceiveCompletedEventArgs eventArgs)
        {
            try
            {
                var msg = this.messageQueue.EndReceive(eventArgs.AsyncResult);

                string data = msg.Body.ToString();

                //// Process the logic be sending the message
                using (StreamWriter file = new StreamWriter(Directory.GetCurrentDirectory() + @"\ParkingRecords.txt", true))
                {
                    file.WriteLine(data);
                }
                //// Restart the asynchronous receive operation.
                this.messageQueue.BeginReceive();
            }
            catch (MessageQueueException qexception)
            {
                Console.WriteLine(qexception);
            }
        }
    }
}
