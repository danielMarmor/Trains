using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubTrainManager
{
    public class Manager
    {
        private readonly ILocomotivePublisher _Locomotive;
        private List<ICabinSubscriber>? _Cabins;
        private TrainStatus _status;
        public Manager()
        {
            _Locomotive = new Locomotive();
            _status = TrainStatus.InPlatform;
        }
        public void AddCabin()
        {
            if (_status == TrainStatus.InMotion)
            {
                throw new Exception("Train In Motion - Cannot Change Cabins");
            }

            if (_Cabins == null)
            {
                _Cabins = new List<ICabinSubscriber>();
            }
            int newCabinId = _Cabins.Count +1;

            var newCabin = new Cabin(newCabinId, _Locomotive);

            _Cabins.Add(newCabin);

        }
        public void RemoveCabin()
        {
            if (_status == TrainStatus.InMotion)
            {
                throw new Exception("Train In Motion - Cannot Change Cabins");
            }

            if (_Cabins == null)
            {
                throw new Exception("No Cabins!");
            }
            if (_Cabins.Count == 0)
            {
                throw new Exception("No Cabins!");
            }
            var cabin = _Cabins.LastOrDefault();
            if (cabin == null)
            {
                throw new Exception($"Cabin Not Found!");
            }
            _Cabins.Remove(cabin);

        }
        public void StartDriving()
        {
            if (_status == TrainStatus.InMotion)
            {
                throw new Exception("Train Already In Motion - Cannot Start");
            }
            _Locomotive.StartDriving();

            _status = TrainStatus.InMotion;
        }
        public void StopDriving()
        {
            if (_status == TrainStatus.InPlatform)
            {
                throw new Exception("Train Already In Platform - Cannot Stop");
            }
            _Locomotive.StopDriving();

            _status = TrainStatus.InPlatform;
        }
        public void PostMessage(string message)
        {
            _Locomotive.PostMessage(message);
        }

    }
}
