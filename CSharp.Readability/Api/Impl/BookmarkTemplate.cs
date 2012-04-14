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
using System.Net;
using System.Collections.Generic;
using System.Collections.Specialized;

using Spring.Http;
using Spring.Rest.Client;
using System.Threading.Tasks;

namespace Spring.Social.Readability.Api.Impl
{
	/// <summary>
	/// Implementation of <see cref="IBookmarkOperations"/>, providing binding to Readabilitys' bookmark-oriented REST resources.
	/// </summary>
	/// <author>Scott Smith</author>
	class BookmarkTemplate : AbstractReadabilityOperations, IBookmarkOperations
	{
		private RestTemplate restTemplate;

		public BookmarkTemplate(RestTemplate restTemplate, bool isAuthorized)
			: base(isAuthorized)
		{
			this.restTemplate = restTemplate;
		}

		#region IBookmarkOperations Members

		public Bookmark GetBookmark(int bookmarkId)
		{
			this.EnsureIsAuthorized();
			return this.restTemplate.GetForObject<Bookmark>("bookmarks/" + bookmarkId.ToString());
		}

		public Task<Bookmark> GetBookmarkAsync(int bookmarkId)
		{
			this.EnsureIsAuthorized();
			return this.restTemplate.GetForObjectAsync<Bookmark>("bookmarks/" + bookmarkId.ToString());
		}

		public BookmarkCollection GetAllBookmarks(int page = 1, int perPage = 20, 
			string order = "-date_added", string domain = "", 
			DateTime? addedSince = null, DateTime? addedUntil = null,
			DateTime? openedSince = null, DateTime? openedUntil = null, 
			DateTime? archivedSince = null, DateTime? archivedUntil = null,
			DateTime? favoritedSince = null, DateTime? favoritedUntil = null, 
			DateTime? updatedSince = null, DateTime? updatedUntil = null)
		{
			this.EnsureIsAuthorized();
			NameValueCollection parameters = new NameValueCollection();
			if (!String.IsNullOrEmpty(domain)) parameters.Add("domain", domain);
			if (addedSince.HasValue) parameters.Add("added_since", addedSince.Value.ToString());
			if (addedUntil.HasValue) parameters.Add("added_until", addedUntil.Value.ToString());
			if (openedSince.HasValue) parameters.Add("opened_since", openedSince.Value.ToString());
			if (openedUntil.HasValue) parameters.Add("opened_until", openedUntil.Value.ToString());
			if (archivedSince.HasValue) parameters.Add("archived_since", archivedSince.Value.ToString());
			if (archivedUntil.HasValue) parameters.Add("archived_until", archivedUntil.Value.ToString());
			if (favoritedSince.HasValue) parameters.Add("favorited_since", favoritedSince.Value.ToString());
			if (favoritedUntil.HasValue) parameters.Add("favorited_until", favoritedUntil.Value.ToString());
			if (updatedSince.HasValue) parameters.Add("updated_since", updatedSince.Value.ToString());
			if (updatedUntil.HasValue) parameters.Add("updated_until", updatedUntil.Value.ToString());
			parameters.Add("order", order);
			parameters.Add("page", page.ToString());
			parameters.Add("per_page", perPage.ToString());
			return this.restTemplate.GetForObject<BookmarkCollection>(BuildUrl("bookmarks", parameters));
		}

