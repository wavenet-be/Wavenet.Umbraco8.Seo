// <copyright file="SeoComposer.cs" company="Wavenet">
// Copyright (c) Wavenet. All rights reserved.
// </copyright>

namespace Wavenet.Umbraco8.Seo.Composing
{
    using Umbraco.Core.Composing;
    using Umbraco.Web;

    using Wavenet.Umbraco8.Seo.Routing;

    /// <summary>
    /// <see cref="SeoComposer"/>.
    /// </summary>
    /// <seealso cref="IUserComposer" />
    public class SeoComposer : IUserComposer
    {
        /// <inheritdoc />
        public void Compose(Composition composition)
        {
            composition.UrlProviders().Insert<SeoUrlProvider>();
            composition.ContentFinders().Append<SeoContentFinder>();
        }
    }
}