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

namespace CSharp.Readability.Api.Models
{
    /// <summary>
    /// Represents a Readability bookmark.
    /// </summary>
    /// <author>Scott Smith</author>
    [Serializable]
    public class BookmarkDetails
    {
        public int User_Id { get; set; }
        public decimal Read_Percent { get; set; }
        public DateTime Date_Updated { get; set; }
        public bool Favorite { get; set; }
        public BookmarkArticle Article { get; set; }
        public bool Deleted { get; set; }
        public int Id { get; set; }
        public DateTime? Date_Archived { get; set; }
        public DateTime? Date_Opened { get; set; }
        public DateTime Date_Added { get; set; }
        public string Article_Href { get; set; }
        public DateTime? Date_Favorited { get; set; }
        public bool Archive { get; set; }
        public List<Tag> tags { get; set; }
    }
}
