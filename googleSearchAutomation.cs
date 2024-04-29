using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

class GoogleSearchAutomation
{
    static async Task Main(string[] args)
    {
        await using var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        var page = await browser.NewPageAsync();

        try
        {
            // Navigate to Google search page
            await page.GotoAsync("https://www.google.com");

            // Type search query and press Enter
            await page.TypeAsync("input[name='q']", "OpenAI");
            await page.Keyboard.PressAsync("Enter");

            // Wait for search results
            await page.WaitForSelectorAsync("div[id='search']");

            // Click on the first search result
            await page.ClickAsync("div[id='search'] a");

            // Wait for the opened page to load
            await page.WaitForNavigationAsync();

            // Get the title of the opened page
            var pageTitle = await page.TitleAsync();

            // Verify the title
            if (pageTitle.Contains("OpenAI"))
            {
                Console.WriteLine("Successfully opened the OpenAI website.");
            }
            else
            {
                Console.WriteLine("Failed to open the OpenAI website.");
            }
        }
        catch (PlaywrightException ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
        finally
        {
            await browser.CloseAsync();
        }
    }
}
