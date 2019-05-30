// Copyright (c) Paul Bentley 2019. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project root for full license information.

namespace EnsuredOutcomes
{
    /// <summary>
    /// A result wrapper indicating the successful outcome of an operation.
    /// </summary>
    public class SuccessfulOutcome : Outcome
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SuccessfulOutcome"/> class.
        /// </summary>
        protected internal SuccessfulOutcome()
            : base(true)
        {
        }
    }
}