		public Task<BookmarkCollection> GetAllBookmarksAsync(int page = 1, int perPage = 20,
			string order = "-date_added", string domain = "",
			DateTime? addedSince = null, DateTime? addedUntil = null,
			DateTime? openedSince = null, DateTime? openedUntil = null,
			DateTime? archivedSince = null, DateTime? archivedUntil = null,
			DateTime? favoritedSince = null, DateTime? favoritedUntil = null,
			DateTime? updatedSince = null, DateTime? updatedUntil = null)
		{
			this.EnsureIsAuthorized();
			NameValueCollection parameters = new NameValueCollection();
			if (!String.IsNullOrEmpty(domain)) parameters.Add("domain", domain);
			if (addedSince.HasValue) parameters.Add("added_since", addedSince.Value.ToString());
			if (addedUntil.HasValue) parameters.Add("added_until", addedUntil.Value.ToString());
			if (openedSince.HasValue) parameters.Add("opened_since", openedSince.Value.ToString());
			if (openedUntil.HasValue) parameters.Add("opened_until", openedUntil.Value.ToString());
			if (archivedSince.HasValue) parameters.Add("archived_since", archivedSince.Value.ToString());
			if (archivedUntil.HasValue) parameters.Add("archived_until", archivedUntil.Value.ToString());
			if (favoritedSince.HasValue) parameters.Add("favorited_since", favoritedSince.Value.ToString());
			if (favoritedUntil.HasValue) parameters.Add("favorited_until", favoritedUntil.Value.ToString());
			if (updatedSince.HasValue) parameters.Add("updated_since", updatedSince.Value.ToString());
			if (updatedUntil.HasValue) parameters.Add("updated_until", updatedUntil.Value.ToString());
			parameters.Add("order", order);
			parameters.Add("page", page.ToString());
			parameters.Add("per_page", perPage.ToString());
			return this.restTemplate.GetForObjectAsync<BookmarkCollection>(BuildUrl("bookmarks", parameters));
		}

		public BookmarkCollection GetReadingListBookmarks(int page = 1, int perPage = 20,
			string order = "-date_added", string domain = "",
			DateTime? addedSince = null, DateTime? addedUntil = null,
			DateTime? openedSince = null, DateTime? openedUntil = null,
			DateTime? archivedSince = null, DateTime? archivedUntil = null,
			DateTime? favoritedSince = null, DateTime? favoritedUntil = null,
			DateTime? updatedSince = null, DateTime? updatedUntil = null)
		{
			this.EnsureIsAuthorized();
			NameValueCollection parameters = new NameValueCollection();
			parameters.Add("archive", "0");
			if (!String.IsNullOrEmpty(domain)) parameters.Add("domain", domain);
			if (addedSince.HasValue) parameters.Add("added_since", addedSince.Value.ToString());
			if (addedUntil.HasValue) parameters.Add("added_until", addedUntil.Value.ToString());
			if (openedSince.HasValue) parameters.Add("opened_since", openedSince.Value.ToString());
			if (openedUntil.HasValue) parameters.Add("opened_until", openedUntil.Value.ToString());
			if (archivedSince.HasValue) parameters.Add("archived_since", archivedSince.Value.ToString());
			if (archivedUntil.HasValue) parameters.Add("archived_until", archivedUntil.Value.ToString());
			if (favoritedSince.HasValue) parameters.Add("favorited_since", favoritedSince.Value.ToString());
			if (favoritedUntil.HasValue) parameters.Add("favorited_until", favoritedUntil.Value.ToString());
			if (updatedSince.HasValue) parameters.Add("updated_since", updatedSince.Value.ToString());
			if (updatedUntil.HasValue) parameters.Add("updated_until", updatedUntil.Value.ToString());
			parameters.Add("order", order);
			parameters.Add("page", page.ToString());
			parameters.Add("per_page", perPage.ToString());
			return this.restTemplate.GetForObject<BookmarkCollection>(BuildUrl("bookmarks", parameters));
		}

