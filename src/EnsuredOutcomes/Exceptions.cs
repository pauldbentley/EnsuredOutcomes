// Copyright (c) Paul Bentley 2019. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project root for full license information.

namespace EnsuredOutcomes
{
    using System;
    using System.Linq;

    /// <summary>
    /// Exceptions for invalid input parameters.
    /// </summary>
    public static class Exceptions
    {
        /// <summary>
        /// Tests if <paramref name="value"/> is null and returns a <see cref="ArgumentNullException"/> if so.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>A <see cref="ArgumentNullException"/> if <paramref name="value"/> is null; otherwise, null.</returns>
        public static ArgumentNullException WhenNull([ValidatedNotNull]object value, string parameterName) =>
            Check.IsNull(value)
                ? ArgumentNull(parameterName)
                : null;

        /// <summary>
        /// Throws a <see cref="ArgumentNullException"/> if <paramref name="value"/> is null.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="value"/> is null.</exception>
        public static void ThrowWhenNull([ValidatedNotNull]object value, string parameterName) =>
            Throw(WhenNull(value, parameterName));

        /// <summary>
        /// Tests if <paramref name="value"/> is null or an empty string and returns a <see cref="ArgumentException"/> if so.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>A <see cref="ArgumentException"/> if <paramref name="value"/> is null or an empty string; otherwise, null.</returns>
        public static ArgumentException WhenNullOrEmpty([ValidatedNotNull]string value, string parameterName) =>
            (ArgumentException)WhenNull(value, parameterName) ??
            (Check.IsNullOrEmpty(value) ? ArgumentOutOfRange(parameterName, null, "Value was out of range.  Must not be empty.") : null);

        /// <summary>
        /// Throws a <see cref="ArgumentException"/> if <paramref name="value"/> is null or an empty string.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <exception cref="ArgumentException">If <paramref name="value"/> is null or an empty string.</exception>
        public static void ThrowWhenNullOrEmpty([ValidatedNotNull]string value, string parameterName) =>
            Throw(WhenNullOrEmpty(value, parameterName));

        /// <summary>
        /// Tests if <paramref name="value"/> is null or whitespace and returns a <see cref="ArgumentException"/> if so.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>A <see cref="ArgumentException"/> if <paramref name="value"/> is null or whitespace; otherwise, null.</returns>
        public static ArgumentException WhenNullOrWhiteSpace([ValidatedNotNull]string value, string parameterName) =>
            WhenNullOrEmpty(value, parameterName) ??
            (Check.IsNullOrWhiteSpace(value) ? ArgumentOutOfRange(parameterName, null, "Value was out of range.  Must not be whitespace.") : null);

        /// <summary>
        /// Throws a <see cref="ArgumentException"/> if <paramref name="value"/> is null or whitespace.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <exception cref="ArgumentException">If <paramref name="value"/> is null or whitespace.</exception>
        public static void ThrowWhenNullOrWhiteSpace([ValidatedNotNull]string value, string parameterName) =>
            Throw(WhenNullOrWhiteSpace(value, parameterName));

        /// <summary>
        /// Tests if the length of <paramref name="value"/> is outside a minimum and maximum and returns a <see cref="ArgumentOutOfRangeException"/> if so.
        /// </summary>
        /// <remarks>
        /// The length of a null string is 0.
        /// It is assumed that callers would have already checked for null, empty or whitepsace if this was a contraint.
        /// </remarks>
        /// <param name="value">The value to test.</param>
        /// <param name="minimumLength">The minimum length.</param>
        /// <param name="maximumLength">The maximum length.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>A <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> has length outside of the given range; otherwise, null.</returns>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="minimumLength"/> is less than 0.</exception>
        public static ArgumentOutOfRangeException WhenLengthIsIncorrect([ValidatedNotNull]string value, int minimumLength, int maximumLength, string parameterName)
        {
            string message = minimumLength == 0
                ? $"Value was out of range.  The length must be less than {maximumLength}."
                : $"Value was out of range.  The length must be between {minimumLength} and {maximumLength}.";

            return !Check.HasCorrectLength(value, minimumLength, maximumLength)
                ? ArgumentOutOfRange(parameterName, value, message)
                : null;
        }

