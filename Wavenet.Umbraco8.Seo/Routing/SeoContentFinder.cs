// <copyright file="SeoContentFinder.cs" company="Wavenet">
// Copyright (c) Wavenet. All rights reserved.
// </copyright>

namespace Wavenet.Umbraco8.Seo.Routing
{
    using System;
    using System.Text.RegularExpressions;

    using Umbraco.Web.Routing;

    /// <summary>
    /// <see cref="SeoContentFinder"/>.
    /// </summary>
    /// <seealso cref="IContentFinder" />
    public class SeoContentFinder : IContentFinder
    {
        /// <inheritdoc />
        public bool TryFindContent(PublishedRequest request)
        {
            var path = request.Uri.AbsolutePath;
            if ("/robots.txt".Equals(path, StringComparison.OrdinalIgnoreCase))
            {
                request.PublishedContent = request.UmbracoContext.Content.GetSingleByXPath("//robotsTxt");
            }
            else if (Regex.IsMatch(path, @"^/sitemap-\w{2}\.xml$", RegexOptions.IgnoreCase))
            {
                request.PublishedContent = request.UmbracoContext.Content.GetSingleByXPath("//sitemapXml");
            }

            return request.PublishedContent != null;
        }
    }
}