using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Models
{
    public class SignupModel
    {
        public string id { get; set; }
        public string name { get; set; }

        public string Password { get; set; }
        public SignupModel(string id, string Password, string name)
        {
            this.id = id;
            this.Password = Password;
            this.name = name;
        }
    }
}
