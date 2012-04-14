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
using CSharp.Readability.Api.Models;
using Spring.Http;
using System.Threading.Tasks;

namespace CSharp.Readability.Api.Interfaces
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
