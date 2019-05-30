// Copyright (c) Paul Bentley 2019. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project root for full license information.

namespace EnsuredOutcomes
{
    /// <summary>
    /// A result wrapper indicating the outcome of an operation.
    /// </summary>
    public class Outcome : OutcomeBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Outcome"/> class.
        /// </summary>
        protected Outcome()
            : base(false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Outcome"/> class with the given success flag.
        /// </summary>
        /// <param name="success">A value indicating the outcome of the operation.</param>
        protected Outcome(bool success)
            : base(success)
        {
        }
    }
}
