using System;
using Coravel.Scheduling.Schedule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tests.Scheduling.Helpers.SchedulingTestHelpers;

namespace Tests.Scheduling
{
    [TestClass]
    public class SchedulerWeeklyTests
    {
        [TestMethod]
        // Note: arrays are [day, hours, minutes]
        [DataRow(new int[] { 0, 0, 0 }, new int[] { 7, 0, 0 })]
        [DataRow(new int[] { 0, 0, 0 }, new int[] { 8, 1, 0 })]
        [DataRow(new int[] { 3, 0, 32 }, new int[] { 10, 0, 33 })]
        public void ValidWeekly(int[] first, int[] second)
        {
            var scheduler = new Scheduler();
            int taskRunCount = 0;

            scheduler.Schedule(() => taskRunCount++).Weekly();

            RunScheduledTasksFromDayHourMinutes(scheduler, first[0], first[1], first[2]);
            RunScheduledTasksFromDayHourMinutes(scheduler, second[0], second[1], second[2]);

            Assert.IsTrue(taskRunCount == 2);
        }

        [TestMethod]
        // Note: arrays are [day, hours, minutes]
        [DataRow(new int[] { 0, 0, 0 }, new int[] { 6, 0, 0 })]
        [DataRow(new int[] { 0, 5, 0 }, new int[] { 7, 4, 59 })]
        [DataRow(new int[] { 0, 5, 0 }, new int[] { 2, 5, 59 })]
        public void Weekly_ShouldRunOnce(int[] first, int[] second)
        {
            var scheduler = new Scheduler();
            int taskRunCount = 0;

            scheduler.Schedule(() => taskRunCount++).Weekly();

            RunScheduledTasksFromDayHourMinutes(scheduler, first[0], first[1], first[2]);
            RunScheduledTasksFromDayHourMinutes(scheduler, second[0], second[1], second[2]);

            Assert.IsTrue(taskRunCount == 1);
        }
    }
}