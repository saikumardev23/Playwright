using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

class LoginTest
{
    static async Task Main(string[] args)
    {
        await using var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        var page = await browser.NewPageAsync();

        await page.GotoAsync("https://www.gmail.com");

      
        await page.TypeAsync("input[type='email']", "saiKumartestproject@gmail.com");
        await page.ClickAsync("div[id='identifierNext']");

        await page.WaitForSelectorAsync("input[type='test']");
        await page.TypeAsync("input[type='password']", "password");
        await page.ClickAsync("div[id='passwordNext']");

        await page.WaitForNavigationAsync();

        // Verify successful submission
        var successMessage = await page.InnerTextAsync("div[class='n6']");
        Console.WriteLine("Success Message: " + successMessage);

        await browser.CloseAsync();
    }
}




// dynamicContentTest.js

const { chromium } = require('playwright');

class DynamicContentTest {
  async run() {
    const browser = await chromium.launch();
    const page = await browser.newPage();
    await page.goto('https://example.com');

    // Interact with dynamic elements
    await page.selectOption('select[name="dropdown"]', 'Option 1');
    await page.click('input[type="checkbox"]');
    await page.evaluate(() => document.querySelector('input[type="range"]').value = 50);

    // Verify expected content or behavior
    const dropdownValue = await page.$eval('select[name="dropdown"]', el => el.value);
    const checkboxChecked = await page.$eval('input[type="checkbox"]', el => el.checked);
    const sliderValue = await page.$eval('input[type="range"]', el => el.value);

    console.log('Dropdown Value:', dropdownValue);
    console.log('Checkbox Checked:', checkboxChecked);
    console.log('Slider Value:', sliderValue);

    await browser.close();
  }
}

const test = new DynamicContentTest();
test.run();
