using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class StressTest
{/*
    // A Test behaves as an ordinary method
    [Test]
    public void StressTestSimplePasses()
    {
        [Header("Components")]

        [SerializeField] private TMP_Text cpuCounterText;

        [Header("Settings")]

        [Tooltip("In which interval should the CPU usage be updated?")]
        [SerializeField] private float updateInterval = 1;

        [Tooltip("The amount of physical CPU cores")]
        [SerializeField] private int processorCount;


        [Header("Output")]
        public float CpuUsage;

        private Thread _cpuThread;
        private float _lasCpuUsage;

        private void Start()
        {
            Application.runInBackground = true;
            cpuCounterText.text = "0% CPU";

            // setup the thread
            _cpuThread = new Thread(UpdateCPUUsage)
            {
                IsBackground = true,
                // Don't let thread steal performance
                Priority = System.Threading.ThreadPriority.BelowNormal
            };

            // start the cpu usage thread
            _cpuThread.Start();
        }

        private void OnValidate()
        {
            //If this returns a wrong value set the value manually
            processorCount = SystemInfo.processorCount / 2;
        }

        private void Update()
        {
            //Skip if nothing has changed
            if (Mathf.Approximately(_lasCpuUsage, CpuUsage)) return;

            //Ignore values that are out of the possible range
            if (CpuUsage < 0 || CpuUsage > 100) return;

            //If CPU usage is in acceptable range, spawn more chunks
            if(CpuUsage < 80){
                
            }

            cpuCounterText.text = CpuUsage.ToString("F1") + "% CPU";
            _lasCpuUsage = CpuUsage;
        }

        /// <summary>
        /// Runs in Thread
        /// </summary>
        private void UpdateCPUUsage()
        {
            var lastCpuTime = new TimeSpan(0);

            // This is ok since this is executed in a background thread
            while (true)
            {
                var cpuTime = new TimeSpan(0);

                // Get a list of all running processes in this PC
                var AllProcesses = Process.GetProcesses();

                // Sum up the total processor time of all running processes
                cpuTime = AllProcesses.Aggregate(cpuTime, (current, process) => current + process.TotalProcessorTime);

                // get the difference between the total sum of processor times
                // and the last time we called this
                var newCPUTime = cpuTime - lastCpuTime;

                // update the value of _lastCpuTime
                lastCpuTime = cpuTime;

                // The value we look for is the difference, so the processor time all processes together used
                // since the last time we called this divided by the time we waited
                // Then since the performance was optionally spread equally over all physical CPUs
                // we also divide by the physical CPU count
                CpuUsage = 100f * (float)newCPUTime.TotalSeconds / updateInterval / processorCount;

                // Wait for UpdateInterval
                Thread.Sleep(Mathf.RoundToInt(updateInterval * 1000));
           }
        }
    }
*/
}
