// Copyright (c) Paul Bentley 2019. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project root for full license information.

namespace EnsuredOutcomes
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Base class for common properties shared by <see cref="Outcome"/> and <see cref="Outcome{T}"/>.
    /// </summary>
    public abstract class OutcomeBase
    {
        private readonly List<Exception> _errors = new List<Exception>();

        /// <summary>
        /// Initializes a new instance of the <see cref="OutcomeBase"/> class.
        /// </summary>
        protected OutcomeBase()
            : this(false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutcomeBase"/> class with the given success flag.
        /// </summary>
        /// <param name="success">A value indicating the outcome of the operation.</param>
        protected OutcomeBase(bool success)
        {
            Success = success;
        }

        /// <summary>
        /// Gets a value indicating whether the result of the operation was a success.
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// Gets a list of errors raised during the operation.
        /// </summary>
        public IEnumerable<Exception> Errors => _errors;

        /// <summary>
        /// Implicit operator from <see cref="OutcomeBase"/> to a <see cref="bool"/>.
        /// </summary>
        /// <param name="result">The result.</param>
        public static implicit operator bool(OutcomeBase result) => result.ToBoolean();

        /// <summary>
        /// Returns a <see cref="bool"/> representation of the <see cref="Outcome"/>.
        /// </summary>
        /// <returns>A <see cref="bool"/> representation of the <see cref="Outcome"/>.</returns>
        public bool ToBoolean() => Success;

        /// <summary>
        /// Adds the given exceptions to the error list.
        /// </summary>
        /// <param name="errors">The errors to add.</param>
        protected void AddError(params Exception[] errors)
        {
            foreach (var error in errors)
            {
                if (errors != null)
                {
                    _errors.Add(error);
                }
            }
        }

        /// <summary>
        /// Adds the given error messages to the error list.
        /// </summary>
        /// <param name="errors">The errors to add.</param>
        protected void AddError(params string[] errors)
        {
            foreach (var error in errors)
            {
                AddError(new OutcomeException(error));
            }
        }
    }
}