		public Task<BookmarkCollection> GetReadingListBookmarksAsync(int page = 1, int perPage = 20,
			string order = "-date_added", string domain = "",
			DateTime? addedSince = null, DateTime? addedUntil = null,
			DateTime? openedSince = null, DateTime? openedUntil = null,
			DateTime? archivedSince = null, DateTime? archivedUntil = null,
			DateTime? favoritedSince = null, DateTime? favoritedUntil = null,
			DateTime? updatedSince = null, DateTime? updatedUntil = null)
		{
			this.EnsureIsAuthorized();
			NameValueCollection parameters = new NameValueCollection();
			parameters.Add("archive", "0");
			if (!String.IsNullOrEmpty(domain)) parameters.Add("domain", domain);
			if (addedSince.HasValue) parameters.Add("added_since", addedSince.Value.ToString());
			if (addedUntil.HasValue) parameters.Add("added_until", addedUntil.Value.ToString());
			if (openedSince.HasValue) parameters.Add("opened_since", openedSince.Value.ToString());
			if (openedUntil.HasValue) parameters.Add("opened_until", openedUntil.Value.ToString());
			if (archivedSince.HasValue) parameters.Add("archived_since", archivedSince.Value.ToString());
			if (archivedUntil.HasValue) parameters.Add("archived_until", archivedUntil.Value.ToString());
			if (favoritedSince.HasValue) parameters.Add("favorited_since", favoritedSince.Value.ToString());
			if (favoritedUntil.HasValue) parameters.Add("favorited_until", favoritedUntil.Value.ToString());
			if (updatedSince.HasValue) parameters.Add("updated_since", updatedSince.Value.ToString());
			if (updatedUntil.HasValue) parameters.Add("updated_until", updatedUntil.Value.ToString());
			parameters.Add("order", order);
			parameters.Add("page", page.ToString());
			parameters.Add("per_page", perPage.ToString());
			return this.restTemplate.GetForObjectAsync<BookmarkCollection>(BuildUrl("bookmarks", parameters));
		}

		public BookmarkCollection GetArchivedBookmarks(int page = 1, int perPage = 20,
			string order = "-date_added", string domain = "",
			DateTime? addedSince = null, DateTime? addedUntil = null,
			DateTime? openedSince = null, DateTime? openedUntil = null,
			DateTime? archivedSince = null, DateTime? archivedUntil = null,
			DateTime? favoritedSince = null, DateTime? favoritedUntil = null,
			DateTime? updatedSince = null, DateTime? updatedUntil = null)
		{
			this.EnsureIsAuthorized();
			NameValueCollection parameters = new NameValueCollection();
			parameters.Add("archive", "1");
			if (!String.IsNullOrEmpty(domain)) parameters.Add("domain", domain);
			if (addedSince.HasValue) parameters.Add("added_since", addedSince.Value.ToString());
			if (addedUntil.HasValue) parameters.Add("added_until", addedUntil.Value.ToString());
			if (openedSince.HasValue) parameters.Add("opened_since", openedSince.Value.ToString());
			if (openedUntil.HasValue) parameters.Add("opened_until", openedUntil.Value.ToString());
			if (archivedSince.HasValue) parameters.Add("archived_since", archivedSince.Value.ToString());
			if (archivedUntil.HasValue) parameters.Add("archived_until", archivedUntil.Value.ToString());
			if (favoritedSince.HasValue) parameters.Add("favorited_since", favoritedSince.Value.ToString());
			if (favoritedUntil.HasValue) parameters.Add("favorited_until", favoritedUntil.Value.ToString());
			if (updatedSince.HasValue) parameters.Add("updated_since", updatedSince.Value.ToString());
			if (updatedUntil.HasValue) parameters.Add("updated_until", updatedUntil.Value.ToString());
			parameters.Add("order", order);
			parameters.Add("page", page.ToString());
			parameters.Add("per_page", perPage.ToString());
			return this.restTemplate.GetForObject<BookmarkCollection>(BuildUrl("bookmarks", parameters));
		}

