using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataMaintenance
{
    public class JobManager
    {
        private bool running { get; set; }

        //how often to check
        static int interval = 1;

        static int wait = interval * 60 * 1000;

        private void Run()
        {
            while (running)
            {
                Debug.WriteLine("JobManager Running");

                //TODO check for new tasks

                Thread.Sleep(wait);
            }
        }

        public bool Start()
        {
            if (!running)
            {
                running = true;
                this.Start();
            }

            return true;
        }

        public bool Stop()
        {
            running = false;

            return true;
        }
    }
}
