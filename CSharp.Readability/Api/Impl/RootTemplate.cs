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
	/// Implementation of <see cref="IRootOperations"/>, providing binding to Readabilitys' root-oriented REST resources.
	/// </summary>
	/// <author>Scott Smith</author>
	class RootTemplate : AbstractReadabilityOperations, IRootOperations
	{
		private RestTemplate restTemplate;

		public RootTemplate(RestTemplate restTemplate, bool isAuthorized)
			: base(isAuthorized)
		{
			this.restTemplate = restTemplate;
		}

		#region IRootOperations Members

		public Root GetRoot()
		{
			this.EnsureIsAuthorized();
			return this.restTemplate.GetForObject<Root>("");
		}

		public Task<Root> GetRootAsync()
		{
			this.EnsureIsAuthorized();
			return this.restTemplate.GetForObjectAsync<Root>("");
		}

		#endregion

		#region Private Methods



		#endregion
	}
}