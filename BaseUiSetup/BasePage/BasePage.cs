using BaseUiSetup.UpgradedSelenium;

namespace BaseUiSetup.BasePage
{
    public abstract class BasePage
    {
        public UpWebDriver Driver { get; set; }

        public abstract string pageUrl { get; set; }

        public string PageUrl
        {
            get => pageUrl;
            set => pageUrl = value;
        }

        public virtual string Url
        {
            get => PageUrl;
            set { }
        }

        protected BasePage()
        {

        }

        protected BasePage(UpWebDriver driver)
        {
            Driver = driver;
        }
    }
}
