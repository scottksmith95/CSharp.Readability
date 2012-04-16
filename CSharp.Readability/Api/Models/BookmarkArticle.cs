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
	/// Represents a Readability bookmark article.
	/// </summary>
	/// <author>Scott Smith</author>
	[Serializable]
	public class BookmarkArticle
	{
		public string Url { get; set; }
		public string Domain { get; set; }
		public string Excerpt { get; set; }
		public int Word_Count { get; set; }
		public bool Processed { get; set; }
		public string Id { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public string Direction { get; set; }
		public DateTime? Date_Published { get; set; }
	}
}
