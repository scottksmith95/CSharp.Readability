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
using CSharp.Readability.Api.Models;
using Spring.Json;

namespace CSharp.Readability.Api.Impl.Json
{
	/// <summary>
	/// JSON deserializer for Readability article.
	/// </summary>
	/// <author>Scott Smith</author>
	class ArticleDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			return new Article
			{
				Id = value.GetValue<string>("id"),
				Author = value.GetValue<string>("author"),
				Content = value.GetValue<string>("content"),
				ContentSize = value.GetValue<int>("content_size"),
				Published = value.GetValue<DateTime>("date_published"),
				Domain = value.GetValue<string>("domain"),
				NextPageHref = value.GetValue<string>("next_page_href"),
				ShortUrl = value.GetValue<string>("short_url"),
				Title = value.GetValue<string>("title"),
				Url = value.GetValue<string>("url"),
				Direction = value.GetValue<string>("direction"),
				WordCount = value.GetValue<int>("word_count"),
				Processed = value.GetValue<bool>("processed"),
			};
		}
	}
}