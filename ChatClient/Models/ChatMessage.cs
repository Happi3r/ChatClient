using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ChatClient.Models
{
    public class ChatMessage
    {
        public string _id { get; set; }
        public string userId { get; set; }
        public string username { get; set; }
        public string message { get; set; }
        public DateTime sendTime { get; set; }

        public int __v { get; set; }

        public HorizontalAlignment MessageAlignment { get => HorizontalAlignment.Left; }
    }
}
