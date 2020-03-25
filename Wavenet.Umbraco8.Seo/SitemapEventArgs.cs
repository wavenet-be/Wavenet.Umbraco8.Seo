// <copyright file="SitemapEventArgs.cs" company="Wavenet">
// Copyright (c) Wavenet. All rights reserved.
// </copyright>

namespace Wavenet.Umbraco8.Seo
{
    using System;

    using Wavenet.Umbraco8.Seo.Models;

    /// <summary>
    /// <see cref="SitemapEventArgs"/>.
    /// </summary>
    /// <seealso cref="EventArgs" />
    public class SitemapEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SitemapEventArgs"/> class.
        /// </summary>
        /// <param name="sitemap">The sitemap.</param>
        public SitemapEventArgs(Sitemap sitemap)
        {
            this.Sitemap = sitemap;
        }

        /// <summary>
        /// Gets the sitemap.
        /// </summary>
        /// <value>
        /// The sitemap.
        /// </value>
        public Sitemap Sitemap { get; }
    }
}