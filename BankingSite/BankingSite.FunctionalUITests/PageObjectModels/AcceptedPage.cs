//using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;
using TestStack.Seleno.PageObjects.Locators;

namespace BankingSite.FunctionalUITests.PageObjectModels
{
    public class AcceptedPage : Page
    {
        public string AcceptedMessage
        {
            get
            {
                return Find.Element(By.Id("acceptMessage")).Text;
            }
        }
    }
}