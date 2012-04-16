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
		public string Username { get; set; }
		public string First_Name { get; set; }
		public string Last_Name { get; set; }
		public DateTime Date_Joined { get; set; }
		public bool Has_Active_Subscription { get; set; }
		public int Reading_Limit { get; set; }
		public bool Is_Publisher { get; set; }
		public int Favorites_Limit { get; set; }
		public string Avatar_Url { get; set; }
	}
}
