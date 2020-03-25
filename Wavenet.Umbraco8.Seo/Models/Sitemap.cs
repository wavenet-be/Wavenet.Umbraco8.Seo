// <copyright file="Sitemap.cs" company="Wavenet">
// Copyright (c) Wavenet. All rights reserved.
// </copyright>

namespace Wavenet.Umbraco8.Seo.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// <see cref="Sitemap"/> model.
    /// </summary>
    [XmlRoot("urlset", Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9")]
    public class Sitemap
    {
        /// <summary>
        /// Gets the urls.
        /// </summary>
        /// <value>
        /// The urls.
        /// </value>
        [XmlElement("url")]
        public List<Url> Urls { get; } = new List<Url>();
    }
}
