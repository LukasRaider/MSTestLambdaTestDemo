using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Xml.Linq;
using System;
[assembly: Parallelize(Workers = 3,Scope =ExecutionScope.MethodLevel )] //Paralell run tests

namespace MSTestLambdaTestDemo
{
	[TestClass]
	public class UnitTest1 : WebDriverInit
	{
		

		[TestMethod]//setting browser and system testing enviromental
		[DataRow(BrowserType.Chrome, "Windows 10", "89.0", "Chrome Test")]
		[DataRow(BrowserType.Edge, "Windows 10" , "86.0", "Firefox Test")]
		public void TestMethod1(BrowserType browserType, string platform, string version, string name)
		{
			using (var driver = GetWebDriver(browserType, platform, version, name))
			{

				//Click on First Chech box
				IWebElement firstCheckBox = driver.FindElement(By.Name("li1"));
				firstCheckBox.Click();

				//Click on Second Check box
				IWebElement secondCheckBox = driver.FindElement(By.Name("li2"));

				//Enter Item name
				IWebElement textfield = driver.FindElement(By.Id("sampletodotext"));
				textfield.SendKeys("First Item");

				//Click on Add button
				IWebElement addButton = driver.FindElement(By.Id("addbutton"));
				addButton.Click();

				//verified Added Item name
				IWebElement itemtext = driver.FindElement(By.XPath("/html/body/div/div/div/ul/li[6]/span"));

				driver.Quit();
			}
		}

		[TestMethod]//setting browser and system testing enviromental
		[DataRow(BrowserType.Edge, "Windows 10", "87.0", "Edge Test")]
		[DataRow(BrowserType.Chrome, "MacOS Catalina", "88.0", "MacOS Test")]
		public void TestMethod2(BrowserType browserType, string platform, string version, string name)
		{
			using (var driver = GetWebDriver(browserType, platform, version, name))
			{

				//Click on First Chech box
				IWebElement firstCheckBox = driver.FindElement(By.Name("li1"));
				firstCheckBox.Click();

				//Click on Second Check box
				IWebElement secondCheckBox = driver.FindElement(By.Name("li2"));

				//Enter Item name
				IWebElement textfield = driver.FindElement(By.Id("sampletodotext"));
				textfield.SendKeys("First Item");

				//Click on Add button
				IWebElement addButton = driver.FindElement(By.Id("addbutton"));
				addButton.Click();

				//verified Added Item name
				IWebElement itemtext = driver.FindElement(By.XPath("/html/body/div/div/div/ul/li[6]/span"));

				driver.Quit();
			}
		}

		
	}
}