		public Task<BookmarkCollection> GetArchivedBookmarksAsync(int page = 1, int perPage = 20,
			string order = "-date_added", string domain = "",
			DateTime? addedSince = null, DateTime? addedUntil = null,
			DateTime? openedSince = null, DateTime? openedUntil = null,
			DateTime? archivedSince = null, DateTime? archivedUntil = null,
			DateTime? favoritedSince = null, DateTime? favoritedUntil = null,
			DateTime? updatedSince = null, DateTime? updatedUntil = null)
		{
			this.EnsureIsAuthorized();
			NameValueCollection parameters = new NameValueCollection();
			parameters.Add("archive", "1");
			if (!String.IsNullOrEmpty(domain)) parameters.Add("domain", domain);
			if (addedSince.HasValue) parameters.Add("added_since", addedSince.Value.ToString());
			if (addedUntil.HasValue) parameters.Add("added_until", addedUntil.Value.ToString());
			if (openedSince.HasValue) parameters.Add("opened_since", openedSince.Value.ToString());
			if (openedUntil.HasValue) parameters.Add("opened_until", openedUntil.Value.ToString());
			if (archivedSince.HasValue) parameters.Add("archived_since", archivedSince.Value.ToString());
			if (archivedUntil.HasValue) parameters.Add("archived_until", archivedUntil.Value.ToString());
			if (favoritedSince.HasValue) parameters.Add("favorited_since", favoritedSince.Value.ToString());
			if (favoritedUntil.HasValue) parameters.Add("favorited_until", favoritedUntil.Value.ToString());
			if (updatedSince.HasValue) parameters.Add("updated_since", updatedSince.Value.ToString());
			if (updatedUntil.HasValue) parameters.Add("updated_until", updatedUntil.Value.ToString());
			parameters.Add("order", order);
			parameters.Add("page", page.ToString());
			parameters.Add("per_page", perPage.ToString());
			return this.restTemplate.GetForObjectAsync<BookmarkCollection>(BuildUrl("bookmarks", parameters));
		}

		public BookmarkCollection GetDeletedBookmarks(int page = 1, int perPage = 20,
			string order = "-date_added", string domain = "",
			DateTime? addedSince = null, DateTime? addedUntil = null,
			DateTime? openedSince = null, DateTime? openedUntil = null,
			DateTime? archivedSince = null, DateTime? archivedUntil = null,
			DateTime? favoritedSince = null, DateTime? favoritedUntil = null,
			DateTime? updatedSince = null, DateTime? updatedUntil = null)
		{
			this.EnsureIsAuthorized();
			NameValueCollection parameters = new NameValueCollection();
			parameters.Add("only_deleted", "1");
			if (!String.IsNullOrEmpty(domain)) parameters.Add("domain", domain);
			if (addedSince.HasValue) parameters.Add("added_since", addedSince.Value.ToString());
			if (addedUntil.HasValue) parameters.Add("added_until", addedUntil.Value.ToString());
			if (openedSince.HasValue) parameters.Add("opened_since", openedSince.Value.ToString());
			if (openedUntil.HasValue) parameters.Add("opened_until", openedUntil.Value.ToString());
			if (archivedSince.HasValue) parameters.Add("archived_since", archivedSince.Value.ToString());
			if (archivedUntil.HasValue) parameters.Add("archived_until", archivedUntil.Value.ToString());
			if (favoritedSince.HasValue) parameters.Add("favorited_since", favoritedSince.Value.ToString());
			if (favoritedUntil.HasValue) parameters.Add("favorited_until", favoritedUntil.Value.ToString());
			if (updatedSince.HasValue) parameters.Add("updated_since", updatedSince.Value.ToString());
			if (updatedUntil.HasValue) parameters.Add("updated_until", updatedUntil.Value.ToString());
			parameters.Add("order", order);
			parameters.Add("page", page.ToString());
			parameters.Add("per_page", perPage.ToString());
			return this.restTemplate.GetForObject<BookmarkCollection>(BuildUrl("bookmarks", parameters));
		}

