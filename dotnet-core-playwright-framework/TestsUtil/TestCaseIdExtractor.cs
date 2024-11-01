using NUnit.Framework;

namespace Tests.TestsUtil
{
    public static class TestCaseIdExtractor
    {
        /// <summary>
        /// Extract the TestRail Id from the Class Name of the Test. Method will find the Current Context and Test.
        /// </summary>
        /// <returns></returns>
        public static string GetTestRailIdFromCurrentTestContextOrRun()
        {
            string foundTestRailId = null;
            //Check if there is a property [TestRailId] in Test
            TestContext.CurrentContext.Test.Properties[TestProperty.TestRailId]
                      .ToList().ForEach(i => foundTestRailId = i.ToString());

            return foundTestRailId;
        }
    }
}