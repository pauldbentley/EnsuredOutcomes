// Copyright (c) Paul Bentley 2019. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project root for full license information.

#define CONTRACTS_FULL

namespace EnsuredOutcomes
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Exceptions for invalid input parameters.
    /// </summary>
    public static class Exceptions
    {
        /// <summary>
        /// Tests if <paramref name="value"/> is null.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>An <see cref="ArgumentNullException"/> if <paramref name="value"/> is null; otherwise, null.</returns>
        public static ArgumentNullException WhenNull([ValidatedNotNull]object value, string parameterName)
        {
            return InputValue.IsNull(value)
                ? ArgumentNull(parameterName)
                : null;
        }

        /// <summary>
        /// Throws a <see cref="ArgumentNullException"/> if <paramref name="value"/> is null.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="value"/> is null.</exception>
        public static void ThrowIfNull([ValidatedNotNull]object value, string parameterName) =>
            Throw(WhenNull(value, parameterName));

        /// <summary>
        /// Tests if <paramref name="value"/> is null or an empty string.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>An <see cref="ArgumentException"/> if <paramref name="value"/> is null or an empty string; otherwise, null.</returns>
        public static ArgumentException WhenNullOrEmpty([ValidatedNotNull]string value, string parameterName)
        {
            return
                (ArgumentException)WhenNull(value, parameterName) ??
                (InputValue.IsNullOrEmpty(value) ? ArgumentOutOfRange(parameterName, null, "Value was out of range.  Must not be empty.") : null);
        }

        /// <summary>
        /// Tests if <paramref name="value"/> is null or whitespace.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>An <see cref="ArgumentException"/> if <paramref name="value"/> is null or whitespace; otherwise, null.</returns>
        public static ArgumentException WhenNullOrWhitespace([ValidatedNotNull]string value, string parameterName)
        {
            return
                WhenNullOrEmpty(value, parameterName) ??
                (string.IsNullOrWhiteSpace(value) ? ArgumentOutOfRange(parameterName, null, "Value was out of range.  Must not be whitespace.") : null);
        }

        /// <summary>
        /// Tests if the length of <paramref name="value"/> is outside a minimum and maximum.
        /// It is assumed that callers would have chacked for null or empty prior to this call if this was a contraint.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <param name="minimumLength">The minimum length.</param>
        /// <param name="maximumLength">The maximum length.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>An <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is null or has length outside of the given range; otherwise null.</returns>
        public static ArgumentOutOfRangeException WhenLengthIsIncorrect([ValidatedNotNull]string value, int minimumLength, int maximumLength, string parameterName)
        {
            // It is assumed that callers would have chacked for null or
            // empty prior to this call if this was a contraint.
            if (value == null)
            {
                return null;
            }

            string message = minimumLength == 0
                ? $"Value was out of range.  The length must be less than {maximumLength}."
                : $"Value was out of range.  The length must be between {minimumLength} and {maximumLength}.";

            return value.Length < minimumLength || value.Length > maximumLength
                ? ArgumentOutOfRange(parameterName, value, message)
                : null;
        }

        /// <summary>
        /// Tests if <paramref name="value"/> not dose not match a given pattern.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <param name="pattern">The pattern.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>An <see cref="ArgumentOutOfRangeException"/> if the pattern match fails; otherwise, null.</returns>
        public static ArgumentOutOfRangeException WhenDoesNotMatchPattern([ValidatedNotNull]string value, string pattern, string parameterName)
        {
            return !Regex.IsMatch(value, pattern)
                ? ArgumentOutOfRange(parameterName, value, $"Value was out of range. Must match the pattern {pattern}.")
                : null;
        }

        /// <summary>
        /// Tests if <paramref name="value"/> is less than to a minimum value.
        /// Dates are converted to universal time before comparison.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>An <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is less than the minimum value; otherwise, null.</returns>
        public static ArgumentOutOfRangeException WhenOutOfRange(DateTime value, DateTime minValue, string parameterName)
        {
            return value.ToUniversalTime() < minValue.ToUniversalTime()
                ? ArgumentOutOfRange(parameterName, value, $"Value was out of range.  Must be greater than {minValue}.")
                : null;
        }

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
        /// <returns>A new <see cref="ArgumentOutOfRangeException"/> instance.</returns>
        public static ArgumentOutOfRangeException ArgumentOutOfRange(string parameterName, object value) =>
            ArgumentOutOfRange(parameterName, value, null);

        /// <summary>
        /// Creates a new <see cref="ArgumentOutOfRangeException"/> instance.
        /// </summary>
        /// <param name="parameterName">The name of the parameter that caused the exception.</param>
        /// <param name="value">The value of the argument that causes this exception.</param>
        /// <param name="message">The message that describes the error.</param>
        /// <returns>A new <see cref="ArgumentOutOfRangeException"/> instance.</returns>
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
