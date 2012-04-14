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
Normal
{
    "conditions": {
        "opened_since": null,
        "added_until": null,
        "opened_until": null,
        "archived_until": null,
        "favorite": null,
        "archived_since": null,
        "favorited_since": null,
        "user": "jdoe",
        "per_page": 2,
        "favorited_until": null,
        "archive": null,
        "added_since": null,
        "order": "-date_added",
        "page": 1,
        "updated_since": null,
        "updated_until": null
    },
    "meta": {
        "num_pages": 38,
        "page": 1,
        "item_count_total": 76,
        "item_count": 2
    },
    "bookmarks": [
        {
            "user_id": 1,
            "read_percent": "0.0",
            "date_updated": "2010-10-12 11:38:39",
            "favorite": false,
            "article": {
                "url": "http://www.adobe.com/devnet/flex/articles/flex4_sparkintro.html",
                "domain": "adobe.com",
                "excerpt": "This is an excerpt of the article text, 200 chars or less &hellip;",
                "word_count": 3482,
                "processed": true,
                "id": 87,
                "title": "A brief overview of the Spark architecture and component set"
            },
            "id": 76,
            "date_archived": null,
            "date_opened": null,
            "date_added": "2010-10-12 11:38:29",
            "article_href": "/api/rest/v1/articles/87/",
            "date_favorited": null,
            "archive": false
        },
        {
            "user_id": 1,
            "read_percent": "0.13",
            "date_updated": "2010-10-12 11:04:46",
            "favorite": false,
            "article": {
                "url": "http://www.w3.org/Submission/wadl/?q=7",
                "domain": "w3.org",
                "excerpt": "This is an excerpt of the article text, 200 chars or less &hellip;",
                "word_count": 3482,
                "processed": true,
                "id": 86,
                "title": "Web Application Description Language"
            },
            "id": 75,
            "date_archived": null,
            "date_opened": null,
            "date_added": "2010-10-12 11:04:46",
            "article_href": "/api/rest/v1/articles/86/",
            "date_favorited": null,
            "archive": false
        }
    ]
}

