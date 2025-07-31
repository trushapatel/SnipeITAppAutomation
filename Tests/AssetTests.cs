namespace SnipeITAutomation.Tests;

using Microsoft.Playwright;
using SnipeITAutomation.Pages;
using SnipITAutomation.Pages;
using NUnit.Framework;

public class AssetTests
{
        private IBrowser _browser;
        private IPage _page;
        private IPlaywright _playwright;

        [SetUp]
        public async Task Setup()
        {

                _playwright = await Playwright.CreateAsync();
                _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
                _page = await _browser.NewPageAsync();
        }


        [Test]
        public async Task CreateAndVerifyAsset()
        {
                string assetName = "Macbook Pro 13\" ";
                string assignedUser = "Admin";

                var loginPage = new LoginPage(_page);
                await loginPage.Login("https://demo.snipeitapp.com/login", "admin", "password");

                var assetPage = new AssetPage(_page);

                await assetPage.CreateAsset(assetName);

                var assetList = new AssetListPage(_page);
                bool isAssetFound = await assetList.SearchAsset(assetPage.assetID);
                Console.WriteLine($"Asset found: {isAssetFound}");

                if (!isAssetFound) throw new Exception("Asset not found");

                await assetList.OpenAssetDetails(assetPage.assetID);

                var assetDetails = new AssetDetailsPage(_page);
                await assetDetails.ValidateAssetDetails(assetName, assignedUser);
                

                
        }
}

