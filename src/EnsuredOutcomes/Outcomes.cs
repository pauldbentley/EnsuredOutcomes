// Copyright (c) Paul Bentley 2019. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project root for full license information.

namespace EnsuredOutcomes
{
    using System;

    /// <summary>
    /// Helper class for creating <see cref="Outcome"/> instances.
    /// </summary>
    public static class Outcomes
    {
        /// <summary>
        /// Creates a successful outcome.
        /// </summary>
        /// <returns>A <see cref="SuccessfulOutcome"/>.</returns>
        public static SuccessfulOutcome Success() => new SuccessfulOutcome();

        /// <summary>
        /// Creates a successful outcome.
        /// </summary>
        /// <typeparam name="T">The type of object returned.</typeparam>
        /// <returns>A <see cref="SuccessfulOutcome{T}"/>.</returns>
        public static SuccessfulOutcome<T> Success<T>() => new SuccessfulOutcome<T>();

        /// <summary>
        /// Creates a successful outcome.
        /// </summary>
        /// <typeparam name="T">The type of object returned.</typeparam>
        /// <param name="value">The object returned.</param>
        /// <returns>A <see cref="SuccessfulOutcome{T}"/> with a value.</returns>
        public static SuccessfulOutcome<T> Success<T>(T value) => new SuccessfulOutcome<T>(value);

        /// <summary>
        /// Creates a failure outcome.
        /// </summary>
        /// <param name="errors">The errors raised during the operation.</param>
        /// <returns>An <see cref="Outcome"/> with the <see cref="OutcomeBase.Success"/> property set to false.</returns>
        public static FailedOutcome Failure(params Exception[] errors) => new FailedOutcome(errors);

        /// <summary>
        /// Creates a failure outcome.
        /// </summary>
        /// <typeparam name="T">The type of object returned.</typeparam>
        /// <param name="errors">The errors raised during the operation.</param>
        /// <returns>An <see cref="Outcome"/> with the <see cref="OutcomeBase.Success"/> property set to false.</returns>
        public static FailedOutcome<T> Failure<T>(params Exception[] errors) => new FailedOutcome<T>(errors);

        /// <summary>
        /// Determines the outcome depending on the instance of an error.
        /// </summary>
        /// <param name="error">An error, if any.</param>
        /// <returns>A <see cref="SuccessfulOutcome"/> if <paramref name="error"/> is null; otherwise a <see cref="FailedOutcome"/>.</returns>
        public static Outcome Determine(Exception error)
        {
            if (error == null)
            {
                return Success();
            }

            return Failure(error);
        }

        /// <summary>
        /// Determines the outcome depending on the instance of an error.
        /// </summary>
        /// <typeparam name="T">The type returned by the outcome.</typeparam>
        /// <param name="error">An error, if any.</param>
        /// <returns>A <see cref="SuccessfulOutcome{T}"/> if <paramref name="error"/> is null; otherwise a <see cref="FailedOutcome{T}"/>.</returns>
        public static Outcome<T> Determine<T>(Exception error)
        {
            if (error == null)
            {
                return Success<T>();
            }

            return Failure<T>(error);
        }
    }
}
