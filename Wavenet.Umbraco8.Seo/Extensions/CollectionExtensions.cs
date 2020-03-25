// <copyright file="CollectionExtensions.cs" company="Wavenet">
// Copyright (c) Wavenet. All rights reserved.
// </copyright>

namespace Wavenet.Umbraco8.Seo.Extensions
{
    using System.Collections.Generic;

    /// <summary>
    /// <see cref="CollectionExtensions"/>.
    /// </summary>
    internal static class CollectionExtensions
    {
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="items">The items.</param>
        public static void Add<TValue>(this ICollection<TValue> collection, IEnumerable<TValue> items)
            => collection.AddRange(items);

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="items">The items.</param>
        public static void AddRange<TValue>(this ICollection<TValue> collection, IEnumerable<TValue> items)
        {
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }
    }
}