// Copyright (c) Paul Bentley 2019. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project root for full license information.

namespace EnsuredOutcomes
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Represents errors that occur during an operation.
    /// </summary>
    [Serializable]
    public class OutcomeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OutcomeException"/> class.
        /// </summary>
        public OutcomeException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutcomeException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public OutcomeException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutcomeException"/> class with a specified error
        /// message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference
        /// (Nothing in Visual Basic) if no inner exception is specified.</param>
        public OutcomeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutcomeException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized
        ///  object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information
        /// about the source or destination.</param>
        protected OutcomeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
