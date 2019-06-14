namespace EnsuredOutcomes
{
    using System;

    public static class InputValue
    {
        public static bool IsNull([ValidatedNotNull]object value) => value == null;

        public static bool IsNullOrEmpty(string value) => string.IsNullOrEmpty(value);
    }
}