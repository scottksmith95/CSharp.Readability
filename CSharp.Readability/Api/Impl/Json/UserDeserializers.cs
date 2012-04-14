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
using System.Collections.Generic;
using System.Globalization;
using Spring.Json;

namespace Spring.Social.Readability.Api.Impl.Json
{
    /// <summary>
    /// JSON deserializer for Readability user.
    /// </summary>
    /// <author>Scott Smith</author>
    class UserDeserializer : IJsonDeserializer
    {
        public object Deserialize(JsonValue value, JsonMapper mapper)
        {
            return new User()
            {
				Username = value.GetValue<string>("username"),
				FirstName = value.GetValue<string>("first_name"),
				LastName = value.GetValue<string>("last_name"),
				Joined = value.GetValue<DateTime>("date_joined"),
				ActiveSubscription = value.GetValue<bool>("has_active_subscription"),
				ReadingLimit = value.GetValue<int>("reading_limit"),
            };
        }
    }
}