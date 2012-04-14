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

namespace CSharp.Readability.Api.Models
{
	/// <summary>
	/// Represents a Readability bookmark.
	/// </summary>
	/// <author>Scott Smith</author>
	[Serializable]
	public class Bookmark
	{
		/// <summary>
		/// Gets or sets the user id. ("user_id")
		/// </summary>
		public int UserId { get; set; }

		/// <summary>
		/// Gets or sets the read percent. ("read_percent")
		/// </summary>
		public decimal ReadPercent { get; set; }

		/// <summary>
		/// Gets or sets the date updated. ("date_updated")
		/// </summary>
		public DateTime Updated { get; set; }

		/// <summary>
		/// Gets or sets the favorite state. ("favorite")
		/// </summary>
		public bool Favorite { get; set; }

		/// <summary>
		/// Gets or sets the article. ("article")
		/// </summary>
		public BookmarkArticle Article { get; set; }

		/// <summary>
		/// Gets or sets the deleted flag. ("deleted")
		/// </summary>
		public bool Deleted { get; set; }

		/// <summary>
		/// Gets or sets the id. ("id")
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the date archived. ("date_archived")
		/// </summary>
		public DateTime? Archived { get; set; }

		/// <summary>
		/// Gets or sets the date opened. ("date_opened")
		/// </summary>
		public DateTime? Opened { get; set; }

		/// <summary>
		/// Gets or sets the date added. ("date_added")
		/// </summary>
		public DateTime Added { get; set; }

		/// <summary>
		/// Gets or sets the article href. ("article_href")
		/// </summary>
		public string ArticleHref { get; set; }

		/// <summary>
		/// Gets or sets the date favorited. ("date_favorited")
		/// </summary>
		public DateTime? Favorited { get; set; }

		/// <summary>
		/// Gets or sets the archive state. ("archive")
		/// </summary>
		public bool Archive { get; set; }
	}
}
