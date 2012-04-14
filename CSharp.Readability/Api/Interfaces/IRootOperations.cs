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
    "resources": {
        "bookmarks": {
            "description": "The Bookmarks Collection Resource",
            "href": "/api/rest/v1/bookmarks"
        },
        "contributions": {
            "description": "The Contributions Collection Resource",
            "href": "/api/rest/v1/contributions"
        },
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
	/// Interface defining the operations for searching Readability and retrieving root data.
	/// </summary>
	/// <author>Scott Smith</author>
	public interface IRootOperations
	{
		/// <summary>
		/// Retrieve the base API URI - information about subresources.
		/// </summary>
		/// <returns>A <see cref="Root"/> for the base api uri.</returns>
		/// <exception cref="ReadabilityApiException">If there is an error while communicating with Readability.</exception>
		/// <exception cref="ReadabilityApiException">If OAuth credentials was not provided.</exception>
		Root GetRoot();

		/// <summary>
		/// Asynchronously retrieve the base API URI - information about subresources.
		/// </summary>
		/// <returns>A <see cref="Root"/> for the base api uri.</returns>
		/// <exception cref="ReadabilityApiException">If there is an error while communicating with Readability.</exception>
		/// <exception cref="ReadabilityApiException">If OAuth credentials was not provided.</exception>
		Task<Root> GetRootAsync();
	}
}
