using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubTrainManager
{
    public class PostMessageEventArgs : EventArgs
    {
        public string Message { get; set; }
        public PostMessageEventArgs(string message)
        {
            Message = message;
        }
    }
}
