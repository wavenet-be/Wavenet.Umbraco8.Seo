// <copyright file="SitemapXmlController.cs" company="Wavenet">
// Copyright (c) Wavenet. All rights reserved.
// </copyright>

namespace Wavenet.Umbraco8.Seo.Controllers.DocumentTypes
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using System.Xml;
    using System.Xml.Serialization;

    using Umbraco.Core.Models.PublishedContent;
    using Umbraco.Web;
    using Umbraco.Web.Models;
    using Umbraco.Web.Mvc;

    using Wavenet.Umbraco8.Seo.Extensions;
    using Wavenet.Umbraco8.Seo.Models;

    /// <summary>
    /// <see cref="SitemapXmlController"/>.
    /// </summary>
    /// <seealso cref="RenderMvcController" />
    public class SitemapXmlController : RenderMvcController
    {
        /// <summary>
        /// Occurs when the sitemap is generated.
        /// </summary>
        public static event EventHandler<SitemapEventArgs> BuildSitemap;

        /// <inheritdoc />
        public override ActionResult Index(ContentModel model)
        {
            var invariantCulture = CultureInfo.InvariantCulture;
            using (var buffer = new MemoryStream())
            using (var writer = XmlWriter.Create(buffer, new XmlWriterSettings { Indent = false, Encoding = Encoding.UTF8 }))
            {
                var sitemap = new Sitemap
                {
                    Urls =
                    {
                        from n in model.Content.Parent.DescendantsOrSelf()
                        where (n.TemplateId ?? 0) > 0
                        select new Url
                        {
                            Content = n,
                            Location = n.Url(mode: UrlMode.Absolute),
                            LastModified = n.UpdateDate,
                        },
                    },
                };

                BuildSitemap?.Invoke(this, new SitemapEventArgs(sitemap));

                var ns = new XmlSerializerNamespaces();
                ns.Add(string.Empty, "http://www.sitemaps.org/schemas/sitemap/0.9");
                var serializer = new XmlSerializer(typeof(Sitemap));
                writer.WriteStartDocument(true);
                serializer.Serialize(writer, sitemap, ns);
                return this.File(buffer.ToArray(), "application/xml");
            }
        }
    }
}