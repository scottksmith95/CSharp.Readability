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
using System.Globalization;
using Spring.Json;

namespace Spring.Social.Readability.Api.Impl.Json
{
	/// <summary>
	/// JSON deserializer for bookmark collections
	/// </summary>
	/// <author>Scott Smith</author>
	class BookmarkCollectionDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			return new BookmarkCollection
			{
				Condition = mapper.Deserialize<BookmarkCondition>(value.GetValue("conditions")),
				Meta = mapper.Deserialize<Meta>(value.GetValue("meta")),
				Bookmarks = mapper.Deserialize<IList<Bookmark>>(value.GetValue("bookmarks"))
			};
		}
	}

	/// <summary>
	/// JSON deserializer for bookmark condition
	/// </summary>
	/// <author>Scott Smith</author>
	class BookmarkConditionDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			return new BookmarkCondition
			{
				OpenedSince = value.GetValue<DateTime?>("opened_since"),
				AddedUntil = value.GetValue<DateTime?>("added_until"),
				OpenedUntil = value.GetValue<DateTime?>("opened_until"),
				ArchivedUntil = value.GetValue<DateTime?>("archived_until"),
				Favorite = value.GetValue<int?>("favorite"),
				ArchivedSince = value.GetValue<DateTime?>("archived_since"),
				FavoritedSince = value.GetValue<DateTime?>("favorited_since"),
				User = value.GetValue<string>("user"),
				PerPage = value.GetValue<int>("per_page"),
				FavoritedUntil = value.GetValue<DateTime?>("favorited_until"),
				Archive = value.GetValue<int?>("archive"),
				AddedSince = value.GetValue<DateTime?>("added_since"),
				Order = value.GetValue<string>("order"),
				Page = value.GetValue<int>("page"),
				UpdatedSince = value.GetValue<DateTime?>("updated_since"),
				UpdatedUntil = value.GetValue<DateTime?>("updated_until"),
				Domain = value.GetValue<string>("domain"),
				ExcludeAccessibility = value.GetValue<string>("exclude_accessibility"),
				OnlyDeleted = value.GetValue<int?>("only_deleted")
			};
		}
	}

	/// <summary>
	/// JSON deserializer for bookmark meta
	/// </summary>
	/// <author>Scott Smith</author>
	class MetaDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			return new Meta()
			{
				NumberOfPages = value.GetValue<int>("num_pages"),
				Page = value.GetValue<int>("page"),
				ItemCountTotal = value.GetValue<int>("item_count_total"),
				ItemCount = value.GetValue<int>("item_count"),
			};
		}
	}

	/// <summary>
	/// JSON deserializer for list of bookmarks
	/// </summary>
	/// <author>Scott Smith</author>
	class BookmarkListDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			IList<Bookmark> bookmarks = new List<Bookmark>();
			foreach (JsonValue itemValue in value.GetValues())
			{
				bookmarks.Add(mapper.Deserialize<Bookmark>(itemValue));
			}
			return bookmarks;
		}
	}

	/// <summary>
	/// JSON deserializer for a bookmark
	/// </summary>
	/// <author>Scott Smith</author>
	class BookmarkDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			var Deleted = false;
			if (value.ContainsName("deleted"))
				Deleted = value.GetValue<bool>("deleted");

			return new Bookmark()
			{
				UserId = value.GetValue<int>("user_id"),
				ReadPercent = value.GetValue<decimal>("read_percent"),
				Updated = value.GetValue<DateTime>("date_updated"),
				Favorite = value.GetValue<bool>("favorite"),
				Article = mapper.Deserialize<BookmarkArticle>(value.GetValue("article")),
				Deleted = Deleted,
				Id = value.GetValue<int>("id"),
				Archived = value.GetValue<DateTime?>("date_archived"),
				Opened = value.GetValue<DateTime?>("date_opened"),
				Added = value.GetValue<DateTime>("date_added"),
				ArticleHref = value.GetValue<string>("article_href"),
				Favorited = value.GetValue<DateTime?>("date_favorited"),
				Archive = value.GetValue<bool>("archive"),
			};
		}
	}

	/// <summary>
	/// JSON deserializer for a bookmark article
	/// </summary>
	/// <author>Scott Smith</author>
	class BookmarkArticleDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			if (value.IsNull)
				return null;

			return new BookmarkArticle()
			{
				Url = value.GetValue<string>("url"),
				Domain = value.GetValue<string>("domain"),
				Excerpt = value.GetValue<string>("excerpt"),
				WordCount = value.GetValue<int>("word_count"),
				Processed = value.GetValue<bool>("processed"),
				Id = value.GetValue<string>("id"),
				Title = value.GetValue<string>("title"),
				Author = value.GetValue<string>("author"),
				Direction = value.GetValue<string>("direction"),
				Published = value.GetValue<DateTime>("date_published"),
			};
		}
	}
}