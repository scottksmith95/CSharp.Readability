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

namespace Spring.Social.Readability.Api
{
	/// <summary>
	/// Represents a Readability article.
	/// </summary>
	/// <author>Scott Smith</author>
	[Serializable]
	public class Article
	{
		/// <summary>
		/// Gets or sets the id. ("id")
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets the author. ("author")
		/// </summary>
		public string Author { get; set; }

		/// <summary>
		/// Gets or sets the content. ("content")
		/// </summary>
		public string Content { get; set; }

		/// <summary>
		/// Gets or sets the content size. ("content_size")
		/// </summary>
		public int ContentSize { get; set; }

		/// <summary>
		/// Gets or sets the published date. ("date_published")
		/// </summary>
		public DateTime Published { get; set; }

		/// <summary>
		/// Gets or sets the domain. ("domain")
		/// </summary>
		public string Domain { get; set; }

		/// <summary>
		/// Gets or sets the next page href. ("next_page_href")
		/// </summary>
		public string NextPageHref { get; set; }

		/// <summary>
		/// Gets or sets the short url. ("short_url")
		/// </summary>
		public string ShortUrl { get; set; }

		/// <summary>
		/// Gets or sets the title. ("title")
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the url. ("url")
		/// </summary>
		public string Url { get; set; }

		/// <summary>
		/// Gets or sets the direction. ("direction")
		/// </summary>
		public string Direction { get; set; }

		/// <summary>
		/// Gets or sets the word count. ("word_count")
		/// </summary>
		public int WordCount { get; set; }

		/// <summary>
		/// Gets or sets the processed. ("processed")
		/// </summary>
		public bool Processed { get; set; }
	}
}
