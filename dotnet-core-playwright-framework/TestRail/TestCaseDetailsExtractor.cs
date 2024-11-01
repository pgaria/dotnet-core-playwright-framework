using NUnit.Framework;
using System.Reflection;
using Tests.TestsUtil;

namespace Tests.TestRail
{
    public static class TestCaseDetailsExtractor
    {
        /// <summary>
        /// Method using Reflection to extract the TestRail Id for the Category.
        /// Method will Filter @Test and then Check the Category and Extract Property TestRailId.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static List<int> GetTestRailIdListForCategory(string category = null)
        {
            List<int> testRailIdListForCategory = new();

            // Look in to Both Test Project Assemblies for the Category or Tests.

            //Get the CDP.Tests Assembly and Extract Category Based tests.
            Assembly[] allAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assembly in allAssemblies)
            {
                ExtractDataInAssembly(assembly, category, testRailIdListForCategory);
            }
            //Check if any TestRail Id is Found or throw exception
            return testRailIdListForCategory.Count != 0
                   ? testRailIdListForCategory
                   : throw new Exception("Not able to find any TestRailIds assigned for Category:" + category + " in the Project/Assemblies, Check Category Name or Running Project.");
        }

        private static void ExtractDataInAssembly(Assembly assembly, string category, List<int> testRailIdListForCategory)
        {
            if (assembly == null)
                return;

            Type[] classes = assembly.GetExportedTypes();
            foreach (Type type in classes)
            {
                MethodInfo[] methods = type.GetMethods();
                foreach (MethodInfo methodInfo in methods)
                {
                    //Filter for method with the test attribute is used.
                    CheckCategoryAndExtractTestrailId(category, testRailIdListForCategory, methodInfo);
                }
            }
        }

        /// <summary>
        /// Check if the Category needs to be checked or not.
        /// Based on the Category Value divide the logic to extract TestRailId.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="testRailIdListForCategory"></param>
        /// <param name="methodInfo"></param>
        private static void CheckCategoryAndExtractTestrailId(string category, List<int> testRailIdListForCategory, MethodInfo methodInfo)
        {
            if (methodInfo.GetCustomAttributes(typeof(TestAttribute), true).Length == 1)
            {
                //As Category Is Null Meaning Add All Tests in the List.
                if (string.IsNullOrWhiteSpace(category))
                {
                    ExtractTestRailIdFromMethodInfo(testRailIdListForCategory, methodInfo);
                }
                else// Look For category First in Method and then extract TestrailId.
                {
                    CategoryAttribute[] attr = (CategoryAttribute[])methodInfo.GetCustomAttributes(typeof(CategoryAttribute), true);
                    foreach (CategoryAttribute categorySingle in attr)
                    {
                        try
                        {
                            string categoryInMethod = categorySingle.Name;
                            //If category in @Test method matches the category expected.
                            if (categoryInMethod.Equals(category, StringComparison.OrdinalIgnoreCase))
                            {
                                ExtractTestRailIdFromMethodInfo(testRailIdListForCategory, methodInfo);
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            //Keep Continue and Ignore
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Extract the TestRailId Property From the MethodInfo
        /// </summary>
        /// <param name="testRailIdListForCategory"></param>
        /// <param name="methodInfo"></param>
        private static void ExtractTestRailIdFromMethodInfo(List<int> testRailIdListForCategory, MethodInfo methodInfo)
        {
            //Check for property attribute to Extract TestRailId
            PropertyAttribute[] propertyAttributes = (PropertyAttribute[])methodInfo.GetCustomAttributes(typeof(PropertyAttribute), true);
            foreach (PropertyAttribute property in propertyAttributes)
            {
                //Extract TestRail Id property from Method info and add in List.
                string testRailId = (string)property.Properties.Get(TestProperty.TestRailId);
                if (!string.IsNullOrWhiteSpace(testRailId))
                    testRailIdListForCategory.Add(Int32.Parse(testRailId));
            }
        }
    }
}