Deleted
{
    "bookmarks": [
        {
            "user_id": 1, 
            "read_percent": "0.00", 
            "date_updated": "2011-12-07 13:42:06", 
            "favorite": true, 
            "article": null, 
            "id": 486, 
            "date_archived": null, 
            "deleted": true, 
            "date_opened": null, 
            "date_added": "2011-12-05 17:27:32", 
            "article_href": null, 
            "date_favorited": "2011-12-05 17:37:45", 
            "archive": false
        }, 
        {
            "user_id": 1, 
            "read_percent": "0.00", 
            "date_updated": "2011-12-12 09:43:54", 
            "favorite": false, 
            "article": null, 
            "id": 481, 
            "date_archived": null, 
            "deleted": true, 
            "date_opened": null, 
            "date_added": "2011-02-23 00:00:00", 
            "article_href": null, 
            "date_favorited": null, 
            "archive": false
        }
    ], 
    "meta": {
        "num_pages": 1, 
        "page": 1, 
        "item_count_total": 2, 
        "item_count": 2
    }, 
    "conditions": {
        "opened_since": null, 
        "favorited_since": null, 
        "domain": "", 
        "updated_until": null, 
        "exclude_accessibility": "", 
        "archived_until": null, 
        "favorite": null, 
        "opened_until": null, 
        "archived_since": null, 
        "added_until": null, 
        "updated_since": null, 
        "user": "jdoe", 
        "per_page": 20, 
        "favorited_until": null, 
        "order": "-date_added", 
        "only_deleted": 1, 
        "archive": null, 
        "added_since": null, 
        "page": 1
    }
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
	/// Interface defining the operations for searching Readability and retrieving bookmark data.
	/// </summary>
	/// <author>Scott Smith</author>
	public interface IBookmarkOperations
	{
		/// <summary>
		/// Retrieve a single Bookmark, including its content.
		/// </summary>
		/// <param name="bookmarkId">The id of the bookmark to return.</param>
		/// <returns>An <see cref="Bookmark"/> with the supplied bookmarkId</returns>
		/// <exception cref="ReadabilityApiException">If there is an error while communicating with Readability.</exception>
		/// <exception cref="ReadabilityApiException">If OAuth credentials was not provided.</exception>
		Bookmark GetBookmark(int bookmarkId);

		/// <summary>
		/// Asynchronously retrieve a single Bookmark, including its content.
		/// </summary>
		/// <param name="bookmarkId">The id of the bookmark to return.</param>
		/// <returns>An <see cref="Bookmark"/> with the supplied bookmarkId.</returns>
		/// <exception cref="ReadabilityApiException">If there is an error while communicating with Readability.</exception>
		/// <exception cref="ReadabilityApiException">If OAuth credentials was not provided.</exception>
		Task<Bookmark> GetBookmarkAsync(int bookmarkId);

		/// <summary>
		/// Retrieve all bookmarks from the bookmarks collection.
		/// </summary>
		/// <param name="page">For pagination, what page of the results you are on. Default is 1.</param>
		/// <param name="perPage">For pagination, how many results to return per page. Default is 20. Max is 50.</param>
		/// <param name="order">What to order these bookmarks by. Default is date_added descending (-date_added). One of: -date_added, date_added, -date_updated, or date_updated.</param>
		/// <param name="domain">Filter bookmarks by domain.</param>
		/// <param name="addedSince">Filter bookmarks by date added (since this date).</param>
		/// <param name="addedUntil">Filter bookmarks by date added (until this date).</param>
		/// <param name="openedSince">Filter bookmarks by date opened (since this date).</param>
		/// <param name="openedUntil">Filter bookmarks by date opened (until this date).</param>
		/// <param name="archivedSince">Filter bookmarks by date archived (since this date).</param>
		/// <param name="archivedUntil">Filter bookmarks by date archived (until this date).</param>
		/// <param name="favoritedSince">Filter bookmarks by date favorited (since this date).</param>
		/// <param name="favoritedUntil">Filter bookmarks by date favorited (until this date).</param>
		/// <param name="updatedSince">Filter bookmarks by date updated (since this date).</param>
		/// <param name="updatedUntil">Filter bookmarks by date updated (until this date).</param>
		/// <returns>A list of <see cref="Bookmark"/>.</returns>
		/// <exception cref="ReadabilityApiException">If there is an error while communicating with Readability.</exception>
		/// <exception cref="ReadabilityApiException">If OAuth credentials was not provided.</exception>
		BookmarkCollection GetAllBookmarks(int page = 1, int perPage = 20, 
			string order = "-date_added", string domain = "", 
			DateTime? addedSince = null, DateTime? addedUntil = null, 
			DateTime? openedSince = null, DateTime? openedUntil = null, 
			DateTime? archivedSince = null, DateTime? archivedUntil = null,
			DateTime? favoritedSince = null, DateTime? favoritedUntil = null, 
			DateTime? updatedSince = null, DateTime? updatedUntil = null);

		/// <summary>
		/// Asynchronously retrieve all bookmarks from the bookmarks collection.
		/// </summary>
		/// <param name="page">For pagination, what page of the results you are on. Default is 1.</param>
		/// <param name="perPage">For pagination, how many results to return per page. Default is 20. Max is 50.</param>
		/// <param name="order">What to order these bookmarks by. Default is date_added descending (-date_added). One of: -date_added, date_added, -date_updated, or date_updated.</param>
		/// <param name="domain">Filter bookmarks by domain.</param>
		/// <param name="addedSince">Filter bookmarks by date added (since this date).</param>
		/// <param name="addedUntil">Filter bookmarks by date added (until this date).</param>
		/// <param name="openedSince">Filter bookmarks by date opened (since this date).</param>
		/// <param name="openedUntil">Filter bookmarks by date opened (until this date).</param>
		/// <param name="archivedSince">Filter bookmarks by date archived (since this date).</param>
		/// <param name="archivedUntil">Filter bookmarks by date archived (until this date).</param>
		/// <param name="favoritedSince">Filter bookmarks by date favorited (since this date).</param>
		/// <param name="favoritedUntil">Filter bookmarks by date favorited (until this date).</param>
		/// <param name="updatedSince">Filter bookmarks by date updated (since this date).</param>
		/// <param name="updatedUntil">Filter bookmarks by date updated (until this date).</param>
		/// <returns>A list of <see cref="Bookmark"/>.</returns>
		/// <exception cref="ReadabilityApiException">If there is an error while communicating with Readability.</exception>
		/// <exception cref="ReadabilityApiException">If OAuth credentials was not provided.</exception>
		Task<BookmarkCollection> GetAllBookmarksAsync(int page = 1, int perPage = 20,
			string order = "-date_added", string domain = "",
			DateTime? addedSince = null, DateTime? addedUntil = null,
			DateTime? openedSince = null, DateTime? openedUntil = null,
			DateTime? archivedSince = null, DateTime? archivedUntil = null,
			DateTime? favoritedSince = null, DateTime? favoritedUntil = null,
			DateTime? updatedSince = null, DateTime? updatedUntil = null);

		/// <summary>
		/// Retrieve reading list bookmarks without archived from the bookmarks collection.
		/// </summary>
		/// <param name="page">For pagination, what page of the results you are on. Default is 1.</param>
		/// <param name="perPage">For pagination, how many results to return per page. Default is 20. Max is 50.</param>
		/// <param name="order">What to order these bookmarks by. Default is date_added descending (-date_added). One of: -date_added, date_added, -date_updated, or date_updated.</param>
		/// <param name="domain">Filter bookmarks by domain.</param>
		/// <param name="addedSince">Filter bookmarks by date added (since this date).</param>
		/// <param name="addedUntil">Filter bookmarks by date added (until this date).</param>
		/// <param name="openedSince">Filter bookmarks by date opened (since this date).</param>
		/// <param name="openedUntil">Filter bookmarks by date opened (until this date).</param>
		/// <param name="archivedSince">Filter bookmarks by date archived (since this date).</param>
		/// <param name="archivedUntil">Filter bookmarks by date archived (until this date).</param>
		/// <param name="favoritedSince">Filter bookmarks by date favorited (since this date).</param>
		/// <param name="favoritedUntil">Filter bookmarks by date favorited (until this date).</param>
		/// <param name="updatedSince">Filter bookmarks by date updated (since this date).</param>
		/// <param name="updatedUntil">Filter bookmarks by date updated (until this date).</param>
		/// <returns>A list of <see cref="Bookmark"/>.</returns>
		/// <exception cref="ReadabilityApiException">If there is an error while communicating with Readability.</exception>
		/// <exception cref="ReadabilityApiException">If OAuth credentials was not provided.</exception>
		BookmarkCollection GetReadingListBookmarks(int page = 1, int perPage = 20,
			string order = "-date_added", string domain = "",
			DateTime? addedSince = null, DateTime? addedUntil = null,
			DateTime? openedSince = null, DateTime? openedUntil = null,
			DateTime? archivedSince = null, DateTime? archivedUntil = null,
			DateTime? favoritedSince = null, DateTime? favoritedUntil = null,
			DateTime? updatedSince = null, DateTime? updatedUntil = null);

		/// <summary>
		/// Asynchronously retrieve reading list bookmarks without archived from the bookmarks collection.
		/// </summary>
		/// <param name="page">For pagination, what page of the results you are on. Default is 1.</param>
		/// <param name="perPage">For pagination, how many results to return per page. Default is 20. Max is 50.</param>
		/// <param name="order">What to order these bookmarks by. Default is date_added descending (-date_added). One of: -date_added, date_added, -date_updated, or date_updated.</param>
		/// <param name="domain">Filter bookmarks by domain.</param>
		/// <param name="addedSince">Filter bookmarks by date added (since this date).</param>
		/// <param name="addedUntil">Filter bookmarks by date added (until this date).</param>
		/// <param name="openedSince">Filter bookmarks by date opened (since this date).</param>
		/// <param name="openedUntil">Filter bookmarks by date opened (until this date).</param>
		/// <param name="archivedSince">Filter bookmarks by date archived (since this date).</param>
		/// <param name="archivedUntil">Filter bookmarks by date archived (until this date).</param>
		/// <param name="favoritedSince">Filter bookmarks by date favorited (since this date).</param>
		/// <param name="favoritedUntil">Filter bookmarks by date favorited (until this date).</param>
		/// <param name="updatedSince">Filter bookmarks by date updated (since this date).</param>
		/// <param name="updatedUntil">Filter bookmarks by date updated (until this date).</param>
		/// <returns>A list of <see cref="Bookmark"/>.</returns>
		/// <exception cref="ReadabilityApiException">If there is an error while communicating with Readability.</exception>
		/// <exception cref="ReadabilityApiException">If OAuth credentials was not provided.</exception>
		Task<BookmarkCollection> GetReadingListBookmarksAsync(int page = 1, int perPage = 20,
			string order = "-date_added", string domain = "",
			DateTime? addedSince = null, DateTime? addedUntil = null,
			DateTime? openedSince = null, DateTime? openedUntil = null,
			DateTime? archivedSince = null, DateTime? archivedUntil = null,
			DateTime? favoritedSince = null, DateTime? favoritedUntil = null,
			DateTime? updatedSince = null, DateTime? updatedUntil = null);

		/// <summary>
		/// Retrieve archived bookmarks from the bookmarks collection.
		/// </summary>
		/// <param name="page">For pagination, what page of the results you are on. Default is 1.</param>
		/// <param name="perPage">For pagination, how many results to return per page. Default is 20. Max is 50.</param>
		/// <param name="order">What to order these bookmarks by. Default is date_added descending (-date_added). One of: -date_added, date_added, -date_updated, or date_updated.</param>
		/// <param name="domain">Filter bookmarks by domain.</param>
		/// <param name="addedSince">Filter bookmarks by date added (since this date).</param>
		/// <param name="addedUntil">Filter bookmarks by date added (until this date).</param>
		/// <param name="openedSince">Filter bookmarks by date opened (since this date).</param>
		/// <param name="openedUntil">Filter bookmarks by date opened (until this date).</param>
		/// <param name="archivedSince">Filter bookmarks by date archived (since this date).</param>
		/// <param name="archivedUntil">Filter bookmarks by date archived (until this date).</param>
		/// <param name="favoritedSince">Filter bookmarks by date favorited (since this date).</param>
		/// <param name="favoritedUntil">Filter bookmarks by date favorited (until this date).</param>
		/// <param name="updatedSince">Filter bookmarks by date updated (since this date).</param>
		/// <param name="updatedUntil">Filter bookmarks by date updated (until this date).</param>
		/// <returns>A list of <see cref="Bookmark"/>.</returns>
		/// <exception cref="ReadabilityApiException">If there is an error while communicating with Readability.</exception>
		/// <exception cref="ReadabilityApiException">If OAuth credentials was not provided.</exception>
		BookmarkCollection GetArchivedBookmarks(int page = 1, int perPage = 20,
			string order = "-date_added", string domain = "",
			DateTime? addedSince = null, DateTime? addedUntil = null,
			DateTime? openedSince = null, DateTime? openedUntil = null,
			DateTime? archivedSince = null, DateTime? archivedUntil = null,
			DateTime? favoritedSince = null, DateTime? favoritedUntil = null,
			DateTime? updatedSince = null, DateTime? updatedUntil = null);

		/// <summary>
		/// Asynchronously retrieve archived bookmarks from the bookmarks collection.
		/// </summary>
		/// <param name="page">For pagination, what page of the results you are on. Default is 1.</param>
		/// <param name="perPage">For pagination, how many results to return per page. Default is 20. Max is 50.</param>
		/// <param name="order">What to order these bookmarks by. Default is date_added descending (-date_added). One of: -date_added, date_added, -date_updated, or date_updated.</param>
		/// <param name="domain">Filter bookmarks by domain.</param>
		/// <param name="addedSince">Filter bookmarks by date added (since this date).</param>
		/// <param name="addedUntil">Filter bookmarks by date added (until this date).</param>
		/// <param name="openedSince">Filter bookmarks by date opened (since this date).</param>
		/// <param name="openedUntil">Filter bookmarks by date opened (until this date).</param>
		/// <param name="archivedSince">Filter bookmarks by date archived (since this date).</param>
		/// <param name="archivedUntil">Filter bookmarks by date archived (until this date).</param>
		/// <param name="favoritedSince">Filter bookmarks by date favorited (since this date).</param>
		/// <param name="favoritedUntil">Filter bookmarks by date favorited (until this date).</param>
		/// <param name="updatedSince">Filter bookmarks by date updated (since this date).</param>
		/// <param name="updatedUntil">Filter bookmarks by date updated (until this date).</param>
		/// <returns>A list of <see cref="Bookmark"/>.</returns>
		/// <exception cref="ReadabilityApiException">If there is an error while communicating with Readability.</exception>
		/// <exception cref="ReadabilityApiException">If OAuth credentials was not provided.</exception>
		Task<BookmarkCollection> GetArchivedBookmarksAsync(int page = 1, int perPage = 20,
			string order = "-date_added", string domain = "",
			DateTime? addedSince = null, DateTime? addedUntil = null,
			DateTime? openedSince = null, DateTime? openedUntil = null,
			DateTime? archivedSince = null, DateTime? archivedUntil = null,
			DateTime? favoritedSince = null, DateTime? favoritedUntil = null,
			DateTime? updatedSince = null, DateTime? updatedUntil = null);

		/// <summary>
		/// Retrieve deleted bookmarks from the bookmarks collection.
		/// </summary>
		/// <param name="page">For pagination, what page of the results you are on. Default is 1.</param>
		/// <param name="perPage">For pagination, how many results to return per page. Default is 20. Max is 50.</param>
		/// <param name="order">What to order these bookmarks by. Default is date_added descending (-date_added). One of: -date_added, date_added, -date_updated, or date_updated.</param>
		/// <param name="domain">Filter bookmarks by domain.</param>
		/// <param name="addedSince">Filter bookmarks by date added (since this date).</param>
		/// <param name="addedUntil">Filter bookmarks by date added (until this date).</param>
		/// <param name="openedSince">Filter bookmarks by date opened (since this date).</param>
		/// <param name="openedUntil">Filter bookmarks by date opened (until this date).</param>
		/// <param name="archivedSince">Filter bookmarks by date archived (since this date).</param>
		/// <param name="archivedUntil">Filter bookmarks by date archived (until this date).</param>
		/// <param name="favoritedSince">Filter bookmarks by date favorited (since this date).</param>
		/// <param name="favoritedUntil">Filter bookmarks by date favorited (until this date).</param>
		/// <param name="updatedSince">Filter bookmarks by date updated (since this date).</param>
		/// <param name="updatedUntil">Filter bookmarks by date updated (until this date).</param>
		/// <returns>A list of <see cref="Bookmark"/>.</returns>
		/// <exception cref="ReadabilityApiException">If there is an error while communicating with Readability.</exception>
		/// <exception cref="ReadabilityApiException">If OAuth credentials was not provided.</exception>
		BookmarkCollection GetDeletedBookmarks(int page = 1, int perPage = 20,
			string order = "-date_added", string domain = "",
			DateTime? addedSince = null, DateTime? addedUntil = null,
			DateTime? openedSince = null, DateTime? openedUntil = null,
			DateTime? archivedSince = null, DateTime? archivedUntil = null,
			DateTime? favoritedSince = null, DateTime? favoritedUntil = null,
			DateTime? updatedSince = null, DateTime? updatedUntil = null);

		/// <summary>
		/// Asynchronously retrieve deleted bookmarks from the bookmarks collection.
		/// </summary>
		/// <param name="page">For pagination, what page of the results you are on. Default is 1.</param>
		/// <param name="perPage">For pagination, how many results to return per page. Default is 20. Max is 50.</param>
		/// <param name="order">What to order these bookmarks by. Default is date_added descending (-date_added). One of: -date_added, date_added, -date_updated, or date_updated.</param>
		/// <param name="domain">Filter bookmarks by domain.</param>
		/// <param name="addedSince">Filter bookmarks by date added (since this date).</param>
		/// <param name="addedUntil">Filter bookmarks by date added (until this date).</param>
		/// <param name="openedSince">Filter bookmarks by date opened (since this date).</param>
		/// <param name="openedUntil">Filter bookmarks by date opened (until this date).</param>
		/// <param name="archivedSince">Filter bookmarks by date archived (since this date).</param>
		/// <param name="archivedUntil">Filter bookmarks by date archived (until this date).</param>
		/// <param name="favoritedSince">Filter bookmarks by date favorited (since this date).</param>
		/// <param name="favoritedUntil">Filter bookmarks by date favorited (until this date).</param>
		/// <param name="updatedSince">Filter bookmarks by date updated (since this date).</param>
		/// <param name="updatedUntil">Filter bookmarks by date updated (until this date).</param>
		/// <returns>A list of <see cref="Bookmark"/>.</returns>
		/// <exception cref="ReadabilityApiException">If there is an error while communicating with Readability.</exception>
		/// <exception cref="ReadabilityApiException">If OAuth credentials was not provided.</exception>
		Task<BookmarkCollection> GetDeletedBookmarksAsync(int page = 1, int perPage = 20,
			string order = "-date_added", string domain = "",
			DateTime? addedSince = null, DateTime? addedUntil = null,
			DateTime? openedSince = null, DateTime? openedUntil = null,
			DateTime? archivedSince = null, DateTime? archivedUntil = null,
			DateTime? favoritedSince = null, DateTime? favoritedUntil = null,
			DateTime? updatedSince = null, DateTime? updatedUntil = null);

		/// <summary>
		/// Retrieve favorite bookmarks from the bookmarks collection.
		/// </summary>
		/// <param name="page">For pagination, what page of the results you are on. Default is 1.</param>
		/// <param name="perPage">For pagination, how many results to return per page. Default is 20. Max is 50.</param>
		/// <param name="order">What to order these bookmarks by. Default is date_added descending (-date_added). One of: -date_added, date_added, -date_updated, or date_updated.</param>
		/// <param name="domain">Filter bookmarks by domain.</param>
		/// <param name="addedSince">Filter bookmarks by date added (since this date).</param>
		/// <param name="addedUntil">Filter bookmarks by date added (until this date).</param>
		/// <param name="openedSince">Filter bookmarks by date opened (since this date).</param>
		/// <param name="openedUntil">Filter bookmarks by date opened (until this date).</param>
		/// <param name="archivedSince">Filter bookmarks by date archived (since this date).</param>
		/// <param name="archivedUntil">Filter bookmarks by date archived (until this date).</param>
		/// <param name="favoritedSince">Filter bookmarks by date favorited (since this date).</param>
		/// <param name="favoritedUntil">Filter bookmarks by date favorited (until this date).</param>
		/// <param name="updatedSince">Filter bookmarks by date updated (since this date).</param>
		/// <param name="updatedUntil">Filter bookmarks by date updated (until this date).</param>
		/// <returns>A list of <see cref="Bookmark"/>.</returns>
		/// <exception cref="ReadabilityApiException">If there is an error while communicating with Readability.</exception>
		/// <exception cref="ReadabilityApiException">If OAuth credentials was not provided.</exception>
		BookmarkCollection GetFavoriteBookmarks(int page = 1, int perPage = 20,
			string order = "-date_added", string domain = "",
			DateTime? addedSince = null, DateTime? addedUntil = null,
			DateTime? openedSince = null, DateTime? openedUntil = null,
			DateTime? archivedSince = null, DateTime? archivedUntil = null,
			DateTime? favoritedSince = null, DateTime? favoritedUntil = null,
			DateTime? updatedSince = null, DateTime? updatedUntil = null);

		/// <summary>
		/// Asynchronously retrieve favorite bookmarks from the bookmarks collection.
		/// </summary>
		/// <param name="page">For pagination, what page of the results you are on. Default is 1.</param>
		/// <param name="perPage">For pagination, how many results to return per page. Default is 20. Max is 50.</param>
		/// <param name="order">What to order these bookmarks by. Default is date_added descending (-date_added). One of: -date_added, date_added, -date_updated, or date_updated.</param>
		/// <param name="domain">Filter bookmarks by domain.</param>
		/// <param name="addedSince">Filter bookmarks by date added (since this date).</param>
		/// <param name="addedUntil">Filter bookmarks by date added (until this date).</param>
		/// <param name="openedSince">Filter bookmarks by date opened (since this date).</param>
		/// <param name="openedUntil">Filter bookmarks by date opened (until this date).</param>
		/// <param name="archivedSince">Filter bookmarks by date archived (since this date).</param>
		/// <param name="archivedUntil">Filter bookmarks by date archived (until this date).</param>
		/// <param name="favoritedSince">Filter bookmarks by date favorited (since this date).</param>
		/// <param name="favoritedUntil">Filter bookmarks by date favorited (until this date).</param>
		/// <param name="updatedSince">Filter bookmarks by date updated (since this date).</param>
		/// <param name="updatedUntil">Filter bookmarks by date updated (until this date).</param>
		/// <returns>A list of <see cref="Bookmark"/>.</returns>
		/// <exception cref="ReadabilityApiException">If there is an error while communicating with Readability.</exception>
		/// <exception cref="ReadabilityApiException">If OAuth credentials was not provided.</exception>
		Task<BookmarkCollection> GetFavoriteBookmarksAsync(int page = 1, int perPage = 20,
			string order = "-date_added", string domain = "",
			DateTime? addedSince = null, DateTime? addedUntil = null,
			DateTime? openedSince = null, DateTime? openedUntil = null,
			DateTime? archivedSince = null, DateTime? archivedUntil = null,
			DateTime? favoritedSince = null, DateTime? favoritedUntil = null,
			DateTime? updatedSince = null, DateTime? updatedUntil = null);

		/// <summary>
		/// Adds a bookmark.
		/// </summary>
		/// <param name="url">
		/// The URL of the article to associate the bookmark with. If it already exists in the users bookmark list, 
		/// it will return a 409 with the Location header to the current bookmark.
		/// </param>
		/// <param name="favorite">Whether this bookmark is favorited or not..</param>
		/// <param name="archived">Whether this bookmark is archived or not.</param>
		/// <returns>An <see cref="Uri"/> to the newly created bookmark</returns>
		/// <exception cref="ReadabilityApiException">If there is an error while communicating with Readability.</exception>
		/// <exception cref="ReadabilityApiException">If OAuth credentials was not provided.</exception>
		Uri AddBookmark(string url, bool favorite = false, bool archived = false);

		/// <summary>
		/// Asynchronously adds a bookmark.
		/// </summary>
		/// <param name="url">
		/// The URL of the article to associate the bookmark with. If it already exists in the users bookmark list, 
		/// it will return a 409 with the Location header to the current bookmark.
		/// </param>
		/// <param name="favorite">Whether this bookmark is favorited or not..</param>
		/// <param name="archived">Whether this bookmark is archived or not.</param>
		/// <returns>An <see cref="Uri"/> to the newly created bookmark</returns>
		/// <exception cref="ReadabilityApiException">If there is an error while communicating with Readability.</exception>
		/// <exception cref="ReadabilityApiException">If OAuth credentials was not provided.</exception>
		Task<Uri> AddBookmarkAsync(string url, bool favorite = false, bool archived = false);

		/// <summary>
		/// Updates a bookmark.
		/// </summary>
		/// <param name="bookmarkId">The id of the bookmark to update.</param>
		/// <param name="favorite">Whether this bookmark is favorited or not..</param>
		/// <param name="archive">Whether this bookmark is archived or not.</param>
		/// <param name="readPercent">
		/// The read progress made in this article, where 1.0 means the bottom and 0.0 means the very top. 
		/// Expressed as a ratio of the document length, from the top of the browser window, unless 
		/// the window is at the bottom.
		/// </param>
		/// <param name="dateOpened">The date and time this article was last opened by the user.</param>
		/// <returns>An <see cref="HttpResponseMessage"/> with a 200 on successful update.</returns>
		/// <exception cref="ReadabilityApiException">If there is an error while communicating with Readability.</exception>
		/// <exception cref="ReadabilityApiException">If OAuth credentials was not provided.</exception>
		HttpResponseMessage UpdateBookmark(int bookmarkId, bool favorite = false, bool archive = false, double? readPercent = 0.0, DateTime? dateOpened = null);

		/// <summary>
		/// Asynchronously updates a bookmark.
		/// </summary>
		/// <param name="bookmarkId">The id of the bookmark to update.</param>
		/// <param name="favorite">Whether this bookmark is favorited or not..</param>
		/// <param name="archive">Whether this bookmark is archived or not.</param>
		/// <param name="readPercent">
		/// The read progress made in this article, where 1.0 means the bottom and 0.0 means the very top. 
		/// Expressed as a ratio of the document length, from the top of the browser window, unless 
		/// the window is at the bottom.
		/// </param>
		/// <param name="dateOpened">The date and time this article was last opened by the user.</param>
		/// <returns>An <see cref="HttpResponseMessage"/> with a 200 on successful update.</returns>
		/// <exception cref="ReadabilityApiException">If there is an error while communicating with Readability.</exception>
		/// <exception cref="ReadabilityApiException">If OAuth credentials was not provided.</exception>
		Task<HttpResponseMessage> UpdateBookmarkAsync(int bookmarkId, bool favorite = false, bool archive = false, double? readPercent = 0.0, DateTime? dateOpened = null);

		/// <summary>
		/// Remove a single bookmark from this user's history. NOTE: THIS IS PROBABLY NOT WHAT YOU WANT. This is particularly 
		/// for the case where a user accidentally bookmarks something they have no intention of reading or supporting. In almost 
		/// all cases, you'll probably want to archive this bookmark.
		/// </summary>
		/// <param name="bookmarkId">The id of the bookmark to delete.</param>
		/// <exception cref="ReadabilityApiException">If there is an error while communicating with Readability.</exception>
		/// <exception cref="ReadabilityApiException">If OAuth credentials was not provided.</exception>
		void DeleteBookmark(int bookmarkId);

		/// <summary>
		/// Remove a single bookmark from this user's history. NOTE: THIS IS PROBABLY NOT WHAT YOU WANT. This is particularly 
		/// for the case where a user accidentally bookmarks something they have no intention of reading or supporting. In almost 
		/// all cases, you'll probably want to archive this bookmark.
		/// </summary>
		/// <param name="bookmarkId">The id of the bookmark to delete.</param>
		/// <exception cref="ReadabilityApiException">If there is an error while communicating with Readability.</exception>
		/// <exception cref="ReadabilityApiException">If OAuth credentials was not provided.</exception>
		Task DeleteBookmarkAsync(int bookmarkId);
	}
}
