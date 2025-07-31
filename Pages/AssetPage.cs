

using Microsoft.Playwright;
using Microsoft.VisualBasic;
using SnipeITAutomation.Pages;


namespace SnipeITAutomation.Pages{
    public class AssetPage
{
    private readonly IPage _page;
    public AssetPage(IPage page) => _page = page;
        public string assetID;

    public async Task CreateAsset(string name)
        {
            await _page.ClickAsync("a:has-text('Assets')");
            await _page.ClickAsync("a.btn.btn-primary.pull-right");

            assetID=await _page.InputValueAsync("#asset_tag");
            await _page.ClickAsync("#select2-model_select_id-container");
            await _page.FillAsync("input.select2-search__field", "MacBook");
            await _page.WaitForSelectorAsync("li.select2-results__option:has-text('Laptops - Macbook Pro 13')");
            await _page.ClickAsync("li.select2-results__option:has-text('Laptops - Macbook Pro 13')");

            await _page.ClickAsync("#select2-status_select_id-container");
            await _page.FillAsync("input.select2-search__field", "Ready");
            await _page.WaitForSelectorAsync("li.select2-results__option:has-text('Ready to Deploy')");
            await _page.ClickAsync("li.select2-results__option:has-text('Ready to Deploy')");

            await _page.ClickAsync("#select2-assigned_user_select-container");
            await _page.FillAsync("input.select2-search__field", "admin");
            await _page.WaitForSelectorAsync("li.select2-results__option:has-text('admin')");
            await _page.ClickAsync("li.select2-results__option:has-text('admin')");

            await Task.Delay(5000); // Additional wait if needed
            await _page.ClickAsync("button:has-text('Save')");
        }
}
}