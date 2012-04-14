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
using System.Text;

using Spring.Json;
using Spring.Http;
using Spring.Rest.Client;
using Spring.Rest.Client.Support;

namespace Spring.Social.Readability.Api.Impl
{
    /// <summary>
    /// Implementation of the <see cref="IResponseErrorHandler"/> that handles errors from Readability's REST API, 
    /// interpreting them into appropriate exceptions.
    /// </summary>
    /// <author>Craig Walls</author>
    /// <author>Bruno Baia (.NET)</author>
    class ReadabilityErrorHandler : DefaultResponseErrorHandler
    {
        // Default encoding for JSON
        private static readonly Encoding DEFAULT_CHARSET = new UTF8Encoding(false); // Remove byte Order Mask (BOM)

        /// <summary>
        /// Handles the error in the given response. 
        /// <para/>
        /// This method is only called when HasError() method has returned <see langword="true"/>.
        /// </summary>
        /// <remarks>
        /// This implementation throws appropriate exception if the response status code 
        /// is a client code error (4xx) or a server code error (5xx). 
        /// </remarks>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="requestMethod">The request method.</param>
        /// <param name="response">The response message with the error.</param>
        public override void HandleError(Uri requestUri, HttpMethod requestMethod, HttpResponseMessage<byte[]> response)
        {
            int type = (int)response.StatusCode / 100;
            if (type == 4)
            {
                this.HandleClientErrors(response);
            }
            else if (type == 5)
            {
                this.HandleServerErrors(response.StatusCode);
            }

            // if not otherwise handled, do default handling and wrap with ReadabilityApiException
            try
            {
                base.HandleError(requestUri, requestMethod, response);
            }
            catch (Exception ex)
            {
                throw new ReadabilityApiException("Error consuming Readability REST API.", ex);
            }
        }

        private void HandleClientErrors(HttpResponseMessage<byte[]> response) 
        {
		    string errorText = this.ExtractErrorDetailsFromResponse(response);
			if (errorText == null) 
            {
				errorText = "";
		    }

			if (response.StatusCode == HttpStatusCode.BadRequest)
			{
				throw new ReadabilityApiException(
					"The server could not understand your request. Verify that request parameters (and content, if any) are valid.",
					ReadabilityApiError.BadRequest);
			}
			else if (response.StatusCode == HttpStatusCode.Unauthorized)
			{
				throw new ReadabilityApiException(
					"Authentication failed or was not provided. Verify that you have sent valid credentials.",
					ReadabilityApiError.AuthorizationRequired);
			}
			else if (response.StatusCode == HttpStatusCode.Forbidden)
			{
				throw new ReadabilityApiException(
					"The server understood your request and verified your credentials, but you are not allowed to perform the requested action.",
					ReadabilityApiError.Forbidden);
			}
			else if (response.StatusCode == HttpStatusCode.NotFound)
			{
				throw new ReadabilityApiException(
					"The resource that you requested does not exist.",
					ReadabilityApiError.NotFound);
			}
			else if (response.StatusCode == HttpStatusCode.Conflict)
			{
				throw new ReadabilityApiException(
					"The resource that you are trying to create already exists. This should also provide a Location header to the resource in question.",
					ReadabilityApiError.Conflict);
			}
	    }

	    private void HandleServerErrors(HttpStatusCode statusCode)
        {
		    if (statusCode == HttpStatusCode.InternalServerError) 
            {
                throw new ReadabilityApiException(
					"An unknown error has occurred.", 
                    ReadabilityApiError.InternalServerError);
		    }
	    }

        private string ExtractErrorDetailsFromResponse(HttpResponseMessage<byte[]> response) 
        {
            if (response.Body == null)
            {
                return null;
            }
            MediaType contentType = response.Headers.ContentType;
            Encoding charset = (contentType != null && contentType.CharSet != null) ? contentType.CharSet : DEFAULT_CHARSET;
            return charset.GetString(response.Body, 0, response.Body.Length);
	    }
    }
}