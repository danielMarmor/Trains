using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubTrainManager
{
    public interface ICabinSubscriber
    {
        public int CabinId { get; set; }
        public ILocomotivePublisher Publisher { get; set; }
        void OpenDoors(object sender, EventArgs e);
        void CloseDoors(object sender, EventArgs e);
        void PostMessage(object sender, PostMessageEventArgs e);
    }
}
