using Sween.Core.CustomEntities;

namespace Sween.API.Response
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }

        public Metadata Meta { get; set; }

        public ApiResponse(T data)
        {
            Data = data;
        }
    }
}
