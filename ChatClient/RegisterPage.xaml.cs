using ChatClient.Models;
using RestSharp;
using System;
using System.CodeDom;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using RestSharp;

namespace ChatClient
{
    /// <summary>
    /// RegisterPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void BackBtnClick(object sender, RoutedEventArgs e)
        {
            App.PageFrame.GoBack();
        }

        private void RegisterBtnClick(object sender, RoutedEventArgs e)
        {
            string id = IDTextBox.Text;
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;
            string passwordValidator = PasswordConfirmTextBox.Password;

            if (password != passwordValidator)
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다.");
            }

            SignupModel model = new SignupModel(id, password, username);
            RestRequest request = new RestRequest("http://localhost:3000/user/signUp", Method.Post);
            request.AddBody(model);

            var response = App.Client.Execute<ResponseModel<JsonObject>>(request);

            if (response.IsSuccessStatusCode && response.Data?.Options != null)
            {
                App.PageFrame.GoBack();
            }
            else
            {
                MessageBox.Show(response.Data?.Message ?? "Unknown Error");
            }
        }
    }
}
