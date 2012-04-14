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

#region Json
/*
{
    "id": 2,
    "author": "Rich Ziade",
    "content": "<div><div class=\"entry\">\n\t\t\t\t<p>A couple of months ago, we announced ... </p></div></div>",
    "content_size": 1424,
    "date_published": "2010-10-04 00:00:00",
    "domain": "blog.arc90.com",
    "next_page_href": null,
    "short_url": "/articles/xi28djqw/",
    "title": "It’s Official: We’re Tossing the Projector at SXSW 2011",
    "url": "http://blog.arc90.com/2010/10/04/its-official-were-tossing-the-projector-at-sxsw-2011/"
}
*/
#endregion

using System;
using System.IO;
using System.Collections.Generic;
using Spring.Rest.Client;
using Spring.Http;
using System.Threading.Tasks;

namespace Spring.Social.Readability.Api
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
