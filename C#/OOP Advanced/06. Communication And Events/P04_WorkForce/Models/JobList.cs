using P04_WorkForce.Contracts;
using P04_WorkForce.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04_WorkForce
{
    public class JobList : List<IJob>
    {
        public void AddJob(IJob job)
        {
            this.Add(job);
            job.UpdateEvent += this.OnUpdateEvent;
        }

        public void OnUpdateEvent(IJob job)
        {
            this.Remove(job);
        }
    }
}
