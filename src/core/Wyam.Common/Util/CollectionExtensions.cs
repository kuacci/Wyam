﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Wyam.Common.Util
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Adds a range of values to a collection.
        /// </summary>
        /// <param name="collection">The collection to add values to.</param>
        /// <param name="items">The items to add.</param>
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }

        /// <summary>
        /// Removes all items that match a predicate from a collection.
        /// </summary>
        /// <param name="collection">The collection to remove items from.</param>
        /// <param name="match">The predicate (return <c>true</c> to remove the item).</param>
        /// <returns>The number of items removed.</returns>
        public static int RemoveAll<T>(this ICollection<T> collection, Func<T, bool> match)
        {
            IList<T> toRemove = collection.Where(match).ToList();
            foreach (var item in toRemove)
            {
                collection.Remove(item);
            }
            return toRemove.Count;
        }
    }
}
