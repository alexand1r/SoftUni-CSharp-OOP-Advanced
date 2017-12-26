using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclingStation.Models
{
    using RecyclingStation.WasteDisposal.Interfaces;

    public class ProcessingData : IProcessingData
    {
        public ProcessingData(double energyBalance, double profit)
        {
            this.EnergyBalance = energyBalance;
            this.CapitalBalance = profit;
        }

        public double EnergyBalance { get; protected set; }

        public double CapitalBalance { get; protected set; }
    }
}
