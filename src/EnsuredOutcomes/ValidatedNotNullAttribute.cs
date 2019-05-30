// Copyright (c) Paul Bentley 2019. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project root for full license information.

namespace EnsuredOutcomes
{
    using System;

    /// <summary>
    /// Attribute for code analysis.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    internal sealed class ValidatedNotNullAttribute : Attribute
    {
    }
}
