// <copyright file="ChangeFrequency.cs" company="Wavenet">
// Copyright (c) Wavenet. All rights reserved.
// </copyright>

namespace Wavenet.Umbraco8.Seo.Models
{
    using System.Xml.Serialization;

    /// <summary>
    /// <see cref="ChangeFrequency"/>.
    /// </summary>
    public enum ChangeFrequency
    {
        /// <summary>
        /// Page changes always.
        /// </summary>
        [XmlEnum("always")]
        Always,

        /// <summary>
        /// Page changes each hour.
        /// </summary>
        [XmlEnum("hourly")]
        Hourly,

        /// <summary>
        /// Page changes each day.
        /// </summary>
        [XmlEnum("daily")]
        Daily,

        /// <summary>
        /// Page changes each week.
        /// </summary>
        [XmlEnum("weekly")]
        Weekly,

        /// <summary>
        /// Page changes each month.
        /// </summary>
        [XmlEnum("monthly")]
        Monthly,

        /// <summary>
        /// Page changes each year.
        /// </summary>
        [XmlEnum("yearly")]
        Yearly,

        /// <summary>
        /// The page never changes.
        /// </summary>
        [XmlEnum("never")]
        Never,
    }
}