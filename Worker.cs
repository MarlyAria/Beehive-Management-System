using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beehive_Management_System
{
    class Worker: Bee
    {
        private string[] jobsICanDo;
        public Worker(string[] jobsICanDo, double weightMg)
            : base(weightMg)
        {
            this.jobsICanDo = jobsICanDo; 
        }
        const double honeyUnitsPerShiftWorked = .65;

        public override double HoneyConsumptionRate()
        {
            double consumption = base.HoneyConsumptionRate();
            consumption += shiftsWorked * honeyUnitsPerShiftWorked;
            return consumption;
        }
        public int ShiftsLeft
        {
            get
            {
                return shiftsToWork - shiftsWorked;
            }
        }
        private string currentJob = " ";
        public string CurrentJob
        {
            get
            {
                return currentJob;
            }
        }
        
        private int shiftsToWork;
        private int shiftsWorked;

        public bool DoThisJob(string job, int numberOfShifts)
        {
            if (!string.IsNullOrEmpty(currentJob))
               return false;
            for (int i = 0; i < jobsICanDo.Length; i++)
                if (jobsICanDo[i] == job)
                    {
                    currentJob = job;
                    this.shiftsToWork = numberOfShifts;
                    shiftsWorked = 0;
                    return true;
                    }
            return false;
        }

        public bool DidYouFinish()
        {
            if (string.IsNullOrEmpty(currentJob))
                return false;
            shiftsWorked++;
            if (shiftsWorked > shiftsToWork)
            {
                shiftsWorked = 0;
                shiftsToWork = 0;
                currentJob = "";
                return true;
            }
            else
                return false;
        }
    }
}
