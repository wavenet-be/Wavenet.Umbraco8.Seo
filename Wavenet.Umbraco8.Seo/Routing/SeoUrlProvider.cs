// <copyright file="SeoUrlProvider.cs" company="Wavenet">
// Copyright (c) Wavenet. All rights reserved.
// </copyright>

namespace Wavenet.Umbraco8.Seo.Routing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Umbraco.Core.Models.PublishedContent;
    using Umbraco.Web;
    using Umbraco.Web.Routing;

    /// <summary>
    /// <see cref="SeoUrlProvider"/>.
    /// </summary>
    /// <seealso cref="IUrlProvider" />
    public class SeoUrlProvider : IUrlProvider
    {
        /// <inheritdoc />
        public IEnumerable<UrlInfo> GetOtherUrls(UmbracoContext umbracoContext, int id, Uri current)
            => Enumerable.Empty<UrlInfo>();

        /// <inheritdoc />
        public UrlInfo GetUrl(UmbracoContext umbracoContext, IPublishedContent content, UrlMode mode, string culture, Uri current)
        {
            string url;
            switch (content.ContentType.Alias)
            {
                case "robotsTxt":
                    url = "/robots.txt";
                    break;

                case "sitemapXml":
                    url = $"/sitemap-{culture}.xml";
                    break;

                default:
                    return null;
            }

            return UrlInfo.Url(mode == UrlMode.Absolute ? new Uri(current, url).ToString() : url);
        }
    }
}