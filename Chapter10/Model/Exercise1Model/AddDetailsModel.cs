
using Chapter10.EndPoint.Exercise1;
using Chapter10.HttpModel.Exercise1;
using Chapter10.Interface;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace Chapter10.Model.Exercise1Model
{
    public class AddDetailsModel
    {
        private AddDetailsEndPoint _addDetailsEndPoint;

        public string Username { get ; set; }
        public string Password { get ; set; }

        public AddDetailsResponceModel ResponceDetails { get; set; }
       
        
        public AddDetailsModel()
        {
            _addDetailsEndPoint = new AddDetailsEndPoint();
        }

        public async Task<ErrorResult> AddDetailsAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var requestModel=new AddDetailsRequestModel()
                {
                    Username = Username,
                    Password = Password
                };
                _addDetailsEndPoint.AddDetailsRequestModel=requestModel;
                var response = await _addDetailsEndPoint.ExecuteAsync();
                if (response.IsSuccessStatusCode)
                {
                    var data=await response.Content.ReadAsStringAsync();
                    var details = JsonConvert.DeserializeObject<AddDetailsResponceModel>(data);
                    ResponceDetails = details;
                    return new ErrorResult()
                    {
                        IsSuccess = true,
                    };
                }
                else
                {
                    return new ErrorResult()
                    {
                        IsSuccess = false,
                        Message="Somthing went wrong"
                    };
                }
            }
            else
            {
                return new ErrorResult()
                {
                    IsSuccess = false,
                    IsInternetError=false,
                    Message = "No internet connection"
                };
            }
        }
    }
}
