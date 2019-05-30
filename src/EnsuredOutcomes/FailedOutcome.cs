// Copyright (c) Paul Bentley 2019. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project root for full license information.

namespace EnsuredOutcomes
{
    using System;

    /// <summary>
    /// A result wrapper indicating an operation which failed.
    /// </summary>
    public class FailedOutcome : Outcome
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailedOutcome"/> class.
        /// </summary>
        /// <param name="error">Any errors which occured during the operation.</param>
        protected internal FailedOutcome(params Exception[] error)
            : base(false)
        {
            AddError(error);
        }

        /// <summary>
        /// Adds the given errors to the outcome.
        /// </summary>
        /// <param name="error">The errors.</param>
        /// <returns>The current instance.</returns>
        public FailedOutcome WithError(params Exception[] error)
        {
            AddError(error);
            return this;
        }

        /// <summary>
        /// Adds the given errors to the outcome.
        /// </summary>
        /// <param name="error">The errors.</param>
        /// <returns>The current instance.</returns>
        public FailedOutcome WithError(params string[] error)
        {
            AddError(error);
            return this;
        }
    }
}
