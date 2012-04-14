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
	/// Represents a Readability bookmark condition.
	/// </summary>
	/// <author>Scott Smith</author>
	[Serializable]
	public class BookmarkCondition
	{
		/// <summary>
		/// Gets or sets the opened since date. ("opened_since")
		/// </summary>
		public DateTime? OpenedSince { get; set; }

		/// <summary>
		/// Gets or sets the added until date. ("added_until")
		/// </summary>
		public DateTime? AddedUntil { get; set; }

		/// <summary>
		/// Gets or sets the opened until date. ("opened_until")
		/// </summary>
		public DateTime? OpenedUntil { get; set; }

		/// <summary>
		/// Gets or sets the archived until date. ("archived_until")
		/// </summary>
		public DateTime? ArchivedUntil { get; set; }

		/// <summary>
		/// Gets or sets the favorite state. ("favorite")
		/// </summary>
		public int? Favorite { get; set; }

		/// <summary>
		/// Gets or sets the archives since date. ("archived_since")
		/// </summary>
		public DateTime? ArchivedSince { get; set; }

		/// <summary>
		/// Gets or sets the favorited since date. ("favorited_since")
		/// </summary>
		public DateTime? FavoritedSince { get; set; }

		/// <summary>
		/// Gets or sets the user. ("user")
		/// </summary>
		public string User { get; set; }

		/// <summary>
		/// Gets or sets the per page. ("per_page")
		/// </summary>
		public int PerPage { get; set; }

		/// <summary>
		/// Gets or sets the favorited until date. ("favorited_until")
		/// </summary>
		public DateTime? FavoritedUntil { get; set; }

		/// <summary>
		/// Gets or sets the archive state. ("archive")
		/// </summary>
		public int? Archive { get; set; }

		/// <summary>
		/// Gets or sets the added since date. ("added_since")
		/// </summary>
		public DateTime? AddedSince { get; set; }

		/// <summary>
		/// Gets or sets the order. ("order")
		/// </summary>
		public string Order { get; set; }

		/// <summary>
		/// Gets or sets the page. ("page")
		/// </summary>
		public int Page { get; set; }

		/// <summary>
		/// Gets or sets the updated since date. ("updated_since")
		/// </summary>
		public DateTime? UpdatedSince { get; set; }

		/// <summary>
		/// Gets or sets the updated until date. ("updated_until")
		/// </summary>
		public DateTime? UpdatedUntil { get; set; }

		/// <summary>
		/// Gets or sets the domain. This only exists in deleted bookmarks. ("domain")
		/// </summary>
		public string Domain { get; set; }

		/// <summary>
		/// Gets or sets the exclude accessibility. This only exists in deleted bookmarks. ("exclude_accessibility")
		/// </summary>
		public string ExcludeAccessibility { get; set; }

		/// <summary>
		/// Gets or sets the only delete flag. This only exists in deleted bookmarks. ("only_deleted")
		/// </summary>
		public int? OnlyDeleted { get; set; }
	}
}
