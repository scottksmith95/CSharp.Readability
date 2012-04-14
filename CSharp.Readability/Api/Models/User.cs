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

namespace CSharp.Readability.Api.Models
{
	/// <summary>
	/// Represents a Readability user.
	/// </summary>
	/// <author>Scott Smith</author>
	[Serializable]
	public class User
	{
		/// <summary>
		/// Gets or sets the username. ("username")
		/// </summary>
		public string Username { get; set; }

		/// <summary>
		/// Gets or sets the first name. ("first_name")
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Gets or sets the last name. ("last_name")
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// Gets or sets the date joined. ("date_joined")
		/// </summary>
		public DateTime Joined { get; set; }

		/// <summary>
		/// Gets or sets the has active subscriptions flag. ("has_active_subscription")
		/// </summary>
		public bool ActiveSubscription { get; set; }

		/// <summary>
		/// Gets or sets the reading limit. ("reading_limit")
		/// </summary>
		public int ReadingLimit { get; set; }
	}
}
