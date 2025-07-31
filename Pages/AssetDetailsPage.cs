namespace SnipeITAutomation.Pages;
using Microsoft.Playwright;
using SnipeITAutomation.Pages;
using NUnit.Framework;

public class AssetDetailsPage
{
    private readonly IPage _page;
    public AssetDetailsPage(IPage page) => _page = page;

    public async Task ValidateAssetDetails(string name, string user)
    {
        var assetName = await _page.TextContentAsync("div.col-md-9");
        var assignedTo = await _page.Locator("//*[@id='details']/div/div/div[2]/div/div[2]/div[2]/a").TextContentAsync();
        Console.WriteLine( assignedTo);
        Assert.That(assetName.Contains("Macbook Pro 13"));
        Assert.That(assignedTo.Contains(user));
        
        
        await _page.Locator("a[href='#history']").ClickAsync();
        var statusText = await _page.Locator("//*[@id='assetHistory']/tbody/tr[1]/td[4]").TextContentAsync();
        Console.WriteLine( statusText);
        Assert.That(statusText.Contains("create new"), "Asset creation not recorded in history.");
        
    }
}
