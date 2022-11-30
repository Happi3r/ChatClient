using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    public class ChangeUsernameModel
    {
        public string Username { get; set; }

        public ChangeUsernameModel(string username) {
            Username = username;
        }
    }
}
