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

namespace Spring.Social.Readability.Api
{
    /// <summary>
    /// The <see cref="ReadabilityApiError"/> enumeration is used by the <see cref="ReadabilityApiException"/> class 
    /// to indicate what kind of error caused the exception.
    /// </summary>
    /// <author>Bruno Baia</author>
    public enum ReadabilityApiError
    {
		/// <summary>
		/// 400 status code. The server could not understand your request. Verify that request parameters (and content, if any) are valid.
		/// </summary>
		BadRequest,

        /// <summary>
		/// 401 status code. Authentication failed or was not provided. Verify that you have sent valid credentials.
        /// </summary>
        AuthorizationRequired,

		/// <summary>
		/// 403 status code. The server understood your request and verified your credentials, but you are not allowed to perform the requested action.
		/// </summary>
		Forbidden,

        /// <summary>
		/// 404 status code. The resource that you requested does not exist.
        /// </summary>
        NotFound,

        /// <summary>
		/// 409 status code. The resource that you are trying to create already exists. This should also provide a Location header to the resource in question.
        /// </summary>
        Conflict,

        /// <summary>
		/// 500 status code. An unknown error has occurred.
        /// </summary>
        InternalServerError
    }
}
