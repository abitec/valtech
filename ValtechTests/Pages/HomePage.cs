using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using ValtechTests.Helper;

namespace ValtechTests.Pages
{
    public class HomePage
    {
        private readonly Context _context;
        private By LatestNewsTxt = By.CssSelector("#container > div:nth-child(2) > div:nth-child(3) > div.news-post__listing-header > header > h2");
        private string PageNameFirstPart = "//*[@id='navigationMenuWrapper']/div/ul/li[";
        private string PageNameSecondPart = "]/a/span";
        private By ContactSection = By.CssSelector("#CTA-form-trigger > div > div > span");
        private By Offices = By.CssSelector("#footer > div > div.footer-content.foot > p.foot__offices");
        public HomePage(Context context)
        {
            _context = context;
        }
  
        public string LatestNews()
        {
            return _context.Driver.FindElement(LatestNewsTxt).Text;
        }

        public IList<string> PagesName()
        {
            var pageNameList = new List<string>();

            for (var pageNumber = 1; pageNumber <= 3; pageNumber++)
            {
                _context.Driver.FindElement(By.XPath(PageNameFirstPart + pageNumber + PageNameSecondPart)).Click();
                pageNameList.Add(_context.Driver.FindElement(By.TagName("H1")).Text);
            }
            return pageNameList;
        }

        public int NumberOfOffices()
        {
            IWebElement contactSection = _context.Driver.FindElement(ContactSection);
            var act = new Actions(_context.Driver);
            act.MoveToElement(contactSection).Perform();
            IWebElement numberOfOffice = _context.Driver.FindElement(Offices);
            var allOffices = numberOfOffice.Text;
            string[] contactOffices =
                (allOffices.Substring(allOffices.IndexOf(":", StringComparison.Ordinal)) + 1)
                    .Split(',');
            var contactOfficesNumber = contactOffices.Length;
            return contactOfficesNumber;
        }
        

    }
}
