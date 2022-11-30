using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ChatClient
{
    /// <summary>
    /// ChangeUsernameDialog.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ChangeUsernameDialog : Window
    {
        public ChangeUsernameDialog()
        {
            InitializeComponent();
        }

        private void ChangeBtnClick(object sender, RoutedEventArgs e)
        {
            RestRequest request = new RestRequest("http://localhost:3000/user/changeUsername", Method.Post);
            request.AddOrUpdateHeader("Authorization", App.AccessToken.Token);
            request.AddOrUpdateHeader("Refresh", App.AccessToken.RefreshToken);

            ChangeUsernameModel model = new ChangeUsernameModel(NewUsernameBox.Text);
            request.AddBody(model);
            var response = App.Client.Execute<ResponseModel<object>>(request);

            if (response.IsSuccessStatusCode && response.Data?.Options != null)
            {
                this.Close();
            }
            else
            {
                if (response.Data?.Code == "EXPIRED_TOKEN")
                {
                    try
                    {
                        App.RefreshTokenModel();
                        ChangeBtnClick(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        App.PageFrame.Navigate(new LoginPage());
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show(response.Data?.Message ?? "Unknown Error");
                }
            }
        }
    }
}
