using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using ValtechTests.Helper;
using ValtechTests.Pages;
using System.Collections.Generic;

namespace ValtechTests.Steps
{
    [Binding]
    public class ValtechFeatureSteps
    {
        private readonly Context _context;
        private readonly HomePage _homePage;
        private IList<string> _pages = new List<string>();
        private int _numberOfOffice;

        public ValtechFeatureSteps(Context context, HomePage homePage)
        {
            _context = context;
            _homePage = homePage;
        }

        [Given(@"Customer is on Valtech website")]
        public void GivenCustomerIsOnValtechWebsite()
        {
            _context.BrowserSetup();
        }
        
 
        [Then(@"Customer can see latest news section")]
        public void ThenCustomerCanSeeLatestNewsSection()
        {
            Assert.IsTrue(_homePage.LatestNews().Equals("LATEST NEWS"));
        }

        [When(@"Navigates to about services and work")]
        public void WhenNavigatesToAboutServicesAndWork()
        {
            _pages = _homePage.PagesName();
        }

        [Then(@"Customer should be on (.*) page")]
        public void ThenCustomerShouldBeOnAboutServicesWorkPage(string pagesName)
        {

            foreach (var page in _pages)
            {
                Assert.IsTrue(pagesName.Contains(page.Trim()));
            }
        }


        [When(@"Navigates to contact section to count the number of offices")]
        public void WhenNavigatesToContactSection()
        {
            _numberOfOffice = _homePage.NumberOfOffices();
        }

        [Then(@"Number of offices should be (.*)")]
        public void ThenNumberOfOfficesShouldBe(int numberOfOffices)
        {
            Assert.AreEqual(_numberOfOffice, numberOfOffices);
        }

    }
}
