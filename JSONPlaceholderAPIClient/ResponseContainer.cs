using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace JSONPlaceholderAPIClient
{
    public class ResponseContainer<T>
    {
        private HttpResponseMessage _response;

        public ResponseContainer(HttpResponseMessage response)
        {
            _response = response;
        }

        public Task<T> DeserealizedContent => _response.Content.ReadAsAsync<T>();

        public HttpStatusCode StatusCode => _response.StatusCode;
    }
}