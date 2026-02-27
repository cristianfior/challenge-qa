using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace grupoa_challengeqa.Drivers;

public class BrowserDriver : IDisposable
{
    public IWebDriver Current { get; }
    
    public BrowserDriver()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
            
        Current = new ChromeDriver(options);
    }

    public void Dispose()
    {
        Current?.Quit();
        Current?.Dispose();
    }
}