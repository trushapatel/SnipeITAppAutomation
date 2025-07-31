namespace SnipeITAutomation.Pages;
using Microsoft.Playwright;
using SnipeITAutomation.Pages;

public class AssetListPage
{
    private readonly IPage _page;
    public AssetListPage(IPage page) => _page = page;

    public async Task<bool> SearchAsset(string assetTag)
    {
        await _page.FillAsync("input[type='search']", assetTag);
        await _page.WaitForTimeoutAsync(1000); // Small wait for results
        return await _page.IsVisibleAsync($"a:has-text('{assetTag}')");
    }

    public async Task OpenAssetDetails(string assetTag)
    {
        await _page.ClickAsync($"a:has-text('{assetTag}')");
        await _page.WaitForURLAsync("**/hardware/*");
    }
}
