
using Chapter10.HttpModel.Exercise1;
using Refit;

namespace Chapter10.Interface.Exercise1
{
    public interface ILogoutApi
    {
        [Post("/login")]
        Task<HttpResponseMessage> AddDetailsAsync([Body] AddDetailsRequestModel model);

    }
}