		public Task<BookmarkCollection> GetDeletedBookmarksAsync(int page = 1, int perPage = 20,
			string order = "-date_added", string domain = "",
			DateTime? addedSince = null, DateTime? addedUntil = null,
			DateTime? openedSince = null, DateTime? openedUntil = null,
			DateTime? archivedSince = null, DateTime? archivedUntil = null,
			DateTime? favoritedSince = null, DateTime? favoritedUntil = null,
			DateTime? updatedSince = null, DateTime? updatedUntil = null)
		{
			this.EnsureIsAuthorized();
			NameValueCollection parameters = new NameValueCollection();
			parameters.Add("only_deleted", "1");
			if (!String.IsNullOrEmpty(domain)) parameters.Add("domain", domain);
			if (addedSince.HasValue) parameters.Add("added_since", addedSince.Value.ToString());
			if (addedUntil.HasValue) parameters.Add("added_until", addedUntil.Value.ToString());
			if (openedSince.HasValue) parameters.Add("opened_since", openedSince.Value.ToString());
			if (openedUntil.HasValue) parameters.Add("opened_until", openedUntil.Value.ToString());
			if (archivedSince.HasValue) parameters.Add("archived_since", archivedSince.Value.ToString());
			if (archivedUntil.HasValue) parameters.Add("archived_until", archivedUntil.Value.ToString());
			if (favoritedSince.HasValue) parameters.Add("favorited_since", favoritedSince.Value.ToString());
			if (favoritedUntil.HasValue) parameters.Add("favorited_until", favoritedUntil.Value.ToString());
			if (updatedSince.HasValue) parameters.Add("updated_since", updatedSince.Value.ToString());
			if (updatedUntil.HasValue) parameters.Add("updated_until", updatedUntil.Value.ToString());
			parameters.Add("order", order);
			parameters.Add("page", page.ToString());
			parameters.Add("per_page", perPage.ToString());
			return this.restTemplate.GetForObjectAsync<BookmarkCollection>(BuildUrl("bookmarks", parameters));
		}

		public BookmarkCollection GetFavoriteBookmarks(int page = 1, int perPage = 20,
			string order = "-date_added", string domain = "",
			DateTime? addedSince = null, DateTime? addedUntil = null,
			DateTime? openedSince = null, DateTime? openedUntil = null,
			DateTime? archivedSince = null, DateTime? archivedUntil = null,
			DateTime? favoritedSince = null, DateTime? favoritedUntil = null,
			DateTime? updatedSince = null, DateTime? updatedUntil = null)
		{
			this.EnsureIsAuthorized();
			NameValueCollection parameters = new NameValueCollection();
			parameters.Add("favorite", "1");
			if (!String.IsNullOrEmpty(domain)) parameters.Add("domain", domain);
			if (addedSince.HasValue) parameters.Add("added_since", addedSince.Value.ToString());
			if (addedUntil.HasValue) parameters.Add("added_until", addedUntil.Value.ToString());
			if (openedSince.HasValue) parameters.Add("opened_since", openedSince.Value.ToString());
			if (openedUntil.HasValue) parameters.Add("opened_until", openedUntil.Value.ToString());
			if (archivedSince.HasValue) parameters.Add("archived_since", archivedSince.Value.ToString());
			if (archivedUntil.HasValue) parameters.Add("archived_until", archivedUntil.Value.ToString());
			if (favoritedSince.HasValue) parameters.Add("favorited_since", favoritedSince.Value.ToString());
			if (favoritedUntil.HasValue) parameters.Add("favorited_until", favoritedUntil.Value.ToString());
			if (updatedSince.HasValue) parameters.Add("updated_since", updatedSince.Value.ToString());
			if (updatedUntil.HasValue) parameters.Add("updated_until", updatedUntil.Value.ToString());
			parameters.Add("order", order);
			parameters.Add("page", page.ToString());
			parameters.Add("per_page", perPage.ToString());
			return this.restTemplate.GetForObject<BookmarkCollection>(BuildUrl("bookmarks", parameters));
		}

