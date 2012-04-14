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
using System.Runtime.Serialization;
using System.Security.Permissions;
using Spring.Social;

namespace CSharp.Readability.Api
{
    /// <summary>
    /// The exception that is thrown when a error occurs while consuming Readability REST API.
    /// </summary>
    /// <author>Bruno Baia</author>
    [Serializable]
    public class ReadabilityApiException : SocialException
    {
        private readonly ReadabilityApiError _error;

        /// <summary>
        /// Gets the Readability error.
        /// </summary>
        public ReadabilityApiError Error
        {
            get { return _error; }
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ReadabilityApiException"/> class.
        /// </summary>
        /// <param name="message">A message about the exception.</param>
        /// <param name="error">The Readability error.</param>
        public ReadabilityApiException(string message, ReadabilityApiError error)
            : base(message)
        {
            _error = error;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ReadabilityApiException"/> class.
        /// </summary>
        /// <param name="message">A message about the exception.</param>
        /// <param name="innerException">The inner exception that is the cause of the current exception.</param>
        public ReadabilityApiException(string message, Exception innerException)
            : base(message, innerException)
        {
            _error = ReadabilityApiError.InternalServerError;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ReadabilityApiException"/> class.
        /// </summary>
        /// <param name="info">
        /// The <see cref="System.Runtime.Serialization.SerializationInfo"/>
        /// that holds the serialized object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="System.Runtime.Serialization.StreamingContext"/>
        /// that contains contextual information about the source or destination.
        /// </param>
        protected ReadabilityApiException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info != null)
            {
                _error = (ReadabilityApiError)info.GetValue("Error", typeof(ReadabilityApiError));
            }
        }

        /// <summary>
        /// Populates the <see cref="System.Runtime.Serialization.SerializationInfo"/> with 
        /// information about the exception.
        /// </summary>
        /// <param name="info">
        /// The <see cref="System.Runtime.Serialization.SerializationInfo"/> that holds 
        /// the serialized object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="System.Runtime.Serialization.StreamingContext"/> that contains contextual 
        /// information about the source or destination.
        /// </param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            if (info != null)
            {
                info.AddValue("Error", _error);
            }
        }
    }
}
