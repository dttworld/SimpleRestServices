﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using JSIStudios.SimpleRESTServices.Core;

namespace JSIStudios.SimpleRESTServices.Client.Json
{
    /// <summary>
    /// An implementation of <see cref="IRestService"/> that uses JSON notation for
    /// the serialized representation of objects.
    /// </summary>
    public class JsonRestServices : RestServiceBase, IRestService
    {
        /// <summary>
        /// Initializes a new instance of <see cref="JsonRestServices"/> with the default
        /// JSON string serializer, retry logic, and URL builder.
        /// </summary>
        public JsonRestServices():this(null) {}

        /// <summary>
        /// Initializes a new instance of <see cref="JsonRestServices"/> with the specified
        /// request logger and the default JSON string serializer and URL builder.
        /// </summary>
        /// <param name="requestLogger">The logger to use for requests. Specify <c>null</c> if requests do not need to be logged.</param>
        public JsonRestServices(IRequestLogger requestLogger) : this(requestLogger, new RequestRetryLogic(), new UrlBuilder(), new JsonStringSerializer()) {}

        /// <summary>
        /// Initializes a new instance of <see cref="JsonRestServices"/> with the specified
        /// logger, retry logic, URI builder, and string serializer.
        /// </summary>
        /// <param name="logger">The logger to use for requests. Specify <c>null</c> if requests do not need to be logged.</param>
        /// <param name="retryLogic">The retry logic to use for REST operations.</param>
        /// <param name="urlBuilder">The URL builder to use for constructing URLs with query parameters.</param>
        /// <param name="stringSerializer">The string serializer to use for requests from this service.</param>
        public JsonRestServices(IRequestLogger logger, IRetryLogic<Response, HttpStatusCode> retryLogic, IUrlBuilder urlBuilder, IStringSerializer stringSerializer) : base(stringSerializer, logger, retryLogic, urlBuilder) { }

        /// <summary>
        /// Gets the default <see cref="RequestSettings"/> to use for requests sent from this service.
        /// </summary>
        /// <remarks>
        /// This implementation uses a new instance of <see cref="JsonRequestSettings"/> as the
        /// default request settings.
        /// </remarks>
        protected override RequestSettings DefaultRequestSettings
        {
            get
            {
                return new JsonRequestSettings();
            }
        }

        /// <inheritdoc/>
        public override Response Execute(Uri url, HttpMethod method, Func<HttpWebResponse, bool, Response> responseBuilderCallback, string body, Dictionary<string, string> headers, Dictionary<string, string> queryStringParameters, RequestSettings settings)
        {
            return base.Execute(url, method, responseBuilderCallback, body, headers, queryStringParameters, settings);
        }

        /// <inheritdoc/>
        public override Response Stream(Uri url, HttpMethod method, Func<HttpWebResponse, bool, Response> responseBuilderCallback, Stream contents, int bufferSize, long maxReadLength, Dictionary<string, string> headers, Dictionary<string, string> queryStringParameters, RequestSettings settings, Action<long> progressUpdated)
        {
            return base.Stream(url, method, responseBuilderCallback, contents, bufferSize, maxReadLength, headers, queryStringParameters, settings, progressUpdated);
        }
    }
}
