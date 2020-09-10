// <copyright file="ResponseEntity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApplicationModelLayer
{
    using System.Net;

    /// <summary>
    /// Model Class To Generate SMD Format Data.
    /// </summary>
    public class ResponseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseEntity"/> class.
        /// </summary>
        /// <param name="statusCode">Status Code.</param>
        /// <param name="message">Message Text.</param>
        /// <param name="data">Data Object.</param>
        public ResponseEntity(HttpStatusCode statusCode, string message, object data)
        {
            this.StatusCode = statusCode;
            this.Message = message;
            this.Data = data;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseEntity"/> class.
        /// </summary>
        /// <param name="httpStatusCode">Status Code.</param>
        /// <param name="message">Message Text.</param>
        public ResponseEntity(HttpStatusCode httpStatusCode, string message)
        {
            this.StatusCode = httpStatusCode;
            this.Message = message;
        }

        /// <summary>
        /// Gets StatusCode.
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Gets Message.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Gets Data.
        /// </summary>
        public object Data { get; }
    }
}
