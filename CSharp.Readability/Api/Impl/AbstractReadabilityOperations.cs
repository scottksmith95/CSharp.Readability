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
using System.Text;
using System.Collections.Specialized;

using Spring.Http;

namespace Spring.Social.Readability.Api.Impl
{
    /// <summary>
    /// Base class for Readability operations.
    /// </summary>
    /// <author>Craig Walls</author>
    /// <author>Bruno Baia (.NET)</author>
    abstract class AbstractReadabilityOperations
    {
        private bool isAuthorized;

	    public AbstractReadabilityOperations(bool isAuthorized) 
        {
		    this.isAuthorized = isAuthorized;
	    }

        protected void EnsureIsAuthorized() 
        {
		    if (!this.isAuthorized) 
            {
			    throw new ReadabilityApiException(
                    "Authorization is required for the operation, but the API binding was created without authorization.", 
                    ReadabilityApiError.AuthorizationRequired);
		    }
	    }

        protected string BuildUrl(string path, string parameterName, string parameterValue)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add(parameterName, parameterValue);
            return this.BuildUrl(path, parameters);
        }

        protected string BuildUrl(string path, NameValueCollection parameters)
        {
            StringBuilder qsBuilder = new StringBuilder();
            bool isFirst = true;
            foreach (string key in parameters)
            {
                if (isFirst)
                {
                    qsBuilder.Append('?');
                    isFirst = false;
                }
                else
                {
                    qsBuilder.Append('&');
                }
                qsBuilder.Append(HttpUtils.UrlEncode(key));
                qsBuilder.Append('=');
                qsBuilder.Append(HttpUtils.UrlEncode(parameters[key]));
            }
            return path + qsBuilder.ToString();
	    }

		public static NameValueCollection BuildPagingParametersWithPerPage(int page, int count)
		{
			NameValueCollection parameters = new NameValueCollection();
			parameters.Add("page", page.ToString());
			parameters.Add("per_page", count.ToString());
			return parameters;
		}
    }
}