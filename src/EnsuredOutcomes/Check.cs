// Copyright (c) Paul Bentley 2019. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project root for full license information.

namespace EnsuredOutcomes
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Checks input values.
    /// </summary>
    public static class Check
    {
        /// <summary>
        /// Tests if <paramref name="value"/> is null.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <returns>true if <paramref name="value"/> is null; otherwise, false.</returns>
        public static bool IsNull([ValidatedNotNull]object value) => value == null;

        /// <summary>
        /// Tests if <paramref name="value"/> is null or an empty string.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <returns>true if <paramref name="value"/> is null or an empty string; otherwise, false.</returns>
        public static bool IsNullOrEmpty([ValidatedNotNull]string value) => string.IsNullOrEmpty(value);

        /// <summary>
        /// Tests if <paramref name="value"/> is null or whitespace.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <returns>true if <paramref name="value"/> is null or whitespace; otherwise, false.</returns>
        public static bool IsNullOrWhiteSpace([ValidatedNotNull]string value) => string.IsNullOrWhiteSpace(value);

        /// <summary>
        /// Tests if the length of <paramref name="value"/> is between a minimum and maximum, inclusive.
        /// </summary>
        /// <remarks>The length of a null string is 0.</remarks>
        /// <param name="value">The value to test.</param>
        /// <param name="minimumLength">The minimum length.</param>
        /// <param name="maximumLength">The maximum length.</param>
        /// <returns>true if the length of <paramref name="value"/> is between the given range; otherwise, false.</returns>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="minimumLength"/> is less than 0.</exception>
        public static bool HasCorrectLength(string value, int minimumLength, int maximumLength)
        {
            if (minimumLength < 0)
            {
                throw Exceptions.ArgumentOutOfRange(nameof(minimumLength), minimumLength);
            }

            // the length of a null string is 0;
            int length = value?.Length ?? 0;
            return length >= minimumLength && length <= maximumLength;
        }

        /// <summary>
        /// Tests if <paramref name="value"/> matches a given <paramref name="pattern"/>.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <param name="pattern">The pattern.</param>
        /// <returns>true if <paramref name="value"/> matches the <paramref name="pattern"/>; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="pattern"/> is null.</exception>
        public static bool MatchesPattern([ValidatedNotNull]string value, string pattern) => Regex.IsMatch(value, pattern);

        /// <summary>
        /// Tests if <paramref name="value"/> is greater than or equal to a minimum value.
        /// </summary>
        /// <remarks>Dates are converted to universal time before comparison.</remarks>
        /// <param name="value">The value to test.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <returns>A <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is less than the minimum value; otherwise, null.</returns>
        public static bool IsInRange(DateTime value, DateTime minValue) =>
            value.ToUniversalTime() >= minValue.ToUniversalTime();
    }
}