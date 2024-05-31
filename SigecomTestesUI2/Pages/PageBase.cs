using OpenQA.Selenium.Appium.Windows;
using SigecomTestesUI2.Services;

namespace SigecomTestesUI2.Pages
{
    public class PageBase
    {
        protected readonly ManipuladorService _manipuladorService;

        public PageBase(WindowsDriver<WindowsElement> driver)
        {
            _manipuladorService = new ManipuladorService(driver);
        }
    }
}