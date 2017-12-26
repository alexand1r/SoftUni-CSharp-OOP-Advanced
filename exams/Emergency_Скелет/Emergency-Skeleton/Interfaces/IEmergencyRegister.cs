using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Skeleton.Interfaces
{
    public interface IEmergencyRegister
    {
        void EnqueueEmergency(IEmergency emergency);

        IEmergency DequeueEmergency();

        IEmergency PeekEmergency();

        bool IsEmpty();
    }
}
