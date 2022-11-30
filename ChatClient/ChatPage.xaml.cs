using ChatClient.Models;
using RestSharp;
using SocketIOClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading;
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

namespace ChatClient
{
    /// <summary>
    /// ChatPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ChatPage : Page
    {
        private bool _isPageLoaded = true;

        public Visibility VisibleOnPageLoaded { 
            get => _isPageLoaded ? Visibility.Visible : Visibility.Hidden;
        }

        public Visibility HiddenOnPageLoaded
        {
            get => _isPageLoaded ? Visibility.Hidden : Visibility.Visible;
        }

        private ObservableCollection<ChatRoom> _chatRooms = new ObservableCollection<ChatRoom>();
        public ObservableCollection<ChatRoom> ChatRooms { get => _chatRooms; }

        public ChatPage()
        {
            InitializeComponent();
            DataContext = this;
            App.ConnectSocketIO();
        }

        private void JoinRoomBtnClick(object sender, RoutedEventArgs e)
        {

        }

        private void ChangeUsernameBtnClick(object sender, RoutedEventArgs e)
        {
            new ChangeUsernameDialog().ShowDialog();
        }
    }
}
