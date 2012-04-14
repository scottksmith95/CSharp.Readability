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
	/// Represents a Readability contribution.
	/// </summary>
	/// <author>Scott Smith</author>
	[Serializable]
	public class Contribution
	{
		/// <summary>
		/// Gets or sets the date. ("date")
		/// </summary>
		public DateTime Date { get; set; }

		/// <summary>
		/// Gets or sets the contribution. ("contribution")
		/// </summary>
		public double ContributionAmount { get; set; }

		/// <summary>
		/// Gets or sets the user. ("user")
		/// </summary>
		public string User { get; set; }

		/// <summary>
		/// Gets or sets the domain. ("domain")
		/// </summary>
		public string Domain { get; set; }

		/// <summary>
		/// Gets or sets the number of bookmarks. ("num_bookmarks")
		/// </summary>
		public int NumberOfBookmarks { get; set; }
	}
}
