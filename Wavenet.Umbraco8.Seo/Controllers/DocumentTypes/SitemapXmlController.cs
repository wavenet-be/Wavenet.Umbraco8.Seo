// <copyright file="SitemapXmlController.cs" company="Wavenet">
// Copyright (c) Wavenet. All rights reserved.
// </copyright>

namespace Wavenet.Web.Site.Controllers.DocumentTypes
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using System.Xml.Linq;

    using Umbraco.Core.Models.PublishedContent;
    using Umbraco.Web;
    using Umbraco.Web.Models;
    using Umbraco.Web.Mvc;

    /// <summary>
    /// <see cref="SitemapXmlController"/>.
    /// </summary>
    /// <seealso cref="RenderMvcController" />
    public class SitemapXmlController : RenderMvcController
    {
        /// <inheritdoc />
        public override ActionResult Index(ContentModel model)
        {
            XNamespace ns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            var invariantCulture = CultureInfo.InvariantCulture;
            using (var writer = new Utf8StringWriter())
            {
                var nodes = from n in model.Content.Parent.DescendantsOrSelf()
                            where (n.TemplateId ?? 0) > 0
                            select new XElement(
                                ns + "url",
                                new XElement(ns + "loc", n.Url(mode: UrlMode.Absolute)),
                                new XElement(ns + "lastmod", n.UpdateDate.ToString("yyyy-MM-dd", invariantCulture)),
                                new XElement(ns + "priority", Math.Pow(0.8, n.Level - 2).ToString("0.00", invariantCulture)));

                new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement(ns + "urlset", nodes)).Save(writer);
                return this.Content(writer.ToString(), "application/xml", Encoding.UTF8);
            }
        }

        private class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }
    }
}