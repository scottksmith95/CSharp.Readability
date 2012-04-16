#region License

/*
 * Copyright 2002-2012 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#endregion

using System;
using System.Collections.Generic;
using CSharp.Readability.Api.Impl.Json;
using CSharp.Readability.Api.Interfaces;
using CSharp.Readability.Api.Models;
using Spring.Json;
using Spring.Rest.Client;
using Spring.Social.OAuth1;
using Spring.Http.Converters;
using Spring.Http.Converters.Json;

namespace CSharp.Readability.Api.Impl
{
    /// <summary>
    /// This is the central class for interacting with Readability.
    /// </summary>
    /// <remarks>
    /// <para>
    /// All Readability operations require OAuth authentication. 
    /// To perform such operations, <see cref="ReadabilityTemplate"/> must be constructed 
    /// with the minimal amount of information required to sign requests to Readability's API 
    /// with an OAuth <code>Authorization</code> header.
    /// </para>
    /// </remarks>
    /// <author>Scott Smith</author>
    public sealed class ReadabilityTemplate : AbstractOAuth1ApiBinding, IReadability 
    {
		private static readonly Uri ApiUriBase = new Uri("https://www.readability.com/api/rest/v1/");

		private IArticleOperations _articleOperations;
		private IBookmarkOperations _bookmarkOperations;
		private IContributionOperations _contributionOperations;
		private IRootOperations _rootOperations;
        private IUserOperations _userOperations;

        /// <summary>
        /// Create a new instance of <see cref="ReadabilityTemplate"/>.
        /// </summary>
        /// <param name="consumerKey">The application's API key.</param>
        /// <param name="consumerSecret">The application's API secret.</param>
        /// <param name="accessToken">An access token acquired through OAuth authentication with Readability.</param>
        /// <param name="accessTokenSecret">An access token secret acquired through OAuth authentication with Readability.</param>
        public ReadabilityTemplate(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret) 
            : base(consumerKey, consumerSecret, accessToken, accessTokenSecret)
        {
            InitSubApis();
	    }

        #region IReadability Members

		/// <summary>
		/// Gets the portion of the Readability API containing the article operations.
		/// </summary>
		public IArticleOperations ArticleOperations
		{
			get { return _articleOperations; }
		}

		/// <summary>
		/// Gets the portion of the Readability API containing the bookmark operations.
		/// </summary>
		public IBookmarkOperations BookmarkOperations
		{
			get { return _bookmarkOperations; }
		}

		/// <summary>
		/// Gets the portion of the Readability API containing the contribution operations.
		/// </summary>
		public IContributionOperations ContributionOperations
		{
			get { return _contributionOperations; }
		}

		/// <summary>
		/// Gets the portion of the Readability API containing the root operations.
		/// </summary>
		public IRootOperations RootOperations
		{
			get { return _rootOperations; }
		}

        /// <summary>
        /// Gets the portion of the Readability API containing the user operations.
        /// </summary>
        public IUserOperations UserOperations
        {
            get { return _userOperations; }
        }

        /// <summary>
        /// Gets the underlying <see cref="IRestOperations"/> object allowing for consumption of Readability endpoints 
        /// that may not be otherwise covered by the API binding. 
        /// </summary>
        /// <remarks>
        /// The <see cref="IRestOperations"/> object returned is configured to include an OAuth "Authorization" header on all requests.
        /// </remarks>
        public IRestOperations RestOperations
        {
            get { return RestTemplate; }
        }

        #endregion

        /// <summary>
        /// Enables customization of the <see cref="RestTemplate"/> used to consume provider API resources.
        /// </summary>
        /// <remarks>
        /// An example use case might be to configure a custom error handler. 
        /// Note that this method is called after the RestTemplate has been configured with the message converters returned from GetMessageConverters().
        /// </remarks>
        /// <param name="restTemplate">The RestTemplate to configure.</param>
        protected override void ConfigureRestTemplate(RestTemplate restTemplate)
        {
            restTemplate.BaseAddress = ApiUriBase;
            restTemplate.ErrorHandler = new ReadabilityErrorHandler();
        }

        /// <summary>
        /// Returns a list of <see cref="IHttpMessageConverter"/>s to be used by the internal <see cref="RestTemplate"/>.
        /// </summary>
        /// <remarks>
        /// This implementation adds <see cref="SpringJsonHttpMessageConverter"/> and <see cref="ByteArrayHttpMessageConverter"/> to the default list.
        /// </remarks>
        /// <returns>
        /// The list of <see cref="IHttpMessageConverter"/>s to be used by the internal <see cref="RestTemplate"/>.
        /// </returns>
        protected override IList<IHttpMessageConverter> GetMessageConverters()
        {
            IList<IHttpMessageConverter> converters = base.GetMessageConverters();
            converters.Add(new ByteArrayHttpMessageConverter());
            converters.Add(GetJsonMessageConverter());
            return converters;
        }

        /// <summary>
        /// Returns a <see cref="SpringJsonHttpMessageConverter"/> to be used by the internal <see cref="RestTemplate"/>.
        /// <para/>
        /// Override to customize the message converter (for example, to set a custom object mapper or supported media types).
        /// </summary>
        /// <returns>The configured <see cref="SpringJsonHttpMessageConverter"/>.</returns>
        private SpringJsonHttpMessageConverter GetJsonMessageConverter()
        {
            var jsonMapper = new JsonMapper();
			jsonMapper.RegisterDeserializer(typeof(Article), new ArticleDeserializer());
			jsonMapper.RegisterDeserializer(typeof(BookmarkCollection), new BookmarkCollectionDeserializer());
			jsonMapper.RegisterDeserializer(typeof(ContributionCollection), new ContributionCollectionDeserializer());
			jsonMapper.RegisterDeserializer(typeof(Root), new RootDeserializer());
			jsonMapper.RegisterDeserializer(typeof(User), new UserDeserializer());

            return new SpringJsonHttpMessageConverter(jsonMapper);
        }

        private void InitSubApis()
        {
			_articleOperations = new ArticleTemplate(RestTemplate, IsAuthorized);
			_bookmarkOperations = new BookmarkTemplate(RestTemplate, IsAuthorized);
			_contributionOperations = new ContributionTemplate(RestTemplate, IsAuthorized);
			_rootOperations = new RootTemplate(RestTemplate, IsAuthorized);
			_userOperations = new UserTemplate(RestTemplate, IsAuthorized);
        }
    }
}