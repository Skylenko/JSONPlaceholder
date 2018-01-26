using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JSONPlaceholderAPIClient
{
    public class ResponseContainer<T>
    {
        private HttpResponseMessage _response;

        public ResponseContainer()
        {
        }

        public ResponseContainer(HttpResponseMessage response)
        {
            this._response = response;
        }

        public Task <T> DeserealizedContent =>  _response.Content.ReadAsAsync<T>();

        public HttpStatusCode StatusCode => _response.StatusCode;

    }
}