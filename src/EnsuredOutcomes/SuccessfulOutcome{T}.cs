// Copyright (c) Paul Bentley 2019. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project root for full license information.

namespace EnsuredOutcomes
{
    /// <summary>
    /// A result wrapper indicating the successful outcome of an operation.
    /// </summary>
    /// <typeparam name="T">The type of object returned by the operation.</typeparam>
    public sealed class SuccessfulOutcome<T> : Outcome<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SuccessfulOutcome{T}"/> class.
        /// </summary>
        internal SuccessfulOutcome()
            : base(true, default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SuccessfulOutcome{T}"/> class.
        /// </summary>
        /// <param name="value">The value returned by the operation.</param>
        internal SuccessfulOutcome(T value)
            : base(true, value)
        {
        }
    }
}
