// <copyright file="RobotsTxtController.cs" company="Wavenet">
// Copyright (c) Wavenet. All rights reserved.
// </copyright>

namespace Wavenet.Umbraco8.Seo.Controllers.DocumentTypes
{
    using System.Linq;
    using System.Web.Mvc;

    using Umbraco.Core.Models.PublishedContent;
    using Umbraco.Web;
    using Umbraco.Web.Models;
    using Umbraco.Web.Mvc;

    /// <summary>
    /// <see cref="RobotsTxtController"/>.
    /// </summary>
    /// <seealso cref="RenderMvcController" />
    public class RobotsTxtController : RenderMvcController
    {
        /// <inheritdoc />
        public override ActionResult Index(ContentModel model)
        {
            string content;
            if (model.Content.Value<bool>("disableIndexing"))
            {
                content = @"User-agent: *
Disallow: /";
            }
            else
            {
                var sitemaps = this.Umbraco.ContentSingleAtXPath("//sitemapXml");
                if (sitemaps != null)
                {
                    content = string.Join("\r\n", sitemaps.Parent.Cultures.Select(c => $"Sitemap: {sitemaps.Url(culture: c.Key, mode: UrlMode.Absolute)}")) + "\r\n";
                }
                else
                {
                    content = null;
                }

                content += model.Content.Value<string>("content");
            }

            return this.Content(content, "text/plain");
        }
    }
}