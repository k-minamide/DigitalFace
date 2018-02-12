using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DigitalFace.Processes
{
    public class BatchList : ExecuteListBase<ProcessStartInfo>
    {
        public BatchList() : base() { }
        public BatchList(ProcessStartInfo setting) : base(setting) { }
        public BatchList(IEnumerable<ProcessStartInfo> settings) : base(settings) { }

        protected override void Execute(IList<ProcessStartInfo> setting)
        {
            Process process = new Process();
            foreach (ProcessStartInfo processStartInfo in setting)
            {
                process.StartInfo = processStartInfo;
                process.Start();
                process.WaitForExit();
            }
        }
    }
}
