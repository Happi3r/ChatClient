using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Models
{
    public class ChatLogModel
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }
        public DateTime SendTime { get; set; }
    }
}
