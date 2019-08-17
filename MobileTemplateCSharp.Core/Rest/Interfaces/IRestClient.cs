using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MobileTemplateCSharp.Core.Rest.Interfaces {
    /// <summary>
    /// Base rest clien. All rest clients should have this one as service.
    /// </summary>
    public interface IRestClient {
        /// <summary>
        /// Making Rest API call.
        /// </summary>
        /// <typeparam name="TResult">Type of returning from rest API result.</typeparam>
        /// <param name="url">the Url^ where API call is making.</param>
        /// <param name="method">defines get or post method.</param>
        /// <param name="data">sending data for post method.</param>
        /// <param name="NeedAuth">true, if authorization is needed.</param>
        /// <returns>object from server of type TResult</returns>
        Task<TResult> MakeApiCall<TResult>(string url, HttpMethod method, object data = null, bool NeedAuth = false)
                        where TResult : class;

        void SetToken(string token);
        bool IsConnected { get; }
        bool IsAuthenticated { get; }

        event Action<bool> ConnectionStatusChanged;
        event Action<bool> AuthenticationStatusChanged;
    }
}