		public Task<BookmarkCollection> GetFavoriteBookmarksAsync(int page = 1, int perPage = 20,
			string order = "-date_added", string domain = "",
			DateTime? addedSince = null, DateTime? addedUntil = null,
			DateTime? openedSince = null, DateTime? openedUntil = null,
			DateTime? archivedSince = null, DateTime? archivedUntil = null,
			DateTime? favoritedSince = null, DateTime? favoritedUntil = null,
			DateTime? updatedSince = null, DateTime? updatedUntil = null)
		{
			this.EnsureIsAuthorized();
			NameValueCollection parameters = new NameValueCollection();
			parameters.Add("favorite", "1");
			if (!String.IsNullOrEmpty(domain)) parameters.Add("domain", domain);
			if (addedSince.HasValue) parameters.Add("added_since", addedSince.Value.ToString());
			if (addedUntil.HasValue) parameters.Add("added_until", addedUntil.Value.ToString());
			if (openedSince.HasValue) parameters.Add("opened_since", openedSince.Value.ToString());
			if (openedUntil.HasValue) parameters.Add("opened_until", openedUntil.Value.ToString());
			if (archivedSince.HasValue) parameters.Add("archived_since", archivedSince.Value.ToString());
			if (archivedUntil.HasValue) parameters.Add("archived_until", archivedUntil.Value.ToString());
			if (favoritedSince.HasValue) parameters.Add("favorited_since", favoritedSince.Value.ToString());
			if (favoritedUntil.HasValue) parameters.Add("favorited_until", favoritedUntil.Value.ToString());
			if (updatedSince.HasValue) parameters.Add("updated_since", updatedSince.Value.ToString());
			if (updatedUntil.HasValue) parameters.Add("updated_until", updatedUntil.Value.ToString());
			parameters.Add("order", order);
			parameters.Add("page", page.ToString());
			parameters.Add("per_page", perPage.ToString());
			return this.restTemplate.GetForObjectAsync<BookmarkCollection>(BuildUrl("bookmarks", parameters));
		}

		public Uri AddBookmark(string url, bool favorite = false, bool archived = false)
		{
			this.EnsureIsAuthorized();
			NameValueCollection parameters = new NameValueCollection();
			parameters.Add("url", url);
			if (favorite) parameters.Add("favorite", "1");
			if (archived) parameters.Add("archive", "1");
			return this.restTemplate.PostForLocation("bookmarks", parameters);
		}

		public Task<Uri> AddBookmarkAsync(string url, bool favorite = false, bool archived = false)
		{
			this.EnsureIsAuthorized();
			NameValueCollection parameters = new NameValueCollection();
			parameters.Add("url", url);
			if (favorite) parameters.Add("favorite", "1");
			if (archived) parameters.Add("archive", "1");
			return this.restTemplate.PostForLocationAsync("bookmarks", parameters);
		}

		public HttpResponseMessage UpdateBookmark(int bookmarkId, bool favorite = false, bool archive = false, double? readPercent = null, DateTime? dateOpened = null)
		{
			this.EnsureIsAuthorized();
			NameValueCollection parameters = new NameValueCollection();
			if (favorite) parameters.Add("favorite", "1"); else parameters.Add("favorite", "0");
			if (archive) parameters.Add("archive", "1"); else parameters.Add("archive", "0");
			if (readPercent.HasValue) parameters.Add("read_percent", readPercent.ToString());
			if (dateOpened.HasValue) parameters.Add("date_opened", dateOpened.Value.ToString());
			return this.restTemplate.PostForMessage("bookmarks/" + bookmarkId, parameters);
		}

		public Task<HttpResponseMessage> UpdateBookmarkAsync(int bookmarkId, bool favorite = false, bool archive = false, double? readPercent = 0.0, DateTime? dateOpened = null)
		{
			this.EnsureIsAuthorized();
			NameValueCollection parameters = new NameValueCollection();
			if (favorite) parameters.Add("favorite", "1"); else parameters.Add("favorite", "0");
			if (archive) parameters.Add("archive", "1"); else parameters.Add("archive", "0");
			if (readPercent.HasValue) parameters.Add("read_percent", readPercent.ToString());
			if (dateOpened.HasValue) parameters.Add("date_opened", dateOpened.Value.ToString());
			return this.restTemplate.PostForMessageAsync("bookmarks/" + bookmarkId, parameters);
		}

		public void DeleteBookmark(int bookmarkId)
		{
			this.EnsureIsAuthorized();
			this.restTemplate.Delete("bookmarks/" + bookmarkId);
		}

		public Task DeleteBookmarkAsync(int bookmarkId)
		{
			this.EnsureIsAuthorized();
			return this.restTemplate.DeleteAsync("bookmarks/" + bookmarkId);
		}

		#endregion

		#region Private Methods



		#endregion
	}
}