// Copyright (c) Paul Bentley 2019. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project root for full license information.

namespace EnsuredOutcomes
{
    using System;

    /// <summary>
    /// A result wrapper indicating the outcome of an operation which returns specific data.
    /// </summary>
    /// <typeparam name="T">The type of data returned.</typeparam>
    public class Outcome<T> : OutcomeBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Outcome{T}"/> class.
        /// </summary>
        /// <param name="success">A value indicating the outcome of the operation.</param>
        /// <param name="value">The value of object returned.</param>
        protected Outcome(bool success, T value)
            : base(success)
        {
            Value = value;
        }

        /// <summary>
        /// Gets or sets the value of the object returned from the operation.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Implicit operator from <see cref="Outcome{T}"/> to a given type.
        /// </summary>
        /// <param name="result">The result.</param>
        public static implicit operator T(Outcome<T> result) => result.ToT();

        /// <summary>
        /// Returns the value of the result.
        /// </summary>
        /// <returns>The value of the result.</returns>
        /// <exception cref="Exception">When the outcome of the operation is a failure.</exception>
        public T ToT() => Value;
    }
}
