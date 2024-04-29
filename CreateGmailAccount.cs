using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

class CreateGmailAccount
{
    static async Task Main(string[] args)
    {
        await using var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        var page = await browser.NewPageAsync();

        await page.GotoAsync("https://www.gmail.com");

        // Click on "Create account"
        await page.ClickAsync("a[data-g-label='Sign Up']");
        await page.WaitForNavigationAsync();

        // Fill in the account creation form
        await page.TypeAsync("input[name='firstName']", "Sai ");
        await page.TypeAsync("input[name='lastName']", "Kumar");
        await page.TypeAsync("input[name='Username']", "saiKumartestproject@gmail.com");
        await page.TypeAsync("input[name='Passwd']", "Testpass");
        await page.TypeAsync("input[name='ConfirmPasswd']", "Testpass");

        // Click on "Next"
        await page.ClickAsync("div[id='accountDetailsNext']");
        await page.WaitForNavigationAsync();

        // Verify successful account creation
        var successMessage = await page.InnerTextAsync("div[id='headingText']");
        Console.WriteLine("Success Message: " + successMessage);

        await browser.CloseAsync();
    }
}