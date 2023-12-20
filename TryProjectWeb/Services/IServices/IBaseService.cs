using AutoMapper.Internal;
using TryProjectWeb.Model;

namespace TryProjectWeb.Services.IServices
{
    public interface IBaseService
    {
        APIResponse responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
