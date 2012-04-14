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
using System.Collections.Specialized;
using System.Globalization;
using CSharp.Readability.Api.Interfaces;
using CSharp.Readability.Api.Models;
using Spring.Rest.Client;
using System.Threading.Tasks;

namespace CSharp.Readability.Api.Impl
{
	/// <summary>
	/// Implementation of <see cref="IContributionOperations"/>, providing binding to Readabilitys' contribution-oriented REST resources.
	/// </summary>
	/// <author>Scott Smith</author>
	class ContributionTemplate : AbstractReadabilityOperations, IContributionOperations
	{
		private readonly RestTemplate _restTemplate;

		public ContributionTemplate(RestTemplate restTemplate, bool isAuthorized)
			: base(isAuthorized)
		{
			_restTemplate = restTemplate;
		}

		#region IContributionOperations Members

		public ContributionCollection GetContributions(int page = 1, int perPage = 20, string domain = "", DateTime? since = null, DateTime? until = null)
		{
			EnsureIsAuthorized();
			var parameters = new NameValueCollection();
			if (since.HasValue) parameters.Add("since", since.Value.ToString(CultureInfo.InvariantCulture));
			if (until.HasValue) parameters.Add("until", until.Value.ToString(CultureInfo.InvariantCulture));
			if (!String.IsNullOrEmpty(domain)) parameters.Add("domain", domain);
			parameters.Add("page", page.ToString(CultureInfo.InvariantCulture));
			parameters.Add("per_page", perPage.ToString(CultureInfo.InvariantCulture));
			return _restTemplate.GetForObject<ContributionCollection>(BuildUrl("contributions", parameters));
		}

		public Task<ContributionCollection> GetContributionsAsync(int page = 1, int perPage = 20, string domain = "", DateTime? since = null, DateTime? until = null)
		{
			EnsureIsAuthorized();
			var parameters = new NameValueCollection();
			if (since.HasValue) parameters.Add("since", since.Value.ToString(CultureInfo.InvariantCulture));
			if (until.HasValue) parameters.Add("until", until.Value.ToString(CultureInfo.InvariantCulture));
			if (!String.IsNullOrEmpty(domain)) parameters.Add("domain", domain);
			parameters.Add("page", page.ToString(CultureInfo.InvariantCulture));
			parameters.Add("per_page", perPage.ToString(CultureInfo.InvariantCulture));
			return _restTemplate.GetForObjectAsync<ContributionCollection>(BuildUrl("contributions", parameters));
		}

		#endregion

		#region Private Methods



		#endregion
	}
}