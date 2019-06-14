// Copyright (c) Paul Bentley 2019. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project root for full license information.

namespace EnsuredOutcomes
{
    /// <summary>
    /// Checks input values.
    /// </summary>
    public static class InputValue
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
        public static bool IsNullOrEmpty(string value) => string.IsNullOrEmpty(value);
    }
}