        /// <summary>
        /// Throws a <see cref="ArgumentOutOfRangeException"/> if the length of <paramref name="value"/> is outside a minimum and maximum.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <param name="minimumLength">The minimum length.</param>
        /// <param name="maximumLength">The maximum length.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <exception cref="ArgumentException">If the length of <paramref name="value"/> is outside a minimum and maximum.</exception>
        public static void ThrowWhenLengthIsIncorrect([ValidatedNotNull]string value, int minimumLength, int maximumLength, string parameterName) =>
            Throw(WhenLengthIsIncorrect(value, minimumLength, maximumLength, parameterName));

        /// <summary>
        /// Tests if <paramref name="value"/> not does not match a given <paramref name="pattern"/> and returns a <see cref="ArgumentOutOfRangeException"/> if so.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <param name="pattern">The pattern.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>A <see cref="ArgumentOutOfRangeException"/> if the pattern match fails; otherwise, null.</returns>
        public static ArgumentOutOfRangeException WhenDoesNotMatchPattern([ValidatedNotNull]string value, string pattern, string parameterName) =>
            !Check.MatchesPattern(value, pattern)
                ? ArgumentOutOfRange(parameterName, value, $"Value was out of range. Must match the pattern {pattern}.")
                : null;

        /// <summary>
        /// Throws a <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> not does not match a given <paramref name="pattern"/>.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <param name="pattern">The pattern.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <exception cref="ArgumentException">If <paramref name="value"/> not does not match a given <paramref name="pattern"/>.</exception>
        public static void ThrowWhenDoesNotMatchPattern([ValidatedNotNull]string value, string pattern, string parameterName) =>
            Throw(WhenDoesNotMatchPattern(value, pattern, parameterName));

        /// <summary>
        /// Tests if <paramref name="value"/> is less than to a minimum value and returns a <see cref="ArgumentOutOfRangeException"/> if so.
        /// </summary>
        /// <remarks>Dates are converted to universal time before comparison.</remarks>
        /// <param name="value">The value to test.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>A <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is less than the minimum value; otherwise, null.</returns>
        public static ArgumentOutOfRangeException WhenOutOfRange(DateTime value, DateTime minValue, string parameterName)
        {
            return !Check.IsInRange(value, minValue)
                ? ArgumentOutOfRange(parameterName, value, $"Value was out of range.  Must be greater than or equal to {minValue}.")
                : null;
        }

        /// <summary>
        /// Throws a <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is less than to a minimum value.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="value"/> is less than to a minimum value.</exception>
        public static void ThrowWhenOutOfRange(DateTime value, DateTime minValue, string parameterName) =>
            Throw(WhenOutOfRange(value, minValue, parameterName));

        /// <summary>
        /// Creates a new <see cref="ArgumentNullException"/> instance.
        /// </summary>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>A <see cref="ArgumentNullException"/> instance.</returns>
        public static ArgumentNullException ArgumentNull(string parameterName) =>
            new ArgumentNullException(parameterName);

        /// <summary>
        /// Creates a new <see cref="ArgumentOutOfRangeException"/> instance.
        /// </summary>
        /// <param name="parameterName">The name of the parameter that caused the exception.</param>
        /// <param name="value">The value of the argument that causes this exception.</param>
        /// <returns>A <see cref="ArgumentOutOfRangeException"/> instance.</returns>
        public static ArgumentOutOfRangeException ArgumentOutOfRange(string parameterName, object value) =>
            ArgumentOutOfRange(parameterName, value, null);

        /// <summary>
        /// Creates a new <see cref="ArgumentOutOfRangeException"/> instance.
        /// </summary>
        /// <param name="parameterName">The name of the parameter that caused the exception.</param>
        /// <param name="value">The value of the argument that causes this exception.</param>
        /// <param name="message">The message that describes the error.</param>
        /// <returns>A <see cref="ArgumentOutOfRangeException"/> instance.</returns>
        public static ArgumentOutOfRangeException ArgumentOutOfRange(string parameterName, object value, string message)
        {
            return value == null
                ? new ArgumentOutOfRangeException(parameterName, message)
                : new ArgumentOutOfRangeException(parameterName, value, message);
        }

        /// <summary>
        /// Throws the given <see cref="Exception"/> if it is not null.
        /// </summary>
        /// <param name="exception">The exception to throw.</param>
        public static void Throw(Exception exception)
        {
            if (exception != null)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Determines whether any element in a sequence of <see cref="Exception"/> is not null.
        /// </summary>
        /// <param name="exceptions">A sequence of <see cref="Exception"/> to test.</param>
        /// <returns>true if there are any <see cref="Exception"/> object which are null; otherwise, false.</returns>
        public static bool Any(params Exception[] exceptions) =>
            exceptions?.Any(e => e != null) == true;
    }
}
