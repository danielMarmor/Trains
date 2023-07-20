using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubTrainManager
{
    internal class Locomotive : ILocomotivePublisher
    {
        public event EventHandler<EventArgs>? StartDrivingPublisher;
        public event EventHandler<EventArgs>? StopDrivingPublisher;
        public event EventHandler<PostMessageEventArgs>? PostMessagePublisher;

        public void OnPostMessage(object sender, PostMessageEventArgs e)
        {
            PostMessagePublisher?.Invoke(sender, e);
        }

        public void OnStartDriving(object sender, EventArgs e)
        {
            StartDrivingPublisher?.Invoke(sender, e);
        }

        public void OnStopDriving(object sender, EventArgs e)
        {
            StopDrivingPublisher?.Invoke(sender, e);
        }

        public void PostMessage(string message)
        {
            var args = new PostMessageEventArgs(message);

            OnPostMessage(this, args);
        }

        public void StartDriving()
        {
            var args = new EventArgs();

            OnStartDriving(this, args);
        }

        public void StopDriving()
        {
            var args = new EventArgs();

            OnStopDriving(this, args);
        }
    }
}
