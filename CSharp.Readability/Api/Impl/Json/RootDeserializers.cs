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

using CSharp.Readability.Api.Models;
using Newtonsoft.Json;
using Spring.Json;

namespace CSharp.Readability.Api.Impl.Json
{
	/// <summary>
	/// JSON deserializer for data for root. 
	/// </summary>
	/// <author>Scott Smith</author>
	class RootDeserializer : IJsonDeserializer
	{
		public object Deserialize(JsonValue value, JsonMapper mapper)
		{
			return JsonConvert.DeserializeObject<Root>(value.GetValue("resources").ToString());
		}
	}
}
