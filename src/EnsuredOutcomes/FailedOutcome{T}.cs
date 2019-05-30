// Copyright (c) Paul Bentley 2019. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project root for full license information.

namespace EnsuredOutcomes
{
    using System;

    /// <summary>
    /// A result wrapper indicating the failed outcome of an operation.
    /// </summary>
    /// <typeparam name="T">The type of object returned by the operation.</typeparam>
    public class FailedOutcome<T> : Outcome<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailedOutcome{T}"/> class.
        /// </summary>
        /// <param name="errors">Any errors which occurred during the operation.</param>
        protected internal FailedOutcome(params Exception[] errors)
            : base(true, default)
        {
            WithError(errors);
        }

        /// <summary>
        /// Adds the given errors to the outcome.
        /// </summary>
        /// <param name="error">The errors.</param>
        /// <returns>The current instance.</returns>
        public FailedOutcome<T> WithError(params Exception[] error)
        {
            AddError(error);
            return this;
        }

        /// <summary>
        /// Adds the given errors to the outcome.
        /// </summary>
        /// <param name="error">The errors.</param>
        /// <returns>The current instance.</returns>
        public FailedOutcome<T> WithError(params string[] error)
        {
            AddError(error);
            return this;
        }
    }
}
