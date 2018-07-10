﻿// Copyright (c) Samuel Cragg.
//
// Licensed under the MIT license. See LICENSE file in the project root for
// full license information.

namespace SharpKml.Dom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SharpKml.Base;

    /// <summary>
    /// Specifies the deletion of zero or more <see cref="Feature"/>s in the
    /// target resource.
    /// </summary>
    /// <remarks>OGC KML 2.2 Section 13.5</remarks>
    [KmlElement("Delete")]
    public sealed class DeleteCollection : Element, ICollection<Feature>
    {
        /// <summary>
        /// Initializes static members of the <see cref="DeleteCollection"/> class.
        /// </summary>
        static DeleteCollection()
        {
            RegisterValidChild<DeleteCollection, Feature>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCollection"/> class.
        /// </summary>
        public DeleteCollection()
        {
        }

        /// <summary>
        /// Gets the number of <see cref="Container"/>s in this instance.
        /// </summary>
        public int Count
        {
            get { return this.Children.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is read-only.
        /// </summary>
        bool ICollection<Feature>.IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Adds a <see cref="Feature"/> to this instance.
        /// </summary>
        /// <param name="item">The <c>Feature</c> to be added.</param>
        /// <exception cref="ArgumentNullException">item is null.</exception>
        /// <exception cref="InvalidOperationException">
        /// item belongs to another <see cref="Element"/>.
        /// </exception>
        public void Add(Feature item)
        {
            this.AddChild(item);
        }

        /// <summary>
        /// Removes all <see cref="Feature"/>s from this instance.
        /// </summary>
        public void Clear()
        {
            for (int i = this.Children.Count; i > 0; --i)
            {
                this.RemoveChild(this.Children.First());
            }
        }

        /// <summary>
        /// Determines whether the specified value is contained in this instance.
        /// </summary>
        /// <param name="item">The value to locate.</param>
        /// <returns>
        /// true if item is found in this instance; otherwise, false. This
        /// method also returns false if the specified value parameter is null.
        /// </returns>
        public bool Contains(Feature item)
        {
            if (item == null)
            {
                return false;
            }

            return this.Children.Contains(item);
        }

        /// <summary>
        /// Copies this instance to a compatible one-dimensional array, starting
        /// at the specified index of the target array.
        /// </summary>
        /// <param name="array">The destination one-dimensional array.</param>
        /// <param name="arrayIndex">
        /// The zero-based index in array at which copying begins.
        /// </param>
        /// <exception cref="ArgumentException">
        /// The number of values contained in this instance is greater than the
        /// available space from arrayIndex to the end of the destination array.
        /// </exception>
        /// <exception cref="ArgumentNullException">array is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// arrayIndex is less than 0.
        /// </exception>
        public void CopyTo(Feature[] array, int arrayIndex)
        {
            this.Children.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Returns an enumerator that iterates through this instance.
        /// </summary>
        /// <returns>An enumerator for this instance.</returns>
        public IEnumerator<Feature> GetEnumerator()
        {
            return this.Children.Cast<Feature>().GetEnumerator();
        }

        /// <summary>
        /// Removes the first occurrence of a specific value from this instance.
        /// </summary>
        /// <param name="item">The value to remove.</param>
        /// <returns>
        /// true if the specified value parameter is successfully removed;
        /// otherwise, false. This method also returns false if the specified
        /// value parameter was not found or is null.
        /// </returns>
        public bool Remove(Feature item)
        {
            if (item == null)
            {
                return false;
            }

            return this.RemoveChild(item);
        }

        /// <summary>
        /// Returns an enumerator that iterates through this instance.
        /// </summary>
        /// <returns>An enumerator for this instance.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
