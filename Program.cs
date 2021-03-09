using PlaywrightSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace humanbenchmark.com
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<string> oof = new List<string>();
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchPersistentContextAsync("Profile", new LaunchOptions() { Headless = false });
            var page = await browser.NewPageAsync();
            await page.GoToAsync("https://humanbenchmark.com/tests/verbal-memory");
            //might want to add a console.readline here to accept cookies or crash to lazy to add it in so i did persistent chromium launch
            //start
            await page.ClickAsync("//*[@id=\"root\"]/div/div[4]/div[1]/div/div/div/div[4]/button");
            Console.ReadLine();
            while (true)
            {
                //word
                if (oof.Contains(page.QuerySelectorAsync("//*[@id=\"root\"]/div/div[4]/div[1]/div/div/div/div[2]/div").Result.GetInnerTextAsync().Result))
                {
                    //seen
                    await page.ClickAsync("//*[@id=\"root\"]/div/div[4]/div[1]/div/div/div/div[3]/button[1]");
                }
                else
                {
                    //new
                    oof.Add(page.QuerySelectorAsync("//*[@id=\"root\"]/div/div[4]/div[1]/div/div/div/div[2]/div").Result.GetInnerTextAsync().Result);
                    await page.ClickAsync("//*[@id=\"root\"]/div/div[4]/div[1]/div/div/div/div[3]/button[2]");
                }
            }
            Console.ReadLine();
        }
    }
}
