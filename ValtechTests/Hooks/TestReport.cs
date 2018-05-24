using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using TechTalk.SpecFlow;

namespace BbpAutomatedTest.Hooks
{
    [Binding]
    public sealed class TestReport
    {
        private static ExtentReports _extent;
        private static ExtentTest _feature;
        private static ExtentTest _scenario;

        [BeforeTestRun]
        public static void TestReportSetUp()
        {
            var htmlReport = new ExtentHtmlReporter(FilePath("","TestReport.html"));
            htmlReport.LoadConfig(FilePath("","extent-config.xml"));
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReport);
            _extent.AddSystemInfo("Environment", "Staging");
        }
        private static string FilePath(string folder, string file)
        {
            var filePath = new FileInfo($@"..\..\{folder}\{file}");
            return filePath.FullName;
        }
        [BeforeFeature]
        public static void BeforeFeature()
        {
            _feature = _extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }
        [BeforeScenario]
        public void BeforeScenario()
        {
            _scenario = _feature.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title)
                .AssignCategory(ScenarioContext.Current.ScenarioInfo.Tags);
        }

        [AfterStep]
        public static void AfterStep()
        {
            var step = ScenarioStepContext.Current.StepInfo.StepInstance.StepDefinitionKeyword.ToString();
            if (ScenarioContext.Current.TestError == null)
            {
                switch (step)
                {
                    case "Given":
                        _scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Log(Status.Pass, "Pass");
                        break;

                    case "When":
                        _scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Log(Status.Pass, "Pass");
                        break;

                    case "Then":
                        _scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Log(Status.Pass, "Pass");
                        break;

                    case "And":
                        _scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Log(Status.Pass, "Pass");
                        break;
                }
            }
            if (ScenarioContext.Current.TestError != null)
            {
                switch (step)
                {
                    case "Given":
                        _scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message + " \r\n " + ScenarioContext.Current.TestError.InnerException);
                        break;

                    case "When":
                        _scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message + " \r\n " + ScenarioContext.Current.TestError.InnerException);
                        break;

                    case "Then":
                        _scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message + " \r\n " + ScenarioContext.Current.TestError.InnerException);
                        break;

                    case "And":
                        _scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message + " \r\n " + ScenarioContext.Current.TestError.InnerException);
                        break;
                }
            }
        }

        [AfterTestRun]
        public static void TestReportTearDown()
        {
            _extent.Flush();
        }
    }
}
