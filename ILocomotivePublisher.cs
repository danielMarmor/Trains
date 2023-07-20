using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubTrainManager
{
    public interface ILocomotivePublisher
    {
        void StartDriving();
        void OnStartDriving(object sender, EventArgs e);
        event EventHandler<EventArgs> StartDrivingPublisher;

        void StopDriving();
        void OnStopDriving(object sender, EventArgs e);
        event EventHandler<EventArgs> StopDrivingPublisher;

        void PostMessage(string message);
        void OnPostMessage(object sender, PostMessageEventArgs e);
        event EventHandler<PostMessageEventArgs> PostMessagePublisher;

    }
}
