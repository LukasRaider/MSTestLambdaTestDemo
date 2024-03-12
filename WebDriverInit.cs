using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestLambdaTestDemo
{
	public enum BrowserType 
	{
		Chrome,
		Firefox,
		Edge,
		Safari
	}
	public class WebDriverInit
	{
		private string _ltUserName;
		private string _ltAppKey;

		public WebDriverInit()
		{
			//login script to LambdaTest
			_ltUserName = "karthiktechgeek";
			_ltAppKey = "d8ZnudrNhLLeJWxwND7SDozcKQb16juda9INsCvojV2MBjELCh";
		}

		public IWebDriver GetWebDriver(BrowserType browserType, string platform, string version, string name) 
		{
			dynamic capability = GetBrowserOptions(browserType);

			if (browserType != BrowserType.Safari && browserType != BrowserType.Edge)
			{
				capability.AddAdditionalCapability("platform", platform, true);
				capability.AddAdditionalCapability("version", version, true);
				capability.AddAdditionalCapability("name", name, true);
				capability.AddAdditionalCapability("build", "Parallel Browser Testing - Local", true);
				capability.AddAdditionalCapability("user", _ltUserName, true);
				capability.AddAdditionalCapability("accessKey", _ltAppKey, true);
				capability.AddAdditionalCapability("tunnel", true, true);
			}
			else
			{
				capability.AddAdditionalCapability("platform", platform);
				capability.AddAdditionalCapability("version", version);
				capability.AddAdditionalCapability("name", name);
				capability.AddAdditionalCapability("build", "Parallel Browser Testing - Local");
				capability.AddAdditionalCapability("user", _ltUserName);
				capability.AddAdditionalCapability("accessKey", _ltAppKey);
				capability.AddAdditionalCapability("tunnel", true);
			}
			//var driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capability);
			//connection with account
			var driver = new RemoteWebDriver(new Uri("https://" + _ltUserName + ":" + _ltAppKey + "@hub.lambdatest.com/wd/hub"), capability.ToCapabilities());

			driver.Manage().Window.Maximize();
			driver.Url = "https://lambdatest.hithub.io/sample-todo-app/";

			return driver;
		}
		private dynamic GetBrowserOptions(BrowserType browserType)
		{
			switch (browserType)
			{ 
				case BrowserType.Chrome:
					return new ChromeOptions();
				case BrowserType.Firefox:
					return new FirefoxOptions();
				case BrowserType.Edge:
					return new EdgeOptions();
				case BrowserType.Safari:
					return new SafariOptions();
				default:
					throw new ArgumentOutOfRangeException(nameof(browserType),browserType,null);
			}
		}
	}
}
