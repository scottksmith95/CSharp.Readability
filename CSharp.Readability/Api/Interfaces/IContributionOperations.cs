﻿#region License

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
    "conditions": {
        "domain": null,
        "since": "2010-09-01",
        "page": 1,
        "user": "admin",
        "per_page": 10,
        "until": "2010-10-01"
    },
    "meta": {
        "num_pages": 1,
        "page": 1,
        "item_count_total": 5,
        "item_count": 5
    },
    "contributions": [
        {
            "date": "2010-09-01",
            "contribution": "1.33",
            "user": "admin",
            "domain": "www.nytimes.com",
            "num_bookmarks": 1
        },
        {
            "date": "2010-09-01",
            "contribution": "1.33",
            "user": "admin",
            "domain": "www.engadget.com",
            "num_bookmarks": 1
        },
        {
            "date": "2010-09-01",
            "contribution": "1.33",
            "user": "admin",
            "domain": "paulgraham.com",
            "num_bookmarks": 1
        },
        {
            "date": "2010-09-01",
            "contribution": "1.33",
            "user": "admin",
            "domain": "voices.washingtonpost.com",
            "num_bookmarks": 1
        },
        {
            "date": "2010-09-01",
            "contribution": "2.67",
            "user": "admin",
            "domain": "gizmodo.com",
            "num_bookmarks": 2
        }
    ]
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
	/// Interface defining the operations for searching Readability and retrieving contribution data.
	/// </summary>
	/// <author>Scott Smith</author>
	public interface IContributionOperations
	{
		/// <summary>
		/// Retrieve contributions from the contributions collection, which is a set of payments by a user to a specific domain.
		/// </summary>
		/// <param name="page">For pagination, what page of the results you are on. Default is 1.</param>
		/// <param name="perPage">For pagination, how many results to return per page. Default is 20. Max is 50.</param>
		/// <param name="domain">Filter contributions by domain.</param>
		/// <param name="since">Filter contributions by date contributed (since this date).</param>
		/// <param name="until">Filter contributions by date contributed (until this date).</param>
		/// <returns>A list of <see cref="Contribution"/>.</returns>
		/// <exception cref="ReadabilityApiException">If there is an error while communicating with Readability.</exception>
		/// <exception cref="ReadabilityApiException">If OAuth credentials was not provided.</exception>
		ContributionCollection GetContributions(int page = 1, int perPage = 20, string domain = "", DateTime? since = null, DateTime? until = null);

		/// <summary>
		/// Asynchronously retrieve contributions from the contributions collection, which is a set of payments by a user to a specific domain.
		/// </summary>
		/// <param name="page">For pagination, what page of the results you are on. Default is 1.</param>
		/// <param name="perPage">For pagination, how many results to return per page. Default is 20. Max is 50.</param>
		/// <param name="domain">Filter contributions by domain.</param>
		/// <param name="since">Filter contributions by date contributed (since this date).</param>
		/// <param name="until">Filter contributions by date contributed (until this date).</param>
		/// <returns>A list of <see cref="Contribution"/>.</returns>
		/// <exception cref="ReadabilityApiException">If there is an error while communicating with Readability.</exception>
		/// <exception cref="ReadabilityApiException">If OAuth credentials was not provided.</exception>
		Task<ContributionCollection> GetContributionsAsync(int page = 1, int perPage = 20, string domain = "", DateTime? since = null, DateTime? until = null);
	}
}