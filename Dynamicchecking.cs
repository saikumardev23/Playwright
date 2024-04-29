using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

class VerifyDynamicContent
{
    static async Task Main(string[] args)
    {
        await using var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        var page = await browser.NewPageAsync();

        await page.GotoAsync("https://www.globalsqa.com/demo-site/select-dropdown-menu/");

        // Wait for the dropdown menu to load
        await page.WaitForSelectorAsync("select[id='cd-dropdown']");

        // Select an option from the dropdown menu
        await page.SelectOptionAsync("select[id='cd-dropdown']", "Asia");

        // Wait for the dynamic content to load
        await page.WaitForSelectorAsync("div[class='cd-item-info']");

        // Verify that the dynamic content is displayed correctly
        var dynamicContent = await page.InnerTextAsync("div[class='cd-item-info']");
        Console.WriteLine("Dynamic Content: " + dynamicContent);

        await browser.CloseAsync();
    }
}
