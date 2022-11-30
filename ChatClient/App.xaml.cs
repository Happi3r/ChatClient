using ChatClient.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using RestSharp;
using SocketIOClient;

namespace ChatClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Frame PageFrame { get; set; }
        public static AccessTokenModel? AccessToken { get; set; }
        public readonly static RestClient Client = new RestClient();
        public static SocketIO SocketClient { get; set; }

        public static AccessTokenModel? RefreshTokenModel()
        {
            RestRequest request = new RestRequest("http://localhost:3000/common/refresh", Method.Get);
            request.AddOrUpdateHeader("Authorization", AccessToken.Token);
            request.AddOrUpdateHeader("Refresh", AccessToken.RefreshToken);
            var response = Client.Execute<ResponseModel<AccessTokenModel>>(request);

            if (response.IsSuccessStatusCode && response.Data?.Options != null)
            {
                AccessToken = response.Data.Options;
                return AccessToken;
            }
            else
            {
                throw new Exception(response.Data?.Message);
            }
        }

        public static void ConnectSocketIO()
        {
            SocketClient = new SocketIO("http://localhost:3001");
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("authorization", "Bearer " + AccessToken.Token);
            headers.Add("refresh", AccessToken.RefreshToken);
            
            SocketClient.Options.ExtraHeaders = headers;
            SocketClient.Options.ConnectionTimeout = TimeSpan.FromMilliseconds(5000);
            SocketClient.OnConnected += (sender, e) =>
            {
                Console.WriteLine();
            };

            SocketClient.ConnectAsync();
        }
    }
}
