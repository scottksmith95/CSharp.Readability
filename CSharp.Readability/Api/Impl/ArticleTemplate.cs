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

using CSharp.Readability.Api.Interfaces;
using CSharp.Readability.Api.Models;
using Spring.Rest.Client;
using System.Threading.Tasks;

namespace CSharp.Readability.Api.Impl
{
	/// <summary>
	/// Implementation of <see cref="IArticleOperations"/>, providing binding to Readabilitys' article-oriented REST resources.
	/// </summary>
	/// <author>Scott Smith</author>
	class ArticleTemplate : AbstractReadabilityOperations, IArticleOperations
	{
		private readonly RestTemplate _restTemplate;

		public ArticleTemplate(RestTemplate restTemplate, bool isAuthorized)
			: base(isAuthorized)
		{
			_restTemplate = restTemplate;
		}

		#region IArticleOperations Members

		public Article GetArticle(string articleId)
		{
			EnsureIsAuthorized();
			return _restTemplate.GetForObject<Article>("articles/" + articleId);
		}

		public Task<Article> GetArticleAsync(string articleId)
		{
			EnsureIsAuthorized();
			return _restTemplate.GetForObjectAsync<Article>("articles/" + articleId);
		}

		#endregion

		#region Private Methods



		#endregion
	}
}