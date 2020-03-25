// <copyright file="Url.cs" company="Wavenet">
// Copyright (c) Wavenet. All rights reserved.
// </copyright>

namespace Wavenet.Umbraco8.Seo.Models
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml.Serialization;

    using Umbraco.Core.Models.PublishedContent;

    /// <summary>
    /// Sitemap URL.
    /// </summary>
    public class Url
    {
        /// <summary>
        /// Gets or sets the change frequency.
        /// </summary>
        /// <value>
        /// The change frequency.
        /// </value>
        [XmlElement("changefreq", Order = 20)]
        public ChangeFrequency? ChangeFrequency { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        [XmlIgnore]
        public IPublishedContent Content { get; set; }

        /// <summary>
        /// Gets or sets the last modified.
        /// </summary>
        /// <value>
        /// The last modified.
        /// </value>
        [XmlElement("lastmod", Order = 10)]
        public DateTime? LastModified { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        [XmlElement("loc", Order = 0)]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        /// <value>
        /// The priority.
        /// </value>
        [XmlIgnore]
        public double? Priority { get; set; }

        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        /// <value>
        /// The priority.
        /// </value>
        [XmlElement("priority", Order = 30)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SerializedPriority
        {
            get => this.Priority?.ToString("0.00", CultureInfo.InvariantCulture);
            set => throw new NotSupportedException();
        }

        /// <summary>
        /// Determine if XML should serialize the ChangeFrequency property.
        /// </summary>
        /// <returns><c>true</c> if it should be serialized; Otherwize <c>false</c>.</returns>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeChangeFrequency()
            => this.ChangeFrequency != null;

        /// <summary>
        /// Determine if XML should serialize the LastModified property.
        /// </summary>
        /// <returns><c>true</c> if it should be serialized; Otherwize <c>false</c>.</returns>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeLastModified()
            => this.LastModified != null;

        /// <summary>
        /// Determine if XML should serialize the Priority property.
        /// </summary>
        /// <returns><c>true</c> if it should be serialized; Otherwize <c>false</c>.</returns>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeSerializedPriority()
            => this.Priority != null;
    }
}