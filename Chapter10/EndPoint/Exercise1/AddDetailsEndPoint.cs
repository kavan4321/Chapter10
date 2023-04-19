
using Chapter10.HttpModel.Exercise1;
using Chapter10.Interface.Exercise1;
using Refit;

namespace Chapter10.EndPoint.Exercise1
{
    public class AddDetailsEndPoint
    {
        public AddDetailsRequestModel AddDetailsRequestModel { get; set; }
        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await
           RestService.For<ILogoutApi>("https://dummyjson.com/auth").
           AddDetailsAsync(AddDetailsRequestModel);
        }
    }
}
