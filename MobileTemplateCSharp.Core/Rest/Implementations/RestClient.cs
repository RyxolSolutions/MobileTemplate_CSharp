using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http.Headers;

using MvvmCross.Base;
using MvvmCross.Logging;

using MobileTemplateCSharp.Core.Rest.Interfaces;
using MobileTemplateCSharp.Core.Models.Rest;

namespace MobileTemplateCSharp.Core.Rest.Implementations {
    public class RestClient : IRestClient {
        private readonly IMvxJsonConverter _jsonConverter;
        private readonly IMvxLog _mvxLog;

        #region Connection

        public event Action<bool> ConnectionStatusChanged;
        public event Action<bool> AuthenticationStatusChanged;

        private object _synchObj = new object();
        private Timer _t;

        private TokenResponseModel tokenResponseModel;
        public TokenResponseModel TokenResponseModel {
            get {
                lock (_synchObj)
                    return tokenResponseModel;
            }
            protected set {
                bool changed = false;

                lock (_synchObj) {
                    changed = tokenResponseModel != value;
                    tokenResponseModel = value;
                    AuthenticationStatusChanged?.Invoke(tokenResponseModel != null);
                }
            }
        }

        public bool IsAuthenticated {
            get {
                lock (_synchObj)
                    return (tokenResponseModel != null);
            }
        }

        private bool _isConnected = true;
        public bool IsConnected {
            get {
                lock (_synchObj)
                    return _isConnected;
            }
            protected set {
                bool needReconnect = false;
                bool changed = false;
                lock (_synchObj) {
                    changed = _isConnected != value;
                    needReconnect = _isConnected != value && !value;
                    _isConnected = value;
                }

                if (needReconnect)
                    Connect(null);

                if (changed)
                    ConnectionStatusChanged?.Invoke(value);
            }
        }

#pragma warning disable RECS0165 // Asynchronous methods should return a Task instead of void
        public async void Connect(object data) {
#pragma warning restore RECS0165 // Asynchronous methods should return a Task instead of void
            await Ping();

            if (IsConnected)
                return;

            if (_t == null)
                _t = new Timer(Connect, null, 20000, Timeout.Infinite);
            else
                _t.Change(20000, Timeout.Infinite);
        }

        public async Task<bool> Ping() {
            var client = new System.Net.Http.HttpClient();
            try {
                string url = string.Format("{0}api/driver/ping", Constants.WebAPIBaseAddress);
                client.BaseAddress = new Uri(url);
                client.Timeout = TimeSpan.FromSeconds(10);

                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode) {
                    IsConnected = true;
                    return true;
                } else {
                    IsConnected = false;
                }
            } catch (WebException ex) {
                _mvxLog.Error($"Ping error: {ex}");
                IsConnected = false;
            } catch (Exception e) {
                if (e.InnerException != null && e.InnerException is WebException) {
                    IsConnected = false;
                } else {
                    IsConnected = true;
                }
            }
            return false;
        }

        private bool IsConnectionAlive(WebException ex) {
            if (ex.Response == null) {
                return false;
            } else {
                return true;
            }
        }

        private bool IsConnectionAlive(WebExceptionStatus stastus) {
            switch (stastus) {
                case WebExceptionStatus.ConnectFailure:
                case WebExceptionStatus.ConnectionClosed:
                case WebExceptionStatus.ReceiveFailure:
                case WebExceptionStatus.SendFailure:
                case WebExceptionStatus.NameResolutionFailure:
                    return false;
                default:
                    return true;
            }
        }

        #endregion

        #region Rest Client

        public RestClient(IMvxJsonConverter jsonConverter, IMvxLog mvxLog) {
            _jsonConverter = jsonConverter;
            _mvxLog = mvxLog;
        }


        public async Task<TResult> MakeApiCall<TResult>(string url, HttpMethod method, object data = null, bool NeedAuth = false) where TResult : class {
            //url = url.Replace("http://", "https://");

            using (var request = new HttpRequestMessage { RequestUri = new Uri(url), Method = method }) {
                // add content
                if (method != HttpMethod.Get) {
                    var json = _jsonConverter.SerializeObject(data);
                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                }
                HttpClient.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (NeedAuth && TokenResponseModel != null)
                    HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", TokenResponseModel.Token);

                HttpResponseMessage response = new HttpResponseMessage();
                try {
                    response = await HttpClient.SendAsync(request, HttpCompletionOption.ResponseContentRead).ConfigureAwait(false);
                } catch (WebException ex) {
                    IsConnected = false;
                    _mvxLog.ErrorException($"MakeApiCall failed ", ex);
                } catch (Exception e) {
                    IsConnected = e.InnerException == null || !(e.InnerException is WebException);
                    _mvxLog.ErrorException("MakeApiCall failed ", e);
                }

                var stringSerialized = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                // deserialize content
                var result = _jsonConverter.DeserializeObject<TResult>(stringSerialized);
                return result;
            }
        }
        private readonly HttpClient HttpClient = new HttpClient();

        public void SetToken(string token) {
            TokenResponseModel = new TokenResponseModel {
                Token = token
            };
        }

        #endregion

    }
}
