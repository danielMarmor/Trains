using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubTrainManager
{
    public enum TrainStatus : int
    {
        InPlatform = 1,
        InMotion = 2
    }

    public enum ManagerOptions : int
    {
        Quit = 0,
        AddCabin = 1,
        RemoveCabin = 2,
        StartDrive = 3,
        StopDrive = 4,
        PostMessageToPassengers = 5,

    }
}
