using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubTrainManager
{
    internal class Cabin : ICabinSubscriber, IDisposable
    {
        public int CabinId { get; set; }
        public ILocomotivePublisher Publisher { get; set; }

        private bool _disposed;
        internal Cabin(int cabinId, ILocomotivePublisher publisher)
        {
            CabinId = cabinId;
            Publisher = publisher;

            Publisher.PostMessagePublisher += PostMessage;
            Publisher.StartDrivingPublisher += CloseDoors;
            Publisher.StopDrivingPublisher += OpenDoors;
        }
        ~Cabin()
        {
            if (!_disposed)
            {
                Dispose();
            }
        }
        public void CloseDoors(object sender, EventArgs e)
        {
            Console.WriteLine($"Closing Doors - Cabin {CabinId}");
        }

        public void OpenDoors(object sender, EventArgs e)
        {
            Console.WriteLine($"Open Doors - Cabin {CabinId}");
        }

        public void PostMessage(object sender, PostMessageEventArgs e)
        {
            Console.WriteLine($"Time is {DateTime.Now} - Cabin {CabinId}");
        }

        public void Dispose()
        {
            Publisher.PostMessagePublisher -= PostMessage;
            Publisher.StartDrivingPublisher -= CloseDoors;
            Publisher.StopDrivingPublisher -= OpenDoors;

            GC.SuppressFinalize(this);

            _disposed = true;
        }
    }
}
