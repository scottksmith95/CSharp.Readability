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

using CSharp.Readability.Api.Models;
using System.Threading.Tasks;

namespace CSharp.Readability.Api.Interfaces
{
	/// <summary>
	/// Interface defining the operations for searching Readability and retrieving article data.
	/// </summary>
	/// <author>Scott Smith</author>
	public interface IArticleOperations
	{
		/// <summary>
		/// Retrieve a single Article, including its content.
		/// </summary>
		/// <param name="articleId">The id of the article to return.</param>
		/// <returns>An <see cref="Article"/> with the supplied articleId</returns>
		/// <exception cref="ReadabilityApiException">If there is an error while communicating with Readability.</exception>
		/// <exception cref="ReadabilityApiException">If OAuth credentials was not provided.</exception>
		Article GetArticle(string articleId);

		/// <summary>
		/// Asynchronously retrieve a single Article, including its content.
		/// </summary>
		/// <param name="articleId">The id of the article to return.</param>
		/// <returns>An <see cref="Article"/> with the supplied articleId.</returns>
		/// <exception cref="ReadabilityApiException">If there is an error while communicating with Readability.</exception>
		/// <exception cref="ReadabilityApiException">If OAuth credentials was not provided.</exception>
		Task<Article> GetArticleAsync(string articleId);
	}
}
