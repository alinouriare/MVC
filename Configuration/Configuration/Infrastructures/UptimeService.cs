﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Configuration.Infrastructures
{
    public class UptimeService
    {
        private Stopwatch stopwatch;
        public UptimeService()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        public long GetUpTime { get { return stopwatch.ElapsedMilliseconds; } }
    }
}
